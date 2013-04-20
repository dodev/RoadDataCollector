using System;

namespace Devices
{
	public class GPRSimulatorDevice : IDevice
	{
		string name;
		const int depth = 256;
		short[] previous;

		public GPRSimulatorDevice ()
		{
			previous = new short[depth];


			for (int i = 0; i < depth; i++) {
				index [i] = Random(Random.Next (-128, 127));
			}
		}

		#region IDevice implementation

		public void Init (string name, IStorageAdapter adapter)
		{
			this.name = name;
		}

		public void Init(string name)
		{
			Init(name, null);
		}

		public object GetData ()
		{
			// Вот здесь можно кодит :)
			throw new NotImplementedException();
			short [] current = new short[depth];
			/*
			Random randoms = new Random ();

			for (int i = 0; i < 511; i++) {
				index [i] = Random.Next (-127, 128);
			}
			*/



			return (object)index;
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
}

