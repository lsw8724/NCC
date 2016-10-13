 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCCCommon.ModuleProtocol.OmapProtocol;
using NCCCommon.ModuleProtocol;
using NCCCommon;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.InteropServices;

namespace NADACommonCalibrator.Receiver
{
    public class ReceiverOmap : SingleTask, IWavesReceiver
    {
        public OmapModule Module;
        public TcpClient tcp;
        public event Action<WaveData[]> WavesReceived;

        public Dictionary<int, OmapCommandTask> commandTasks = new Dictionary<int, OmapCommandTask>();
        public Dictionary<int, OmapDataReceiver> waveReceivers = new Dictionary<int, OmapDataReceiver>();
        public Dictionary<int, OmapDataReceiver> vectorReceivers = new Dictionary<int, OmapDataReceiver>();

        public ReceiverOmap(OmapModule module)
        {
            Module = module;
            vectorReceivers.Add(module.Id, new OmapDataReceiver(module, SessionType.SessionType_Vector, module.DataPort, "Omap.Vec." + module.ModuleIp));
            waveReceivers.Add(module.Id, new OmapDataReceiver(module, SessionType.SessionType_Wave, module.DataPort + 1, "Omap.Wav." + module.ModuleIp));
            commandTasks.Add(module.Id, new OmapCommandTask(module, new CancellationTokenSource(), vectorReceivers[module.Id], waveReceivers[module.Id]));
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
                    var result = tcp.BeginConnect(Module.ModuleIp, Module.DataPort + 1, null, null);
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
            while (!token.IsCancellationRequested)
            {
                var msg = stream.ReadDspMessage();
                if (msg.Type != MsgType.MsgType_Data_ModuleWaves)
                    continue;

                var waves = ModuleWaves.Parse(msg);
                Module.IsTriggered = Module.TimeTrigger.FetchTrigger();
                if (Module.IsTriggered)
                    Module.WaveReceiveCount++;

                var waveDatas = new WaveData[] { waves[0], waves[1], waves[2], waves[3], waves[4], waves[5], waves[6], waves[7] };
                WavesReceived(waveDatas);
            }
            stream.Close();
        }

        [DspMsg(MsgType.MsgType_Session_Init)]
        [StructLayout(LayoutKind.Sequential)]
        public struct SessionInit
        {
            public int InitType;
        }
    }

    internal class OmapCommandTask : SingleTask
    {
        private OmapModule module;
        public ModuleCommandConnection conn;
        private OmapDataReceiver vectorReceiver;
        private OmapDataReceiver waveReceiver;
        public OmapCommandTask(OmapModule module, CancellationTokenSource cts, OmapDataReceiver vectorTask, OmapDataReceiver waveTask)
            : base(cts, "Cmd" + module.Name, "Cmd" + module.Name)
        {
            this.module = module;
            this.vectorReceiver = vectorTask;
            this.waveReceiver = waveTask;
            conn = new ModuleCommandConnection(module, module.CommandPort, new ModuleOptions(), channelConfig);
        }

        protected override void OnNewTask(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    WriteLog("Connecting");
                    if (!conn.Connect())
                    {
                        Thread.Sleep(1000);
                        continue;
                    }
                    conn.SendConfigs();
                    WriteLog("Configs Sent");

                    Thread.Sleep(500);
                    vectorReceiver.Start();
                    waveReceiver.Start();

                    OnConnected(token);
                }
                catch (Exception ex)
                {
                    WriteLog("Error - " + ex);
                }
            }
        }

        private void OnConnected(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                Thread.Sleep(1000);
                conn.Send(MsgType.MsgType_Cmd_RealTime);
            }
        }
    }

    internal class OmapDataReceiver : SingleTask
    {
        private OmapModule module;
        private TcpClient tcp;

        public event Action<ModuleWaves> WaveReceived;
        public event Action<DspMessage> MsgReceived;

        public long WaveReceiveCount { get; set; }

        internal SimpleTimeTrigger TimeTrigger { get; set; }

        public bool IsTriggered { get; set; }

        public SessionType SessionType { get; private set; }

        public int Port { get; private set; }

        public OmapDataReceiver(OmapModule module, SessionType sessionType, int port, string traceName)
        {
            this.module = module;
            this.SessionType = sessionType;
            this.Port = port;
            this.TimeTrigger = new SimpleTimeTrigger(TimeSpan.FromSeconds(1));
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
                    var result = tcp.BeginConnect(module.ModuleIp, Port, null, null);
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
            stream.SendAsDspMessage(new SessionInit { InitType = (int)SessionType });
            int nReadCount = 0;
            while (!token.IsCancellationRequested)
            {
                var msg = stream.ReadDspMessage();
                MsgReceived(msg);

                //for (int i = 0; i < 12;i++)
                //{
                //    if(msg.Data != null)
                //        Console.WriteLine();
                //}

                if (msg.Type != MsgType.MsgType_Data_ModuleWaves)
                    continue;

                //테스트
                //stream.SendAsDspMessage(new HeartBeat());

                var waves = ModuleWaves.Parse(msg);
                IsTriggered = TimeTrigger.FetchTrigger();
                if (IsTriggered)
                    WaveReceiveCount++;

                if (nReadCount++ % 300 == 0)
                    WriteLog("Wave Receives - Triggered:" + WaveReceiveCount + ", Read:" + nReadCount);

                WaveReceived(waves);
            }
            stream.Close();
        }
    }
}
