using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCCCommon.ModuleProtocol.OmapProtocol
{
    public static class ByteUtil
    {
        //public static int WriteInt16(int n, byte[] buff, int startIndex)
        //{
        //    int i = startIndex;
        //    buff[i++] = (byte)((n & 0xFF00) >> 8);
        //    buff[i++] = (byte)(n & 0xFF);
        //    return 2;
        //}
        //public static int WriteUInt16(uint n, byte[] buff, int startIndex)
        //{
        //    int i = startIndex;
        //    buff[i++] = (byte)((n & 0xFF00) >> 8);
        //    buff[i++] = (byte)(n & 0xFF);
        //    return 2;
        //}
        public static int WriteInt32(int n, byte[] buff, int startIndex)
        {
            int i = startIndex;
            buff[i++] = (byte)(n >> 24);
            buff[i++] = (byte)((n & 0xFF0000) >> 16);
            buff[i++] = (byte)((n & 0xFF00) >> 8);
            buff[i++] = (byte)(n & 0xFF);

#if !BIGENDIAN
            Array.Reverse(buff, startIndex, 4);
#endif

            return 4;
        }

        public static int WriteFloat(float v, byte[] buff, int startindex)
        {
            int i = startindex;

            var temp = BitConverter.GetBytes(v);
#if !BIGENDIAN
            //Array.Reverse(captured);
#endif
            Buffer.BlockCopy(temp, 0, buff, startindex, 4);

            return 4;
        }

        //public static int WriteUInt32(uint n, byte[] buff, int startIndex)
        //{
        //    int i = startIndex;
        //    buff[i++] = (byte)(n >> 24);
        //    buff[i++] = (byte)((n & 0xFF0000) >> 16);
        //    buff[i++] = (byte)((n & 0xFF00) >> 8);
        //    buff[i++] = (byte)(n & 0xFF);
        //    return 4;
        //}
        //public static int ReadInt16(byte[] buff, int startindex)
        //{
        //    int i = startindex;
        //    return (buff[i] << 8) | buff[i + 1];
        //}
        //public static uint ReadUInt16(byte[] buff, int startindex)
        //{
        //    int i = startindex;
        //    return (uint)(buff[i] << 8) | buff[i + 1];
        //}
        public static int ReadInt32(byte[] buff, int startindex)
        {
            int i = startindex;

#if !BIGENDIAN
            var temp = new byte[4];
            Buffer.BlockCopy(buff, startindex, temp, 0, 4);
            Array.Reverse(temp);
            return ((temp[0] << 24) | (temp[1] << 16) | (temp[2] << 8) | temp[3]);
#endif
            return ((buff[i] << 24) | (buff[i + 1] << 16) | (buff[i + 2] << 8) | buff[i + 3]);
        }

        public static float ReadFloat(byte[] buff, int startindex)
        {
            int i = startindex;

            var temp = new byte[4];
            Buffer.BlockCopy(buff, startindex, temp, 0, 4);

#if !BIGENDIAN
            //Array.Reverse(captured);
#endif
            return BitConverter.ToSingle(temp, 0);
        }

        //public static uint ReadUInt32(byte[] buff, int startindex)
        //{
        //    int i = startindex;
        //    return (uint)((buff[i] << 24) | (buff[i + 1] << 16) | (buff[i + 2] << 8) | buff[i + 3]);
        //}

        /// <summary>
        /// 8비트중 오른쪽에서 bitOrdinal번째 비트가 0인지 1인지 리턴
        /// </summary>
        public static bool Extrct1BitFromRight(byte b, int bitOrdinal)
        {
            return ((b & (1 << bitOrdinal)) >> bitOrdinal) != 0;
        }

        /// <summary>
        /// 8비트중 왼쪽에서 bitOrdinal번째 비트가 0인지 1인지 리턴
        /// </summary>
        public static bool Extrct1BitFromLeft(byte b, int bitOrdinal)
        {
            return Extrct1BitFromRight(b, 7 - bitOrdinal);
        }

        public static byte[] ToBytes(this IBytesConvertable bc)
        {
            if (!bc.BytesCount.HasValue)
                throw new Exception("Can't calculate byte size");
            var bytes = new byte[bc.BytesCount.Value];
            bc.ToBytes(bytes);
            return bytes;
        }

        public static System.IO.BinaryReader NewReader(this System.IO.Stream stream, Encoding encoding, bool bigEndian)
        {
            if (bigEndian)
                return new Sasa.IO.PortableReader(stream, encoding);
            else
                return new System.IO.BinaryReader(stream, encoding);
        }
        public static System.IO.BinaryWriter NewWriter(this System.IO.Stream stream, Encoding encoding, bool bigEndian)
        {
            if (bigEndian)
                return new Sasa.IO.PortableWriter(stream, encoding);
            else
                return new System.IO.BinaryWriter(stream, encoding);
        }

        public static string ReadString(this System.IO.BinaryReader reader, Encoding encoding, int bytesCount)
        {
            return encoding.GetString(reader.ReadBytes(bytesCount));
        }
        public static void WriteString(this System.IO.BinaryWriter writer, string str, Encoding encoding, int bytesCount)
        {
            var _bytes = encoding.GetBytes(str);
            if (_bytes.Length < bytesCount)
            {
                writer.Write(_bytes);
                writer.Write(new byte[bytesCount - _bytes.Length]);
            }
            else if (_bytes.Length > bytesCount)
                writer.Write(_bytes, 0, bytesCount);
            else
                writer.Write(_bytes);
        }

        public static void WriteArray<T>(this System.IO.BinaryWriter _writer, IEnumerable<T> array) where T : struct
        {
            switch (Type.GetTypeCode(typeof(T)))
            {
                case TypeCode.Boolean: foreach (T v in array) _writer.Write((bool)(object)v); break;
                case TypeCode.Char: foreach (T v in array) _writer.Write((char)(object)v); break;
                case TypeCode.Decimal: foreach (T v in array) _writer.Write((decimal)(object)v); break;
                case TypeCode.Double: foreach (T v in array) _writer.Write((double)(object)v); break;
                case TypeCode.Single: foreach (T v in array) _writer.Write((float)(object)v); break;
                case TypeCode.Int16: foreach (T v in array) _writer.Write((Int16)(object)v); break;
                case TypeCode.Int32: foreach (T v in array) _writer.Write((Int32)(object)v); break;
                case TypeCode.Int64: foreach (T v in array) _writer.Write((Int64)(object)v); break;
                case TypeCode.Byte: foreach (T v in array) _writer.Write((byte)(object)v); break;
                case TypeCode.SByte: foreach (T v in array) _writer.Write((sbyte)(object)v); break;
                case TypeCode.UInt16: foreach (T v in array) _writer.Write((UInt16)(object)v); break;
                case TypeCode.UInt32: foreach (T v in array) _writer.Write((UInt32)(object)v); break;
                case TypeCode.UInt64: foreach (T v in array) _writer.Write((UInt64)(object)v); break;
                default: throw new ArgumentException("Not supported Type - " + typeof(T));
            }
        }

        public static byte CalBCC(this byte[] inputStream, int length)
        {
            byte bcc = 0;

            if (inputStream != null && inputStream.Length > 0)
            {
                for (int i = 0; i < length; i++)
                {
                    bcc ^= inputStream[i];
                }
            }

            return bcc;
        }
    }

    public interface IBytesConvertable
    {
        /// <summary>
        /// ToBytes의 결과의 크기를 미리 계산
        /// 지원하지 않는 경우 null리턴
        /// </summary>
        int? BytesCount { get; }

        int ToBytes(byte[] buffer, int offset = 0);
    }
}
