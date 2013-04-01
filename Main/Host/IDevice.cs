using System;

using DBConnection;

namespace Host
{
    interface IDevice
    {
		IStorageAdapter Adapter {get;}
        void Init();
        string GetName();
        object GetData();
    }
}
