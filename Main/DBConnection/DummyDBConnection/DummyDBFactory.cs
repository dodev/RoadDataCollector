using System;

namespace DBConnection
{
	public class DummyDBFactory : IDBFactory
	{
		public DummyDBFactory ()
		{
		}

		#region IDBFactory implementation

		public IDBConnection CreateConnection ()
		{
			return new DummyDBConnection ();
		}

		public IStorageAdapter CreateAdapter (string deviceName)
		{
			// TODO: include config and return adapters depending on te device type
			throw new NotImplementedException ();
		}

		#endregion
	}
}

