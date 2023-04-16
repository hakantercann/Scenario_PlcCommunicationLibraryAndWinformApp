namespace ModbusTcpDll
{
    public interface IConnectivity
    {   //will implement the sharp7
        //will implement the tcp client
        //will implement the tcp server
        //implemeneted the modbus tcp client
        //implemented the S7netplus
        void Connect();
        void Disconnect();

        void WriteOneItem(string[] strings, object value);

        void WriteMultipleItems(string[] strings, string[] bytes);

        void ReadOneItem(string[] strings);

        void ReadMultipleItems(string[] strings);

        bool Ping();

        bool CheckConnection();

        byte[] GetRead();
    }
}