using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCCCommon.ModuleProtocol.Daq5509Protocol
{
    public class DaqModule
    {
        public string ModuleIp { get; set; }
        public DaqChannel[] Channels { get; set; }
        public float[] scaleFactors;
        public DaqSamplingRate nSamplingRate;
        public int Fmax { get { return Channels[0].AsyncFMax; } }
        public int Line { get { return Channels[0].AsyncLine; } }
        public double AcquireSec { get { return (double)(Line / (double)Fmax); } }
        public TimeSpan TimeOffset { get; set; }

        public DaqInputType InputType { get; set; }
        public int PacketCountFor1Sec = 16;

        public DaqModule()
        {
            this.InputType = DaqInputType.AC;
            this.Channels = new DaqChannel[8];
            for (int i = 0; i < Channels.Length; i++)
                Channels[i] = new DaqChannel() { PhysicalIndex = i, Id = i + 1 };
          
            scaleFactors = new float[Channels.Length];
            foreach (var channel in Channels)
                scaleFactors[channel.PhysicalIndex] = channel.ScaleFactorByDisplayUnit();//channel.ScaleFactor;//db.GetChannel(ch + 1).ScaleFactor;

            if (!Enum.TryParse<DaqSamplingRate>("_" + (Channels[0].AsyncFMax * 2.56), out nSamplingRate))
                nSamplingRate = DaqSamplingRate._8192;
        }
    }
}
