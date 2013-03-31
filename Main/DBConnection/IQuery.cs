using System;

namespace DBConnection
{
	/// <summary>
	/// Объекты реал. этот интерфейс могут читатся DBConnection-a
	/// </summary>
	public interface IQuery
	{
		string GetSQL ();
	}
}

