using System;
using System.Collections.Generic;
using System.Text;

namespace DBConnection
{
	/// <summary>
	/// Пример реализации IQuery для СУБД DummyDB (текстовой файл)
	/// Генерируется строка содержащая запрос на вставки в БД
	/// используя StringBuilder.
	/// </summary>
	public class DummyQuery : IQuery
	{
		string table;
		IEnumerable<string> attributes;
		IEnumerable<string> values;

		/// <summary>
		/// Конструктор может имет любую структуру, т.к. он не включен в интерфейса IQuery
		/// Используйте его для добавления информации в объекте
		/// </summary>
		/// <param name="table">Table.</param>
		/// <param name="attributes">Attributes.</param>
		/// <param name="values">Values.</param>
		public DummyQuery (string table, IEnumerable<string> attributes, IEnumerable<string> values)
		{
			this.table = table;
			this.attributes = attributes;
			this.values = values;
		}

		#region IQuery implementation

		public object GetQueryData ()
		{
			StringBuilder sb = new StringBuilder ();
			sb.Append ("INSERT INTO ");
			sb.Append (table);

			// перечисляем атрибуты
			sb.Append (" (");
			foreach (string attr in attributes)
				sb.Append (attr + ", ");
			sb.Remove (sb.Length - 2, 2); // удаляем послдные ", "

			// перечисляем значения
			sb.Append (") VALUES (");
			foreach (string val in values)
				sb.Append (val + ", ");
			sb.Remove (sb.Length - 2, 2); // удаляем послдные ", "
			sb.Append (")");

			return sb.ToString ();
		}

		#endregion
	}
}

