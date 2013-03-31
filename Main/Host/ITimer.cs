using System;
using System.Threading;

namespace Host
{
	public interface ITimer
	{
		void Init (EventWaitHandle eventHandle);
		void Start ();
		void Stop ();
	}
}

