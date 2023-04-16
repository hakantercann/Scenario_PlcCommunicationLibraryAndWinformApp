using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusTcpDll
{
    public class ModbusTcpClient : TcpClient, IConnectivity
    {
        #region Function code variables
        private uint transactionIdentifierInternal = 0;
        private byte[] transactionIdentifier = new byte[2];
        private byte[] protocolIdentifier = new byte[2];
        private byte[] length = new byte[2];
        private byte unitIdentifier = 0x01;
        private byte functionCode;
        private byte[] startingAddress = new byte[2];
        private byte[] quantity = new byte[2];
        #endregion

        #region standart variables
        private string ipAddress;
        private int port;
        private int referRead = 0;
        #endregion

        #region Constructors
        public ModbusTcpClient(string ipAddress, int port)
        { 
            this.ipAddress = ipAddress;
            this.port = port;
        }
        public ModbusTcpClient(string ipAddress, int port, byte id)
        {
            this.unitIdentifier = id;
            this.ipAddress = ipAddress;
            this.port = port;
        }
        #endregion
        #region Interface implementation IConnectivity
        public void Connect()
        {
            try
            {
                connect(ipAddress, port);
            }
            catch { }
        }

        public void Disconnect()
        {
            disconnect();
        }


        public byte[] GetRead()
        {
            try
            {
                if (receiveInterrupt)
                {
                    receiveInterrupt = false;
                    if (dataBuffer == null)
                    {
                        return null;
                    }
                    var temp = dataBuffer;
                    var sb = new StringBuilder(temp.Length * 2);
                    var tempBuffer = temp.Skip(9).ToArray();
                    var pduLength = temp.Skip(4).Take(2).ToArray();
                    int dataLength = ConvertTools.ByteArrToUnsignedInt(pduLength);
                    byte[] dataIdentifier;
                    byte[] returnData;
                    switch (referRead)
                    {
                        case 1://read coils
                            try
                            {
                                dataIdentifier = Encoding.ASCII.GetBytes("RC");
                                returnData = new byte[tempBuffer.Length + dataIdentifier.Length];
                                Buffer.BlockCopy(dataIdentifier, 0, returnData, 0, dataIdentifier.Length);
                                Buffer.BlockCopy(tempBuffer, 0, returnData, dataIdentifier.Length, tempBuffer.Length);
                                return returnData;
                            }
                            catch { }
                            break;
                        case 2://read analog inputs
                            try
                            {
                                dataIdentifier = Encoding.ASCII.GetBytes("RA");
                                returnData = new byte[tempBuffer.Length + dataIdentifier.Length];

                                Buffer.BlockCopy(dataIdentifier, 0, returnData, 0, dataIdentifier.Length);
                                Buffer.BlockCopy(tempBuffer, 0, returnData, dataIdentifier.Length, tempBuffer.Length);
                                return returnData;
                                ////for (int j = 0; j < dataLength - 4; j++)
                                ////{

                                ////    var tempValue = tempBuffer.Skip(j * 2).Take(2).ToArray();
                                ////    int value = ConvertTools.ByteArrToSignedInt(tempValue);
                                ////    sb.AppendFormat(j + "int" + value.ToString() + "\n ***");
                                ////}
                            }
                            catch { }
                            break;
                        case 4://read holding registers
                            try
                            {
                                dataIdentifier = Encoding.ASCII.GetBytes("RH");
                                returnData = new byte[tempBuffer.Length + dataIdentifier.Length];

                                Buffer.BlockCopy(dataIdentifier, 0, returnData, 0, dataIdentifier.Length);
                                Buffer.BlockCopy(tempBuffer, 0, returnData, dataIdentifier.Length, tempBuffer.Length);
                                return returnData;
                            }
                            catch
                            { }
                            break;
                        case 5:
                            try
                            {
                                dataIdentifier = Encoding.ASCII.GetBytes("RI");
                                returnData = new byte[tempBuffer.Length + dataIdentifier.Length];
                                Buffer.BlockCopy(dataIdentifier, 0, returnData, 0, dataIdentifier.Length);
                                Buffer.BlockCopy(tempBuffer, 0, returnData, dataIdentifier.Length, tempBuffer.Length);
                                return returnData;
                            }
                            catch { }
                            break;
                    }
                    return null;
                }
                else
                {
                    return null;
                }
            }
            catch { return null; }
        }

        public bool Ping()
        {
            return TcpPing(ipAddress, port);
        }

        public void ReadMultipleItems(string[] strings)
        {
            try
            {
                switch (strings[0].Substring(0, 3))
                {
                    //starting address, quantity
                    case "FC1":
                        FC1Function(strings[1], strings[2]);
                        break;
                    case "FC2":
                        FC2function(strings[1], strings[2]);
                        break;
                    case "FC3":
                        FC3function(strings[1], strings[2]);
                        break;
                    case "FC4":
                        FC4function(strings[1], strings[2]);
                        break;
                }
            }
            catch { }
        }

        public void ReadOneItem(string[] strings)
        {
            throw new NotImplementedException();
        }


        public void WriteMultipleItems(string[] strings, string[] bytes)
        {
            switch (strings[0].Substring(0, 4))
            {
                //starting address, quantity, values
                case "FC0F":
                    try
                    {
                        FC0Ffunction(strings[1], strings[2], strings[3]);
                    }
                    catch { }
                    break;
                case "FC10":
                    try
                    {
                        FC10function(strings[1], bytes);
                    }
                    catch { }
                    break;
            }
        }

        
        public void WriteOneItem(string[] strings, object value)
        {
            try
            {
                switch (strings[0].Substring(0, 3))
                {
                    //starting address, value
                    case "FC5":
                        try
                        {
                            FC5function(strings[1], Convert.ToBoolean(value));
                        }
                        catch { }
                        break;
                    case "FC6":
                        try
                        {
                            FC6function(strings[1], value.ToString());
                        }
                        catch { }
                        break;

                }
            }
            catch { }
        }
        public bool CheckConnection()
        {
            return IsConnected();
        }

        #endregion

        #region Function code functions


        //private olacak
        private void FC1Function(string startingAddress, string quantity) //Read Coils
        {
            try
            {
                transactionIdentifierInternal++;
                referRead = 1;
                this.transactionIdentifier = BitConverter.GetBytes(Convert.ToInt16(transactionIdentifierInternal));
                this.protocolIdentifier = BitConverter.GetBytes(Convert.ToInt16(0x0000));
                this.length = BitConverter.GetBytes(Convert.ToInt16(0x0006));
                this.unitIdentifier = 0x01;
                this.functionCode = 0x01;
                this.startingAddress = BitConverter.GetBytes(Convert.ToInt16(startingAddress));
                this.quantity = BitConverter.GetBytes(Convert.ToInt16(quantity));
                Byte[] full_packet = new byte[]{
                            this.transactionIdentifier[1],
                            this.transactionIdentifier[0],
                            this.protocolIdentifier[1],
                            this.protocolIdentifier[0],
                            this.length[1],
                            this.length[0],
                            this.unitIdentifier,
                            this.functionCode,
                            this.startingAddress[1],
                            this.startingAddress[0],
                            this.quantity[1],
                            this.quantity[0],
            };
                try
                {
                    writeAsByteArr(full_packet);
                }
                catch { }
            }
            catch { }
        }
        private void FC2function(string startingAddress, string quantity) //Read Discrete Inputs
        {
            try
            {
                referRead = 5;
                transactionIdentifierInternal++;
                this.transactionIdentifier = BitConverter.GetBytes(Convert.ToInt16(transactionIdentifierInternal));
                this.protocolIdentifier = BitConverter.GetBytes(Convert.ToInt16(0x0000));
                this.length = BitConverter.GetBytes(Convert.ToInt16(0x0006));
                this.unitIdentifier = 0x01;
                this.functionCode = 0x02;
                this.startingAddress = BitConverter.GetBytes(Convert.ToInt16(startingAddress));
                this.quantity = BitConverter.GetBytes(Convert.ToInt16(quantity));
                Byte[] full_packet = new byte[]
                                {
                            this.transactionIdentifier[1],
                            this.transactionIdentifier[0],
                            this.protocolIdentifier[1],
                            this.protocolIdentifier[0],
                            this.length[1],
                            this.length[0],
                            this.unitIdentifier,
                            this.functionCode,
                            this.startingAddress[1],
                            this.startingAddress[0],
                            this.quantity[1],
                            this.quantity[0],
                                };
                try
                {
                    writeAsByteArr(full_packet);
                }
                catch { }
            }
            catch { }
        }
        private void FC3function(string startingAddress, string quantity) // Read Holding Registers
        {
            try
            {
                transactionIdentifierInternal++;
                referRead = 4;
                this.transactionIdentifier = BitConverter.GetBytes(Convert.ToInt16(transactionIdentifierInternal));
                this.protocolIdentifier = BitConverter.GetBytes(Convert.ToInt16(0x0000));
                this.length = BitConverter.GetBytes(Convert.ToInt16(0x0006));
                this.unitIdentifier = 0x01;
                this.functionCode = 0x03;
                this.startingAddress = BitConverter.GetBytes(Convert.ToInt16(startingAddress));
                this.quantity = BitConverter.GetBytes(Convert.ToInt16(quantity));
                Byte[] full_packet = new byte[]{   this.transactionIdentifier[1],
                            this.transactionIdentifier[0],
                            this.protocolIdentifier[1],
                            this.protocolIdentifier[0],
                            this.length[1],
                            this.length[0],
                            this.unitIdentifier,
                            this.functionCode,
                            this.startingAddress[1],
                            this.startingAddress[0],
                            this.quantity[1],
                            this.quantity[0],
            };
                try
                {
                    writeAsByteArr(full_packet);
                }
                catch { }
            }
            catch { }

        }

        private void FC4function(string startingAddress, string quantity) // Read Analog Inputs
        {

            try
            {
                transactionIdentifierInternal++;
                referRead = 2;
                this.transactionIdentifier = BitConverter.GetBytes(Convert.ToInt16(transactionIdentifierInternal));
                this.protocolIdentifier = BitConverter.GetBytes(Convert.ToInt16(0x0000));
                this.length = BitConverter.GetBytes(Convert.ToInt16(0x0006));
                this.unitIdentifier = 0x01;
                this.functionCode = 0x04;
                this.startingAddress = BitConverter.GetBytes(Convert.ToInt16(startingAddress));
                this.quantity = BitConverter.GetBytes(Convert.ToInt16(quantity));
                Byte[] full_packet = new byte[]
                                {
                            this.transactionIdentifier[1],
                            this.transactionIdentifier[0],
                            this.protocolIdentifier[1],
                            this.protocolIdentifier[0],
                            this.length[1],
                            this.length[0],
                            this.unitIdentifier,
                            this.functionCode,
                            this.startingAddress[1],
                            this.startingAddress[0],
                            this.quantity[1],
                            this.quantity[0],
                                };
                try
                {
                    writeAsByteArr(full_packet);
                }
                catch { }
            }
            catch { }
        }

        private void FC5function(string startingAddress, bool value) //Write single coil
        {
            try
            {
                referRead = 3;
                transactionIdentifierInternal++;
                this.transactionIdentifier = BitConverter.GetBytes(Convert.ToInt16(transactionIdentifierInternal));
                this.protocolIdentifier = BitConverter.GetBytes(Convert.ToInt16(0x0000));
                this.length = BitConverter.GetBytes(Convert.ToInt16(0x0006));
                this.unitIdentifier = 0x01;
                this.functionCode = 0x05;
                this.startingAddress = BitConverter.GetBytes(Convert.ToInt16(startingAddress));
                byte[] registerValue = BitConverter.GetBytes(value ? 0xFF00 : 0x0000);
                Byte[] full_packet = new byte[]{
                            this.transactionIdentifier[1],
                            this.transactionIdentifier[0],
                            this.protocolIdentifier[1],
                            this.protocolIdentifier[0],
                            this.length[1],
                            this.length[0],
                            this.unitIdentifier,
                            this.functionCode,
                            this.startingAddress[1],
                            this.startingAddress[0],
                            registerValue[1],
                            registerValue[0],
            };

                try
                {
                    writeAsByteArr(full_packet);
                }
                catch { }
            }
            catch { }
        }

        private void FC6function(string startingAddress, string value) // Write single holding register
        {
            try
            {
                transactionIdentifierInternal++;
                referRead = 3;
                byte[] registerValue = new byte[2];
                this.transactionIdentifier = BitConverter.GetBytes(Convert.ToInt16(transactionIdentifierInternal));
                this.protocolIdentifier = BitConverter.GetBytes(Convert.ToInt16(0x0000));
                this.length = BitConverter.GetBytes(Convert.ToInt16(0x0006));
                this.unitIdentifier = 0x01;
                this.functionCode = 0x06;
                this.startingAddress = BitConverter.GetBytes(Convert.ToInt16(startingAddress));
                registerValue = BitConverter.GetBytes(Convert.ToInt16(value));

                Byte[] full_packet = new byte[]{   this.transactionIdentifier[1],
                            this.transactionIdentifier[0],
                            this.protocolIdentifier[1],
                            this.protocolIdentifier[0],
                            this.length[1],
                            this.length[0],
                            this.unitIdentifier,
                            this.functionCode,
                            this.startingAddress[1],
                            this.startingAddress[0],
                            registerValue[1],
                            registerValue[0],
                            };
                try
                {
                    writeAsByteArr(full_packet);
                }
                catch { }
            }
            catch
            {
            }
        }
        public void FC0Ffunction(string startingAddress, string quantity, string value) // write multiple coils
        {
            try
            {
                referRead = 3;
                transactionIdentifierInternal++;
                this.transactionIdentifier = BitConverter.GetBytes(Convert.ToInt16(transactionIdentifierInternal));
                this.protocolIdentifier = BitConverter.GetBytes(Convert.ToInt16(0x0000));
                //this.length = BitConverter.GetBytes((int)0x0006);
                this.unitIdentifier = 0x01;
                this.functionCode = 0x0F;
                this.startingAddress = BitConverter.GetBytes(Convert.ToInt16(startingAddress));
                this.quantity = BitConverter.GetBytes(Convert.ToInt16(quantity));
                var numbersOfRegisters = Convert.ToInt16(quantity);
                var coilsByte = numbersOfRegisters % 8 == 0 ? (int)numbersOfRegisters / 8 : (int)numbersOfRegisters / 8 + 1;
                byte numberOfDataBytes = (byte)coilsByte;
                byte[] valuesOfCoils = new byte[coilsByte];
                this.length = BitConverter.GetBytes(Convert.ToInt16(7 + coilsByte));
                valuesOfCoils = BitConverter.GetBytes(Convert.ToInt16(value));

                //byte byteCount = (byte)((values.Length % 8 != 0 ? values.Length / 8 + 1 : (values.Length / 8)));
                Byte[] full_packet = new byte[13 + coilsByte];
                full_packet[0] = this.transactionIdentifier[1];
                full_packet[1] = this.transactionIdentifier[0];
                full_packet[2] = this.protocolIdentifier[1];
                full_packet[3] = this.protocolIdentifier[0];
                full_packet[4] = this.length[1];
                full_packet[5] = this.length[0];
                full_packet[6] = this.unitIdentifier;
                full_packet[7] = this.functionCode;
                full_packet[8] = this.startingAddress[1];
                full_packet[9] = this.startingAddress[0];
                full_packet[10] = this.quantity[1];
                full_packet[11] = this.quantity[0];
                full_packet[12] = numberOfDataBytes;
                for (int i = 0; i < coilsByte; i++)
                {
                    full_packet[13 + i] = valuesOfCoils[i];
                }
                try
                {
                    writeAsByteArr(full_packet);
                }
                catch { }
            }
            catch
            {
            }
        }

        public void FC10function(string startingAddress, string[] values) // write multiple holding registers
        {
            try
            {
                referRead = 3;
                transactionIdentifierInternal++;
                this.transactionIdentifier = BitConverter.GetBytes(Convert.ToInt16(transactionIdentifierInternal));
                this.protocolIdentifier = BitConverter.GetBytes(Convert.ToInt16(0x0000));
                this.unitIdentifier = 0x01;
                this.functionCode = 0x10;
                this.startingAddress = BitConverter.GetBytes(Convert.ToInt16(startingAddress));
                int coilsByte = values.Length;
                this.quantity = BitConverter.GetBytes(Convert.ToInt16(coilsByte));

                byte numberOfDataBytes = (byte)(coilsByte * 2);

                this.length = BitConverter.GetBytes(Convert.ToInt16(7 + coilsByte * 2));

                Byte[] full_packet = new byte[13 + values.Length * 2];
                full_packet[0] = this.transactionIdentifier[1];
                full_packet[1] = this.transactionIdentifier[0];
                full_packet[2] = this.protocolIdentifier[1];
                full_packet[3] = this.protocolIdentifier[0];
                full_packet[4] = this.length[1];
                full_packet[5] = this.length[0];
                full_packet[6] = this.unitIdentifier;
                full_packet[7] = this.functionCode;
                full_packet[8] = this.startingAddress[1];
                full_packet[9] = this.startingAddress[0];
                full_packet[10] = this.quantity[1];
                full_packet[11] = this.quantity[0];
                full_packet[12] = numberOfDataBytes;
                for (int i = 0; i < values.Length; i++)
                {
                    byte[] valuesOfRegister = BitConverter.GetBytes(Convert.ToInt16(values[i]));
                    full_packet[13 + i * 2] = valuesOfRegister[1];
                    full_packet[14 + i * 2] = valuesOfRegister[0];
                }

                try
                {
                    writeAsByteArr(full_packet);
                }
                catch { }
            }
            catch { }
        }





        #endregion
    }
}
