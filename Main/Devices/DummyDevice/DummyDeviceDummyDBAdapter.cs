using System;
using DBConnection;

namespace Devices
{
	public class DummyDeviceDummyDBAdapter : IStorageAdapter
	{
		public DummyDeviceDummyDBAdapter ()
		{
		}

		#region IStorageAdapter implementation

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

