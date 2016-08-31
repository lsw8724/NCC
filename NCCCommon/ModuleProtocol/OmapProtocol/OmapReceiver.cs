using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NCCCommon.ModuleProtocol.OmapProtocol
{
    public class OmapReceiver : SingleTask, IWavesReceiver
    {
        public string ModuleIp { get; set; }
        private int DataPort = 4511;
        private int CommandPort = 4510;
        public ModuleType OmapModuleType { get; set; }
        
        public AlarmBufferMode ModuleAlarmBufferMode { get; set; }
        public SensorChannel[] SensorChannels { get; set; }

        private TcpClient tcp;

        public double WaveIntervalTime;

        public event Action<WaveData[]> WavesReceived;

        public long WaveReceiveCount;

        internal SimpleTimeTrigger TimeTrigger { get; set; }

        public bool IsTriggered;

        public OmapReceiver()
        {
            OmapModuleType = ModuleType.Vibration;
            ModuleAlarmBufferMode = AlarmBufferMode.Slow;
            SensorChannels = new SensorChannel[8];
            for (int i = 0; i < SensorChannels.Length; i++)
                SensorChannels[i] = new SensorChannel() { Id = i + 1, PhysicalCh = i };
            this.TimeTrigger = new SimpleTimeTrigger(TimeSpan.FromSeconds(WaveIntervalTime));
        }

        protected override void OnNewTask(CancellationToken token)
        {
            //ReconnectLoop
            while (!token.IsCancellationRequested)
            {
                try
                {
                    WriteLog("Connecting");
                    tcp = new TcpClient();
                    tcp.ReceiveTimeout = 5000;
                    //tcp.Connect(module.IP, module.Port + 1);
                    var result = tcp.BeginConnect(ModuleIp, DataPort + 1, null, null);
                    bool success = result.AsyncWaitHandle.WaitOne(new TimeSpan(0, 0, 5), true);
                    if (!success)
                        throw new Exception("Connect Timeout");

                    ReadLoop(token);

                    WriteLog("Closing");
                    tcp.Close();
                }
                catch (Exception ex)
                {
                    WriteLog("Error - " + ex);
                    Thread.Sleep(100);
                }
            }
        }

        private void ReadLoop(CancellationToken token)
        {
            var stream = tcp.GetStream();
            stream.SendAsDspMessage(new SessionInit { InitType = (int)SessionType.SessionType_Wave });
            int nReadCount = 0;
            while (!token.IsCancellationRequested)
            {
                var msg = stream.ReadDspMessage();
                if (msg.Type != MsgType.MsgType_Data_ModuleWaves)
                    continue;

                var waves = ModuleWaves.Parse(msg);
                IsTriggered = TimeTrigger.FetchTrigger();
                if (IsTriggered)
                    WaveReceiveCount++;

                if (nReadCount++ % 300 == 0)
                    WriteLog("Wave Receives - Triggered:" + WaveReceiveCount + ", Read:" + nReadCount);

                var waveDatas = new WaveData[] { waves[0], waves[1], waves[2], waves[3], waves[4], waves[5], waves[6], waves[7] };
                WavesReceived(waveDatas);
            }
            stream.Close();
        }
    }

    public class SensorChannel
    {
        public int Id { get; set; }
        public int PhysicalCh { get; set; }
        public int Angle { get; set; }
        public ChannelType ChannelType { get; set; }
        public bool RecordOutActive { get; set; }
        public int MROType;
        public int MRORange;
        public int MRORangeLow;

        public SensorChannel()
        {
            ChannelType = ChannelType.Accelate;
            Angle = 45;
        }
    }

    [DspMsg(MsgType.MsgType_Session_Init)]
    [StructLayout(LayoutKind.Sequential)]
    public struct SessionInit
    {
        public int InitType;
    }
}
