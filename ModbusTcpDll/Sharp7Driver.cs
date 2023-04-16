using S7.Net;
using Sharp7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ModbusTcpDll
{
    public class Sharp7Driver : IConnectivity
    {
        #region variables
        string ip;
        ushort rack;
        ushort slot;
        CpuType cpu;
        private TcpClient tcpClient;
        private S7Client _client;
        private byte[] data_buffer;
        private object single_data_buffer;
        public bool receiveInterrupt = false;
        private int referRead = 0;
        #endregion

        #region Constructors
        public Sharp7Driver(string ip)
        {
            this.ip = ip;
            this.cpu = CpuType.S71200;
            this.rack = 0;
            this.slot = 1;
            _client = new S7Client();
            _client.SetConnectionParams(ip, rack, slot);
        }
        public Sharp7Driver(string ip, ushort rack, ushort slot)
        {
            this.ip = ip;
            this.cpu = CpuType.S71200;
            this.rack = rack;
            this.slot = slot;
            _client = new S7Client();
            _client.SetConnectionParams(ip, rack, slot);
        }

        #endregion
        public bool CheckConnection()
        {
            if (_client != null)
            {
                if (_client.Connected)
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
                _client.Connect();
            }
            catch { }
        }

        public void Disconnect()
        {
            _client.Disconnect();
        }

        public byte[] GetRead()
        {
            throw new NotImplementedException();
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
                referRead = 1;
                //Area Type
                //DB Number
                // Start Address
                // Numbers Of Reg
                // Length Of Total
                // Buffer
                _client.ReadArea(S7Consts.S7AreaDB, Convert.ToInt32(strings[1]), Convert.ToInt32(strings[2]), Convert.ToInt32(strings[3]), Convert.ToInt32(strings[4]), data_buffer);
                receiveInterrupt = true;
            }
            catch { }
        }

        public void ReadOneItem(string[] strings)
        {
            throw new NotImplementedException();
        }

        public void WriteMultipleItems(string[] strings, string[] bytes)
        {
            throw new NotImplementedException();
        }

        public void WriteOneItem(string[] strings, object value)
        {
            throw new NotImplementedException();
        }
    }
}
