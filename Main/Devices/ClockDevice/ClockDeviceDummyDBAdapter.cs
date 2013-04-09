using System;

using DBConnection;

namespace Devices
{
	public class ClockDeviceDummyDBAdapter : IStorageAdapter
	{
		public ClockDeviceDummyDBAdapter ()
		{
		}

		#region IStorageAdapter implementation

		public IQuery PrepareQuery (object data)
		{
			var cd = data as ClockDeviceData;
			if (cd == null)
				throw new Exception ("could not convert information from device data object");

			return new DummyQuery (
				"time",
				new string[] {"hours", "minutes", "seconds", "milliseconds"},
				new string[] {cd.Hours.ToString (), cd.Minutes.ToString (), cd.Seconds.ToString (), cd.Milliseconds.ToString ()}
			);
		}

		#endregion
	}
}

