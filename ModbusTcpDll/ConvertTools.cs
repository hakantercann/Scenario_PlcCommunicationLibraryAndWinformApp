using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusTcpDll
{
    public static class ConvertTools
    {
        public static int ByteArrToUnsignedInt(byte[] a)
        {
            var highByte = a[0];
            var lowByte = a[1];
            return (((highByte) & 0xFF) << 8 | (lowByte) & 0xFF);
        }
        public static int ByteArrToSignedInt(byte[] a)
        {

            var highByte = a[0];
            var lowByte = a[1];
            var bitArr = Convert.ToString(highByte, 2);
            if (bitArr.Last() == '1')
            {
                highByte = (byte)(255 - highByte);
                lowByte = (byte)(255 - lowByte);
                return ((((highByte) & 0xFF) << 8 | (lowByte) & 0xFF) + 1) * -1;
            }
            return (((highByte) & 0xFF) << 8 | (lowByte) & 0xFF);
        }
        public static char ByteArrToChar(byte[] a)
        {
            int value;
            if (a.Length < 2)
            {
                value = (a[0]) & 0xFF;
                return (char)value;
            }
            var highByte = a[0];
            var lowByte = a[1];
            value = (((highByte) & 0xFF) << 8 | (lowByte) & 0xFF);
            return (char)value;
        }
        public static byte[] IntToByteArray(int a)
        {
            return BitConverter.GetBytes(a);
        }
    }
}
