using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCCCommon.ModuleProtocol.OmapProtocol
{
    public class OmapModule
    {
        public string ModuleIp { get; set; }
        public int DataPort = 4511;
        public int CommandPort = 4510;
        public ModuleType OmapModuleType { get; set; }
        public double WaveIntervalTime;
        public AlarmBufferMode ModuleAlarmBufferMode { get; set; }
        public OmapChannel[] SensorChannels { get; set; }
        public SimpleTimeTrigger TimeTrigger { get; set; }
        public long WaveReceiveCount;
        public bool IsTriggered;

        public OmapModule()
        {
            ModuleIp = "192.168.0.10";
            OmapModuleType = ModuleType.Vibration;
            ModuleAlarmBufferMode = AlarmBufferMode.Slow;
            SensorChannels = new OmapChannel[8];
            for (int i = 0; i < SensorChannels.Length; i++)
                SensorChannels[i] = new OmapChannel() { Id = i + 1, PhysicalCh = i };
            this.TimeTrigger = new SimpleTimeTrigger(TimeSpan.FromSeconds(WaveIntervalTime));
        }
    }
}
