namespace Configuration
{
	public class DeviceConfiguration
	{
		/// <summary>
		/// Нужно для работы сериализации настроек.
		/// </summary>
		private DeviceConfiguration()
		{ }

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

		// Где находится устройство: библиотека, namespace, имя типа
		public string Assembly { get; set; }
		public string Namespace { get; set; }
		public string DeviceType { get; set; }
	}
}

