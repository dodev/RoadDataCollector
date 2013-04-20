using System;
using DBConnection;

namespace Devices
{
    class GPSDeviceSimulatorLocalDBAdapter : IStorageAdapter
    {
        public GPSDeviceSimulatorLocalDBAdapter()
        {
        }

        public IQuery PrepareQuery(object data)
        {
            var Data = data as GPSDeviceSimulatorData;
            if (Data == null)
                throw new Exception("Data passed was not of the required type");

            var query = new localDBQuery("GPSTable", (new Random()).Next(1000), 
                (string.Concat("N", ((Data.GetPositionLat()).ToString()), " E", ((Data.GetPositionLong()).ToString()))), 
                DateTime.Now);
            
            return query;
        }
    }
}
