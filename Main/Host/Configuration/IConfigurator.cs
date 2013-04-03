using System;

namespace Host.Configuration
{
	public interface IConfigurator : IDisposable
	{
		bool Load ();
		object GetItem (string name);
		void SetItem (string name, object value);
	}
}

