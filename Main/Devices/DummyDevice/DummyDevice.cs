using System;

using DBConnection;

namespace Devices
{
	public class DummyDevice : IDevice
	{
		string name;
		IStorageAdapter adapter;
		Random rand;

		public DummyDevice ()
		{
			rand = new Random ();
		}

		#region IDevice implementation
		
		public string ID {
			get { return name; }
		}

		public void Init (string name, IStorageAdapter adapter)
		{
			this.name = name;
			this.adapter = adapter;
		}

		public object GetData ()
		{
			return new DummyDeviceData (rand.Next (), rand.Next (), rand.Next ());
		}

		public IStorageAdapter Adapter {
			get { return adapter; }
		}

		#endregion
	}
}

