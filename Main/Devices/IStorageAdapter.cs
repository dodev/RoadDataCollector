using System;

using DBConnection;

namespace Devices
{
	/// <summary>
	/// Переводит инфоримацию устройств на языке СУДБ
	/// </summary>
	public interface IStorageAdapter
	{
		/// <summary>
		/// Берет информацию из дивайса как object. Переобразует ее в
		/// класс данных устройва и создает IQuery для соответственного класса связи с БД.
		/// </summary>
		/// <returns>The query.</returns>
		/// <param name="data">Data.</param>
		IQuery PrepareQuery (object data);
	}
}

