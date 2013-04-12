using System;
using System.Collections.Generic;
using System.Threading;
using System.Runtime.Remoting;

using DBConnection;
using Timers;
using Configuration;
using Devices;

namespace Host
{
	public class CollectorHost : IDisposable
    {
		#region fields

		// оболочки БД, которые содержат в себе очереди
		// и контрулируют доступ до них
		DBShell[] dbShells;

		// масив устройств
		IDevice[] devices;

		// масивы потоков
		Thread[] devicesThreads;
		Thread[] dbThreads;

		// таймер
		ITimer timer;

		// события для синхронизации потоков
		EventWaitHandle timerSignal;
		EventWaitHandle queriesReadySignal;

		// ее величество, конфигурация
		IConfigurator config;

		// флажки для определения состояния хоста
		bool isInitialized;
		bool isRunning;
		bool isDisposing;

		#endregion fields

		#region initialization

		/// <summary>
		/// Initializes a new instance of the <see cref="Host.CollectorHost"/> class.
		/// </summary>
		/// <param name="conf">Configuration.</param>
		public CollectorHost (IConfigurator conf)
		{
			config = conf;
			isInitialized = false;
			isRunning = false;
			isDisposing = false;
		}

		/// <summary>
		/// Init this instance.
		/// </summary>
		public void Init ()
		{
			if (isInitialized)
				return;
			try {
				OnInitializing ();

				// инициализируем устройств

				// загружаем настройки из конфигурации
				var devConfList = config.GetItem ("dev_conf_list") as DeviceConfiguration[];
				if (devConfList == null)
                    throw new Exception("Запись 'dev_conf_list' не найдена в конфигурациях"); 

				// создеам масивов устройств и потоков
				devices = new IDevice[devConfList.Length];
				devicesThreads = new Thread[devConfList.Length];

				// инициализируем устройств и потоков
				for (int x = 0; x < devConfList.Length; x++) {
					var dev = Activator.CreateInstance (GetType (devConfList[x].Assembly, devConfList[x].Namespace, devConfList[x].DeviceType)) as IDevice;
					if (dev == null)
						throw new Exception ("Невозможно создать устройство с идентификатором " + devConfList[x].ID);
					dev.Init (devConfList[x].ID);
					devices[x] = dev;
					devicesThreads [x] = new Thread (new ParameterizedThreadStart (CollectDeviceInfo));
				}

				// инициализуруем БД оболочек

				// загружаем настройки из конфигурации
				var dbConf = config.GetItem ("db_conf_list") as DBConfiguration [];
				if (dbConf == null)
					throw new Exception ("Запись 'dev_conf_list' не найдена в конфигурациях");
				var qcapacity = config.GetItem ("queue_capacity");
				if (qcapacity == null)
                    throw new Exception("Запись 'queue_capacity' не найдена в конфигурациях");

				// создаем масивов оболочек и потоков
				dbShells = new DBShell [dbConf.Length];
				dbThreads = new Thread [dbConf.Length];

				// и инициализурем их
				for (int i = 0; i < dbConf.Length; i ++) {
					var dbFactory = Activator.CreateInstance (GetType (dbConf[i].Assembly, dbConf[i].Namespace, dbConf[i].FactoryType)) as IDBFactory;
					if (dbFactory == null)
						throw new Exception  ("База данных не может быть загружена");

					dbFactory.InitDBLayer (dbConf[i]);
					dbShells [i] = new DBShell (dbFactory.CreateConnection (), (int)qcapacity, new OutputDelegate (OnOutputPending));
					foreach (DeviceConfiguration devConf in devConfList) {
						var adapter = Activator.CreateInstance (GetType (devConf.Assembly, devConf.Namespace, dbFactory.GetAdapterTypeName (devConf.ID))) as IStorageAdapter;
						dbShells [i].AddAdapter (devConf.ID, adapter);
					}

					dbThreads [i] = new Thread (new ParameterizedThreadStart (HandleDBRequest));
				}

				// настройки таймера
				timer = CreateTimer ();
				if (timer == null)
					throw new Exception ("Ошибка инициализации таймера");

				// событие для таймера
				timerSignal = new ManualResetEvent (false);

				// событие для БД
				queriesReadySignal = new ManualResetEvent (false);

				isInitialized = true;

				OnInitialized ();

			} catch (Exception ex) {
				OnOutputPending ("Произошла ошибка: " + ex.ToString ());
				isInitialized = false;
			}
		}

