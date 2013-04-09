using System;

namespace Devices
{
	public class ClockDeviceData
	{
		int hours;
		int minutes;
		int seconds;
		int milliseconds;

		public ClockDeviceData (int hours, int minutes, int seconds, int milliseconds)
		{
			this.hours = hours;
			this.minutes = minutes;
			this.seconds = seconds;
			this.milliseconds = milliseconds;
		}

		public int Hours {
			get { return hours; }
		}

		public int Minutes {
			get { return minutes; }
		}

		public int Seconds {
			get { return seconds; }
		}

		public int Milliseconds {
			get { return milliseconds; }
		}
	}
}

