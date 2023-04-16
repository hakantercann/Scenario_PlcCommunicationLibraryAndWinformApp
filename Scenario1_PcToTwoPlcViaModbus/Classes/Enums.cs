using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenario1_PcToTwoPlcViaModbus.Classes
{
    public enum SqlConnectionType
    {
        none = 0,
        local = 1,
        remote = 2,
    }
    public enum PlcConnectionType
    {
        none = 0,
        modbus = 1,
        S7 = 2,
        Sharp7 = 3,
        TcpClient = 4,
        TcpServer = 5,
    }
}
