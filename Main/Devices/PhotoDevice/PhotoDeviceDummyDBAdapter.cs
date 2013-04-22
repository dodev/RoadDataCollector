using System;
using DBConnection;
using System.Drawing;

namespace Devices
{
	public class PhotoDeviceDummyDBAdapter : IStorageAdapter
	{
		int num;
		public PhotoDeviceDummyDBAdapter ()
		{
			num = 0;
		}

		#region IStorageAdapter implementation

		public IQuery PrepareQuery (object data)
		{
			var dummyData = data as Bitmap;
			if (dummyData == null)
				throw new Exception ("Data passed was not of the required type");

			string fileName = num.ToString () + ".bmp";
			dummyData.Save (fileName);
            num++;

			var query = new DummyQuery ("dummy_images",
				new string[] {"filename"},
				new string[] { fileName });

			return query;
		}

		#endregion
	}
}

