using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using AForge.Video;
using AForge.Video.DirectShow;


namespace Devices
{
    public class PhotoDevice : IDevice
    {
        string name;
        private FilterInfoCollection VideoCaptureDevices;
        private VideoCaptureDevice FinalVideo;
        public Bitmap gLatestFrame;

        public PhotoDevice()
        {
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
            VideoCaptureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            FinalVideo = new VideoCaptureDevice(VideoCaptureDevices[0].MonikerString); // [0] - использует первую найденную камеру
            FinalVideo.NewFrame += new NewFrameEventHandler(FinalVideo_NewFrame);
            FinalVideo.Start();
            while (FinalVideo.FramesReceived == 0) { }; // ждём, пока появится первый кадр

            if (FinalVideo.IsRunning)
            {
                FinalVideo.Stop();
            }

            return gLatestFrame;
        }

        void FinalVideo_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            gLatestFrame = (Bitmap)eventArgs.Frame.Clone();
        }



    }
}