		/// <summary>
		/// Возвращает System.Type из стринг для библиотеки, неймспейс, и имя типа
		/// </summary>
		/// <returns>The type.</returns>
		/// <param name="assembly">Assembly.</param>
		/// <param name="nmspace">Nmspace.</param>
		/// <param name="type">Type.</param>
		Type GetType (string assembly, string nmspace, string type)
		{
			return Type.GetType (String.Format ("{0}.{1}, {2}", nmspace, type, assembly));
		}

		/// <summary>
		/// Creates the timer.
		/// </summary>
		/// <returns>The timer.</returns>
		ITimer CreateTimer ()
		{
			ITimer theTimer = null;

			var type = config.GetItem ("timer_type") as String;
			if (type == null)
				throw new Exception ("Запись 'timer_type' не найдена в конфигурациях");

			if (type == "time") {
				var timeInterval = config.GetItem ("timer_time_interval_ms");
				if (timeInterval == null)
                    throw new Exception("Запись 'timer_time_interval_ms' не найдена в конфигурациях");

				theTimer = new TimeIntervalTimer ((int)timeInterval);

			} else if (type == "distance") {
				throw new NotImplementedException ("Счетчик расстояния еще не реализован!");
			}

			return theTimer;
		}

		#endregion initialization

		#region workers

		/// <summary>
		/// Ждет запросы к БД в отдельном потоке
		/// </summary>
		void HandleDBRequest (object param)
		{
			var dbShell = param as DBShell;
			if (dbShell == null) {
				OnOutputPending ("Конфигураций БД не доступна");
				Stop ();
			}

			// связываемся с БД
			dbShell.Connect ();
			OnOutputPending ("Соединение с БД удалось");

			// бесконечный цикл обработки запросов
			for (;;) {
				// ждем пока очередь не заполнится других потоков
				queriesReadySignal.WaitOne ();

				try {

					// выполняем все запросы в очереди
					dbShell.ExecutePendingQueries ();

				} catch (Exception ex) {
					OnOutputPending (ex.Message);
				}

				// выключаем сигнал пока не добавится элементов в очереди
				queriesReadySignal.Reset ();
			}
		}

		/// <summary>
		/// Собирает информацию с устройств
		/// </summary>
		void CollectDeviceInfo (object param)
		{
			var dev = param as IDevice;
			if (dev == null) {
				OnOutputPending ("Устройство не может быть загружено во внешнего потока!");
				Stop ();
			}

			object buf;

			for (;;) {
				// ждем следущего сигнала
				timerSignal.WaitOne ();

				try {
					// собиреам инфу и проверяем
					buf = dev.GetData ();
					if (buf != null) {
						// уведомляем потребителю
						OnOutputPending ("Данные собраны собраны с устройства " + dev.ID);

						// отправляем запросы к каждой БД
						foreach (DBShell dbShell in dbShells)
							dbShell.EnqueueQueryFrom (dev.ID, buf);

						// уведомить поток БД что есть запрос на выполнение
						queriesReadySignal.Set ();
					}
				} catch (Exception ex) {
					OnOutputPending (ex.Message);
				}

				// выключаем сигнал
				timerSignal.Reset ();
			}
		}

		#endregion workers

		#region user_control

		void StartDBThreads ()
		{
			for (int i = 0; i < dbShells.Length; i ++)
				dbThreads [i].Start (dbShells [i]);
		}

		void StopDBThreadsAndDisconnect ()
		{
			for (int i = 0; i < dbShells.Length; i ++) {
				dbThreads [i].Abort ();
				dbThreads [i].Join ();
				dbShells [i].Disconnect ();
			}
		}

