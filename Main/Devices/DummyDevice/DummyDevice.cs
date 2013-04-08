using System;

namespace Devices
{
	/// <summary>
	/// Примерное устройство. Генерирует 3 произвольных чисел и с ним заполняет объект из типа DummyDeviceData
	/// </summary>
	public class DummyDevice : IDevice
	{
		// имя устройства в конфиг файле
		string name;
		Random rand;

		/// <summary>
		/// Конструктор должен быть без параметров!
		/// </summary>
		public DummyDevice ()
		{
			rand = new Random ();
		}

		#region IDevice implementation

		/// <summary>
		/// Дает имя объекта, как он назван в конфиг файле
		/// </summary>
		/// <value>The I.</value>
		public string ID {
			get { return name; }
		}

		/// <summary>
		/// Инициализирует устройство с имя из конфиг файла и адаптер для подготовки DummyDeviceData для вставления в БД.
		/// </summary>
		/// <param name="name">Name.</param>
		/// <param name="adapter">Adapter.</param>
		public void Init (string name)
		{
			this.name = name;
		}

		/// <summary>
		/// Генерация информации. В ваших устройств, здесь должен быть код общающимся с физическое устройство.
		/// Также и код создания объекта содержащии информации из устройства.
		/// В этом случае - DummyDeviceData.
		/// </summary>
		/// <returns>The data.</returns>
		public object GetData ()
		{
			return new DummyDeviceData (rand.Next (), rand.Next (), rand.Next ());
		}

		#endregion
	}
}

