using System;
using System.Collections.Generic;

namespace Configuration
{
	public class DummyConfigurator : IConfigurator
	{
		IDictionary<string, object> items;

		public DummyConfigurator ()
		{
			IDictionary<string, string> dummyDBAdapters = new Dictionary<string, string> () {{"dummy_device", "DummyDeviceDummyDBAdapter"}};
			items = new Dictionary<string, object> ()
			{
				{"timer_time_interval_ms", 1000},
				{"queue_capacity", 20},
				{"db_conf", new DBConfiguration ("test", "dummy_db", "dodo", "dodo", "DBConnection", "DBConnection", "DummyDBFactory", dummyDBAdapters)},
				{"dev_conf_list", new DeviceConfiguration[] {new DeviceConfiguration("dummy_device", "Пробное устройство", "Devices", "Devices", "DummyDevice")}}
			};
		}

		#region IConfigurator implementation

		public bool Load ()
		{
			//throw new NotImplementedException ();
			return true;
		}

		public object GetItem (string name)
		{
			name = name.ToLowerInvariant ();
			if (items.ContainsKey (name)) {
				return items [name];
			}

			return null;
		}

		public void SetItem (string name, object o)
		{
			name = name.ToLowerInvariant ();
			if (items.ContainsKey (name)) {
				items [name] = o;
			} else {
				items.Add (name, o);
			}
		}

		#endregion

		#region IDisposable implementation

		public void Dispose ()
		{
			//throw new NotImplementedException ();
		}

		#endregion
	}
}

