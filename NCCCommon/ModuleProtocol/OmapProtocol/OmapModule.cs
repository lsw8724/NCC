﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCCCommon.ModuleProtocol.OmapProtocol
{
    public class OmapModule
    {
        public string Ip { get; set; }
        public int AsyncFMax { get; set; }
        public int AsyncLine { get; set; }
        public int HWGain { get; set; }
        public float Sensitivity { get; set; }
        public bool ICP { get; set; }
        public AlarmBufferMode AlarmBufferMode { get; set; }

        public Keyphasor[] KeyPhasors = new Keyphasor[2];
        public DisChannel[] Channels = new DisChannel[8];
        public int DataPort = 4511;
        public int CommandPort = 4510;

        public void Init()
        {
            for (int i = 0; i < KeyPhasors.Length; i++)
            {
                KeyPhasors[i] = new Keyphasor()
                {
                    Id = i+1,
                    ModuleId = 1,
                    PhysicalCh = i+1,
                    Angle = 0,
                    IsSimulated = 0,
                    SimulatedRpm = 0,
                    HysterisisVolt = 0,
                    AutoThreshold = 0,
                    ThresholdVolt = 0,
                    MaxRpm = 5000,
                    PulsePerRev = 1
                };
            }
            for (int i = 0; i < Channels.Length; i++)
            {
                Channels[i] = new DisChannel()
                {
                    Id = i + 4,
                    ModuleId = 1,
                    PhysicalCh = i + 1,
                    Angle = 45,
                    Active = 1,
                    TransducerUnit = (int)Unit1Type.g,
                    TransducerUnit2 = (int)Unit2Type.rms,
                    DisplayUnit = (int)Unit1Type.g,
                    KeyphasorId = 1,
                    Integral = 0,
                    Sensitivity = Sensitivity,
                    HWGain = HWGain,
                    Bandwidth = 0,
                    ICP = ICP ? 1 : 0,
                    nX = 3,
                    BandLow = 20,
                    BandHigh = 3200,
                    SyncSR = 128,
                    SyncRev = 8,
                    AsyncFMax = AsyncFMax,
                    AsyncLine = AsyncLine
                };
            }
        }
    }
}
