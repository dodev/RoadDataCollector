using System;
using System.Collections.Generic;

namespace DBConnection
{
	public interface IDBFactory
	{
		IDBConnection CreateConnection ();
		IEnumerable<IStorageAdapter> CreateAdapters ();
		IQuery CreateQuery ();
	}
}

