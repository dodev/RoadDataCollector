using System;

namespace Devices
{
    class GPSDeviceSimulatorData
    {
        double positionLat, positionLong;

        public GPSDeviceSimulatorData(double positionLat, double positionLong)
        {
            this.positionLat = positionLat;
            this.positionLong = positionLong;
        }

        public double GetPositionLat() { return positionLat; }
        public double GetPositionLong() { return positionLong; }
    }
}
