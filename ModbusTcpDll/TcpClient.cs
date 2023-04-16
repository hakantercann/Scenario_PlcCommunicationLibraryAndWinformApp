using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ModbusTcpDll
{
    public class TcpClient
    {
        public Socket tcpClientSocket { get; set; }
        private byte[] _buffer = new byte[1024];
        public byte[] dataBuffer { get; set; }
        public bool receiveInterrupt = false;
        public int connect(string ip, int port)
        {
            ////if (TcpPing(ip, port))
            ////{
                try
                {
                    tcpClientSocket = createSocket();
                    IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ip), port);
                    tcpClientSocket.BeginConnect(endPoint, new AsyncCallback(ConnectCallback), null);

                }
                catch { return 1; }
            ////}

            return 0;
        }

        private void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                tcpClientSocket.EndConnect(ar);
                tcpClientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), tcpClientSocket);
            }
            catch
            {
                tcpClientSocket = null;
            }
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            Socket socket = (Socket)ar.AsyncState;
            try
            {
                int received = socket.EndReceive(ar);
                if (received < 1)
                {
                    socket.Close();
                    tcpClientSocket.Close();
                    tcpClientSocket = null;
                }
                else
                {
                    dataBuffer = new byte[received];
                    Array.Copy(_buffer, dataBuffer, received);

                    string text = Encoding.ASCII.GetString(dataBuffer);
                    text = "Received data: " + text + "  from " + socket.RemoteEndPoint.ToString();
                    Console.WriteLine(text);
                    receiveInterrupt = true;
                    socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
                }
            }
            catch { }
        }

        public void disconnect()
        {
            if (tcpClientSocket != null && tcpClientSocket.Connected)
            {
                tcpClientSocket.Dispose();
                tcpClientSocket = null;   
            }
        }

        public bool TcpPing(string ip, int port)
        {
            tcpClientSocket = createSocket();
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            try
            {
                IAsyncResult result = tcpClientSocket.BeginConnect(endPoint, null, null);
                bool success = result.AsyncWaitHandle.WaitOne(1000);

                if (success)
                {
                    tcpClientSocket.BeginDisconnect(false, new AsyncCallback(DisconnectCallback), tcpClientSocket);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch { return false; }
        }

        private void DisconnectCallback(IAsyncResult ar)
        {
            Socket socket = (Socket)ar.AsyncState;
            try
            {
                socket.EndDisconnect(ar);
                socket.Dispose();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            catch { }
        }

        public byte[] read()
        {
            if (dataBuffer != null)
            {
                return dataBuffer;
            }
            return new byte[1];
        }

        ////public void write(string text)
        ////{
        ////    byte[] dataBuffer = Encoding.ASCII.GetBytes(text);
        ////    tcpClientSocket.BeginSend(dataBuffer, 0, dataBuffer.Length, SocketFlags.None, new AsyncCallback(SendCallback), tcpClientSocket);
        ////}

        private void SendCallback(IAsyncResult ar)
        {
            Socket socket = (Socket)ar.AsyncState;
            try
            {
                socket.EndSend(ar);
            }
            catch { }
        }

        public Socket createSocket()
        {
            try
            {
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.NoDelay = true;
                return socket;
            }
            catch { return null; }
        }

        public bool IsConnected()
        {
            if (tcpClientSocket != null)
            {
                if (tcpClientSocket.Connected)
                {
                    return true;
                }
            }
            return false;
        }


        
        public void writeAsByteArr(Byte[] bytes)
        {
            try
            {
                tcpClientSocket.BeginSend(bytes, 0, bytes.Length, SocketFlags.None, new AsyncCallback(SendCallback), tcpClientSocket);
            }
            catch { }
        }
        public void write(object SendingData, int lenght)
        {
            switch (SendingData.GetType().ToString())
            {
                case "System.Byte[]":
                    Console.WriteLine("byte");
                    byte[] sendByte = ObjectToByteArray(SendingData);
                    Console.WriteLine(sendByte[0]);
                    tcpClientSocket.BeginSend(sendByte, 0, sendByte.Length, SocketFlags.None, new AsyncCallback(SendCallback), tcpClientSocket);

                    break;
                case "System.String":
                    Console.WriteLine("string");
                    byte[] sendBuf = Encoding.ASCII.GetBytes(SendingData.ToString());
                    tcpClientSocket.BeginSend(sendBuf, 0, sendBuf.Length, SocketFlags.None, new AsyncCallback(SendCallback), tcpClientSocket);
                    break;
            }
        }
        private byte[] ObjectToByteArray(object obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
    }
}
