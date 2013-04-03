using System;

namespace Host
{
	public class DeviceConfiguration
	{
		public DeviceConfiguration (string id, string displayName, string type)
		{
			ID = id;
			DisplayName = displayName;
			TypeRepresentation = System.Type.GetType (type);
		}

		public string ID { get; set; }
		public string DisplayName { get; set; }
		public Type TypeRepresentation { get; set; }
	}
}

