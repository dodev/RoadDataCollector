using System;
using System.Collections.Generic;

namespace DBConnection
{
	public interface IDBFactory
	{
		IDBConnection CreateConnection ();
		/// <summary>
		/// Создает адаптер для каждого IDevice и возвращает его через yeild return
		/// </summary>
		/// <returns>The adapters.</returns>
		IEnumerable<IStorageAdapter> CreateAdapters ();

		/// <summary>
		/// Создает объекты типа IQuery, которыми будут исполнятся в IDBFactory
		/// </summary>
		/// <returns>The query.</returns>
		IQuery CreateQuery ();
	}
}

