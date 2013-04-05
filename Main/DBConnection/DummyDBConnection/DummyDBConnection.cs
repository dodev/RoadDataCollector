using System;
using System.IO;

namespace DBConnection
{
	public class DummyDBConnection : IDBConnection
	{
		string serverAddress;
		string dbName;
		string dbUser;
		string dbPassword;

		StreamWriter writer;

		const string DB_FILE = "dummy_db.txt";

		public DummyDBConnection (string serverUrl, string database, string user, string password)
		{
			serverAddress = serverUrl;
			dbName = database;
			dbUser = user;
			dbPassword = password;
		}

		#region IDBConnection implementation

		public void Connect ()
		{
			// use serverAddress, dbName, dbUser, dbPassword to connect
			//throw new NotImplementedException ();
			writer = new StreamWriter (DB_FILE);
		}

		public void Disconnect ()
		{
			writer.Close ();
			writer.Dispose ();
		}

		public bool ExecuteQuery (IQuery query)
		{
			string test = query.GetSQL ();
			writer.WriteLine (test);
			return true;
		}

		public string GetLastResponse ()
		{
			return "Everything is OK :)";
		}

		#endregion

		#region IDisposable implementation

		public void Dispose ()
		{

		}

		#endregion
	}
}

