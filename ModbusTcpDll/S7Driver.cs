using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusTcpDll
{
    public class S7Driver : IConnectivity, IS7Driver
    {
        public Plc Plc { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        #region variables
        string ip;
        short rack;
        short slot;
        CpuType cpu;
        private TcpClient tcpClient;
        private Plc _client;
        private byte[] data_buffer;
        private object single_data_buffer;
        public bool receiveInterrupt = false;
        private int referRead = 0;
        #endregion

        #region Constructors
        public S7Driver(string ip)
        {
            this.ip = ip;
            this.cpu = CpuType.S71200;
            this.rack = 0;
            this.slot = 1;
            _client = new Plc(cpu, ip, rack, slot);
        }
        public S7Driver(string ip, short rack, short slot) 
        {
            this.ip = ip;
            this.cpu = CpuType.S71200;
            this.rack = rack;
            this.slot = slot;
            _client = new Plc(cpu, ip, rack, slot);
        }
        public S7Driver(CpuType cpu ,string ip, short rack, short slot)
        {
            this.ip = ip;
            this.cpu = cpu;
            this.rack = rack;
            this.slot = slot;
            _client = new Plc(this.cpu, this.ip, this.rack, this.slot);
        }
        #endregion

        #region Interface implementation IConnectivity 
        public bool CheckConnection()
        {
            if(_client !=null)
            {
                if(_client.IsConnected)
                {
                    return true;
                }
            }
            return false;
        }

        public void Connect()
        {
            try
            {
                _client.Open();
            }
            catch { }
        }

        public void Disconnect()
        {
            try
            {

                _client.Close();
            }
            catch { }
        }

        public byte[] GetRead()
        {
            try
            {


                if (receiveInterrupt)
                {
                    switch (referRead)
                    {
                        case 1:
                            try
                            {
                                receiveInterrupt = false;
                                return data_buffer;
                            }
                            catch { }
                            break;
                        case 2:
                            try
                            {
                                var bytes = BitConverter.GetBytes(Convert.ToInt16(single_data_buffer));
                                receiveInterrupt = false;
                                return bytes;
                            }
                            catch { }
                            break;
                    }

                }
                receiveInterrupt = false;
                return null;
            }
            catch { return null; }
        }

        public bool Ping()
        {
            try
            {
                tcpClient = new TcpClient();
                var success = tcpClient.TcpPing(ip, 102);
                return success;
            }
            catch
            {
                return false;
            }
            finally { tcpClient = null; }
        }



        public void ReadMultipleItems(string[] strings)
        {
            try
            {
                switch (strings[0])
                {
                    case "DB":
                        referRead = 1;
                        data_buffer = _client.ReadBytes(DataType.DataBlock, Convert.ToInt32(strings[1]), Convert.ToInt32(strings[2]), Convert.ToInt32(strings[3]));
                        receiveInterrupt = true;
                        break;
                }
            }
            catch { }
        }

        public void ReadOneItem(string[] strings)
        {
            try
            {
                referRead = 2;
                receiveInterrupt = true;
                single_data_buffer = _client.Read(strings[0]);
            }
            catch { }
        }
        public void WriteMultipleItems(string[] strings, string[] bytes)
        {
            var temp = new byte[bytes.Length * 2];
            for(int i = 0; i < bytes.Length; i++)
            {
                byte[] values = BitConverter.GetBytes(Convert.ToInt16(bytes[i]));
                temp[i * 2] = values[1];
                temp[1 + (i * 2)] = values[0];
            }
            _client.WriteBytes(DataType.DataBlock, Convert.ToInt32(strings[1]), Convert.ToInt32(strings[2]), temp);

        }

        public void WriteOneItem(string[] strings, object value)
        {
            try
            {
                string dataAddress = "DB" + strings[0] + "." + "DBW" + strings[1];
                _client.Write(dataAddress, value);
            }
            catch { }
        }
        #endregion

        #region Interface implementation IS7Driver
        public void ReadStruct()
        {
            throw new NotImplementedException();
        }
        public void ReadClass()
        {
            throw new NotImplementedException();
        }

        public void WriteClass()
        {
            throw new NotImplementedException();
        }

        public void WriteStruct()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
