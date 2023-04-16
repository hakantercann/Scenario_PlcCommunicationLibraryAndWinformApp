using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModbusTcpDll;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        ModbusTcpClient testClient = new ModbusTcpClient("127.0.0.1", 502);
        public UnitTest1()
        {
            testClient.Connect();
        }
        [TestMethod]
        public void TestMethod1()
        {
            bool result = testClient.CheckConnection();
            Assert.IsTrue(result);
            testClient.Disconnect();
        }

        [TestMethod]
        public void TestMethod2()
        {
            bool result = testClient.CheckConnection();
            Assert.IsFalse(result);
        }
    }
    [TestClass]
    public class FunctionCodeUnitTests
    {
        static ModbusTcpClient testClient = new ModbusTcpClient("127.0.0.1", 502);
        public FunctionCodeUnitTests()
        {
            testClient.Connect();
        }
        #region read single and multple value(function name readMultipleItems)
        #region FC1 Function tests
        [TestMethod]
        public void FC1SingleByteUnitTest()//FC1 Read Coil Function One Byte test
        {
            
            string[] packet = new string[3];
            packet[0] = "FC1";
            packet[1] = "0";
            packet[2] = "1";
            testClient.ReadMultipleItems(packet);
            Thread.Sleep(10000);
            byte[] bytes = testClient.dataBuffer;
            byte[] expected = new byte[]
            {
                (byte) 0x00, //transaction id
                (byte) 0x02,
                (byte) 0x00, //protocol id
                (byte) 0x00,
                (byte) 0x00, // message length
                (byte) 0x04,
                (byte) 0x01, //device address
                (byte) 0x01, // function code
                (byte) 0x01, // numbers of byte
                //value
                (byte) 0x01,

            };
            bool result = true;
            for(int i = 0; i < bytes.Length; i++)
            {
                try
                {
                    if (expected[i] != bytes[i])
                    {
                        result = false;
                    }
                }
                catch { result = false; }
            }
            Assert.IsTrue(result);
            
        }
        [TestMethod]
        public void FC1MultipleBytesUnitTest()
        {
            string[] packet = new string[3];
            packet[0] = "FC1";
            packet[1] = "0";
            packet[2] = "10";
            testClient.ReadMultipleItems(packet);
            Thread.Sleep(10000);
            byte[] bytes = testClient.dataBuffer;
            byte[] expected = new byte[]
            {
                (byte) 0x00, //transaction id
                (byte) 0x01,
                (byte) 0x00, //protocol id
                (byte) 0x00,
                (byte) 0x00, // message length
                (byte) 0x05,
                (byte) 0x01, //device address
                (byte) 0x01, // function code
                (byte) 0x02, // numbers of byte
                //values
                (byte) 0x4B, 
                (byte) 0x02,
            };
            bool result = true;
            for (int i = 0; i < bytes.Length; i++)
            {
                try
                {
                    if (expected[i] != bytes[i])
                    {
                        result = false;
                    }
                }
                catch { result = false; }
            }
            Assert.IsTrue(result);
        }
        #endregion
        #region FC2 Function tests
        [TestMethod]
        public void FC2SingleByteUnitTest() //Read digital inputs
        {
            string[] packet = new string[3];
            packet[0] = "FC2";
            packet[1] = "0";
            packet[2] = "1";
            testClient.ReadMultipleItems(packet);
            Thread.Sleep(20000);
            byte[] bytes = testClient.dataBuffer;
            byte[] expected = new byte[]
            {
                (byte) 0x00, //transaction id
                (byte) 0x04,
                (byte) 0x00, //protocol id
                (byte) 0x00,
                (byte) 0x00, // message length
                (byte) 0x04,
                (byte) 0x01, //device address
                (byte) 0x02, // function code
                (byte) 0x01, // numbers of byte
                 //value
                (byte) 0x00
            };
            bool result = true;
            for (int i = 0; i < bytes.Length; i++)
            {
                try
                {
                    if (expected[i] != bytes[i])
                    {
                        result = false;
                    }
                }
                catch { result = false; }
            }
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void FC2MultpileBytesUnitTest()
        {
            string[] packet = new string[3];
            packet[0] = "FC2";
            packet[1] = "0";
            packet[2] = "8";
            testClient.ReadMultipleItems(packet);
            Thread.Sleep(20000);
            byte[] bytes = testClient.dataBuffer;
            byte[] expected = new byte[]
            {
                (byte) 0x00, //transaction id
                (byte) 0x03,
                (byte) 0x00, //protocol id
                (byte) 0x00,
                (byte) 0x00, // message length
                (byte) 0x04,
                (byte) 0x01, //device address
                (byte) 0x02, // function code
                (byte) 0x01, // numbers of byte
                //values
                (byte) 0x06, 
            };
            bool result = true;
            for (int i = 0; i < bytes.Length; i++)
            {
                try
                {
                    if (expected[i] != bytes[i])
                    {
                        result = false;
                    }
                }
                catch { result = false; }
            }
            Assert.IsTrue(result);
        }
        #endregion
        #region FC3 Function tests
        [TestMethod]
        public void FC3SingleByteUnitTest()
        {
            string[] packet = new string[3];
            packet[0] = "FC3";
            packet[1] = "0";
            packet[2] = "1";
            testClient.ReadMultipleItems(packet);
            Thread.Sleep(10000);
            byte[] bytes = testClient.dataBuffer;
            byte[] expected = new byte[]
            {
                (byte) 0x00, //transaction id
                (byte) 0x06,
                (byte) 0x00, //protocol id
                (byte) 0x00,
                (byte) 0x00, // message length
                (byte) 0x05,
                (byte) 0x01, //device address
                (byte) 0x03, // function code
                (byte) 0x02, // numbers of byte
                //value
                (byte) 0x00, 
                (byte) 0x7C,
            };
            bool result = true;
            for (int i = 0; i < bytes.Length; i++)
            {
                try
                {
                    if (expected[i] != bytes[i])
                    {
                        result = false;
                    }
                }
                catch { result = false; }
            }
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void FC3MultpileBytesUnitTest()
        {
            string[] packet = new string[3];
            packet[0] = "FC3";
            packet[1] = "0";
            packet[2] = "3";
            testClient.ReadMultipleItems(packet);
            Thread.Sleep(10000);
            byte[] bytes = testClient.dataBuffer;
            byte[] expected = new byte[]
            {
                (byte) 0x00, //transaction id
                (byte) 0x05,
                (byte) 0x00, //protocol id
                (byte) 0x00,
                (byte) 0x00, // message length
                (byte) 0x09,
                (byte) 0x01, //device address
                (byte) 0x03, // function code
                (byte) 0x06, // numbers of byte
                //values
                (byte) 0x00,
                (byte) 0x7C,
                (byte) 0x24,
                (byte) 0x81,
                (byte) 0x00,
                (byte) 0x7B,
            };
            bool result = true;
            for (int i = 0; i < bytes.Length; i++)
            {
                try
                {
                    if (expected[i] != bytes[i])
                    {
                        result = false;
                    }
                }
                catch { result = false; }
            }
            Assert.IsTrue(result);
        }
        #endregion
        #region FC4 Function tests
        [TestMethod]
        public void FC4SingleByteUnitTest()
        {
            string[] packet = new string[3];
            packet[0] = "FC4";
            packet[1] = "1"; //start address
            packet[2] = "1"; // numbers of reading elements
            testClient.ReadMultipleItems(packet);
            Thread.Sleep(10000);
            byte[] bytes = testClient.dataBuffer;
            byte[] expected = new byte[]
            {
                (byte) 0x00, //transaction id
                (byte) 0x08,
                (byte) 0x00, //protocol id
                (byte) 0x00,
                (byte) 0x00, // message length
                (byte) 0x05,
                (byte) 0x01, //device address
                (byte) 0x04, // function code
                (byte) 0x02, // numbers of byte
                //value
                (byte) 0x00,
                (byte) 0x80,
            };
            bool result = true;
            for (int i = 0; i < bytes.Length; i++)
            {
                try
                {
                    if (expected[i] != bytes[i])
                    {
                        result = false;
                    }
                }
                catch { result = false; }
            }
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void FC4MultpileBytesUnitTest()
        {
            string[] packet = new string[3];
            packet[0] = "FC4";
            packet[1] = "0"; //Start Address
            packet[2] = "3"; //Numbers of reading element
            testClient.ReadMultipleItems(packet);
            Thread.Sleep(10000);
            byte[] bytes = testClient.dataBuffer;
            byte[] expected = new byte[]
            {
                (byte) 0x00, //transaction id
                (byte) 0x07,
                (byte) 0x00, //protocol id
                (byte) 0x00,
                (byte) 0x00, // message length
                (byte) 0x09,
                (byte) 0x01, //device address
                (byte) 0x04, // function code
                (byte) 0x06, // numbers of byte
               //values
                (byte) 0x00,
                (byte) 0x80,
                (byte) 0x00,
                (byte) 0x80,
                (byte) 0x00,
                (byte) 0xD5,
            };
            bool result = true;
            for (int i = 0; i < bytes.Length; i++)
            {
                try
                {
                    if (expected[i] != bytes[i])
                    {
                        result = false;
                    }
                }
                catch { result = false; }
            }
            Assert.IsTrue(result);
        }
        #endregion
        #endregion

        #region write single value(function name writeOneItem)
        #region FC5 Function tests
        [TestMethod]
        public void FC5WriteSingleByteToCoilRegisterUnitTest()
        {
            string[] packet = new string[3];
            packet[0] = "FC5";
            packet[1] = "1"; //start address
            object value = true;
            testClient.WriteOneItem(packet, value);
            Thread.Sleep(10000);
            byte[] bytes = testClient.dataBuffer;
            byte[] expected = new byte[]
            {
                (byte) 0x00, //transaction id
                (byte) 0x09,
                (byte) 0x00, //protocol id
                (byte) 0x00,
                (byte) 0x00, // message length
                (byte) 0x06,
                (byte) 0x01, //device address
                (byte) 0x05, // function code
                (byte) 0x00, // Hi Register Address Byte
                (byte) 0x01, // Lo Register Address Byte
                (byte) 0xFF, // Hi Byte Meaning 
                (byte) 0x00, // Lo Byte Meaning
            };
            bool result = true;
            for (int i = 0; i < bytes.Length; i++)
            {
                try
                {
                    if (expected[i] != bytes[i])
                    {
                        result = false;
                    }
                }
                catch { result = false; }
            }
            Assert.IsTrue(result);
        }
        #endregion

        #region FC6 Function Test
        [TestMethod]
        public void FC6WriteSingleByteToHoldingRegisterUnitTest()
        {
            string[] packet = new string[3];
            packet[0] = "FC6";
            packet[1] = "3"; //Start Address
            object value = 128;
            testClient.WriteOneItem(packet, value);
            Thread.Sleep(10000);
            byte[] bytes = testClient.dataBuffer;
            byte[] expected = new byte[]
            {
                (byte) 0x00, //transaction id
                (byte) 0x01,
                (byte) 0x00, //protocol id
                (byte) 0x00,
                (byte) 0x00, // message length
                (byte) 0x06,
                (byte) 0x01, //device address
                (byte) 0x06, // function code
                (byte) 0x00, // Hi Register Address Byte
                (byte) 0x03, // Lo Register Address Byte
                (byte) 0x00, // Hi Byte Meaning 
                (byte) 0x80, // Lo Byte Meaning
            };
            bool result = true;
            for (int i = 0; i < bytes.Length; i++)
            {
                try
                {
                    if (expected[i] != bytes[i])
                    {
                        result = false;
                    }
                }
                catch { result = false; }
            }
            Assert.IsTrue(result);
        }
        #endregion
        #endregion
        #region write multple values (function name WriteMultipleItems)
        

        #endregion 
    }

}

