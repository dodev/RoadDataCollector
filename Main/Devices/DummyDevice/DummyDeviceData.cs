using System;

namespace Devices
{
	/// <summary>
	/// Содержит информацию из устройства и методы для ее извлечения.
	/// </summary>
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

