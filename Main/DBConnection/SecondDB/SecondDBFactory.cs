using System;

using Configuration;

namespace DBConnection
{
	public class SecondDBFactory : IDBFactory
	{
		DBConfiguration config;

		public SecondDBFactory ()
		{
		}

		#region IDBFactory implementation

		public void InitDBLayer (Configuration.DBConfiguration config)
		{
			this.config = config;
		}

		public IDBConnection CreateConnection ()
		{
			return new SecondDBConnection ();
		}

		public string GetAdapterTypeName (string deviceId)
		{
			if (config.ApprovedAdapters.ContainsKey (deviceId))
				return config.ApprovedAdapters[deviceId];

			return String.Empty;
		}

		#endregion
	}
}

