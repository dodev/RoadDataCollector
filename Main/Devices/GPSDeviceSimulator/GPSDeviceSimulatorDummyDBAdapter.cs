using System;
using DBConnection;

namespace Devices
{
	class GPSDeviceSimulatorDummyDBAdapter : IStorageAdapter
	{
		public GPSDeviceSimulatorDummyDBAdapter()
		{
		}

		public IQuery PrepareQuery(object data)
		{
			var Data = data as GPSDeviceSimulatorData;
			if (Data == null)
				throw new Exception("Data passed was not of the required type");

			var query = new DummyQuery("GPSTable", new string[] {"long", "lat"}, 
			new string[] {Data.GetPositionLong ().ToString (), Data.GetPositionLat ().ToString ()});

			return query;
		}
	}
}

