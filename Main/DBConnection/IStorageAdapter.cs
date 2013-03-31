using System;

namespace DBConnection
{
	public interface IStorageAdapter
	{
		IQuery PrepareQuery (object data);
	}
}

