using System;

using DBConnection;

namespace Host
{
    interface IDevice
    {
		IStorageAdapter Adapter {get;}
        void Init (string name, IStorageAdapter adapter);
        string GetName ();
        object GetData ();
    }
}
