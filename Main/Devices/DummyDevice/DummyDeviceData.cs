using System;

namespace Devices
{
	public class DummyDeviceData
	{
		int x;
		int y;
		int z;
		public DummyDeviceData (int x, int y, int z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		public int GetX () {return x;}
		public int GetY () {return y;}
		public int GetZ () {return z;}
	}
}

