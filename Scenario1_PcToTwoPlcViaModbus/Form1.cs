
using ModbusTcpDll;
using Scenario1_PcToTwoPlcViaModbus.Classes;
using Scenario1_PcToTwoPlcViaModbus.Pages;
using Scenario1_PcToTwoPlcViaModbus.UserControls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scenario1_PcToTwoPlcViaModbus
{
    public partial class Form1 : Form
    {
        #region control variables

        string[] plc1Text;
        string[] plc2Text;
        string[] plc3Text;
        string[] plc4Text;
        string[] plc5Text;
        IConnectivity plc1_client;
        IConnectivity plc2_client;
        IConnectivity plc3_client;
        IConnectivity plc4_client;
        IConnectivity plc5_client;
        Thread plc1_mainThread;
        Thread plc2_mainThread;
        Thread plc3_mainThread;
        Thread plc4_mainThread;
        Thread plc5_mainThread;

        Thread plc1Thread; //
        bool plc1Flashor = false;

        Thread plc2Thread; //
        bool plc2Flashor = false;

        Thread plc3Thread; //
        bool plc3Flashor = false;

        Thread plc4Thread; //
        bool plc4Flashor = false;

        Thread plc5Thread; //
        bool plc5Flashor = false;

        #endregion
        #region datas of plc
        TableLayoutPanel plc1_holdingRegisters_panel;
        List<TextBox> plc1_holdingRegisters_textbox; 
        TableLayoutPanel plc1_coilRegisters_panel;
        List<TextBox> plc1_coilRegisters_textbox;
        TableLayoutPanel plc2_holdingRegisters_panel;
        List<TextBox> plc2_holdingRegisters_textbox;
        TableLayoutPanel plc2_coilRegisters_panel;
        List<TextBox> plc2_coilRegisters_textbox;
        TableLayoutPanel plc3_holdingRegisters_panel;
        List<TextBox> plc3_holdingRegisters_textbox;
        TableLayoutPanel plc3_coilRegisters_panel;
        List<TextBox> plc3_coilRegisters_textbox;
        TableLayoutPanel plc4_holdingRegisters_panel;
        List<TextBox> plc4_holdingRegisters_textbox;
        TableLayoutPanel plc4_coilRegisters_panel;
        List<TextBox> plc4_coilRegisters_textbox;
        TableLayoutPanel plc5_holdingRegisters_panel;
        List<TextBox> plc5_holdingRegisters_textbox;
        TableLayoutPanel plc5_coilRegisters_panel;
        List<TextBox> plc5_coilRegisters_textbox;
        List<string> plc1_HoldingRegisters;
        List<string> plc2_HoldingRegisters;
        List<string> plc3_HoldingRegisters;
        List<string> plc4_HoldingRegisters;
        List<string> plc5_HoldingRegisters;
        List<string> plc1_coilRegisters;
        List<string> plc2_coilRegisters;
        List<string> plc3_coilRegisters;
        List<string> plc4_coilRegisters;
        List<string> plc5_coilRegisters;

        #endregion

        //maybe can optimize o dynamic structure 
        #region Form Event Controls
        public Form1()
        {
            InitializeComponent();
            createTableLayoutPlc1();
            createTableLayoutPlc2();
            createTableLayoutPlc3();
            createTableLayoutPlc4();
            createTableLayoutPlc5();
            CheckForIllegalCrossThreadCalls = false;
            plc1_mainThread = new Thread(plc1_mainLoop);
            plc1_mainThread.Priority = ThreadPriority.Highest;
            plc2_mainThread = new Thread(plc2_mainLoop);
            plc2_mainThread.Priority = ThreadPriority.Highest;
            plc3_mainThread = new Thread(plc3_mainLoop);
            plc3_mainThread.Priority = ThreadPriority.Highest;
            plc4_mainThread = new Thread(plc4_mainLoop);
            plc4_mainThread.Priority = ThreadPriority.Highest;
            plc5_mainThread = new Thread(plc5_mainLoop);
            plc5_mainThread.Priority = ThreadPriority.Highest;
            plc1Thread = new Thread(plc1Loop);
            plc1Thread.Priority = ThreadPriority.Normal;
            plc2Thread = new Thread(plc2Loop);
            plc2Thread.Priority = ThreadPriority.Normal;
            plc3Thread = new Thread(plc3Loop);
            plc3Thread.Priority = ThreadPriority.Normal;
            plc4Thread = new Thread(plc4Loop);
            plc4Thread.Priority = ThreadPriority.Normal;
            plc5Thread = new Thread(plc5Loop);
            plc5Thread.Priority = ThreadPriority.Normal;
        }



        private void Form1_Shown(object sender, EventArgs e)
        {
            plc1Text = Properties.Settings.Default.plc1.Split(';');
            if (Convert.ToBoolean(plc1Text[1]))
            {
                
                switch (Enum.Parse(typeof(PlcConnectionType), plc1Text[4]))
                {
                    case PlcConnectionType.modbus:
                        plc1_status.Text = "Modbus";
                        plc1Thread.Start();
                        break;
                    case PlcConnectionType.S7:
                        plc1_status.Text = "S7";
                        plc1Thread.Start();
                        break;
                    case PlcConnectionType.none:
                        plc1_status.Text = "none";
                        break;
                }
                

            }
            else
            {
                plc1_status.Text = "Aktif Değil";
            }
            plc2Text = Properties.Settings.Default.plc2.Split(';');
            if (Convert.ToBoolean(plc2Text[1]))
            {                
                switch (Enum.Parse(typeof(PlcConnectionType), plc2Text[4]))
                {
                    case PlcConnectionType.modbus:
                        plc2_status.Text = "Modbus";
                        plc2Thread.Start();
                        break;
                    case PlcConnectionType.S7:
                        plc2_status.Text = "S7";
                        
                        plc2Thread.Start();
                        break;
                    case PlcConnectionType.none:
                        plc2_status.Text = "none";
                        break;
                }
            }
            else
            {
                plc2_status.Text = "Aktif Değil";
            }
            plc3Text = Properties.Settings.Default.plc3.Split(';');
            if (Convert.ToBoolean(plc3Text[1]))
            {
                switch (Enum.Parse(typeof(PlcConnectionType), plc3Text[4]))
                {
                    case PlcConnectionType.modbus:
                        plc3_status.Text = "Modbus";
                        plc3Thread.Start();
                        break;
                    case PlcConnectionType.S7:
                        plc3_status.Text = "S7";

                        plc3Thread.Start();
                        break;
                    case PlcConnectionType.none:
                        plc3_status.Text = "none";
                        break;
                }
            }
            else
            {
                plc3_status.Text = "Aktif Değil";
            }
            plc4Text = Properties.Settings.Default.plc4.Split(';');
            if (Convert.ToBoolean(plc4Text[1]))
            {

                switch (Enum.Parse(typeof(PlcConnectionType), plc4Text[4]))
                {
                    case PlcConnectionType.modbus:
                        plc4_status.Text = "Modbus";
                        plc4Thread.Start();
                        break;
                    case PlcConnectionType.S7:
                        plc4_status.Text = "S7";
                        plc4Thread.Start();
                        break;
                    case PlcConnectionType.none:
                        plc4_status.Text = "none";
                        break;
                }


            }
            else
            {
                plc4_status.Text = "Aktif Değil";
            }
            plc5Text = Properties.Settings.Default.plc5.Split(';');
            if (Convert.ToBoolean(plc5Text[1]))
            {

                switch (Enum.Parse(typeof(PlcConnectionType), plc5Text[4]))
                {
                    case PlcConnectionType.modbus:
                        plc5_status.Text = "Modbus";
                        plc5Thread.Start();
                        break;
                    case PlcConnectionType.S7:
                        plc5_status.Text = "S7";
                        plc5Thread.Start();
                        break;
                    case PlcConnectionType.none:
                        plc5_status.Text = "none";
                        break;
                }


            }
            else
            {
                plc5_status.Text = "Aktif Değil";
            }
        }
        #endregion

        //will add a new structure for read more bytes than 200
        //maybe can optimize o dynamic structure 
        #region Threads
        private void plc5Loop()
        {
            switch (Enum.Parse(typeof(PlcConnectionType), plc5Text[4]))
            {
                case PlcConnectionType.modbus:
                    while (true)
                    {
                        plc5Flashor = !plc5Flashor;
                        if (plc5_client != null)
                        {
                            if (plc5_client.CheckConnection())
                            {
                                string[] packet = new string[3];
                                try
                                {
                                    packet[0] = "FC3";
                                    packet[1] = "0";
                                    packet[2] = "100";
                                    plc5_client.ReadMultipleItems(packet);
                                }
                                catch { }
                                if (plc5Flashor)
                                {
                                    plc5State.BackColor = Color.Lime;
                                }
                                else
                                {
                                    plc5State.BackColor = Color.Green;
                                }

                            }
                            else
                            {
                                //   transferToPlc2.Enabled = false;
                                //     plc1_client.connect("192.168.1.178", 502);
                                if (plc5Flashor)
                                {
                                    plc5State.BackColor = Color.Orange;
                                }
                                else
                                {
                                    plc5State.BackColor = Color.Red;
                                }
                            }
                        }
                        Thread.Sleep(200);
                    }
                case PlcConnectionType.S7:
                    while (true)
                    {
                        plc5Flashor = !plc5Flashor;

                        if (plc5_client != null)
                        {
                            if (plc5_client.CheckConnection())
                            {
                                string[] packet = new string[4];
                                packet[0] = "DB";
                                packet[1] = "13";
                                packet[2] = "0";
                                packet[3] = "200";
                                plc5_client.ReadMultipleItems(packet);
                                if (plc5Flashor)
                                {
                                    plc5State.BackColor = Color.Lime;
                                }
                                else
                                {
                                    plc5State.BackColor = Color.Green;
                                }
                            }
                            else
                            {
                                //            transferToPlc2.Enabled = false;
                                if (plc5Flashor)
                                {
                                    plc5State.BackColor = Color.Orange;
                                }
                                else
                                {
                                    plc5State.BackColor = Color.Red;
                                }
                            }
                        }
                        Thread.Sleep(200);
                    }
            }
        }

        private void plc4Loop()
        {
            switch (Enum.Parse(typeof(PlcConnectionType), plc4Text[4]))
            {
                case PlcConnectionType.modbus:
                    while (true)
                    {
                        plc4Flashor = !plc4Flashor;
                        if (plc4_client != null)
                        {
                            if (plc4_client.CheckConnection())
                            {
                                string[] packet = new string[3];
                                try
                                {
                                    packet[0] = "FC3";
                                    packet[1] = "0";
                                    packet[2] = "100";
                                    plc4_client.ReadMultipleItems(packet);
                                }
                                catch { }
                                if (plc4Flashor)
                                {
                                    plc4State.BackColor = Color.Lime;
                                }
                                else
                                {
                                    plc4State.BackColor = Color.Green;
                                }

                            }
                            else
                            {
                                if (plc4Flashor)
                                {
                                    plc4State.BackColor = Color.Orange;
                                }
                                else
                                {
                                    plc4State.BackColor = Color.Red;
                                }
                            }
                        }
                        Thread.Sleep(200);
                    }
                case PlcConnectionType.S7:
                    while (true)
                    {
                        plc4Flashor = !plc4Flashor;

                        if (plc4_client != null)
                        {
                            if (plc4_client.CheckConnection())
                            {
                                string[] packet = new string[4];
                                packet[0] = "DB";
                                packet[1] = "13";
                                packet[2] = "0";
                                packet[3] = "200";
                                plc4_client.ReadMultipleItems(packet);
                                if (plc4Flashor)
                                {
                                    plc4State.BackColor = Color.Lime;
                                }
                                else
                                {
                                    plc4State.BackColor = Color.Green;
                                }
                            }
                            else
                            {
                                //            transferToPlc2.Enabled = false;
                                if (plc4Flashor)
                                {
                                    plc4State.BackColor = Color.Orange;
                                }
                                else
                                {
                                    plc4State.BackColor = Color.Red;
                                }
                            }
                        }
                        Thread.Sleep(200);
                    }
            }
        }
        private void plc3Loop()
        {
            switch (Enum.Parse(typeof(PlcConnectionType), plc3Text[4]))
            {
                case PlcConnectionType.modbus:
                    while (true)
                    {
                        plc3Flashor = !plc3Flashor;
                        //if (plc1_client.getConnection())
                        if (plc3_client != null)
                        {
                            if (plc3_client.CheckConnection())
                            {
                                string[] packet = new string[3];
                                try
                                {
                                    packet[0] = "FC3";
                                    packet[1] = "0";
                                    packet[2] = "100";
                                    plc3_client.ReadMultipleItems(packet);
                                }
                                catch { }
                                if (plc3Flashor)
                                {
                                    plc3State.BackColor = Color.Lime;
                                }
                                else
                                {
                                    plc3State.BackColor = Color.Green;
                                }

                            }
                            else
                            {
                                //   transferToPlc2.Enabled = false;
                                //     plc1_client.connect("192.168.1.178", 502);
                                if (plc3Flashor)
                                {
                                    plc3State.BackColor = Color.Orange;
                                }
                                else
                                {
                                    plc3State.BackColor = Color.Red;
                                }
                            }
                        }
                        Thread.Sleep(200);
                    }
                case PlcConnectionType.S7:
                    while (true)
                    {
                        plc3Flashor = !plc3Flashor;

                        if (plc3_client != null)
                        {
                            if (plc3_client.CheckConnection())
                            {
                                string[] packet = new string[4];
                                packet[0] = "DB";
                                packet[1] = "13";
                                packet[2] = "0";
                                packet[3] = "200";
                                plc3_client.ReadMultipleItems(packet);
                                if (plc3Flashor)
                                {
                                    plc3State.BackColor = Color.Lime;
                                }
                                else
                                {
                                    plc3State.BackColor = Color.Green;
                                }
                            }
                            else
                            {
                                //            transferToPlc2.Enabled = false;
                                if (plc3Flashor)
                                {
                                    plc3State.BackColor = Color.Orange;
                                }
                                else
                                {
                                    plc3State.BackColor = Color.Red;
                                }
                            }
                        }
                        Thread.Sleep(200);
                    }
            }

        }

        private void plc2Loop()
        {
            switch (Enum.Parse(typeof(PlcConnectionType), plc2Text[4]))
            {
                case PlcConnectionType.modbus:
                    while (true)
                    {
                        plc2Flashor = !plc2Flashor;

                        if (plc2_client != null)
                        {
                            if (plc2_client.CheckConnection())
                            {
                                string[] packet = new string[3];
                                packet[0] = "FC3";
                                packet[1] = "0";
                                packet[2] = "100";
                                try
                                {
                                    plc2_client.ReadMultipleItems(packet);
                                }
                                catch { }
                                if (plc2Flashor)
                                {

                                    plc2State.BackColor = Color.Lime;
                                }
                                else
                                {
                                    plc2State.BackColor = Color.Green;
                                }
                            }
                            else
                            {
                                //            transferToPlc2.Enabled = false;
                                if (plc2Flashor)
                                {
                                    plc2State.BackColor = Color.Orange;
                                }
                                else
                                {
                                    plc2State.BackColor = Color.Red;
                                }
                            }
                        }
                        Thread.Sleep(200);
                    }
                case PlcConnectionType.S7:
                    while (true)
                    {
                        plc2Flashor = !plc2Flashor;

                        if (plc2_client != null)
                        {
                            if (plc2_client.CheckConnection())
                            {
                                string[] packet = new string[4];
                                packet[0] = "DB";
                                packet[1] = "13";
                                packet[2] = "0";
                                packet[3] = "200";
                                plc2_client.ReadMultipleItems(packet);
                                if (plc2Flashor)
                                {
                                    plc2State.BackColor = Color.Lime;
                                }
                                else
                                {
                                    plc2State.BackColor = Color.Green;
                                }
                            }
                            else
                            {
                                //            transferToPlc2.Enabled = false;
                                if (plc2Flashor)
                                {
                                    plc2State.BackColor = Color.Orange;
                                }
                                else
                                {
                                    plc2State.BackColor = Color.Red;
                                }
                            }
                        }
                        Thread.Sleep(200);
                    }
            }
            
        }
        private void plc1Loop()
        {
            switch(Enum.Parse(typeof(PlcConnectionType), plc1Text[4]))
            {
                case PlcConnectionType.modbus:
                    while (true)
                    {
                        plc1Flashor = !plc1Flashor;
                        //if (plc1_client.getConnection())
                        if (plc1_client != null)
                        {
                            if (plc1_client.CheckConnection())
                            {
                                string[] packet = new string[3];

                                try
                                {
                                    packet[0] = "FC3";
                                    packet[1] = "0";
                                    packet[2] = "100";
                                    plc1_client.ReadMultipleItems(packet);
                                }
                                catch { }
                                if (plc1Flashor)
                                {
                                    plc1State.BackColor = Color.Lime;
                                }
                                else
                                { 
                                    plc1State.BackColor = Color.Green;
                                }

                            }
                            else
                            {
                                //   transferToPlc2.Enabled = false;
                                //     plc1_client.connect("192.168.1.178", 502);
                                if (plc1Flashor)
                                {
                                    plc1State.BackColor = Color.Orange;
                                }
                                else
                                {
                                    plc1State.BackColor = Color.Red;
                                }
                            }
                        }
                        Thread.Sleep(200);
                    }
                case PlcConnectionType.S7:
                    while (true)
                    {
                        plc1Flashor = !plc1Flashor;

                        if (plc1_client != null)
                        {
                            if (plc1_client.CheckConnection())
                            {
                                string[] packet = new string[4];
                                packet[0] = "DB";
                                packet[1] = "13";
                                packet[2] = "0";
                                packet[3] = "200";
                                plc1_client.ReadMultipleItems(packet);
                                if (plc1Flashor)
                                {
                                    plc1State.BackColor = Color.Lime;
                                }
                                else
                                {
                                    plc1State.BackColor = Color.Green;
                                }
                            }
                            else
                            {
                                //            transferToPlc2.Enabled = false;
                                if (plc1Flashor)
                                {
                                    plc1State.BackColor = Color.Orange;
                                }
                                else
                                {
                                    plc1State.BackColor = Color.Red;
                                }
                            }
                        }
                        Thread.Sleep(200);
                    }
            }
           
        }
        private void plc5_mainLoop()
        {
            switch (Enum.Parse(typeof(PlcConnectionType), plc5Text[4]))
            {
                case PlcConnectionType.S7:
                    while (true)
                    {
                        try
                        {
                            PlcLoopS7Function(plc5_client, plc5_HoldingRegisters, plc5_holdingRegisters_textbox);
                        }
                        catch
                        { }
                        Thread.Sleep(100);
                    }
                case PlcConnectionType.modbus:
                    while (true)
                    {
                        #region main thread plc5 controls
                        try
                        {
                            PlcLoopModbusFunction(plc5_client, plc5_HoldingRegisters, plc5_holdingRegisters_textbox, null, null);
                        }
                        catch { }
                        Thread.Sleep(100);
                        #endregion
                    }
            }
        }

        private void plc4_mainLoop()
        {
            switch (Enum.Parse(typeof(PlcConnectionType), plc4Text[4]))
            {
                case PlcConnectionType.S7:
                    while (true)
                    {
                        try
                        {
                            PlcLoopS7Function(plc4_client, plc4_HoldingRegisters, plc4_holdingRegisters_textbox);
                        }
                        catch
                        { }
                        Thread.Sleep(100);
                    }
                case PlcConnectionType.modbus:
                    while (true)
                    {
                        #region main thread plc4 controls
                        try
                        {
                            PlcLoopModbusFunction(plc4_client, plc4_HoldingRegisters, plc4_holdingRegisters_textbox, null, null);
                        }
                        catch { }
                        Thread.Sleep(100);
                        #endregion
                    }
            }
        }

        private void plc3_mainLoop()
        {

            switch (Enum.Parse(typeof(PlcConnectionType), plc3Text[4]))
            {
                case PlcConnectionType.S7:
                    while (true)
                    {
                        try
                        {
                            PlcLoopS7Function(plc3_client, plc3_HoldingRegisters, plc3_holdingRegisters_textbox);
                        }
                        catch
                        { }
                        Thread.Sleep(100);
                    }
                case PlcConnectionType.modbus:
                    while (true)
                    {
                        #region main thread plc3 controls
                        try
                        {
                            PlcLoopModbusFunction(plc3_client, plc3_HoldingRegisters, plc3_holdingRegisters_textbox, null, null);
                        }
                        catch { } 
                        Thread.Sleep(100);
                        #endregion
                    }
            }
        }
        private void plc2_mainLoop()
        {
            switch (Enum.Parse(typeof(PlcConnectionType), plc2Text[4]))
            {
                case PlcConnectionType.S7:
                    while (true)
                    {
                        #region main thread plc2 controls
                        try
                        {
                            PlcLoopS7Function(plc2_client, plc2_HoldingRegisters, plc2_holdingRegisters_textbox);
                        }
                        catch
                        { }
                        Thread.Sleep(100);
                        #endregion
                    }
                case PlcConnectionType.modbus:
                    while (true)
                    {
                        #region main thread plc2 controls
                        PlcLoopModbusFunction(plc2_client, plc2_HoldingRegisters, plc2_holdingRegisters_textbox, plc2_coilRegisters, plc2_coilRegisters_textbox);
                        #endregion
                        Thread.Sleep(100);
                    }
            }
        }
        private void plc1_mainLoop()
        {
            switch(Enum.Parse(typeof(PlcConnectionType), plc1Text[4]))
            {
                case PlcConnectionType.S7:
                    while (true)
                    {
                        #region main thread plc1 controls
                        try
                        {
                            PlcLoopS7Function(plc2_client, plc2_HoldingRegisters, plc2_holdingRegisters_textbox);
                        }
                        catch
                        { }
                        Thread.Sleep(100);
                        #endregion
                    }
                case PlcConnectionType.modbus:
                    while (true)
                    {
                        #region main thread plc1 controls
                        try
                        {
                            PlcLoopModbusFunction(plc1_client, plc1_HoldingRegisters, plc1_holdingRegisters_textbox, plc1_coilRegisters, plc1_coilRegisters_textbox);
                        }
                        catch
                        { }
                        Thread.Sleep(100);
                        #endregion
                    }
            }
           
        }
        #endregion

        //maybe can optimize o dynamic structure 
       #region menu button function events
        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(plc1Text[1]))
            {
                switch(Enum.Parse(typeof(PlcConnectionType), plc1Text[4]))
                {
                    case PlcConnectionType.modbus:
                        plc1_client = null;
                        plc1_client = new ModbusTcpClient(plc1Text[2], Convert.ToInt32(plc1Text[3]));

                        plc1_client.Connect();
                        if (!plc1_mainThread.IsAlive)
                        {
                            plc1_mainThread.Start();
                        }
                        break;
                    case PlcConnectionType.S7:
                        plc1_client = new S7Driver(plc1Text[2]);
                        plc1_client.Connect();
                        if (!plc1_mainThread.IsAlive)
                        {
                            plc1_mainThread.Start();
                        }
                        break;
                }

            }
            if (Convert.ToBoolean(plc2Text[1]))
            {
                switch (Enum.Parse(typeof(PlcConnectionType), plc2Text[4]))
                {
                    case PlcConnectionType.modbus:
                        plc2_client = null;
                        plc2_client = new ModbusTcpClient(plc2Text[2], Convert.ToInt32(plc2Text[3]));

                        plc2_client.Connect();
                        if (!plc2_mainThread.IsAlive)
                        {
                            plc2_mainThread.Start();
                        }
                        break;
                    case PlcConnectionType.S7:
                        plc2_client = new S7Driver(plc2Text[2]);
                        plc2_client.Connect();
                        if (!plc2_mainThread.IsAlive)
                        {
                            plc2_mainThread.Start();
                        }
                        break;
                }


            }
            if (Convert.ToBoolean(plc3Text[1]))
            {
                switch (Enum.Parse(typeof(PlcConnectionType), plc3Text[4]))
                {
                    case PlcConnectionType.modbus:
                        plc3_client = null;
                        plc3_client = new ModbusTcpClient(plc3Text[2], Convert.ToInt32(plc3Text[3]));

                        plc3_client.Connect();
                        if (!plc3_mainThread.IsAlive)
                        {
                            plc3_mainThread.Start();
                        }
                        break;
                    case PlcConnectionType.S7:
                        plc3_client = new S7Driver(plc3Text[2]);
                        plc3_client.Connect();
                        if (!plc3_mainThread.IsAlive)
                        {
                            plc3_mainThread.Start();
                        }
                        break;
                }
            }
            if (Convert.ToBoolean(plc4Text[1]))
            {
                switch (Enum.Parse(typeof(PlcConnectionType), plc4Text[4]))
                {
                    case PlcConnectionType.modbus:
                        plc4_client = null;
                        plc4_client = new ModbusTcpClient(plc4Text[2], Convert.ToInt32(plc4Text[3]));

                        plc4_client.Connect();
                        if (!plc4_mainThread.IsAlive)
                        {
                            plc4_mainThread.Start();
                        }
                        break;
                    case PlcConnectionType.S7:
                        plc4_client = new S7Driver(plc4Text[2]);
                        plc4_client.Connect();
                        if (!plc4_mainThread.IsAlive)
                        {
                            plc4_mainThread.Start();
                        }
                        break;
                }
            }
            if (Convert.ToBoolean(plc5Text[1]))
            {
                switch (Enum.Parse(typeof(PlcConnectionType), plc5Text[4]))
                {
                    case PlcConnectionType.modbus:
                        plc5_client = null;
                        plc5_client = new ModbusTcpClient(plc5Text[2], Convert.ToInt32(plc5Text[3]));

                        plc5_client.Connect();
                        if (!plc5_mainThread.IsAlive)
                        {
                            plc5_mainThread.Start();
                        }
                        break;
                    case PlcConnectionType.S7:
                        plc5_client = new S7Driver(plc3Text[2]);
                        plc5_client.Connect();
                        if (!plc5_mainThread.IsAlive)
                        {
                            plc5_mainThread.Start();
                        }
                        break;
                }
            }

        }
        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(plc1_client != null)
            {
                plc1_client.Disconnect();
                plc1_client = null;
            }
            if(plc2_client !=null)
            {
                plc2_client.Disconnect();
                plc2_client = null;
            }
            if (plc3_client != null)
            {
                plc3_client.Disconnect();
                plc3_client = null;
            }
            if (plc4_client != null)
            {
                plc4_client.Disconnect();
                plc4_client = null;
            }
            if (plc5_client != null)
            {
                plc5_client.Disconnect();
                plc5_client = null;
            }
            stopMechanism();
        }
        private void setActiveDeactiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsCommunication page = new SettingsCommunication();
            page.ShowDialog();
        }
        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            plc1_mainThread.Abort();
            plc2_mainThread.Abort();
            plc3_mainThread.Abort();
            plc4_mainThread.Abort();
            plc5_mainThread.Abort();
            if (plc1Thread.IsAlive)
            {
                plc1Thread.Abort();
            }
            if (plc2Thread.IsAlive)
            {
                plc2Thread.Abort();
            }
            if (plc3Thread.IsAlive)
            {
                plc3Thread.Abort();
            }
            if (plc4Thread.IsAlive)
            {
                plc4Thread.Abort();
            }
            if (plc5Thread.IsAlive)
            {
                plc5Thread.Abort();
            }
            if (plc1_client != null)
            {
                plc1_client.Disconnect();
            }
            if (plc2_client != null)
            {
                plc2_client.Disconnect();
            }
            if (plc3_client != null)
            {
                plc3_client.Disconnect();
            }
            if (plc4_client != null)
            {
                plc4_client.Disconnect();
            }
            if (plc5_client != null)
            {
                plc5_client.Disconnect();
            }
            this.Close();
            Application.Exit();
        }
        private void operatorPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stopMechanism();
        }
        #endregion



        //will add control according to connection types for setting data
        #region tablelayoutpanel controls
        
        //PLC5
        private void createTableLayoutPlc5()
        {
            Height = 800;
            Width = 150;
            plc5_holdingRegisters_textbox = new List<TextBox>();
            plc5_holdingRegisters_panel = new TableLayoutPanel();
            plc5_holdingRegisters_panel.Location = new Point(800, 0);
            plc5_holdingRegisters_panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            plc5_holdingRegisters_panel.AutoScroll = true;
            plc5_holdingRegisters_panel.Size = new Size(Width, Height);
            plc5_holdingRegisters_panel.ColumnCount = 3;
            plc5_holdingRegisters_panel.RowCount = 100;
            plc5_holdingRegisters_panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            plc5_holdingRegisters_panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            plc5_holdingRegisters_panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            for (int i = 0; i < 100; i++)
            {
                plc5_holdingRegisters_panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
                plc5_holdingRegisters_panel.Controls.Add(new System.Windows.Forms.Label() { Text = (40000 + i).ToString() }, 0, i);
                TextBox textBox = new TextBox()
                {
                    Name = i + "textbox",
                    Text = ""
                };
                plc5_holdingRegisters_textbox.Add(textBox);
                textBox.ReadOnly = true;
                plc5_holdingRegisters_panel.Controls.Add(textBox, 1, i);
                Button btn = new Button()
                {
                    Name = i.ToString(),
                    Text = "Değiştir"
                };
                btn.Click += new EventHandler(this.click_event_table9);
                plc5_holdingRegisters_panel.Controls.Add(btn, 2, i);

            }

            ////plc5_coilRegisters_textbox = new List<TextBox>();
            ////plc5_coilRegisters_panel = new TableLayoutPanel();
            ////plc5_coilRegisters_panel.Location = new Point(600, 0);
            ////plc5_coilRegisters_panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            ////plc5_coilRegisters_panel.AutoScroll = true;
            ////plc5_coilRegisters_panel.Size = new Size(Width, Height);
            ////plc5_coilRegisters_panel.ColumnCount = 3;
            ////plc5_coilRegisters_panel.RowCount = 100;
            ////plc5_coilRegisters_panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            ////plc5_coilRegisters_panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            ////plc5_coilRegisters_panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            ////for (int i = 0; i < 16; i++)
            ////{
            ////    plc5_coilRegisters_panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            ////    plc5_coilRegisters_panel.Controls.Add(new System.Windows.Forms.Label() { Text = (00000 + i).ToString() }, 0, i);
            ////    TextBox textBox = new TextBox()
            ////    {
            ////        Name = i + "textbox",
            ////        Text = ""
            ////    };
            ////    textBox.ReadOnly = true;
            ////    plc5_coilRegisters_textbox.Add(textBox);
            ////    plc5_coilRegisters_panel.Controls.Add(textBox, 1, i);
            ////    Button btn = new Button()
            ////    {
            ////        Name = i.ToString(),
            ////        Text = "Değiştir"
            ////    };
            ////    btn.Click += new EventHandler(this.click_event_table10);
            ////    plc5_coilRegisters_panel.Controls.Add(btn, 2, i);
            ////}
            control_panel.Controls.Add(plc5_holdingRegisters_panel);
            // control_panel.Controls.Add(plc5_coilRegisters_panel);
        }
        //PLC5 Write Coil
        private void click_event_table10(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Console.WriteLine(button.Name.ToString());
            var startAddress = button.Name.ToString();
            string[] packet = new string[2];
            packet[0] = "FC5";
            packet[1] = startAddress;
            plc5_client.WriteOneItem(packet, true);
        }

        //PLC5 Write Holding Register
        private void click_event_table9(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Console.WriteLine(button.Name.ToString());
            var startAddress = button.Name.ToString();
            string[] packet = new string[2];
            packet[0] = "FC6";
            packet[1] = startAddress;
            plc5_client.WriteOneItem(packet, Convert.ToInt16(rh_textBox.Text));
        }
        //PLC4
        private void createTableLayoutPlc4()
        {
            Height = 800;
            Width = 150;
            plc4_holdingRegisters_textbox = new List<TextBox>();
            plc4_holdingRegisters_panel = new TableLayoutPanel();
            plc4_holdingRegisters_panel.Location = new Point(600, 0);
            plc4_holdingRegisters_panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            plc4_holdingRegisters_panel.AutoScroll = true;
            plc4_holdingRegisters_panel.Size = new Size(Width, Height);
            plc4_holdingRegisters_panel.ColumnCount = 3;
            plc4_holdingRegisters_panel.RowCount = 100;
            plc4_holdingRegisters_panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            plc4_holdingRegisters_panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            plc4_holdingRegisters_panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            for (int i = 0; i < 100; i++)
            {
                plc4_holdingRegisters_panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
                plc4_holdingRegisters_panel.Controls.Add(new System.Windows.Forms.Label() { Text = (40000 + i).ToString() }, 0, i);
                TextBox textBox = new TextBox()
                {
                    Name = i + "textbox",
                    Text = ""
                };
                plc4_holdingRegisters_textbox.Add(textBox);
                textBox.ReadOnly = true;
                plc4_holdingRegisters_panel.Controls.Add(textBox, 1, i);
                Button btn = new Button()
                {
                    Name = i.ToString(),
                    Text = "Değiştir"
                };
                btn.Click += new EventHandler(this.click_event_table7);
                plc4_holdingRegisters_panel.Controls.Add(btn, 2, i);

            }

            ////plc4_coilRegisters_textbox = new List<TextBox>();
            ////plc4_coilRegisters_panel = new TableLayoutPanel();
            ////plc4_coilRegisters_panel.Location = new Point(600, 0);
            ////plc4_coilRegisters_panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            ////plc4_coilRegisters_panel.AutoScroll = true;
            ////plc4_coilRegisters_panel.Size = new Size(Width, Height);
            ////plc4_coilRegisters_panel.ColumnCount = 3;
            ////plc4_coilRegisters_panel.RowCount = 100;
            ////plc4_coilRegisters_panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            ////plc4_coilRegisters_panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            ////plc4_coilRegisters_panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            ////for (int i = 0; i < 16; i++)
            ////{
            ////    plc4_coilRegisters_panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            ////    plc4_coilRegisters_panel.Controls.Add(new System.Windows.Forms.Label() { Text = (00000 + i).ToString() }, 0, i);
            ////    TextBox textBox = new TextBox()
            ////    {
            ////        Name = i + "textbox",
            ////        Text = ""
            ////    };
            ////    textBox.ReadOnly = true;
            ////    plc4_coilRegisters_textbox.Add(textBox);
            ////    plc4_coilRegisters_panel.Controls.Add(textBox, 1, i);
            ////    Button btn = new Button()
            ////    {
            ////        Name = i.ToString(),
            ////        Text = "Değiştir"
            ////    };
            ////    btn.Click += new EventHandler(this.click_event_table8);
            ////    plc4_coilRegisters_panel.Controls.Add(btn, 2, i);
            ////}
            control_panel.Controls.Add(plc4_holdingRegisters_panel);
            // control_panel.Controls.Add(plc4_coilRegisters_panel);
        }
        //PLC4 Write Coil
        private void click_event_table8(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Console.WriteLine(button.Name.ToString());
            var startAddress = button.Name.ToString();
            string[] packet = new string[2];
            packet[0] = "FC5";
            packet[1] = startAddress;
            plc4_client.WriteOneItem(packet, true);
        }
        //PLC4 Write Holding Register
        private void click_event_table7(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Console.WriteLine(button.Name.ToString());
            var startAddress = button.Name.ToString();
            string[] packet = new string[2];
            packet[0] = "FC6";
            packet[1] = startAddress;
            plc4_client.WriteOneItem(packet, Convert.ToInt16(rh_textBox.Text));
        }


        //PLC3
        private void createTableLayoutPlc3()
        {
            Height = 800;
            Width = 150;
            plc3_holdingRegisters_textbox = new List<TextBox>();
            plc3_holdingRegisters_panel = new TableLayoutPanel();
            plc3_holdingRegisters_panel.Location = new Point(400, 0);
            plc3_holdingRegisters_panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            plc3_holdingRegisters_panel.AutoScroll = true;
            plc3_holdingRegisters_panel.Size = new Size(Width, Height);
            plc3_holdingRegisters_panel.ColumnCount = 3;
            plc3_holdingRegisters_panel.RowCount = 100;
            plc3_holdingRegisters_panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            plc3_holdingRegisters_panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            plc3_holdingRegisters_panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            for (int i = 0; i < 100; i++)
            {
                plc3_holdingRegisters_panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
                plc3_holdingRegisters_panel.Controls.Add(new System.Windows.Forms.Label() { Text = (40000 + i).ToString() }, 0, i);
                TextBox textBox = new TextBox()
                {
                    Name = i + "textbox",
                    Text = ""
                };
                plc3_holdingRegisters_textbox.Add(textBox);
                textBox.ReadOnly = true;
                plc3_holdingRegisters_panel.Controls.Add(textBox, 1, i);
                Button btn = new Button()
                {
                    Name = i.ToString(),
                    Text = "Değiştir"
                };
                btn.Click += new EventHandler(this.click_event_table5);
                plc3_holdingRegisters_panel.Controls.Add(btn, 2, i);

            }

            plc3_coilRegisters_textbox = new List<TextBox>();
            plc3_coilRegisters_panel = new TableLayoutPanel();
            plc3_coilRegisters_panel.Location = new Point(600, 0);
            plc3_coilRegisters_panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            plc3_coilRegisters_panel.AutoScroll = true;
            plc3_coilRegisters_panel.Size = new Size(Width, Height);
            plc3_coilRegisters_panel.ColumnCount = 3;
            plc3_coilRegisters_panel.RowCount = 100;
            plc3_coilRegisters_panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            plc3_coilRegisters_panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            plc3_coilRegisters_panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            for (int i = 0; i < 16; i++)
            {
                plc3_coilRegisters_panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
                plc3_coilRegisters_panel.Controls.Add(new System.Windows.Forms.Label() { Text = (00000 + i).ToString() }, 0, i);
                TextBox textBox = new TextBox()
                {
                    Name = i + "textbox",
                    Text = ""
                };
                textBox.ReadOnly = true;
                plc3_coilRegisters_textbox.Add(textBox);
                plc3_coilRegisters_panel.Controls.Add(textBox, 1, i);
                Button btn = new Button()
                {
                    Name = i.ToString(),
                    Text = "Değiştir"
                };
                btn.Click += new EventHandler(this.click_event_table6);
                plc3_coilRegisters_panel.Controls.Add(btn, 2, i);
            }
            control_panel.Controls.Add(plc3_holdingRegisters_panel);
           // control_panel.Controls.Add(plc1_coilRegisters_panel);
        }
        //PLC3 Write Coil
        private void click_event_table6(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Console.WriteLine(button.Name.ToString());
            var startAddress = button.Name.ToString();
            string[] packet = new string[2];
            packet[0] = "FC5";
            packet[1] = startAddress;
            plc3_client.WriteOneItem(packet, true);
        }
        //PLC3 Write Holding Register
        private void click_event_table5(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Console.WriteLine(button.Name.ToString());
            var startAddress = button.Name.ToString();
            string[] packet = new string[2];
            packet[0] = "FC6";
            packet[1] = startAddress;
            plc3_client.WriteOneItem(packet, Convert.ToInt16(rh_textBox.Text));
        }


        //PLC2
        private void createTableLayoutPlc2()
        {
            Height = 800;
            Width = 150;
            plc2_holdingRegisters_textbox = new List<TextBox>();
            plc2_holdingRegisters_panel = new TableLayoutPanel();
            plc2_holdingRegisters_panel.Location = new Point(200, 0);
            plc2_holdingRegisters_panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            plc2_holdingRegisters_panel.AutoScroll = true;
            plc2_holdingRegisters_panel.Size = new Size(Width, Height);
            plc2_holdingRegisters_panel.ColumnCount = 3;
            plc2_holdingRegisters_panel.RowCount = 100;
            plc2_holdingRegisters_panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            plc2_holdingRegisters_panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            plc2_holdingRegisters_panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            for (int i = 0; i < 100; i++)
            {
                plc2_holdingRegisters_panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
                plc2_holdingRegisters_panel.Controls.Add(new System.Windows.Forms.Label() { Text = (40000 + i).ToString() }, 0, i);
                TextBox textBox = new TextBox()
                {
                    Name = i + "textbox",
                    Text = ""
                };
                textBox.ReadOnly = true;
                plc2_holdingRegisters_textbox.Add(textBox);
                plc2_holdingRegisters_panel.Controls.Add(textBox, 1, i);
                Button btn = new Button()
                {
                    Name = i.ToString(),
                    Text = "Değiştir"
                };
                btn.Click += new EventHandler(this.click_event_table3);
                plc2_holdingRegisters_panel.Controls.Add(btn, 2, i);

            }
            plc2_coilRegisters_textbox = new List<TextBox>();
            plc2_coilRegisters_panel = new TableLayoutPanel();
            plc2_coilRegisters_panel.Location = new Point(900, 0);
            plc2_coilRegisters_panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            plc2_coilRegisters_panel.AutoScroll = true;
            plc2_coilRegisters_panel.Size = new Size(Width, Height);
            plc2_coilRegisters_panel.ColumnCount = 3;
            plc2_coilRegisters_panel.RowCount = 100;
            plc2_coilRegisters_panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            plc2_coilRegisters_panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            plc2_coilRegisters_panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            for (int i = 0; i < 16; i++)
            {
                plc2_coilRegisters_panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
                plc2_coilRegisters_panel.Controls.Add(new System.Windows.Forms.Label() { Text = i.ToString() }, 0, i);
                TextBox textBox = new TextBox()
                {
                    Name = i + "textbox",
                    Text = ""
                };
                textBox.ReadOnly = true;
                plc2_coilRegisters_textbox.Add(textBox);
                plc2_coilRegisters_panel.Controls.Add(textBox, 1, i);
                Button btn = new Button()
                {
                    Name = i.ToString(),
                    Text = "Değiştir"
                };
                btn.Click += new EventHandler(this.click_event_table4);
                plc2_coilRegisters_panel.Controls.Add(btn, 2, i);

            }

            control_panel.Controls.Add(plc2_holdingRegisters_panel);
        //    control_panel.Controls.Add(plc2_coilRegisters_panel);
        }
        //PLC2 Write Coil
        private void click_event_table4(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Console.WriteLine(button.Name.ToString());
            var startAddress = button.Name.ToString();
            string[] packet = new string[2];
            packet[0] = "FC5";
            packet[1] = startAddress;
            plc2_client.WriteOneItem(packet, true);
        }
        //PLC2 Write Holding Register
        private void click_event_table3(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Console.WriteLine(button.Name.ToString());
            var startAddress = button.Name.ToString();
            string[] packet = new string[2];
            packet[0] = "FC6";
            packet[1] = startAddress;
            plc2_client.WriteOneItem(packet, Convert.ToInt16(rh_textBox.Text));
        }

        //PLC1
        private void createTableLayoutPlc1()
        {
            Height = 800;
            Width = 150;
            plc1_holdingRegisters_textbox = new List<TextBox>();
            plc1_holdingRegisters_panel = new TableLayoutPanel();
            plc1_holdingRegisters_panel.Location = new Point(0, 0);
            plc1_holdingRegisters_panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            plc1_holdingRegisters_panel.AutoScroll = true;
            plc1_holdingRegisters_panel.Size = new Size(Width, Height);
            plc1_holdingRegisters_panel.ColumnCount = 3;
            plc1_holdingRegisters_panel.RowCount = 100;
            plc1_holdingRegisters_panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            plc1_holdingRegisters_panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            plc1_holdingRegisters_panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            for (int i = 0; i < 100; i++)
            {
                plc1_holdingRegisters_panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
                plc1_holdingRegisters_panel.Controls.Add(new System.Windows.Forms.Label() { Text = (40000 + i).ToString() }, 0, i);
                TextBox textBox = new TextBox()
                {
                    Name = i + "textbox",
                    Text = ""
                };
                plc1_holdingRegisters_textbox.Add(textBox);
                textBox.ReadOnly = true;
                plc1_holdingRegisters_panel.Controls.Add(textBox, 1, i);
                Button btn = new Button()
                {
                    Name = i.ToString(),
                    Text = "Değiştir"
                };
                btn.Click += new EventHandler(this.click_event_table);
                plc1_holdingRegisters_panel.Controls.Add(btn, 2, i);
                
            }

            ////plc1_coilRegisters_textbox = new List<TextBox>();
            ////plc1_coilRegisters_panel = new TableLayoutPanel();
            ////plc1_coilRegisters_panel.Location = new Point(300, 0);
            ////plc1_coilRegisters_panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            ////plc1_coilRegisters_panel.AutoScroll = true;
            ////plc1_coilRegisters_panel.Size = new Size(Width, Height);
            ////plc1_coilRegisters_panel.ColumnCount = 3;
            ////plc1_coilRegisters_panel.RowCount = 100;
            ////plc1_coilRegisters_panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            ////plc1_coilRegisters_panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            ////plc1_coilRegisters_panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            ////for (int i = 0; i < 16; i++)
            ////{
            ////    plc1_coilRegisters_panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            ////    plc1_coilRegisters_panel.Controls.Add(new System.Windows.Forms.Label() { Text = (00000 + i).ToString() }, 0, i);
            ////    TextBox textBox = new TextBox()
            ////    {
            ////        Name = i + "textbox",
            ////        Text = ""
            ////    };
            ////    textBox.ReadOnly = true;
            ////    plc1_coilRegisters_textbox.Add(textBox);
            ////    plc1_coilRegisters_panel.Controls.Add(textBox, 1, i);
            ////    Button btn = new Button()
            ////    {
            ////        Name = i.ToString(),
            ////        Text = "Değiştir"
            ////    };
            ////    btn.Click += new EventHandler(this.click_event_table2);
            ////    plc1_coilRegisters_panel.Controls.Add(btn, 2, i);
            ////}
            control_panel.Controls.Add(plc1_holdingRegisters_panel);
        //    control_panel.Controls.Add(plc1_coilRegisters_panel);
        }
        //PLC1 Write Coil
        private void click_event_table2(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Console.WriteLine(button.Name.ToString());
            var startAddress = button.Name.ToString();
            string[] packet = new string[1]
            {
                startAddress,
            };
            plc1_client.WriteOneItem(packet, rc_checkBox.Checked);


        }
        //PLC1 Write Holding Register
        void click_event_table(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Console.WriteLine(button.Name.ToString());
            var startAddress = button.Name.ToString();
            string[] packet = new string[2]
            {
                "FC6",
                startAddress,
            };
            plc1_client.WriteOneItem(packet, rh_textBox.Text);
        }

        #endregion
        //will add control according to connection types for setting data, transfering data
        #region communication command between two plc's 

        private void transferToPlc2_Click(object sender, EventArgs e)
        {
            ////string[] packet = new string[3];
            ////packet[0] = "FC10"; //function code
            ////packet[1] = "0"; // starting address
            ////StringBuilder sb = new StringBuilder();
            ////foreach (var item in plc1_HoldingRegisters)
            ////{
            ////    sb.Append(item + "\n");
            ////}
            ////packet[2] = sb.ToString(); //values
            ////plc2_client.WriteMultipleItem(packet);
         //   plc2_client.FC10function("0", plc1_HoldingRegisters.ToArray());
        }

        private void transferToPlc1_Click(object sender, EventArgs e)
        {
            ////string[] packet = new string[3];
            ////packet[0] = "FC10"; //function code
            ////packet[1] = "0"; // starting address
            ////StringBuilder sb = new StringBuilder();
            ////foreach(var item in plc2_HoldingRegisters)
            ////{
            ////    sb.Append(item + "\n");
            ////}
            ////packet[2] = sb.ToString(); //values
            ////plc1_client.WriteMultipleItem(packet);
        //    plc1_client.FC10function("0", plc2_HoldingRegisters.ToArray());
        }
        private void transferToPlc2_coils_Click(object sender, EventArgs e)
        {

            //plc2_client.FC0Ffunction("0", "16", StringListToString(plc1_coilRegisters));
        }
        private void transferToPlc1_coils_Click(object sender, EventArgs e)
        {
            ////string[] packet = new string[3];
            ////packet[0] = "FC0F";
            ////plc1_client.WriteMultipleItem();
            ////plc1_client.FC0Ffunction("0", "16", StringListToString(plc2_coilRegisters));

        }
        private string StringListToString(List<String> list)
        {
            int value = 0;

            byte[] bytes = new byte[2];
            for (int i = 0; i < 8; i++)
            {
                var bit = list[i].Equals("True") ? 1 : 0;
                value += bit * Convert.ToInt16(Math.Pow(2, i));

            }
            bytes[1] = Convert.ToByte(value);
            value = 0;
            for (int i = 0; i < 8; i++)
            {
                var bit = list[i + 8].Equals("True") ? 1 : 0;
                value += bit * Convert.ToInt16(Math.Pow(2, i));

            }
            bytes[0] = Convert.ToByte(value);
            value = ConvertTools.ByteArrToUnsignedInt(bytes);
            return value.ToString();
        }
        #endregion


        //Fixed to ping methods
        #region ping buttons
        private void plc1State_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(plc1Text[1]))
            {
                IConnectivity temp = plc1_client;
                MessageBox.Show(temp.Ping().ToString());
                temp = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();

            }
        }
     
        private void plc2State_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(plc2Text[1]))
            {
                IConnectivity temp = plc2_client;
                MessageBox.Show(temp.Ping().ToString());
                temp = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
        private void plc3State_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(plc3Text[1]))
            {
                IConnectivity temp = plc3_client;
                MessageBox.Show(temp.Ping().ToString());
                temp = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
        #endregion

        //Can change to circumstances // because of just optimize certain data for use
        #region private function
        private void PlcLoopS7Function(IConnectivity plc_client, List<string> plc_HoldingRegisters, List<TextBox> plc_holdingRegisters_textbox)
        {
            try
            {
                if (plc_client != null)
                {
                    if (plc_client.CheckConnection())
                    {
                        var control = plc_client.GetRead();
                        if (control != null)
                        {
                            var packet = control.Skip(2).ToArray();
                            plc_HoldingRegisters = new List<string>();
                            try
                            {
                                for (int j = 0; j < control.Length - 6; j++)
                                {
                                    var tempValue = packet.Skip(j * 2).Take(2).ToArray();
                                    int value = ConvertTools.ByteArrToSignedInt(tempValue);
                                    plc_HoldingRegisters.Add(value.ToString());
                                }
                            }
                            catch { }
                            int i = 0;
                            foreach (var item in plc_holdingRegisters_textbox)
                            {
                                item.Text = plc_HoldingRegisters[i];
                                i++;
                            }

                        }
                    }
                }
            }
            catch
            { }
            Thread.Sleep(100);
        }
        private void PlcLoopModbusFunction(IConnectivity plc_client, List<string> plc_HoldingRegisters, List<TextBox> plc_holdingRegisters_textbox, List<String> plc_coilRegisters, List<TextBox> plc_coilRegisters_textbox)
        {
            try
            {
                if (plc_client != null)
                {
                    if (plc_client.CheckConnection())
                    {
                        var control = plc_client.GetRead();
                        if (control != null)
                        {
                            var packetId = control.Skip(0).Take(2).ToArray();
                            var packet = control.Skip(2).ToArray();
                            switch (Encoding.ASCII.GetString(packetId))
                            {
                                case "RC":
                                    plc_coilRegisters = new List<string>();
                                    try
                                    {
                                        var bitArray1 = new BitArray(packet);
                                        foreach (var item in bitArray1)
                                        {
                                            plc_coilRegisters.Add(Convert.ToBoolean(item).ToString());
                                        }
                                    }
                                    catch
                                    { }
                                    int i = 0;
                                    foreach (var item in plc_coilRegisters_textbox)
                                    {
                                        item.Text = plc_coilRegisters[i];
                                        i++;
                                    }
                                    break;
                                case "RI":
                                    var bitArray2 = new BitArray(packet);
                                    foreach (var item in bitArray2)
                                    {

                                        Console.WriteLine(Convert.ToBoolean(item).ToString());
                                    }
                                    break;
                                case "RA":
                                    for (int j = 0; j < control.Length - 6; j++)
                                    {
                                        var tempValue = packet.Skip(j * 2).Take(2).ToArray();
                                        int value = ConvertTools.ByteArrToUnsignedInt(tempValue);
                                        Console.WriteLine(value.ToString());
                                    }
                                    break;
                                case "RH":
                                    plc_HoldingRegisters = new List<string>();
                                    try
                                    {
                                        for (int j = 0; j < control.Length - 6; j++)
                                        {
                                            var tempValue = packet.Skip(j * 2).Take(2).ToArray();
                                            int value = ConvertTools.ByteArrToUnsignedInt(tempValue);
                                            plc_HoldingRegisters.Add(value.ToString());
                                        }
                                    }
                                    catch { }
                                    i = 0;

                                    foreach (var item in plc_holdingRegisters_textbox)
                                    {
                                        item.Text = plc_HoldingRegisters[i];
                                        i++;
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
            catch { }
            Thread.Sleep(100);
        }
        private void stopMechanism()
        {
            plc1Text = Properties.Settings.Default.plc1.Split(';');
            plc2Text = Properties.Settings.Default.plc2.Split(';');
            plc3Text = Properties.Settings.Default.plc3.Split(';');
            plc4Text = Properties.Settings.Default.plc4.Split(';');
            plc5Text = Properties.Settings.Default.plc5.Split(';');
            if (Convert.ToBoolean(plc1Text[1]))
            {
                if (!plc1Thread.IsAlive)
                {
                    plc1Thread.Abort();
                    plc1Thread = null;
                    plc1Thread = new Thread(plc1Loop);
                    plc1Thread.Priority = ThreadPriority.Normal;
                    plc1Thread.Start();
                }
                plc1_status.Text = plc1Text[4];
            }
            else
            {
                plc1_status.Text = "Aktif Değil";
                plc1State.BackColor = Color.Red;
            }
            if (Convert.ToBoolean(plc2Text[1]))
            {
                if (!plc2Thread.IsAlive)
                {
                    plc2Thread.Abort();
                    plc2Thread = null;
                    plc2Thread = new Thread(plc2Loop);
                    plc2Thread.Priority = ThreadPriority.Normal;
                    plc2Thread.Start();
                }
                plc2_status.Text = plc2Text[4];
            }
            else
            {
                plc2_status.Text = "Aktif Değil";
                plc2State.BackColor = Color.Red;
            }
            if (Convert.ToBoolean(plc3Text[1]))
            {
                if (!plc3Thread.IsAlive)
                {
                    plc3Thread.Abort();
                    plc3Thread = null;
                    plc3Thread = new Thread(plc3Loop);
                    plc3Thread.Priority = ThreadPriority.Normal;
                    plc3Thread.Start();
                }
                plc3_status.Text = plc3Text[4];
            }
            else
            {
                plc3_status.Text = "Aktif Değil";
                plc3State.BackColor = Color.Red;
            }
            if (Convert.ToBoolean(plc4Text[1]))
            {
                if (!plc4Thread.IsAlive)
                {
                    plc4Thread.Abort();
                    plc4Thread = null;
                    plc4Thread = new Thread(plc4Loop);
                    plc4Thread.Priority = ThreadPriority.Normal;
                    plc4Thread.Start();
                }
                plc4_status.Text = plc4Text[4];
            }
            else
            {
                plc4_status.Text = "Aktif Değil";
                plc4State.BackColor = Color.Red;
            }
            if (Convert.ToBoolean(plc5Text[1]))
            {
                if (!plc5Thread.IsAlive)
                {
                    plc5Thread.Abort();
                    plc5Thread = null;
                    plc5Thread = new Thread(plc5Loop);
                    plc5Thread.Priority = ThreadPriority.Normal;
                    plc5Thread.Start();
                }
                plc5_status.Text = plc5Text[4];
            }
            else
            {
                plc5_status.Text = "Aktif Değil";
                plc5State.BackColor = Color.Red;
            }
            if (plc1Thread.IsAlive)
            {
                plc1Thread.Abort();
                plc1Thread = null;
                plc1Thread = new Thread(plc1Loop);
                plc1Thread.Priority = ThreadPriority.Normal;
                plc1Thread.Start();
            }
            if (plc2Thread.IsAlive)
            {
                plc2Thread.Abort();
                plc2Thread = null;
                plc2Thread = new Thread(plc2Loop);
                plc2Thread.Priority = ThreadPriority.Normal;
                plc2Thread.Start();
            }
            if (plc1_mainThread.IsAlive)
            {
                plc1_mainThread.Abort();
                plc1_mainThread = null;
                plc1_mainThread = new Thread(plc1_mainLoop);
                plc1_mainThread.Priority = ThreadPriority.Highest;
            }
            if (plc2_mainThread.IsAlive)
            {
                plc2_mainThread.Abort();
                plc2_mainThread = null;
                plc2_mainThread = new Thread(plc2_mainLoop);
                plc2_mainThread.Priority = ThreadPriority.Highest;
            }
            if (plc3Thread.IsAlive)
            {
                plc3Thread.Abort();
                plc3Thread = null;
                plc3Thread = new Thread(plc3Loop);
                plc3Thread.Priority = ThreadPriority.Normal;
                plc3Thread.Start();
            }
            if (plc3_mainThread.IsAlive)
            {
                plc3_mainThread.Abort();
                plc3_mainThread = null;
                plc3_mainThread = new Thread(plc3_mainLoop);
                plc3_mainThread.Priority = ThreadPriority.Highest;
            }
            if (plc4Thread.IsAlive)
            {
                plc4Thread.Abort();
                plc4Thread = null;
                plc4Thread = new Thread(plc4Loop);
                plc4Thread.Priority = ThreadPriority.Normal;
                plc4Thread.Start();
            }
            if (plc4_mainThread.IsAlive)
            {
                plc4_mainThread.Abort();
                plc4_mainThread = null;
                plc4_mainThread = new Thread(plc4_mainLoop);
                plc4_mainThread.Priority = ThreadPriority.Highest;
            }
            if (plc5Thread.IsAlive)
            {
                plc5Thread.Abort();
                plc5Thread = null;
                plc5Thread = new Thread(plc5Loop);
                plc5Thread.Priority = ThreadPriority.Normal;
                plc5Thread.Start();
            }
            if (plc5_mainThread.IsAlive)
            {
                plc5_mainThread.Abort();
                plc5_mainThread = null;
                plc5_mainThread = new Thread(plc5_mainLoop);
                plc5_mainThread.Priority = ThreadPriority.Highest;
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        { 
            switch(_fromPlc)
            {
                case "Plc1":
                    switch(_toPlc)
                    {

                    }
                    switch(Enum.Parse(typeof(PlcConnectionType), plc1Text[4]))
                    {
                        case PlcConnectionType.modbus:
                            break;
                    }
                    break;
            }

        }

        string _fromPlc = "";
        string _toPlc = "";
        private void radioButton1_Click(object sender, EventArgs e)
        {
            var rb = (RadioButton)sender;
            if (rb.Checked)
            {
                _fromPlc = rb.Text;
                groupBox1.Text = rb.Text;
            }

        }


        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            var rb = (RadioButton)sender;
            if (rb.Checked)
            {
                _toPlc = rb.Text;
                groupBox2.Text = rb.Text;
            }
        }
    }
}