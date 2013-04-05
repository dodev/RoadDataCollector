using System;

using Configuration;

namespace DBConnection
{
	/// <summary>
	/// Примерная реазилация БД фабрики.
	/// </summary>
	public class DummyDBFactory : IDBFactory
	{
		DBConfiguration config;

		/// <summary>
		/// У ваших реализации должен быть только конструктор без параметров a.k.a default constructor
		/// Потому что этот конструктор пользуется при создания объекта через Activator.CreateInstance ()
		/// </summary>
		public DummyDBFactory ()
		{
		}

		#region IDBFactory implementation

		/// <summary>
		/// Здесь фабрика получает что ей нужно знать - DBConfiguration :)
		/// </summary>
		/// <param name="config">Config.</param>
		public void InitDBLayer (DBConfiguration config)
		{
			this.config = config;
		}

		/// <summary>
		/// Возвращает класс для связи с БД с вашим настроек
		/// </summary>
		/// <returns>The connection.</returns>
		public IDBConnection CreateConnection ()
		{
			return new DummyDBConnection (config.Address, config.Name, config.User, config.Password);
		}

		/// <summary>
		/// Дает имя класса адаптера для каждого IDevice.
		/// </summary>
		/// <param name="deviceName">the id of the device</param>
		/// <returns>The adapters.</returns>
		public string GetAdapterTypeName (string deviceName)
		{
			if (config.ApprovedAdapters.ContainsKey (deviceName))
				return config.ApprovedAdapters[deviceName];

			return String.Empty;
		}

		#endregion
	}
}

