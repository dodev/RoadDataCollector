using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBConnection;

namespace Devices
{
    class DummyDeviceLocalDBAdapter : IStorageAdapter
    {
        public DummyDeviceLocalDBAdapter()
        {
        }

        #region IStorageAdapter
        public IQuery PrepareQuery(object data)
        {
            var dummyData = data as DummyDeviceData;
            if (dummyData == null)
                throw new Exception("Data passed was not of the required type");

            var query = new localDBQuery("GPSTable", (new Random()).Next(1000),
                localDBHelper.PointToString(dummyData.GetX(), dummyData.GetY(), dummyData.GetZ()),
                DateTime.Now);

            return query;
        }
        #endregion
    }
}
