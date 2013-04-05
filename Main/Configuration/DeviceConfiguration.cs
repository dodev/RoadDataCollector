using System;

namespace Configuration
{
	public class DeviceConfiguration
	{
		public DeviceConfiguration (string id, string displayName, string assembly, string nmspace, string type)
		{
			ID = id;
			DisplayName = displayName;
			Assembly = assembly;
			Namespace = nmspace;
			DeviceType = type;
		}

		public string ID { get; set; }
		public string DisplayName { get; set; }

		// Где находиться устройство: библиотека, namespace, имя типа
		public string Assembly { get; set; }
		public string Namespace { get; set; }
		public string DeviceType { get; set; }
	}
}

