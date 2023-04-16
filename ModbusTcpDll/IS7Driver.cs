using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusTcpDll
{
    public interface IS7Driver
    {
        Plc Plc { get; set; }
        void ReadStruct();

        void WriteStruct();

        void ReadClass();

        void WriteClass();
    }
}
