using System;

namespace Configuration
{
	public interface IConfigurator : IDisposable
	{
		void Load ();
		object GetItem (string name);
		void SetItem (string name, object value);
	}
}

