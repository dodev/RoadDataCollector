using System;

namespace Devices
{
    public interface IDevice
    {
		/// <summary>
		/// Имя устройства, как оно названо в конф файле.
		/// </summary>
		/// <value>The I.</value>
		string ID { get; }

		/// <summary>
		/// Инициализирует устройство с имя из конфиг файла и адаптер для подготовки данных для вставления в БД.
		/// </summary>
		/// <param name="name">Name.</param>
		/// <param name="adapter">Adapter.</param>
        void Init (string name, IStorageAdapter adapter);

		/// <summary>
		/// Снимает данных с устройва
		/// </summary>
		/// <returns>The data.</returns>
        object GetData ();

		/// <summary>
		/// Gets the adapter.
		/// </summary>
		/// <value>The adapter.</value>
		IStorageAdapter Adapter {get;}
    }
}
