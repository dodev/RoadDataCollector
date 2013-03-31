using System;

namespace DBConnection
{
	public interface IDBConnection : IDisposable
	{
		void Connect (string serverUrl, string database, string user, string password);
		void Disconnect ();
		bool ExecuteQuery (IQuery query);
	}
}

