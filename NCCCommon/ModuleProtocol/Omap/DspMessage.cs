using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace NCCCommon.ModuleProtocol.Omap
{
    public class DspMessage : IBytesConvertable
    {
        /// <summary>
        /// 헤더 전체 길이
        /// </summary>
        public const int HeaderSize = 16;

        public const int Prefix1 = 0115065117;
        public const int Prefix2 = 01074040661;

        public MsgType Type { get; set; }
        public int Size { get; set; }
        public byte[] Data { get; set; }

        public int Received = 0;

        public int? BytesCount
        {
            get { return CurrentPacketSize; }
        }

        public int CurrentPacketSize
        {
            get { return Data == null ? HeaderSize : HeaderSize + Data.Length; }
        }

        public byte[] ToBytes()
        {
            var bytes = new byte[CurrentPacketSize];
            ToBytes(bytes);
            return bytes;
        }

        public int ToBytes(byte[] bytes, int offset = 0)
        {
            if (offset < 0 || offset >= bytes.Length)
                throw new ArgumentOutOfRangeException("offset");

            var resultSize = CurrentPacketSize;
            if (bytes.Length < offset + resultSize)
                throw new ArgumentException("Not enough buffer size - Required:" + resultSize +", BufferSize:" + bytes.Length + ", offset:" + offset, "bytes");

            if (Data != null)
            {
                int i = offset;
                ByteUtil.WriteInt32(Prefix1, bytes, i);
                i += 4;
                ByteUtil.WriteInt32(Prefix2, bytes, i);
                i += 4;
                ByteUtil.WriteInt32((int)Type, bytes, i);
                i += 4;
                ByteUtil.WriteInt32(Size, bytes, i);
                i += 4;
                Buffer.BlockCopy(Data, 0, bytes, i, Data.Length);
                i += Data.Length;
                return i;
            }
            else
            {
                int i = offset;
                ByteUtil.WriteInt32(Prefix1, bytes, i);
                i += 4;
                ByteUtil.WriteInt32(Prefix2, bytes, i);
                i += 4;
                ByteUtil.WriteInt32((int)Type, bytes, i);
                i += 4;
                ByteUtil.WriteInt32(Size, bytes, i);
                i += 4;
                return HeaderSize;
            }
        }

        public T GetDataAsStruct<T>() where T : struct
        {
            var fieldsCount = typeof(T).GetFields().Length;
            //빈 구조체인 경우
            if (fieldsCount == 0)
            {
                var attr = typeof(T).GetCustomAttributes(typeof(DspMsgAttribute), false).OfType<DspMsgAttribute>().First();
                if (this.Type != attr.MsgType)
                    throw new Exception("Type mismatch - this.Type:"+ Type + ", " + attr.MsgType);
                return new T();
            }

            int size = Marshal.SizeOf(typeof(T));
            if (Data == null)
                throw new Exception("Invalid casting - Data:null, Target struct size:" + size);
            if (size > Data.Length)
                throw new Exception("Invalid casting - DataLength:" + Data.Length + ", Target struct size:" + size);

            //pinned로 최적화. http://www.matthew-long.com/2005/10/18/memory-pinning/ 참조
            //var ptr = IntPtr.Zero;
            var pinnedRawData = GCHandle.Alloc(Data, GCHandleType.Pinned);
            T structValue;
            try
            {
                var pinnedRawDataPtr = pinnedRawData.AddrOfPinnedObject();
                structValue = (T)Marshal.PtrToStructure(pinnedRawDataPtr, typeof(T));

                //ptr = Marshal.AllocHGlobal(size);
                //Marshal.Copy(Data, 0, ptr, size);
                //structValue = (T)Marshal.PtrToStructure(ptr, typeof(T));
            }
            finally
            {
                pinnedRawData.Free();
                //if (ptr != IntPtr.Zero)
                //    Marshal.FreeHGlobal(ptr);
            }
            return structValue;
        }

        public void SetData<T>(T obj) where T : struct
        {
            var fieldsCount = typeof(T).GetFields().Length;

            var attr = typeof(T).GetCustomAttributes(typeof(DspMsgAttribute), false).OfType<DspMsgAttribute>().First();
            Type = attr.MsgType;
            if (fieldsCount == 0)
            {
                Size = 0;
                Data = null;
            }
            else
            {
                Size = Marshal.SizeOf(obj);
                Data = new byte[Size];

                //IntPtr ptr = Marshal.AllocHGlobal(Size);
                //Marshal.StructureToPtr(obj, ptr, true);
                //Marshal.Copy(ptr, Data, 0, Size);
                //Marshal.FreeHGlobal(ptr);

                var pinnedRawData = GCHandle.Alloc(Data, GCHandleType.Pinned);
                try
                {
                    Marshal.StructureToPtr((object)obj, pinnedRawData.AddrOfPinnedObject(), false);
                }
                finally
                {
                    pinnedRawData.Free();
                }
            }
        }

        public DspMessage()
        {
        }

        public DspMessage(MsgType type, byte[] data)
        {
            Type = type;
            Size = data.Length;
            Data = data;
        }

        public static DspMessage FromStruct<T>(T obj) where T : struct
        {
            var msg = new DspMessage();
            msg.SetData(obj);
            return msg;
        }

        //public static DspMessage ReadFrom(TcpSocket s)
        //{
        //    var headerBuffer = s.Read(HeaderSize);

        //    int i = 0;
        //    int prefix1 = ByteUtil.ReadInt32(headerBuffer, i);
        //    i += 4;
        //    int prefix2 = ByteUtil.ReadInt32(headerBuffer, i);
        //    i += 4;

        //    if (prefix1 != DspMessage.Prefix1 || prefix2 != DspMessage.Prefix2)
        //        throw new Exception("Wrong Prefix - " + prefix1 + ", " + prefix2);

        //    MsgType msgType = (MsgType)ByteUtil.ReadInt32(headerBuffer, i);
        //    i += 4;

        //    int msgSize = ByteUtil.ReadInt32(headerBuffer, i);
        //    i += 4;

        //    Debug.WriteLine("DspMsg Read - type:" + msgType + ", size:" + msgSize);

        //    DspMessage msg;
        //    if (msgSize <= 0)
        //    {
        //        msg = new DspMessage { Type = msgType, Size = msgSize };
        //    }
        //    else
        //    {
        //        var msgBuffer = s.Read(msgSize);
        //        msg = new DspMessage { Type = msgType, Size = msgSize, Data = msgBuffer };
        //    }

        //    return msg;
        //}

        //public static void Send<T>(TcpSocket s, T body) where T : struct
        //{
        //    var msg = new DspMessage();
        //    msg.SetData<T>(body);
        //    s.Send(msg.ToBytes());
        //}

        public bool IsResponse
        {
            get { return ((int)Type & 0xFF00) == 0x0000; }
        }
        public bool IsCommand
        {
            get { return ((int)Type & 0xFF00) == 0x0100; }
        }
        public bool IsConfig
        {
            get { return ((int)Type & 0xFF00) == 0x0200; }
        }
        public bool IsData
        {
            get { return ((int)Type & 0xFF00) == 0x0300; }
        }
    }
}
