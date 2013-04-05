using System;
using System.Collections.Generic;

namespace Configuration
{
	public class DBConfiguration
	{
		public DBConfiguration (string address, string name, string user, string password, string assembly, string nmspace, string factoryType, IDictionary<string, string> adaptersDict)
		{
			Address = address;
			Name = name;
			User = user;
			Password = password;
			Assembly = assembly;
			// check if namespace has a trailing '.'
			if (nmspace [nmspace.Length - 1] == '.')
				nmspace = nmspace.Remove (nmspace.Length - 1);
			Namespace = nmspace;
			FactoryType = factoryType;
			ApprovedAdapters = adaptersDict;
		}

		public string Address { get; set; }
		public string Name { get; set; }
		public string User { get; set; }
		public string Password { get; set; }
		public string Assembly { get; set; }
		public string Namespace { get; set; }
		public string FactoryType { get; set; }
		public IDictionary<string, string> ApprovedAdapters { get; set; }
	}
}

