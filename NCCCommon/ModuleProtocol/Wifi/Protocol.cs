using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NCCCommon.ModuleProtocol.Wifi
{
    public class RxPacketHeader
    {
        public ushort Prefix;

        public void Read(Stream s)
        {
            byte[] buf = new byte[2];
            s.Read(buf, 0, buf.Length);
            Prefix = BitConverter.ToUInt16(buf, 0);

            if (Prefix != 0xFFFF)
                throw new Exception("Invalid Prefix");
        }
    }
    public class RxPacket
    {
        public RxPacketHeader Header = new RxPacketHeader();
        public ushort[] Payload;
        public ushort Tail; //0xEEEE

        public void Read(Stream s)
        {
            Header.Read(s);

            byte[] buf = new byte[1020];
            s.Read(buf, 0, buf.Length);
            Payload = ToWords(buf);

            buf = new byte[2];
            s.Read(buf, 0, buf.Length);
            Tail = BitConverter.ToUInt16(buf, 0);

            if (Tail != 0xEEEE)
                throw new Exception("Invalid Tail");
        }

        private static ushort[] ToWords(byte[] bytes)
        {
            int wordSize = sizeof(ushort);
            ushort[] result = new ushort[bytes.Length / wordSize];

            for (int i = 0; i < bytes.Length; i += wordSize)
            {
                var word = new byte[] { bytes[i], bytes[i + 1] };
                result[i / wordSize] = BitConverter.ToUInt16(word, 0);
            }
            return result;
        }
    }
}
