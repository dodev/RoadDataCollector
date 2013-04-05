using System;
using DBConnection;

namespace Devices
{
	/// <summary>
	/// Примерная реализация адаптера для DummyDevice и DummyDB
	/// </summary>
	public class DummyDeviceDummyDBAdapter : IStorageAdapter
	{
		/// <summary>
		/// Конструктор должет быть без аргументов!!!
		/// </summary>
		public DummyDeviceDummyDBAdapter ()
		{
		}

		#region IStorageAdapter implementation

		/// <summary>
		/// Берет информацию из дивайса как object. Переобразует ее в
		/// класс данных устройва и создает IQuery для соответственного класса связи с БД.
		/// </summary>
		/// <returns>The query.</returns>
		/// <param name="data">Data.</param>
		public IQuery PrepareQuery (object data)
		{
			var dummyData = data as DummyDeviceData;
			if (dummyData == null)
				throw new Exception ("Data passed was not of the required type");

			var query = new DummyQuery ("dummy_coordinates",
				new string[] {"x", "y", "x"},
				new string[] {
						dummyData.GetX ().ToString (),
						dummyData.GetY ().ToString (),
						dummyData.GetZ ().ToString ()
				});

			return query;
		}

		#endregion
	}
}

