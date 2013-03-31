using System;
using System.Collections.Generic;
using System.Text;

namespace DBConnection
{
	/// <summary>
	/// Пример реализации IQuery для СУБД MySQL.
	/// Генерируется строка содержащая запрос на вставки в БД
	/// используя StringBuilder.
	/// </summary>
	public class InsertStringQuery : IQuery
	{
		string table;
		IEnumerable<string> attributes;
		IEnumerable<string> values;

		public InsertStringQuery (string table, IEnumerable<string> attributes, IEnumerable<string> values)
		{
			this.table = table;
			this.attributes = attributes;
			this.values = values;
		}

		#region IQuery implementation

		string IQuery.GetSQL ()
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

