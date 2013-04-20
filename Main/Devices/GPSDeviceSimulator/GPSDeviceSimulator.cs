using System;

namespace Devices
{
    class GPSDeviceSimulator: IDevice
    {
        string name;
        Random rand;

        //текущее время и разница во времени между вызовами GetData 
        DateTime time;
        TimeSpan span;

        //широта и долгота в градусах
        double positionLat, positionLong;

        public GPSDeviceSimulator()
        {
            rand = new Random();
            time = DateTime.Now;

            //случайное положение в пределах москвы
            positionLat =  55.5 + ((rand.Next(50))/100);   //N 55.55 - 55.9
            positionLong = 37.3 + ((rand.Next(60))/100);  //E 37.35 - 37.85
        }

        public string ID
        {
            get { return name; }
        }

        public void Init(string name)
        {
            this.name = name;
        }

        public object GetData()
        {
            span = time - DateTime.Now;
            time = DateTime.Now;
            double speed = 0.009*(rand.NextDouble()); //скорость в градусах/минуту
            
            //случайное направление движения
            double directionLat, directionLong;
            directionLat =  ((rand.Next(2)) - 1) * (((rand.NextDouble()) / 2) + 0.5);
            directionLong = ((rand.Next(2)) - 1) * (((rand.NextDouble()) / 2) + 0.5);

            //вычисление новых gps координат
            positionLat =  positionLat + (directionLat * (speed * (span.TotalMinutes)));
            positionLong = positionLong + (directionLong * (speed * (span.TotalMinutes)));

            positionLat = (Math.Round(positionLat, 6));
            positionLong = (Math.Round(positionLong, 6));

            return new GPSDeviceSimulatorData(positionLat, positionLong);
        }
        
    }
}
