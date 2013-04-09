using System;

using DBConnection;

namespace Devices
{
	public class ClockDeviceSecondDBAdapter : IStorageAdapter
	{
		public ClockDeviceSecondDBAdapter ()
		{
		}

		#region IStorageAdapter implementation

		public IQuery PrepareQuery (object data)
		{
			var cd = data as ClockDeviceData;
			if (cd == null)
				throw new Exception ("could not convert information from device data object");

			return new SecondDBQuery (
				new string[] {cd.Hours.ToString (), cd.Minutes.ToString (), cd.Seconds.ToString (), cd.Milliseconds.ToString ()}
			);
		}

		#endregion
	}
}

