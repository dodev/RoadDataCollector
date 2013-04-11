using System;
using System.Collections.Generic;


namespace Configuration
{
	/// <summary>
	/// Примерная реализация класса конфигуратора.
	/// Он должен имет тоже самый интерфейс, но загружать конфигурацию из xml или json файла
	/// и представлят ее через тоже самой структуры, т.е. int, string, DBConfiguration, DeviceConfiguration..
	/// </summary>
	public class DummyConfigurator : IConfigurator
	{
		// словарь с конфигурационными значениями
		IDictionary<string, object> items;

		public DummyConfigurator ()
		{
			IDictionary<string, string> dummyDBAdapters = new Dictionary<string, string> () {
				{"dummy_device", "DummyDeviceDummyDBAdapter"},
				{"clock_device", "ClockDeviceDummyDBAdapter"}
			};
			IDictionary<string, string> secondDBAdapters = new Dictionary<string, string> () {
				{"dummy_device", "DummyDeviceSecondDBAdapter"},
				{"clock_device", "ClockDeviceSecondDBAdapter"}
			};
			items = new Dictionary<string, object> ()
			{
				{"timer_type", "time"},
				{"timer_time_interval_ms", 1000},
				{"queue_capacity", 20},
				{"db_conf", new DBConfiguration [] {
						new DBConfiguration ("test", "dummy_db", "dodo", "dodo", "DBConnection", "DBConnection", "DummyDBFactory", dummyDBAdapters),
						new DBConfiguration ("test", "dummy_db", "dodo", "dodo", "DBConnection", "DBConnection", "SecondDBFactory", secondDBAdapters)
					}
				},
				{"dev_conf_list", new DeviceConfiguration [] {
						new DeviceConfiguration("dummy_device", "Пробное устройство", "Devices", "Devices", "DummyDevice"),
						new DeviceConfiguration("clock_device", "Часы", "Devices", "Devices", "ClockDevice")
					}
				}
			};
		}

		#region IConfigurator implementation

		public void Load ()
		{
			// Здесь должно произходит чтение файла
			// если что нибудь поидет не так - thrown new Exception ("<описание>");
		}

		/// <summary>
		/// Возращает object, который потом может преобразоватся в любой тип
		/// </summary>
		/// <returns>The item.</returns>
		/// <param name="name">Name.</param>
		public object GetItem (string name)
		{
			name = name.ToLowerInvariant ();
			if (items.ContainsKey (name)) {
				return items [name];
			}

			return null;
		}

		/// <summary>
		/// Меняет или добавляет значение в словаре с конфигурацией
		/// </summary>
		/// <param name="name">Name.</param>
		/// <param name="o">O.</param>
		public void SetItem (string name, object o)
		{
			name = name.ToLowerInvariant ();
			if (items.ContainsKey (name)) {
				items [name] = o;
			} else {
				items.Add (name, o);
			}
		}

		#endregion

		#region IDisposable implementation

		public void Dispose ()
		{
			// здесь будут все объекты которы должны быт помечены как "мусор" после употребы
			//throw new NotImplementedException ();
		}

		#endregion
	}
}

