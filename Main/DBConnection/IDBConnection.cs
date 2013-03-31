using System;

namespace DBConnection
{
	/// <summary>
	/// Интерфейс для работы с БД.
	/// Хранит объект связи с БД.
	/// </summary>
	public interface IDBConnection : IDisposable
	{
		void Connect (string serverUrl, string database, string user, string password);
		void Disconnect ();
		bool ExecuteQuery (IQuery query);
	}
}

