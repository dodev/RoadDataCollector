using System;
using System.Collections.Generic;
using System.Text;
using Configuration;

namespace DBConnection
{
    public class localDBFactory : IDBFactory
    {
        DBConfiguration config;

        public localDBFactory()
		{
		}

		#region IDBFactory

		public void InitDBLayer (Configuration.DBConfiguration config)
		{
			this.config = config;
		}

		public IDBConnection CreateConnection ()
		{
			return new localDBConnection(config.Address);
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
