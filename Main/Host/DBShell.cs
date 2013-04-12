using System;
using System.Collections.Generic;

using DBConnection;
using Devices;

namespace Host
{
	public class DBShell
	{
		IDBConnection db;
		Queue<IQuery> queue;
		Dictionary<string, IStorageAdapter> adapters;
		OutputDelegate OutputMessage;

		public DBShell (IDBConnection connection, int capacity, OutputDelegate outputMsg)
		{
			db = connection;
			queue = new Queue<IQuery> (capacity);
			adapters = new Dictionary<string, IStorageAdapter> ();
			OutputMessage = outputMsg;
		}

		public void AddAdapter (string devID, IStorageAdapter adapter)
		{
			if (adapter == null)
				throw new Exception ("Could not create an adapter for device with id" + devID);//Не удалось создать адаптер для устройства с идентификатором

			if (adapters.ContainsKey (devID))
				throw new Exception ("Can not create 2 adapters for the same device device");//Не удается создать два адаптера для одного устройства

			adapters.Add (devID, adapter);
		}

		public void EnqueueQueryFrom (string devID, object data)
		{
			if ( ! adapters.ContainsKey (devID))
				throw new Exception ("No adapter found for device with id " + devID);//Не найден адаптер для устройства с идентификатором

			IQuery query = adapters [devID].PrepareQuery (data);

			lock (queue) {
				queue.Enqueue (query);
			}
		}

		public void ExecutePendingQueries ()
		{
			IQuery query;

			while (GetSafeQueueCount () > 0) {

				query = null;

				lock (queue) {
					if (queue.Count > 0)
						query = queue.Dequeue ();
				}

				if (query != null) {
					if (db.ExecuteQuery (query)) {
						// query прошло, дать потребителю знать 
						OutputMessage ("Выполненный запрос #0x"+query.GetHashCode ().ToString ("X"));//Executed query
					} else {
						// если запрос не выполнился, покажи сообщение из СУБД
						OutputMessage (db.GetLastResponse ());
					}
				}
			}
		}

		int GetSafeQueueCount () 
		{
			lock (queue) {
				return queue.Count;
			}
		}

		public void Connect ()
		{
			db.Connect ();
		}

		public void Disconnect ()
		{
			db.Disconnect ();
		}

		public void Dispose ()
		{
			db.Dispose ();
		}
	}
}