		void StartDevicesThreads ()
		{
			for (int i = 0; i < devices.Length; i ++)
				devicesThreads [i].Start (devices [i]);
		}

		void StopDevicesThreads ()
		{
			for (int i = 0; i < devices.Length; i ++) {
				devicesThreads [i].Abort ();
				devicesThreads [i].Join ();
			}
		}

		/// <summary>
		/// Начинает снятия информации с устройств и запис в БД
		/// </summary>
		public void Start ()
		{
			if ( ! isInitialized || isRunning)
				return;

			try {
				OnStarting ();

				StartDBThreads ();
				OnOutputPending ("Взаимодействие с Базой Данных началось.");
				StartDevicesThreads ();
				OnOutputPending ("Устройства запущены.");
				timer.Init (timerSignal);
				timer.Start ();
				OnOutputPending ("Таймер запущен.");
				isRunning = true;

				OnStarted ();

			} catch (Exception ex) {
				OnOutputPending ("Произошла ошибка при попытке запуска сбора данных: " + ex.Message);
				OnOutputPending ("Сессия прекращена.");
				Stop ();
			}
		}

		/// <summary>
		/// Перекращает работу потоков
		/// </summary>
		public void Stop ()
		{
			if (! isInitialized)
				return;
			try {
				OnStopping ();

				timer.Stop ();
				OnOutputPending ("Таймеры остановлены.");
				StopDevicesThreads ();
				OnOutputPending ("Устройства отключены.");
				StopDBThreadsAndDisconnect ();
				OnOutputPending ("Взаимодействие с Базой данных завершено.");

				OnStopped ();
			
			} catch (Exception ex) {
				OnOutputPending ("Произошла ошибка при  попытке остановить сбор данных: " + ex.Message);
				OnOutputPending ("Сессия прекращена.");
			} finally {
				// re-init on next run
				isInitialized = false;
				isRunning = false;
			}
		}

		public bool IsRunning {
			get { return isRunning; }
		}

		#endregion user_control

		#region Events

		/// <summary>
		/// Происходит когда есть информация для вывода
		/// </summary>
		public event OutputPendingDelegate OutputPending;

		// стадии жизни хоста
		public event EventHandler<EventArgs> Initializing;
		public event EventHandler<EventArgs> Initialized;
		public event EventHandler<EventArgs> Starting;
		public event EventHandler<EventArgs> Started;
		public event EventHandler<EventArgs> Stopping;
		public event EventHandler<EventArgs> Stopped;

		public delegate void OutputPendingDelegate (string displayMe);

		void OnOutputPending (string msg) {
			if (OutputPending != null)
				OutputPending (msg);
		}

		void OnInitializing () {
			if (Initializing != null)
				Initializing (this, EventArgs.Empty);
		}

		void OnInitialized () {
			if (Initialized != null)
				Initialized (this, EventArgs.Empty);
		}

		void OnStarting () {
			if (Starting != null)
				Starting (this, EventArgs.Empty);
		}

		void OnStarted () {
			if (Started != null)
				Started (this, EventArgs.Empty);
		}

		void OnStopping () {
			if (Stopping != null)
				Stopping (this, EventArgs.Empty);
		}

		void OnStopped () {
			if (Stopped != null)
				Stopped (this, EventArgs.Empty);
		}

		#endregion Events

		#region IDisposable implementation

		public void Dispose ()
		{
			// если объекты поля хоста не инициализированы нет смысла их удалять
			if (! isInitialized)
				return;

			// если метод уже вызвали хотя бы 1 раз
			if (isDisposing)
				return;

			// если хост еще работает
			if (isRunning)
				Stop ();

			// даем все уборщику
			foreach (DBShell dbs in dbShells)
				dbs.Disconnect ();

			queriesReadySignal.Dispose ();
			timerSignal.Dispose ();
			isDisposing = true;
		}

		#endregion

    }

	public delegate void OutputDelegate (string message);
}

