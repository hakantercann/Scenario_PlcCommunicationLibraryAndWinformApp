using ModbusTcpDll;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicCommunication.Classes
{
    public class PlcModel
    {
        public int Id { get; set; }
        public string PlcName { get; set; }
        public PlcConnectionType ConnectionType { get; set; }
        public IConnectivity Client { get; set; }

        public string IpAddress { get; set; }
        public int Port { get; set; }
        public Thread MainThread { get; set; }
        
        public Thread PlcThread { get; set; }

        public bool plcFlahsor { get; set; }
        
        public Panel StateLabel { get; set; }

        public TableLayoutPanel TablePanel { get; set; }

        public List<TextBox> TextBoxes { get; set; }

        public List<string> HoldingRegisters { get; set; }



        public void MainLoop()
        {
            switch(ConnectionType)
            {
                case PlcConnectionType.modbus:
                    while(true)
                    {
                        try
                        {
                            if (Client != null)
                            {
                                if (Client.CheckConnection())
                                {
                                    MainLoopModbusFunction();
                                }

                            }
                        }
                        catch { }
                        Thread.Sleep(100);
                    }
                case PlcConnectionType.S7 :
                    while(true)
                    {
                        try
                        {
                            if (Client != null)
                            {
                                if (Client.CheckConnection())
                                {
                                    MainLoopS7Function();
                                }
                                else
                                {

                                }
                            }
                        }
                        catch { }
                        Thread.Sleep(100);
                    }
            }
        }
        public void PlcLoop()
        {
            switch (ConnectionType)
            {
                case PlcConnectionType.modbus:
                    while (true)
                    {
                        this.plcFlahsor = !this.plcFlahsor;
                        try
                        {
                            if (Client != null)
                            {
                                if (Client.CheckConnection())
                                {
                                    PlcLoopModbusFunction();


                                    if (this.plcFlahsor)
                                    {
                                        this.StateLabel.BackColor = Color.Lime;
                                    }
                                    else
                                    {
                                        this.StateLabel.BackColor = Color.Green;
                                    }
                                }
                                else
                                {
                                    if (this.plcFlahsor)
                                    {
                                        this.StateLabel.BackColor = Color.Orange;
                                    }
                                    else
                                    {
                                        this.StateLabel.BackColor = Color.Red;
                                    }
                                }
                            }
                            else
                            {
                                if (this.plcFlahsor)
                                {
                                    this.StateLabel.BackColor = Color.Orange;
                                }
                                else
                                {
                                    this.StateLabel.BackColor = Color.Red;
                                }
                            }

                        }
                        catch { }
                        Thread.Sleep(200);
                    }
                case PlcConnectionType.S7:
                    while (true)
                    {
                        this.plcFlahsor = !this.plcFlahsor;

                        try
                        {

                            if (Client != null)
                            {
                                if (Client.CheckConnection())
                                {
                                    PlcLoopS7Function();

                                    if (this.plcFlahsor)
                                    {
                                        this.StateLabel.BackColor = Color.Lime;
                                    }
                                    else
                                    {
                                        this.StateLabel.BackColor = Color.Green;
                                    }
                                }
                                else
                                {
                                    if (this.plcFlahsor)
                                    {
                                        this.StateLabel.BackColor = Color.Orange;
                                    }
                                    else
                                    {
                                        this.StateLabel.BackColor = Color.Red;
                                    }

                                }
                            }
                            else
                            {
                                if (this.plcFlahsor)
                                {
                                    this.StateLabel.BackColor = Color.Orange;
                                }
                                else
                                {
                                    this.StateLabel.BackColor = Color.Red;
                                }
                            }
                        }
                        catch { }
                        Thread.Sleep(200);
                    }
            }
        }
        private void PlcLoopModbusFunction()
        {
            string[] packet = new string[3];
            try
            {
                packet[0] = "FC3";
                packet[1] = "0";
                packet[2] = "100";
                Client.ReadMultipleItems(packet);
            }
            catch { }
        }
        private void PlcLoopS7Function()
        {
            string[] packet = new string[4];
            try
            {
                packet[0] = "DB";
                packet[1] = "13";
                packet[2] = "0";
                packet[3] = "100";
                Client.ReadMultipleItems(packet);
            }
            catch { }
        }
        private void MainLoopS7Function()
        {
            try
            {
                if (this.Client != null)
                {
                    if (this.Client.CheckConnection())
                    {
                        var control = this.Client.GetRead();
                        if (control != null)
                        {
                            var packet = control.Skip(2).ToArray();
                            HoldingRegisters = new List<string>();
                            try
                            {
                                for (int j = 0; j < control.Length - 6; j++)
                                {
                                    var tempValue = packet.Skip(j * 2).Take(2).ToArray();
                                    int value = ConvertTools.ByteArrToSignedInt(tempValue);
                                    HoldingRegisters.Add(value.ToString());
                                }
                            }
                            catch { }
                            int i = 0;
                            foreach (var item in TextBoxes)
                            {
                                item.Text = HoldingRegisters[i];
                                i++;
                            }

                        }
                    }
                }
            }
            catch
            { }
        }
        private void MainLoopModbusFunction()
        {
            try
            {
                if (this.Client != null)
                {
                    if (this.Client.CheckConnection())
                    {
                        var control = this.Client.GetRead();
                        if (control != null)
                        {
                            var packetId = control.Skip(0).Take(2).ToArray();
                            var packet = control.Skip(2).ToArray();
                            switch (Encoding.ASCII.GetString(packetId))
                            {
                                ////case "RC":
                                ////    plc_coilRegisters = new List<string>();
                                ////    try
                                ////    {
                                ////        var bitArray1 = new BitArray(packet);
                                ////        foreach (var item in bitArray1)
                                ////        {
                                ////            plc_coilRegisters.Add(Convert.ToBoolean(item).ToString());
                                ////        }
                                ////    }
                                ////    catch
                                ////    { }
                                ////    int i = 0;
                                ////    foreach (var item in plc_coilRegisters_textbox)
                                ////    {
                                ////        item.Text = plc_coilRegisters[i];
                                ////        i++;
                                ////    }
                                ////    break;
                                ////case "RI":
                                ////    var bitArray2 = new BitArray(packet);
                                ////    foreach (var item in bitArray2)
                                ////    {

                                ////        Console.WriteLine(Convert.ToBoolean(item).ToString());
                                ////    }
                                ////    break;
                                ////case "RA":
                                ////    for (int j = 0; j < control.Length - 6; j++)
                                ////    {
                                ////        var tempValue = packet.Skip(j * 2).Take(2).ToArray();
                                ////        int value = ConvertTools.ByteArrToUnsignedInt(tempValue);
                                ////        Console.WriteLine(value.ToString());
                                ////    }
                                ////    break;
                                case "RH":
                                    this.HoldingRegisters = new List<string>();
                                    try
                                    {
                                        for (int j = 0; j < control.Length - 6; j++)
                                        {
                                            var tempValue = packet.Skip(j * 2).Take(2).ToArray();
                                            int value = ConvertTools.ByteArrToUnsignedInt(tempValue);
                                            this.HoldingRegisters.Add(value.ToString());
                                        }
                                    }
                                    catch { }
                                    var i = 0;

                                    foreach (var item in TextBoxes)
                                    {
                                        item.Text = HoldingRegisters[i];
                                        i++;
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
            catch { }
        }
        public void CreateTableLayoutPanel(Panel panel, int LocationX, int LocationY)
        {
            int height = 800;
            int width = 150;
            TablePanel.Location = new System.Drawing.Point(LocationX, 0);
            TablePanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            TablePanel.AutoScroll = true;
            TablePanel.Size = new Size(width, height);
            TablePanel.ColumnCount = 3;
            TablePanel.RowCount = 100;
            TablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            TablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            TablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            for (int i = 0; i < 100; i++)
            {
                TablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
                TablePanel.Controls.Add(new System.Windows.Forms.Label() { Text = (40000 + i).ToString() }, 0, i);
                TextBox textBox = new TextBox()
                {
                    Name = i + "textbox",
                    Text = ""
                };
                TextBoxes.Add(textBox);
                textBox.ReadOnly = true;
                TablePanel.Controls.Add(textBox, 1, i);
                Button btn = new Button()
                {
                    Name = i.ToString(),
                    Text = "Değiştir"
                };
                btn.Click += new EventHandler(click_event_table);
                TablePanel.Controls.Add(btn, 2, i);
                

            }
            panel.Controls.Add(TablePanel);

                //    model.Client.WriteOneItem(packet, rh_textBox.Text);
        }
        void click_event_table(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Console.WriteLine(button.Name.ToString());
            var startAddress = (Convert.ToInt16(button.Name) * 2).ToString();
            string[] packet;
            if (Form1.Instance != null)
            {
                if (Form1.Instance.rh_textBox.Text != null || !Form1.Instance.rh_textBox.Text.Equals(""))
                {
                    try
                    {
                        switch (ConnectionType)
                        {

                            case PlcConnectionType.S7:
                                packet = new string[2]
                                {
                        "13",
                        startAddress,
                                };

                                Client.WriteOneItem(packet, Convert.ToInt16(Form1.Instance.rh_textBox.Text));
                                break;
                            case PlcConnectionType.modbus:
                                packet = new string[2]
                                {
                        "FC6",
                        startAddress,
                                };
                                Client.WriteOneItem(packet, Form1.Instance.rh_textBox.Text);
                                break;
                        }
                    }
                    catch { }
                }
            }
        }

    }
}
