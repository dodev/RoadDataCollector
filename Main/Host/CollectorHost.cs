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
		IDBConnection db;
		Thread dbThread;
		Queue<IQuery> dbQueue;
		List<IDevice> devices;
		Thread devicesThread;
		ITimer timer;
		EventWaitHandle timerSignal;
		EventWaitHandle queriesReadySignal;
		IConfigurator conf;
		bool isInitialized;

		/// <summary>
		/// Initializes a new instance of the <see cref="Host.CollectorHost"/> class.
		/// </summary>
		/// <param name="conf">Conf.</param>
		public CollectorHost (IConfigurator conf)
		{
			this.conf = conf;
			isInitialized = false;
		}

		public void Init ()
		{
			if (isInitialized)
				return;
			try {
				// настраиваем БД
				var dbConf = conf.GetItem ("db_conf") as DBConfiguration;
				if (dbConf == null)
					throw new Exception ("'db_conf' item coulnd't be found in the configuration");

				var dbFactory = Activator.CreateInstance (GetType (dbConf.Assembly, dbConf.Namespace, dbConf.FactoryType)) as IDBFactory;
				dbFactory.InitDBLayer (dbConf);
				db = dbFactory.CreateConnection ();
				dbThread = new Thread (new ThreadStart (HandleDBRequest));
				// и очередь БД
				var capacity = conf.GetItem ("queue_capacity");
				if (capacity == null)
					throw new Exception ("queue_capacity item couldn't be found in the configuration");
				dbQueue = new Queue<IQuery> ((int)capacity);

				// список устройств
				var devConfList = conf.GetItem ("dev_conf_list") as DeviceConfiguration[];
				if (devConfList == null)
					throw new Exception ("'dev_conf_list' couldn't be found in the configuration");
				devices = new List<IDevice> (devConfList.Length);
				foreach (DeviceConfiguration devConf in devConfList) {
					var dev = Activator.CreateInstance (GetType (devConf.Assembly, devConf.Namespace, devConf.DeviceType)) as IDevice;
					if (dev == null)
						throw new Exception ("Could not create device with id " + devConf.ID);
					var adapter = Activator.CreateInstance (GetType (devConf.Assembly, devConf.Namespace, dbFactory.GetAdapterTypeName (devConf.ID))) as IStorageAdapter;
					if (adapter == null)
						throw new Exception ("Adapter for device with id '" + dev.ID + "' could not be found!");
					dev.Init (devConf.ID, adapter);
					devices.Add (dev);
				}
				devicesThread = new Thread (new ThreadStart (CollectDeviceInfo));

				// настройки таймера
				// TODO: add mechanism for changing timers
				var timeInterval = conf.GetItem ("timer_time_interval_ms");
				if (timeInterval == null)
					throw new Exception ("'timer_time_interval_ms' couldn't be found in the configuration object");
				timer = new TimeIntervalTimer ((int)timeInterval);

				// событие для таймера
				timerSignal = new ManualResetEvent (false);

				// событие для БД
				queriesReadySignal = new ManualResetEvent (false);

				isInitialized = true;

			} catch (Exception ex) {
				OutputMsg ("Error occured: " + ex.ToString ());
				isInitialized = false;
			}
		}

		Type GetType (string assembly, string nmspace, string type)
		{
			return Type.GetType (String.Format ("{0}.{1}, {2}", nmspace, type, assembly));
		}


		/// <summary>
		/// Ждет запросы к БД в отдельном потоке
		/// </summary>
		void HandleDBRequest ()
		{
			if (db == null)
				throw new Exception ("DB configuration or connection object not available");

			// связываемся с БД
			db.Connect ();
			OutputMsg ("Successfully connected to DB"); 

			int count;
			IQuery queryBuf;

			// бесконечный цикл обработки запросов
			for (;;) {
				// ждем пока очередь не заполнится других потоков
				queriesReadySignal.WaitOne ();

				try {

					do {
						OutputMsg ("Recording to DB"); // Dummy output TODO: remove this when everything is working

						queryBuf = null;
						// вытаскиваем первы запрос из очереди
						lock (dbQueue) {
							if (dbQueue.Count > 0)
								queryBuf = dbQueue.Dequeue ();
						}

						// выполняем запроса
						// предполагаем, что это будет медлено выполнятся
						if (queryBuf != null) {
							if ( ! db.ExecuteQuery (queryBuf))
								// если запрос не выполнился, покажи сообщение из СУБД
								OutputMsg (db.GetLastResponse ());
							// queryBuf.Dispose ();
						}

						// так как прошло много времени с момента выполнения запроса
						// блокируем доступ к dbQueu и проверяем оставшихся элементов в очереди
						lock (dbQueue) {
							count = dbQueue.Count;
						}
					} while (count > 0);

				} catch (Exception ex) {
					// выводим в консоль текст изключении
					OutputMsg (ex.ToString ());
				}
				// выполняются все запросы в очереди

				// выключаем сигнал пока не добавится элементов в очереди
				queriesReadySignal.Reset ();
			}
		}

		/// <summary>
		/// Собирает информацию с устройств
		/// </summary>
		void CollectDeviceInfo ()
		{
			object buf;
			IQuery queryBuf;

			for (;;) {
				timerSignal.WaitOne ();

				try {
					/*lock (outputQueue) {
					 outputQueue.Enqueue ("Collect data method called!");
					 } */

					// TODO: COllect info from devices
					foreach (IDevice dev in devices) {
						buf = dev.GetData ();
						if (buf != null) {
							queryBuf = dev.Adapter.PrepareQuery (buf);
							lock (dbQueue) {
								dbQueue.Enqueue (queryBuf);
							}
							// queriesReadySignal.Set (); TODO: uncomment this when testing is finished and the devices and adapters are working
						}
					}
					// TODO: generate queries
					queriesReadySignal.Set (); // Dummy call TODO: remove this when devices and adapters are working
					OutputMsg ("Collecting data from devices"); // Dummy output

				} catch (Exception ex) {
					OutputMsg (ex.ToString ());
				}

				timerSignal.Reset ();
			}
		}

		/// <summary>
		/// Начинает снятия информации с устройств и запис в БД
		/// </summary>
		public void Start ()
		{
			if (! isInitialized)
				return;
			try {

				OutputMsg ("Starting devices...");
				timer.Init (timerSignal);
				timer.Start ();
				// TODO: fire events
				devicesThread.Start ();
				dbThread.Start ();

			} catch (Exception ex) {
				OutputMsg ("Error occured: " + ex.ToString ());
				OutputMsg ("Terminating session.");
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

			OutputMsg ("Stopping host...");
			timer.Stop ();
			devicesThread.Abort ();
			devicesThread.Join ();
			OutputMsg ("Devices stopped");
			dbThread.Abort ();
			dbThread.Join ();
			db.Disconnect ();
			OutputMsg ("Database communication stopped");
			// TODO: disconnect from DB
			isInitialized = false;
			// TODO: re-init threads
			// TODO: add events for starting and stopping
		}

		/// <summary>
		/// Происходит когда есть информация для вывода
		/// </summary>
		public event OutputPendingDelegate OutputPending;

		public delegate void OutputPendingDelegate (string displayMe);

		void OnOutputPending (string msg) {
			if (OutputPending != null)
				OutputPending (msg);
		}

		/// <summary>
		/// Отправляет msg для вывод на экран
		/// </summary>
		/// <param name="msg">Message.</param>
		void OutputMsg (string msg)
		{
			OnOutputPending (msg);
		}

		#region IDisposable implementation

		public void Dispose ()
		{
			// TODO: Добавь все что требует очистку здесь
			// TODO: Check if threads are working and stop them if they are.
		}

		#endregion

    }
}
