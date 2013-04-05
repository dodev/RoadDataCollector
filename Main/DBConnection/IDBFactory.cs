using System;

using Configuration;

namespace DBConnection
{
	public interface IDBFactory
	{
		/// <summary>
		/// Передает конфигурационный объект фабрику.
		/// </summary>
		/// <param name="config">Config.</param>
		void InitDBLayer (DBConfiguration config);

		IDBConnection CreateConnection ();

		/// <summary>
		/// Дает имя класса адаптера для каждого IDevice.
		/// </summary>
		/// <param name="deviceName">the id of the device</param>
		/// <returns>The adapters.</returns>
		string GetAdapterTypeName (string deviceId);
	}
}

