using System;
using System.Collections.Generic;
using System.Threading;

using DBConnection;

namespace Host
{
	public class CollectorHost : IDisposable
    {
		IDBConnection db;
		Thread dbThread;
		Queue<IQuery> dbQueue;
		List<IDevice> devices;
		List<IStorageAdapter> adapters;
		Thread devicesThread;
		Queue<string> outputQueue;
		Thread outputThread;
		ITimer timer;
		EventWaitHandle timerSignal;

        /// <summary>
        /// Default constructor
        /// </summary>
        public CollectorHost()
        {

        }


		//
		// примерная реализация таймера
		//
		#region Zaglushka

		const int QCAPACITY = 20;

		/// <summary>
		/// Заглушка host-a
		/// </summary>
		/// <param name="dummy">If set to <c>true</c> dummy.</param>
		public CollectorHost (bool dummy)
		{
			db = null;
			dbThread = new Thread (new ThreadStart (HandleDBRequest));
			dbQueue = new Queue<IQuery> (QCAPACITY);
			devices = null;
			adapters = null;
			devicesThread = new Thread (new ThreadStart (CollectDeviceInfo));
			outputQueue = new Queue<string> (QCAPACITY);
			outputThread = new Thread (new ThreadStart (WriteToGUIConsole));
			timer = new DummyTimer (1000);
			timerSignal = new ManualResetEvent (false);

		}

		void HandleDBRequest ()
		{

		}

		void CollectDeviceInfo ()
		{
			for (;;) {
				timerSignal.WaitOne ();

				lock (outputQueue) {
					outputQueue.Enqueue ("Collect data method called!");
				}
				OnOutputPending ();

				timerSignal.Reset ();
			}
		}

		public event OutputPendingDelegate OutputPending;

		public delegate void OutputPendingDelegate (string displayMe);

		void OnOutputPending () {
			if (OutputPending != null && outputQueue.Count > 0)
				OutputPending (outputQueue.Dequeue ());
		}

		void WriteToGUIConsole ()
		{

		}

		class DummyTimer : ITimer
		{
			EventWaitHandle eventHandle;
			Timer timer;
			int interval;

			public DummyTimer (int milliseconds)
			{
				eventHandle = null;
				timer = null;
				interval = milliseconds;
			}
			#region ITimer implementation

			public void Init (EventWaitHandle waitHandle)
			{
				if (eventHandle == null && waitHandle != null) {
					eventHandle = waitHandle;
					eventHandle.Reset (); // make sure the handle is not signaled

				}
			}

			void setEvent (object state)
			{
				eventHandle.Set ();
			}

			public void Start ()
			{
				if (eventHandle != null)
					timer = new Timer (new TimerCallback (setEvent), null, 0, interval);
			}

			public void Stop ()
			{
				timer.Dispose ();
			}

			#endregion
		}

		#endregion Zaglushka

		public void Start ()
		{
			timer.Init (timerSignal);
			timer.Start ();
			devicesThread.Start ();
		}

		public void Stop ()
		{
			timer.Stop ();
			devicesThread.Abort ();
			devicesThread.Join ();
			// TODO: re-init threads
		}

		#region IDisposable implementation


		public void Dispose ()
		{
			// TODO: Добавь все что требует очистку здесь
		}

		#endregion

    }
}
