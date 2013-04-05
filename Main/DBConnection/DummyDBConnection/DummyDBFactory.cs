using System;

using Configuration;

namespace DBConnection
{
	public class DummyDBFactory : IDBFactory
	{
		DBConfiguration config;

		public DummyDBFactory ()
		{
		}

		#region IDBFactory implementation

		public void InitDBLayer (DBConfiguration config)
		{
			this.config = config;
		}

		public IDBConnection CreateConnection ()
		{
			return new DummyDBConnection (config.Address, config.Name, config.User, config.Password);
		}

		public string GetAdapterTypeName (string deviceName)
		{
			if (config.ApprovedAdapters.ContainsKey (deviceName))
				return config.ApprovedAdapters[deviceName];

			return String.Empty;
		}

		#endregion
	}
}

