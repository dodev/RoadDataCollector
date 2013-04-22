using System;

namespace Devices
{
	/*
	public class GPRSimulatorDevice : IDevice
	{
		string name;
		// const int depth;
		const int width = 256;
		const int height = 256;
		double[] values;
		// short[] previous;

		public GPRSimulatorDevice ()
		{
			values = new double[width * height];

			for (int i = 0; i < height; i++) {
				for (int j = 0; j < height; j++) {
					setSample(i, j, GetRandomNumber (-1, 1));
				}
			}
			/*
			previous = new short[depth];


			for (int i = 0; i < depth; i++) {
				index [i] = Random(Random.Next (-128, 127));
			}
			*/
		}

		#region IDevice implementation

		public double sample (int x, int y)
		{
			return values [(x & (width - 1)) + (y & (height - 1)) * width];
		}

		public double setSample (int x, int y, double value)
		{
			values [(x & (width - 1)) + (y & (height - 1)) * width] = value;
		}

		public void sampleSquare(int x, int y, int size, double value)
		{
			int hs = size / 2;
			
			double a = sample(x - hs, y - hs);
			double b = sample(x + hs, y - hs);
			double c = sample(x - hs, y + hs);
			double d = sample(x + hs, y + hs);
			
			setSample(x, y, ((a + b + c + d) / 4.0) + value);
			
		}

		public void sampleDiamond(int x, int y, int size, double value)
		{
			int hs = size / 2;

			double a = sample(x - hs, y);
			double b = sample(x + hs, y);
			double c = sample(x, y - hs);
			double d = sample(x, y + hs);
			
			setSample(x, y, ((a + b + c + d) / 4.0) + value);
		}

		void DiamondSquare(int stepsize, double scale)
		{
			int halfstep = stepsize / 2;
			
			for (int y = halfstep; y < h + halfstep; y += stepsize)
			{
				for (int x = halfstep; x < w + halfstep; x += stepsize)
				{
					sampleSquare(x, y, stepsize, frand() * scale);
				}
			}
			
			for (int y = 0; y < h; y += stepsize)
			{
				for (int x = 0; x < w; x += stepsize)
				{
					sampleDiamond(x + halfstep, y, stepsize, frand() * scale);
					sampleDiamond(x, y + halfstep, stepsize, frand() * scale);
				}
			}
			
		}

		public void Init (string name, IStorageAdapter adapter)
		{
			this.name = name;
		}


		public void Init(string name)
		{
			Init(name, null);
		}

		public double GetRandomNumber(double minimum, double maximum)
		{ 
			Random random = new Random();
			return random.NextDouble() * (maximum - minimum) + minimum;
		}

		public object GetData ()
		{

			// Вот здесь можно кодит :)
			throw new NotImplementedException();

			int samplesize = 10;
			double scale = 1.0;
			
			while (samplesize > 1)
			{
				DiamondSquare(samplesize, scale);
				
				samplesize /= 2;
				scale /= 2.0;
			}

			
				/* 
			short [][] current = new short[depth];

			for (int i = 0; i < depth; i++) {
			for (int j = 0; j < depth; j++) {
				current [j][i] = previous [i] + Random.Next (-2, 2);
			}
		}
		*/



			return (object)values;
		}

		public string ID {
			get {
				return name;
			}
		}

		public IStorageAdapter Adapter {
			get {
				throw new NotImplementedException ();
			}
		}

		#endregion
	}
	*/
}

