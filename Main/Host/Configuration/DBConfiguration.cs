using System;

namespace Host.Configuration
{
	public class DBConfiguration
	{
		public DBConfiguration (string address, string name, string user, string password, string factoryType)
		{
			Address = address;
			Name = name;
			User = user;
			Password = password;
			FactoryType = System.Type.GetType (factoryType);
		}

		public string Address { get; set; }
		public string Name { get; set; }
		public string User { get; set; }
		public string Password { get; set; }
		public Type FactoryType { get; set; }
	}
}

