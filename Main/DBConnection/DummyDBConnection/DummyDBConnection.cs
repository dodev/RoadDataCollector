using System;

namespace DBConnection
{
	public class DummyDBConnection : IDBConnection
	{
		public DummyDBConnection ()
		{
		}

		#region IDBConnection implementation

		public void Connect (string serverUrl, string database, string user, string password)
		{
			//throw new NotImplementedException ();
		}

		public void Disconnect ()
		{
			throw new NotImplementedException ();
		}

		public bool ExecuteQuery (IQuery query)
		{
			throw new NotImplementedException ();
		}

		public string GetLastResponse ()
		{
			throw new NotImplementedException ();
		}

		#endregion

		#region IDisposable implementation

		public void Dispose ()
		{
			throw new NotImplementedException ();
		}

		#endregion
	}
}

