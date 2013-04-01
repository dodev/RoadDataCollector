using System;
using System.Threading;

namespace Timers
{
	public class TimeIntervalTimer : ITimer
	{
		EventWaitHandle eventHandle;
		Timer timer;
		int interval;

		public TimeIntervalTimer (int milliseconds)
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
}

