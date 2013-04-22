using System;

using DBConnection;

namespace Devices
{
	public class PhotoDeviceSecondDBAdapter : IStorageAdapter
	{
		public PhotoDeviceSecondDBAdapter ()
		{
		}

		#region IStorageAdapter implementation

		public DBConnection.IQuery PrepareQuery (object data)
		{
			var query = new SecondDBQuery (new string[] {
						"an image was aded"
					});

			return query;
		}

		#endregion
	}
}

