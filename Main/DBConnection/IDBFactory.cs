using System;

namespace DBConnection
{
	public interface IDBFactory
	{
		IDBConnection CreateConnection ();

		/// <summary>
		/// Создает адаптер для каждого IDevice и возвращает его через yeild return
		/// </summary>
		/// <param name="deviceName">the id of the device</param>
		/// <returns>The adapters.</returns>
		IStorageAdapter CreateAdapters (string deviceName);
	}
}

