using System;
using System.Collections.Generic;
using System.Threading;

using DBConnection;
using Timers;

namespace Host
{
	public class CollectorHost : IDisposable
    {
		IDBConnection db;
		Thread dbThread;
		Queue<IQuery> dbQueue;
		List<IDevice> devices;
		//List<IStorageAdapter> adapters;
		Thread devicesThread;
		//Queue<string> outputQueue;
		//Thread outputThread;
		ITimer timer;
		EventWaitHandle timerSignal;
		EventWaitHandle queriesReadySignal;

        /// <summary>
        /// Default constructor
        /// </summary>
        /*public CollectorHost()
        {

        }*/


		//
		// примерная реализация таймера
		//
		#region Zaglushka

		const int QCAPACITY = 20; // TODO: move this variable into the config class

		/// <summary>
		/// Заглушка host-a
		/// </summary>
		/// <param name="dummy">If set to <c>true</c> dummy.</param>
		public CollectorHost (bool dummy)
		{
			db = null;
			dbThread = new Thread (new ThreadStart (HandleDBRequest));
			dbQueue = new Queue<IQuery> (QCAPACITY);
			devices = new List<IDevice> (3);
			//adapters = null;
			devicesThread = new Thread (new ThreadStart (CollectDeviceInfo));
			//outputQueue = new Queue<string> (QCAPACITY);
			//outputThread = new Thread (new ThreadStart (WriteToGUIConsole));
			timer = new TimeIntervalTimer (1000);
			timerSignal = new ManualResetEvent (false);
			queriesReadySignal = new ManualResetEvent (false);

		}

		void HandleDBRequest ()
		{
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

		public event OutputPendingDelegate OutputPending;

		public delegate void OutputPendingDelegate (string displayMe);

		void OnOutputPending () {
			/*lock (outputQueue) {
				if (OutputPending != null && outputQueue.Count > 0)
					OutputPending (outputQueue.Dequeue ());
			}*/
		}

		void OnOutputPending (string msg) {
			if (OutputPending != null)
				OutputPending (msg);
		}

		#endregion Zaglushka

		public void Start ()
		{
			timer.Init (timerSignal);
			timer.Start ();
			devicesThread.Start ();
			dbThread.Start ();
		}

		public void Stop ()
		{
			timer.Stop ();
			devicesThread.Abort ();
			devicesThread.Join ();
			dbThread.Abort ();
			dbThread.Join ();
			// TODO: re-init threads
		}

		void OutputMsg (string msg)
		{
			OnOutputPending (msg);
		}

		#region IDisposable implementation

		public void Dispose ()
		{
			// TODO: Добавь все что требует очистку здесь
		}

		#endregion

    }
}
