using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Linq;

namespace Configuration
{
	/// <summary>
	/// Конфигурация БД.... Тупой коментар, но что можешь сделать :)
	/// </summary>
	public class DBConfiguration
	{
		/// <summary>
		/// Нужно для работы сериализации настроек.
		/// </summary>
		private DBConfiguration()
		{ }

		public DBConfiguration (string address, string name, string user, string password, string assembly, string nmspace, string factoryType, IDictionary<string, string> adaptersDict)
		{
			Address = address;
			Name = name;
			User = user;
			Password = password;
			Assembly = assembly;
			// check if namespace has a trailing '.'
			if (nmspace [nmspace.Length - 1] == '.')
				nmspace = nmspace.Remove (nmspace.Length - 1);
			Namespace = nmspace;
			FactoryType = factoryType;
			ApprovedAdapters = adaptersDict;
		}

		public string Address { get; set; }
		public string Name { get; set; }
		public string User { get; set; }
		public string Password { get; set; }

		// Информация о том где находиться классы реализации БД слоя
		// библиотека, namespace, и имя класса
		// они нужны для инициализации объекта фабрикы из стринг
		public string Assembly { get; set; }
		public string Namespace { get; set; }
		public string FactoryType { get; set; }

		/// <summary>
		/// Нужно для работы XML - сериализации.
		/// Возвращает словарь, сериализованный в строку в формате XML.
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public string[] SerializedAdapters
		{
			get
			{
				var values =
					ApprovedAdapters.Aggregate(new List<string>(), (arr, kvp) => { arr.Add(kvp.Key); arr.Add(kvp.Value); return arr; }).ToArray();
				return values;
			}
			set
			{
				ApprovedAdapters = new Dictionary<string, string>();

				for (int i = 0; i < value.Length; i+= 2)
				{
					ApprovedAdapters.Add(value[i], value[i + 1]);
				}
			}
		}

		// словарь, с структурой "имя-устройства => имя-класса-адаптера-для-этой-бд"
		[XmlIgnore]
		public IDictionary<string, string> ApprovedAdapters { get; set; }
	}
}

