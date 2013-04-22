using System;
using DBConnection;

namespace Devices
{
    class GPSDeviceSimulatorRemoteDBAdapter : IStorageAdapter
    {
        public GPSDeviceSimulatorRemoteDBAdapter()
        {
        }

        public IQuery PrepareQuery(object data)
        {
            var Data = data as GPSDeviceSimulatorData;
            if (Data == null)
                throw new Exception("Data passed was not of the required type");

			// TODO: create query for remote db
            var query = new SecondDBQuery(new string[] {string.Concat("N", ((Data.GetPositionLat()).ToString())), string.Concat("E", ((Data.GetPositionLong()).ToString())) });

            return query;
        }
    }
}