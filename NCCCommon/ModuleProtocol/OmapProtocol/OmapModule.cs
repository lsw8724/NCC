using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCCCommon.ModuleProtocol.OmapProtocol
{
    public class OmapModule
    {
        public int Id { get; set; }
        public string ModuleIp { get; set; }
        public int DataPort = 4511;
        public int CommandPort = 4510;
        public ModuleType OmapModuleType { get; set; }
        public double WaveIntervalTime;
        public AlarmBufferMode ModuleAlarmBufferMode { get; set; }
        public OmapChannel[] Channels { get; set; }
        public SimpleTimeTrigger TimeTrigger { get; set; }
        public long WaveReceiveCount;
        public bool IsTriggered;

        public OmapModule()
        {
            OmapModuleType = ModuleType.Vibration;
            ModuleAlarmBufferMode = AlarmBufferMode.Slow;
            Channels = new OmapChannel[8];
            for (int i = 0; i < Channels.Length; i++)
                Channels[i] = new OmapChannel() 
                {
                    Id = i + 1,
                    PhysicalIndex = i,
                    Angle = 45, 
                    MROType = 0,
                    MRORange = 150,
                    MRORangeLow = 0,
                 
                    TransducerUnit = Unit1Type.g,
                    Rectification = 0,
                    Sensitivity = 7.87f,
                    HWGain = 1,
                    Bandwidth = 0,
                    ICP = true,
                    DisplayUnit = Unit1Type.g,
                    Integral = 0,
                    PairChannelId =0,
                    TransducerUnit2 = Unit2Type.rms,
                    KeyphasorId = 0,
                    AngleDirection = AngleDirection.Left,
                    Shaft = ShaftDirection.CCW,
                    CorrectionValue = 1,
                    Offset =0,

                    nX = 3,
                    BandLow = 20,
                    BandHigh = 3200,
                    SyncSR = 128,
                    SyncRev =8,
                    AsyncFMax = 3200,
                    AsyncLine = 3200
                };
            this.TimeTrigger = new SimpleTimeTrigger(TimeSpan.FromSeconds(WaveIntervalTime));
        }
    }

    public class OmapChannel
    {
        public int Id { get; set; }
        public int PhysicalIndex {get;set;}
        public int Angle{get;set;}
        public int MROType{get;set;}
        public int MRORange{get;set;}
        public int MRORangeLow{get;set;}

        public Unit1Type TransducerUnit{get;set;}
        public int Rectification{get;set;}
        public float Sensitivity{get;set;}
        public int HWGain{get;set;}
        public int Bandwidth{get;set;}
        public bool ICP{get;set;}
        public Unit1Type DisplayUnit{get;set;}
        public int Integral{get;set;}
        public int PairChannelId{get;set;}
        public Unit2Type TransducerUnit2{get;set;}
        public int KeyphasorId{get;set;}
        public AngleDirection AngleDirection{get;set;}
        public ShaftDirection Shaft{get;set;}
        public float CorrectionValue{get;set;}
        public float Offset{get;set;}

        public float nX{get;set;}
        public int BandLow{get;set;}
        public int BandHigh{get;set;}
        public int SyncSR{get;set;}
        public int SyncRev{get;set;}
        public int AsyncFMax{get;set;}
        public int AsyncLine{get;set;}
    }
}
