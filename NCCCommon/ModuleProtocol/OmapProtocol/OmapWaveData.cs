using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace NCCCommon.ModuleProtocol.OmapProtocol
{
    [DspMsg(MsgType.MsgType_Data_WaveData)]
    [StructLayout(LayoutKind.Sequential)]
    public struct OmapWaveData
    {
        public uint Idx;
        public int ChannelId;
        public int SaveType;
        public UtcAndMiliseconds DateTime;
        public float Rpm;
        public int SyncDataCount;
        public int AsyncDataCount;
        public float[] SyncData;
        public float[] AsyncData;

        public static WaveData Parse(DspMessage msg)
        {
            var data = new WaveData();
            int i = 0;
            var buff = msg.Data;

            i += ReadHeader(ref data, i, buff);

            i += ReadBody(ref data, i, buff);

            return data;
        }

        public static WaveData ParseHeader(DspMessage msg)
        {
            var data = new WaveData();
            int i = 0;
            var buff = msg.Data;
            ReadHeader(ref data, i, buff);

            return data;
        }

        internal static int ReadHeader(ref WaveData data, int i, byte[] buff)
        {
            data.Idx = (uint)ByteUtil.ReadInt32(buff, i);
            i += 4;
            data.ChannelId = ByteUtil.ReadInt32(buff, i);
            i += 4;
            data.SaveType = ByteUtil.ReadInt32(buff, i);
            i += 4;

            var utcSeconds = ByteUtil.ReadInt32(buff, i);
            i += 4;
            var Miliseconds = ByteUtil.ReadInt32(buff, i);
            i += 4;

            data.DateTime = new DateTime(1970,1,1,0,0,0).AddSeconds(utcSeconds).AddMilliseconds(Miliseconds/1000);

            data.Rpm = ByteUtil.ReadFloat(buff, i);
            i += 4;

            data.SyncDataCount = ByteUtil.ReadInt32(buff, i);
            i += 4;
            data.AsyncDataCount = ByteUtil.ReadInt32(buff, i);
            i += 4;

            //아래는 C구조체의 주소 저장부분
            i += 4;
            i += 4;

            return i;
        }

        internal static int ReadBody(ref WaveData data, int i, byte[] buff)
        {
            data.SyncData = new float[data.SyncDataCount];
            int syncDataSize = sizeof(float) * data.SyncDataCount;
            Buffer.BlockCopy(buff, i, data.SyncData, 0, syncDataSize);
            i += syncDataSize;

            data.AsyncData = new float[data.AsyncDataCount];
            int asyncDataSize = sizeof(float) * data.AsyncDataCount;
            var overSize = (asyncDataSize + i) - buff.Length;
            if (overSize > 0)
                asyncDataSize -= overSize;

            Buffer.BlockCopy(buff, i, data.AsyncData, 0, asyncDataSize);
            i += asyncDataSize;
            return i;
        }

        public byte[] ToBytes()
        {
            int syncDataSize = sizeof(float) * SyncDataCount;
            int asyncDataSize = sizeof(float) * AsyncDataCount;

            var buff = new byte[8 * 4 + syncDataSize + asyncDataSize + 2 * 4];
            int i = 0;

            i += ByteUtil.WriteInt32((int)Idx, buff, i);
            i += ByteUtil.WriteInt32((int)ChannelId, buff, i);
            i += ByteUtil.WriteInt32((int)SaveType, buff, i);
            i += ByteUtil.WriteInt32(DateTime.UtcSeconds, buff, i);
            i += ByteUtil.WriteInt32((int)DateTime.Miliseconds, buff, i);
            i += ByteUtil.WriteFloat(Rpm, buff, i);
            i += ByteUtil.WriteInt32(SyncDataCount, buff, i);
            i += ByteUtil.WriteInt32(AsyncDataCount, buff, i);

            i += 4;
            i += 4;

            Buffer.BlockCopy(SyncData, 0, buff, i, syncDataSize);
            i += syncDataSize;

            Buffer.BlockCopy(AsyncData, 0, buff, i, asyncDataSize);
            i += asyncDataSize;

            return buff;
        }
    }

}
