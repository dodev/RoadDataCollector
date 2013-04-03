using System;

using DBConnection;

namespace Devices
{
    public interface IDevice
    {
		string ID { get; }
        void Init (string name, IStorageAdapter adapter);
        object GetData ();
		IStorageAdapter Adapter {get;}
    }
}
