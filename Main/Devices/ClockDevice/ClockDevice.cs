using System;

namespace Devices
{
	public class ClockDevice : IDevice
	{
		string name;

		public ClockDevice ()
		{
		}

		#region IDevice implementation

		public void Init (string name)
		{
			this.name = name;
		}

		public object GetData ()
		{
			return new ClockDeviceData (DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond);
		}

		public string ID {
			get {
				return name;
			}
		}

		#endregion
	}
}

