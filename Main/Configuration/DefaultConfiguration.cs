using System.Collections.Generic;

namespace Configuration
{
	class DefaultConfiguration : Dictionary<string, object>
	{
		/// <summary>
		/// Конфигурация по умолчанию, сохраняемая классом <see cref="XmlConfigurator"/>
		/// в конфигурационный файл в случае его отсутствия.
		/// </summary>
		public DefaultConfiguration()
		{
			IDictionary<string, string> dummyDBAdapters = new Dictionary<string, string>() {
				{"dummy_device", "DummyDeviceDummyDBAdapter"},
				{"clock_device", "ClockDeviceDummyDBAdapter"},
			};

			IDictionary<string, string> secondDBAdapters = new Dictionary<string, string>() {
				{"dummy_device", "DummyDeviceSecondDBAdapter"},
				{"clock_device", "ClockDeviceSecondDBAdapter"}
			};

           // IDictionary<string, string> localDBAdapters = new Dictionary<string, string>() {
			//	{"dummy_device", "DummyDeviceLocalDBAdapter"}
			//};

			Add("timer_type", "time");
			Add("timer_time_interval_ms", 1000);
			Add("queue_capacity", 20);
			Add("db_conf_list", new DBConfiguration [] {
						new DBConfiguration ("test", "dummy_db", "dodo", "dodo", "DBConnection", "DBConnection", "DummyDBFactory", dummyDBAdapters),
						new DBConfiguration ("test", "dummy_db", "dodo", "dodo", "DBConnection", "DBConnection", "SecondDBFactory", secondDBAdapters)//,
                        //new DBConfiguration ("Server=.\\SQLExpress;AttachDbFilename=|DataDirectory|\\localDB\\LocalDB.mdf;Database=RDC_LDBC;Trusted_Connection=Yes;",
                        //    null, null, null, "DBConnection", "DBConnection", "localDBFactory", localDBAdapters)
					});

			Add("dev_conf_list", new DeviceConfiguration[] {
						new DeviceConfiguration("dummy_device", "Пробное устройство", "Devices", "Devices", "DummyDevice"),
						new DeviceConfiguration("clock_device", "Часы", "Devices", "Devices", "ClockDevice")
					});
		}
	}
}