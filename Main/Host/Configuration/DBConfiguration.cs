using System;

namespace Host.Configuration
{
	public class DBConfiguration
	{
		public DBConfiguration (string address, string name, string user, string password)
		{
			Address = address;
			Name = name;
			User = user;
			Password = password;
		}

		public string Address { get; set; }
		public string Name { get; set; }
		public string User { get; set; }
		public string Password { get; set; }
	}
}

