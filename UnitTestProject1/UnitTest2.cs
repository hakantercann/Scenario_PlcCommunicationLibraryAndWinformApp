using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModbusTcpDll;
using S7.Net;
using System;
using System.Threading;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest2
    {
        IConnectivity plc;
        public UnitTest2()
        {
            plc = new S7Driver("192.168.1.178");
        }

        #region connection opne, close and break tests
        [TestMethod]
        public void ConnectionOpenUnitTest()
        {
            plc.Connect();
            bool success = plc.CheckConnection();
            plc.Disconnect();
            Assert.IsTrue(success);
            
        }
        [TestMethod]
        public void ConnectionCloseUnitTest()
        {
            plc.Connect();
            bool success = plc.CheckConnection();
            if (!success)
            {
                Assert.Fail();
                return;
            }

            plc.Disconnect();
            bool result = plc.CheckConnection();
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void ConnectionBreakUnitTest()
        {
            plc.Connect();
            bool success = plc.CheckConnection();
            if(!success)
            {
                Assert.Fail();
                return;
            }
            Thread.Sleep(2000);
            bool result = plc.CheckConnection();
            Assert.IsFalse(plc.Ping());
        }
        #endregion

        #region Data Transfer Test
        [TestMethod]
        public void GetOneDataUnitTest()
        {
            Thread.Sleep(100);
            plc.Connect();
            if(!plc.CheckConnection())
            {
                Assert.Fail();
                return;
            }
            string[] packet = new string[1];
            packet[0] = "DB13.DBW0";
            plc.ReadOneItem(packet);
            var control = plc.GetRead();
            byte[] expected = new byte[2]
            {
                0x05,
                0x05,
            };
            if(control != null)
            {
                bool result = true;
                for (int i = 0; i < control.Length; i++)
                {
                    try
                    {
                        if (expected[i] != control[i])
                        {
                            result = false;
                        }
                    }
                    catch { result = false; }
                }
                Assert.IsTrue(result);
            }
            else
            {
                Assert.Fail();
            }
        }
        [TestMethod]
        public void GetMultipleDataUnitTest()
        {
            Thread.Sleep(100);
            if (!plc.CheckConnection())
            {
                plc.Connect();
                if (!plc.CheckConnection())
                {
                    Assert.Fail();
                    return;
                }
            }
            string[] packet = new string[4];
            packet[0] = "DB";
            packet[1] = "13"; //db address
            packet[2] = "0"; //start address
            packet[3] = "10"; // count
            plc.ReadMultipleItems(packet);
            byte[] expected = new byte[10]
            {
                0x05,
                0x05,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
            };
            
            var control = plc.GetRead();

            if(control != null)
            {
                bool result = true;
                for (int i = 0; i < control.Length; i++)
                {
                    try
                    {
                        if (expected[i] != control[i])
                        {
                            result = false;
                        }
                    }
                    catch { result = false; }
                }
                Assert.IsTrue(result);
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void SetOneVariable()
        {
            Thread.Sleep(100);
            if (!plc.CheckConnection())
            {
                plc.Connect();
                if (!plc.CheckConnection())
                {
                    Assert.Fail();
                    return;
                }
            }
            string[] packet = new string[1];
            packet[0] = "DB1.DBX0.0";
            plc.WriteOneItem(packet, true);
            plc.ReadOneItem(packet);
            Thread.Sleep(100);
            var control = plc.GetRead();
            if(control != null)
            {
                Assert.IsTrue(Convert.ToBoolean(S7.Net.Types.Bit.FromByte(control[0], 0)));
            }
            else
            {
                Assert.Fail();
            }
        }

        #endregion

    }
}