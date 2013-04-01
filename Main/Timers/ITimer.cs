using System;
using System.Threading;

namespace Timers
{
	/// <summary>
	/// Таймер включает EventWaitHandle в состояние Signaled на определеном интервале 
	/// времени или растоянии. На этом событии ждут потоки снятия данных из устройств.
	/// </summary>
	public interface ITimer
	{
		void Init (EventWaitHandle eventHandle);
		void Start ();
		void Stop ();
	}
}

