using System;

using Configuration;

namespace DBConnection
{
	public interface IDBFactory
	{
		void InitDBLayer (DBConfiguration config);

		IDBConnection CreateConnection ();

		/// <summary>
		/// Создает адаптер для каждого IDevice и возвращает его через yeild return
		/// </summary>
		/// <param name="deviceName">the id of the device</param>
		/// <returns>The adapters.</returns>
		string GetAdapterTypeName (string deviceId);
	}
}

