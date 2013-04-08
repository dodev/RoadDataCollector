using System;

using DBConnection;

namespace Devices
{
	public class DummyDeviceSecondDBAdapter : IStorageAdapter
	{
		public DummyDeviceSecondDBAdapter ()
		{
		}

		#region IStorageAdapter implementation

		public DBConnection.IQuery PrepareQuery (object data)
		{
			var dummyData = data as DummyDeviceData;
			if (dummyData == null)
				throw new Exception ("Data passed was not of the required type");

			var query = new SecondDBQuery (new string[] {
						dummyData.GetX ().ToString (),
						dummyData.GetY ().ToString (),
						dummyData.GetZ ().ToString ()
					});

			return query;
		}

		#endregion
	}
}

