using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Host
{
    interface IDevice
    {
        void Init();
        string GetName();
        object GetData();
    }
}
