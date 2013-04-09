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
		/// Инициализирует устройство с имя из конфиг файла.
		/// </summary>
		/// <param name="name">Name.</param>
        void Init (string name);

		/// <summary>
		/// Снимает данных с устройва
		/// </summary>
		/// <returns>The data.</returns>
        object GetData ();
    }
}
