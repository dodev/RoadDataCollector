using System;
using System.IO;

namespace DBConnection
{
	public class SecondDBConnection : IDBConnection
	{
		StreamWriter writer;
		bool firstRun;

		const string DB_FILE = "json_db.js";

		public SecondDBConnection ()
		{
			firstRun = true;
		}

		#region IDBConnection implementation

		public void Connect ()
		{
			// connecting
			writer = new StreamWriter (DB_FILE, false);
			writer.WriteLine ("[");
		}

		public void Disconnect ()
		{
			// disconnecting
			writer.WriteLine ("]");
			writer.Close ();
			writer.Dispose ();

		}

		public bool ExecuteQuery (IQuery query)
		{
			String test = query.GetQueryData () as String;
			if (test == null)
				return false;

			if (!firstRun)
				writer.Write (",");

			firstRun = false;

			writer.WriteLine (test);
			return true;
		}

		public string GetLastResponse ()
		{
			return "Something went wong";
		}

		#endregion

		#region IDisposable implementation

		public void Dispose ()
		{
			/// pshew
		}

		#endregion
	}
}

