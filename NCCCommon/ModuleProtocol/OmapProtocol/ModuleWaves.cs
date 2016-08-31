using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace NCCCommon.ModuleProtocol.OmapProtocol
{
    [DspMsg(MsgType.MsgType_Data_ModuleWaves)]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class ModuleWaves
    {
        public int ModuleId;
        //public UtcAndMiliseconds DateTime;

        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.LPStruct, SizeConst = 8)]
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        //public VectorData Vectors[8];
        public WaveData Wave0;

        public WaveData Wave1;
        public WaveData Wave2;
        public WaveData Wave3;
        public WaveData Wave4;
        public WaveData Wave5;
        public WaveData Wave6;
        public WaveData Wave7;
 
        public bool HasChannelData(int chId)
        {
            if (chId == Wave0.ChannelId) return true;
            if (chId == Wave1.ChannelId) return true;
            if (chId == Wave2.ChannelId) return true;
            if (chId == Wave3.ChannelId) return true;
            if (chId == Wave4.ChannelId) return true;
            if (chId == Wave5.ChannelId) return true;
            if (chId == Wave6.ChannelId) return true;
            if (chId == Wave7.ChannelId) return true;
            return false;
        }

        //public WaveData? FindByChannel(int chId)
        //{
        //    if (chId == Wave0.ChannelId) return Wave0;
        //    if (chId == Wave1.ChannelId) return Wave1;
        //    if (chId == Wave2.ChannelId) return Wave2;
        //    if (chId == Wave3.ChannelId) return Wave3;
        //    if (chId == Wave4.ChannelId) return Wave4;
        //    if (chId == Wave5.ChannelId) return Wave5;
        //    if (chId == Wave6.ChannelId) return Wave6;
        //    if (chId == Wave7.ChannelId) return Wave7;
        //    return null;
        //}

        public static ModuleWaves Parse(DspMessage msg)
        {
            return Parse(msg, null);
        }

        public static ModuleWaves Parse(DspMessage msg, TimeSpan? timeOffset)
        {
            var waves = new ModuleWaves();
            int i = 0;
            var buff = msg.Data;

            for (int ch = 0; ch < 8; ch++)
            {
                var data = new WaveData();
                i = OmapWaveData.ReadHeader(ref data, i, buff);
                i = OmapWaveData.ReadBody(ref data, i, buff);
                //if (timeOffset != null)
                //{
                //    var newTime = data.DateTime + timeOffset.Value;
                //    data.DateTime = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(newTime.ToUtcSeconds()).AddMilliseconds(newTime.Millisecond);
                //}
                waves[ch] = data;
            }

            return waves;
        }

        //public void ClearTime()
        //{
        //    Wave0.DateTime.SetZero();
        //    Wave1.DateTime.SetZero();
        //    Wave2.DateTime.SetZero();
        //    Wave3.DateTime.SetZero();
        //    Wave4.DateTime.SetZero();
        //    Wave5.DateTime.SetZero();
        //    Wave6.DateTime.SetZero();
        //    Wave7.DateTime.SetZero();
        //}
        //public void SetTime(DateTime newtime)
        //{
        //    var time = new UtcAndMiliseconds(newtime, false);
        //    Wave0.DateTime = time;
        //    Wave1.DateTime = time;
        //    Wave2.DateTime = time;
        //    Wave3.DateTime = time;
        //    Wave4.DateTime = time;
        //    Wave5.DateTime = time;
        //    Wave6.DateTime = time;
        //    Wave7.DateTime = time;
        //}

        //public bool AllHasTime()
        //{
        //    for (int i = 0; i < 8; i++)
        //    {
        //        if (this[i].DateTime.IsZero)
        //            return false;
        //    }
        //    return true;
        //}

        public WaveData this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0: return Wave0;
                    case 1: return Wave1;
                    case 2: return Wave2;
                    case 3: return Wave3;
                    case 4: return Wave4;
                    case 5: return Wave5;
                    case 6: return Wave6;
                    case 7: return Wave7;
                }
                throw new Exception("Out of index:" + i);
            }

            set
            {
                switch (i)
                {
                    case 0: Wave0 = value; return;
                    case 1: Wave1 = value; return;
                    case 2: Wave2 = value; return;
                    case 3: Wave3 = value; return;
                    case 4: Wave4 = value; return;
                    case 5: Wave5 = value; return;
                    case 6: Wave6 = value; return;
                    case 7: Wave7 = value; return;
                }
                throw new Exception("Out of index:" + i);
            }
        }
    }
}
