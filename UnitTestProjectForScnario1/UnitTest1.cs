using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ModbusTcpDll;
using System.Threading;
using System.Threading.Tasks;

namespace UnitTestProjectForScnario1
{
    [TestClass]
    public class UnitTest1
    {
        ModbusTcpClient testClient;
        
        [TestMethod]
        public async void TestMethod1() //connect
        {
            testClient = new ModbusTcpClient("127.0.0.1", 502);
            testClient.Connect();
            await Task.Delay(1000);
            bool result = testClient.CheckConnection();
            
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async void TestMethod2()
        {
            testClient = new ModbusTcpClient("127.0.0.1", 502);
            testClient.Connect();

            await Task.Delay(1000);
            testClient.Disconnect();
            await Task.Delay(100);
            Assert.IsFalse(testClient.CheckConnection());
        }
    }

}

