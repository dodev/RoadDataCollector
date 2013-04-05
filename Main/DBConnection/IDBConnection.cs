using System;

namespace DBConnection
{
	/// <summary>
	/// Интерфейс для работы с БД.
	/// Хранит объект связи с БД.
	/// </summary>
	public interface IDBConnection : IDisposable
	{
		void Connect ();
		void Disconnect ();
		bool ExecuteQuery (IQuery query);
		string GetLastResponse ();
	}
}

