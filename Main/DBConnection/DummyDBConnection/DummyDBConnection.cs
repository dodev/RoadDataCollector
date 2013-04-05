using System;
using System.IO;

namespace DBConnection
{
	/// <summary>
	/// Примерная реализация класса для подержки связи с БД
	/// Здесь не используется конфигурация, передана файла в конструктура.
	/// Она дана только как примера.
	/// Сам БД представляет себе текстовой файл :)
	/// В нем мы добавляем строчки (записи)
	/// </summary>
	public class DummyDBConnection : IDBConnection
	{
		string serverAddress;
		string dbName;
		string dbUser;
		string dbPassword;

		StreamWriter writer;

		const string DB_FILE = "dummy_db.txt";

		public DummyDBConnection (string serverUrl, string database, string user, string password)
		{
			// примерная настройка БД
			// эти переменные не пользуется нигде
			// еще раз, только для примера :)
			serverAddress = serverUrl;
			dbName = database;
			dbUser = user;
			dbPassword = password;
		}

		#region IDBConnection implementation

		/// <summary>
		/// Вызивается при попытке установления связи с БД.
		/// При случае неудачи подлючения, используйте throw new Exception
		/// для уповещения host-a
		/// </summary>
		public void Connect ()
		{
			// здесь наверно пригодятся параметры конфигурации если они нужны
			writer = new StreamWriter (DB_FILE, true);
		}

		/// <summary>
		/// В конце процедуры снятие данных закрываем все что отркыли
		/// </summary>
		public void Disconnect ()
		{
			writer.Close ();
			writer.Dispose ();
		}

		/// обрабатываем все запросы здесь
		public bool ExecuteQuery (IQuery query)
		{
			String test = query.GetQueryData () as String;
			if (test == null)
				return false;

			writer.WriteLine (test);
			return true;
		}

		/// <summary>
		/// Метод вызивается при неудачи выполнения запроса
		/// Должен вернут текст с ошибкой из БД
		/// </summary>
		/// <returns>The last response.</returns>
		public string GetLastResponse ()
		{
			return "Something went wong!";
		}

		#endregion

		#region IDisposable implementation

		/// <summary>
		/// Удаляем БД после употребы
		/// </summary>
		/// <remarks>Call <see cref="Dispose"/> when you are finished using the <see cref="DBConnection.DummyDBConnection"/>. The
		/// <see cref="Dispose"/> method leaves the <see cref="DBConnection.DummyDBConnection"/> in an unusable state. After
		/// calling <see cref="Dispose"/>, you must release all references to the <see cref="DBConnection.DummyDBConnection"/>
		/// so the garbage collector can reclaim the memory that the <see cref="DBConnection.DummyDBConnection"/> was occupying.</remarks>
		public void Dispose ()
		{

		}

		#endregion
	}
}

