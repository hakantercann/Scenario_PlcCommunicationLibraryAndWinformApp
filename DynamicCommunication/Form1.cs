using DynamicCommunication.Classes;
using DynamicCommunication.Pages;
using ModbusTcpDll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicCommunication
{
    public partial class Form1 : Form
    {
        private System.Collections.Specialized.StringCollection _devices;
        private List<PlcModel> _PlcModels;
        private string _fromPlc;
        private string _toPlc;

        #region Form Controls
        private static readonly Form1 _instance = new Form1();
        public static Form1 Instance
        {
            get
            {
                return _instance;
            }
        }
        private Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            _PlcModels = new List<PlcModel>();
            _devices = Properties.Settings.Default.plcs;
            PlcModel plcModel;
            var locx_ForTableLayoutPanel = 0;
            foreach (var item in _devices)
            {
                var features = item.Split(';');
                plcModel = new PlcModel()
                {
                    Id = Convert.ToInt32(features[0]),
                    PlcName = features[1],
                    ConnectionType = (PlcConnectionType)Enum.Parse(typeof(PlcConnectionType), features[4].ToString()),
                    IpAddress = features[2],
                    Port = Convert.ToInt32(features[3]),
                    plcFlahsor = false,
                    TablePanel = new TableLayoutPanel(),
                    TextBoxes = new List<TextBox>(),
                    HoldingRegisters = new List<string>()
                };
                plcModel.MainThread = new Thread(plcModel.MainLoop)
                {
                    Name = plcModel.PlcName + "MainThread",
                    Priority = ThreadPriority.Highest,
                };
                plcModel.PlcThread = new Thread(plcModel.PlcLoop)
                {
                    Name = plcModel.PlcName + "PlcThread",
                    Priority = ThreadPriority.Normal,
                };
                plcModel.CreateTableLayoutPanel(control_panel, locx_ForTableLayoutPanel, 0);
                locx_ForTableLayoutPanel += 200;
                
                CreatePlcConnectionPanel(plcModel);
                _PlcModels.Add(plcModel);
            };


        }


        private void Form1_Shown(object sender, EventArgs e)
        {
            foreach(var item in _PlcModels)
            {
                item.PlcThread.Start();
            }
        }
        #endregion

        #region Transfer Data Operate Between Plcs
        private void radioButton1_Click(object sender, EventArgs e)
        {
            var rb = (RadioButton)sender;
            if (rb.Checked)
            {
                _fromPlc = rb.Text.ToLower();
                groupBox1.Text = rb.Text;
            }
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            var rb = (RadioButton)sender;
            if (rb.Checked)
            {
                _toPlc = rb.Text.ToLower();
                groupBox2.Text = rb.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var fromCLient = _PlcModels.Find(x => x.PlcName.Equals(_fromPlc));
            var toCLient = _PlcModels.Find(x => x.PlcName.Equals(_toPlc));
            
            switch(toCLient.ConnectionType)
            {
                case PlcConnectionType.S7:
                    var packet = new string[3];
                    packet[1] = "13";
                    packet[2] = "0";
                    toCLient.Client.WriteMultipleItems(packet, fromCLient.HoldingRegisters.ToArray());
                    break;
                case PlcConnectionType.modbus:
                    packet = new string[2];
                    packet[0] = "FC10";
                    packet[1] = "0";
                    

                    toCLient.Client.WriteMultipleItems(packet, fromCLient.HoldingRegisters.ToArray());
                    break;
            }
        }
        #endregion



        #region Menu Events Function
        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in _PlcModels)
            {
                switch (item.ConnectionType)
                {
                    case PlcConnectionType.modbus:
                        item.Client = new ModbusTcpClient(item.IpAddress, item.Port);
                        item.Client.Connect();
                        if(!item.MainThread.IsAlive)
                        {
                            item.MainThread.Start();
                        }
                        break;
                    case PlcConnectionType.S7:
                        item.Client = new S7Driver(item.IpAddress);
                        item.Client.Connect();
                        if (!item.MainThread.IsAlive)
                        {
                            item.MainThread.Start();
                        }
                        break;
                }
            }
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(var item in _PlcModels)
            {
                try
                {
                    if (item.Client != null)
                    {
                        item.Client.Disconnect();
                        Thread.Sleep(200);
                        item.Client = null;
                    }
                    if (item.MainThread.IsAlive)
                    {
                        item.MainThread.Abort();
                        item.MainThread = null;
                        item.MainThread = new Thread(item.MainLoop);
                        item.MainThread.Priority = ThreadPriority.Highest;
                    }
                    if (item.PlcThread.IsAlive)
                    {
                        item.PlcThread.Abort();
                        item.PlcThread = null;
                        item.PlcThread = new Thread(item.PlcLoop);
                        item.PlcThread.Priority = ThreadPriority.Normal;
                        item.PlcThread.Start();
                    }
                    else
                    {
                        item.PlcThread = null;
                        item.PlcThread = new Thread(item.PlcLoop);
                        item.PlcThread.Priority = ThreadPriority.Normal;
                        item.PlcThread.Start();
                    }
                }
                catch { }
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        private void setActiveDeactiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetActiveDeactiveForm frm = new SetActiveDeactiveForm();
            frm.ShowDialog();
        }
        private void RefreshMechanism()
        {

            _devices = Properties.Settings.Default.plcs;
            
            foreach(var item in _PlcModels)
            {
                if (item.Client != null)
                {
                    item.Client.Disconnect();
                    Thread.Sleep(200);
                    item.Client = null;
                }
                if(item.MainThread.IsAlive)
                {
                    item.MainThread.Abort();
                }
                if(item.PlcThread.IsAlive)
                {
                    item.PlcThread.Abort();
                }
            }
            _PlcModels.Clear();
            control_panel.Controls.Clear();
            statesPanel.Controls.Clear();
            var locx = 0;
            foreach (var item in _devices)
            {
                var features = item.Split(';');
                PlcModel plcModel = new PlcModel()
                {
                    Id = Convert.ToInt32(features[0]),
                    PlcName = features[1],
                    ConnectionType = (PlcConnectionType)Enum.Parse(typeof(PlcConnectionType), features[4].ToString()),
                    IpAddress = features[2],
                    Port = Convert.ToInt32(features[3]),
                    plcFlahsor = false,
                    TablePanel = new TableLayoutPanel(),
                    TextBoxes = new List<TextBox>(),
                    HoldingRegisters = new List<string>()
                };
                plcModel.MainThread = new Thread(plcModel.MainLoop)
                {
                    Name = plcModel.PlcName + "MainThread",
                    Priority = ThreadPriority.Highest,
                };
                plcModel.PlcThread = new Thread(plcModel.PlcLoop)
                {
                    Name = plcModel.PlcName + "PlcThread",
                    Priority = ThreadPriority.Normal,
                };
                plcModel.CreateTableLayoutPanel(control_panel, locx, 0);
                
                CreatePlcConnectionPanel(plcModel);
                locx += 200;
                plcModel.PlcThread.Start();
                _PlcModels.Add(plcModel);
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void refreshToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            RefreshMechanism();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in _PlcModels)
            {
                try
                {
                    if (item.MainThread.IsAlive)
                    {
                        item.MainThread.Abort();
                    }
                    if (item.PlcThread.IsAlive)
                    {
                        item.PlcThread.Abort();
                    }
                    if (item.Client != null)
                    {
                        if (item.Client.CheckConnection())
                        {
                            item.Client.Disconnect();
                            Thread.Sleep(200);
                        }
                        item.Client = null;
                    }
                    
                }
                catch { }
            }

            _PlcModels.Clear();
            this.Close();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Application.Exit();
        }
        #endregion

        #region Connection States GUI
        public void CreatePlcConnectionPanel(PlcModel plcModel)
        {
            var tablePanel = new TableLayoutPanel()
            {
                ColumnCount = 2,
                RowCount = 4,
                AutoScroll = true,
            };
            tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            var newPanel = new Panel();
            newPanel.BackColor = Color.Red;
            newPanel.Dock = DockStyle.Fill;
            plcModel.StateLabel = newPanel;
            tablePanel.Controls.Add(newPanel, 0, 0);
            tablePanel.Controls.Add(new Label() { Text = "Ip"}, 0, 1);
            tablePanel.Controls.Add(new Label() { Text = "Port" }, 0, 2);
            tablePanel.Controls.Add(new Label() { Text = "Conn" }, 0, 3);
            var plcName = new Label();
            plcName.Text = plcModel.PlcName;
            plcName.AutoSize = true;
            plcName.Dock = DockStyle.Fill;
            plcName.TextAlign = ContentAlignment.MiddleLeft;
            tablePanel.Controls.Add(plcName, 1, 0);
            tablePanel.Controls.Add(new Label() { Text = plcModel.IpAddress }, 1, 1);
            tablePanel.Controls.Add(new Label() { Text = plcModel.Port.ToString() }, 1, 2);
            tablePanel.Controls.Add(new Label() { Text = Enum.GetName(typeof(PlcConnectionType), plcModel.ConnectionType) }, 1, 3);
            tablePanel.Dock = System.Windows.Forms.DockStyle.Top;
            tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            tablePanel.Size = new System.Drawing.Size(225, 200);
            statesPanel.Controls.Add(tablePanel);
        }


        #endregion


    }
}
