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
		/// <summary>
		/// Берет информации из query и с ней выполняет запрос к БД
		/// </summary>
		/// <returns><c>true</c>, if query was executed, <c>false</c> otherwise.</returns>
		/// <param name="query">Query.</param>
		bool ExecuteQuery (IQuery query);

		/// <summary>
		/// При ошибке метод вызивается чтобы уточнить проблемой.
		/// Метод должен содержать сообщение передано классу БД.
		/// </summary>
		/// <returns>The last response.</returns>
		string GetLastResponse ();
	}
}

