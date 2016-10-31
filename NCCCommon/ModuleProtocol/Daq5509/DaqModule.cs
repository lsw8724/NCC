using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCCCommon.ModuleProtocol.Daq5509
{
    public class DaqModule
    {
        public string Ip { get; set; }
        public DaqSamplingRate SamplingRate { get; set; }
        public int AsyncFMax { get; set; }
        public int AsyncLine { get; set; }
        public DaqGain HWGain { get; set; }
        public float Sensitivity { get; set; }
        public DaqInputType InputType { get; set; }
        public bool ICP { get; set; }

        public TimeSpan TimeOffset { get; set; }
        public DaqChannel[] Channels;
        public int PacketCountFor1Sec = 16;
        public double AcquireSec { get { return (double)(AsyncLine / (double)AsyncFMax); } }

        public void Init()
        {
            Channels = new DaqChannel[8];
            for (int i = 0; i < Channels.Length; i++)
                Channels[i] = new DaqChannel()
                {
                    HWGain = this.HWGain,
                    PhysicalIndex = i, Id = i + 1,
                    AsyncFMax = this.AsyncFMax,
                    AsyncLine = this.AsyncLine,
                    Sensitivity = this.Sensitivity,
                    ICP = this.ICP,
                };
        }
    }

    public class DaqChannel
    {
        public int Id { get; set; }
        public int PhysicalIndex { get; set; }
        public int AsyncFMax { get; set; }
        public int AsyncLine { get; set; }
        public bool ICP { get; set; }
        public DaqGain HWGain { get; set; }
        public float Sensitivity { get; set; }
        public float ScaleFactors { get { return  1.0f; } }
    }
}
