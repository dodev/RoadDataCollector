using System;

namespace Devices
{
	public class GPRSimulatorDevice : IDevice
	{
		string name;

		public GPRSimulatorDevice ()
		{
		}

		#region IDevice implementation

		public void Init (string name, IStorageAdapter adapter)
		{
			this.name = name;
		}

		public void Init(string name)
		{
			Init(name, null);
		}

		public object GetData ()
		{
			// Вот здесь можно кодит :)
			throw new NotImplementedException();
		}

		public string ID {
			get {
				return name;
			}
		}

		public IStorageAdapter Adapter {
			get {
				throw new NotImplementedException ();
			}
		}

		#endregion
	}
}

