using ModbusTcpDll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scenario1_PcToTwoPlcViaModbus.Classes
{
    public class PlcModel
    {
        public int Id { get; set; }
        public string PlcName { get; set; }
        public IConnectivity Client { get; set; }
        public Thread MainThread { get; set; }

        public PlcConnectionType ConnectionType { get; set; }
        public Thread PlcLoop { get; set; }

        public bool plcFlahsor { get; set; }

        public TableLayoutPanel TablePanel { get; set; }

        public List<TextBox> TextBoxes { get; set; }

        public List<string> HoldingRegisters { get; set; }


    }
}
