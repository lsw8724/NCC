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
using System.Diagnostics;

namespace NADACommonCalibrator.Receiver
{
    public class ReceiverOmap : IWavesReceiver
    {
        public OmapModule Module = new OmapModule();
        public event Action<WaveData[]> WavesReceived;

        public OmapCommandTask commandTask { get;set;}
        public OmapDataReceiver waveReceiver { get; set; }
        public OmapDataReceiver vectorReceiver { get; set; }
        private WaveData[] Waves = new WaveData[8];

        void ReceiverOmap_MsgReceived(DspMessage msg)
        {
            Console.WriteLine(msg.Type.ToString());
            switch (msg.Type)
            {
                case MsgType.MsgType_Data_VectorData:
                    var vector = msg.GetDataAsStruct<VectorData>();
                    vector.GetType();
                    if ((DataSaveType)vector.SaveType == DataSaveType.TimeSave) return;
                    break;

                case MsgType.MsgType_Data_WaveData: 
                    var wave = OmapWaveData.ParseWave(msg);
                    Waves[wave.ChannelId - 4] = wave;
                    if(!Waves.Contains(null))
                        WavesReceived(Waves);
                    break;
            }            
        }       

        public void Start()
        {
            Module.Init();

            vectorReceiver = new OmapDataReceiver(Module, SessionType.SessionType_Vector, Module.DataPort);
            waveReceiver = new OmapDataReceiver(Module, SessionType.SessionType_Wave, Module.DataPort + 1);
            commandTask = new OmapCommandTask(Module, vectorReceiver, waveReceiver);

            waveReceiver.MsgReceived += ReceiverOmap_MsgReceived;
            vectorReceiver.MsgReceived += ReceiverOmap_MsgReceived;
            commandTask.Start();
        }

        public void Stop()
        {
            commandTask.Stop();
            vectorReceiver.Stop();
            waveReceiver.Stop();
        }

        public void Dispose()
        {
        }
    }

    public class OmapCommandTask : SingleTask
    {
        public OmapModule module;
        public ModuleCommandConnection conn;
        private OmapDataReceiver vectorReceiver;
        private OmapDataReceiver waveReceiver;

        public OmapCommandTask(OmapModule module, OmapDataReceiver vectorTask, OmapDataReceiver waveTask) 
        {
            this.module = module;
            this.vectorReceiver = vectorTask;
            this.waveReceiver = waveTask;
            conn = new ModuleCommandConnection(module, module.CommandPort);
        }

        protected override void OnNewTask(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    if (!conn.Connect())
                    {
                        Thread.Sleep(1000);
                        continue;
                    }
                    conn.SendConfigs();

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

    public class OmapDataReceiver : SingleTask
    {
        public OmapModule module;
        private TcpClient tcp;

        public event Action<DspMessage> MsgReceived;

        public long WaveReceiveCount { get; set; }

        internal SimpleTimeTrigger TimeTrigger { get; set; }

        public bool IsTriggered { get; set; }

        public SessionType SessionType { get; private set; }

        public int Port { get; private set; }

        public OmapDataReceiver(OmapModule module, SessionType sessionType, int port)
        {
            this.module = module;
            this.SessionType = sessionType;
            this.Port = port;
            this.TimeTrigger = new SimpleTimeTrigger(TimeSpan.FromSeconds(1));
        }

        protected override void OnNewTask(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    tcp = new TcpClient();
                    tcp.ReceiveTimeout = 5000;
                    var result = tcp.BeginConnect(module.Ip, Port, null, null);
                    bool success = result.AsyncWaitHandle.WaitOne(new TimeSpan(0, 0, 5), true);
                    if (!success)
                        throw new Exception("Connect Timeout");

                    ReadLoop(token);

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
            while (!token.IsCancellationRequested)
            {
                var msg = stream.ReadDspMessage();
                MsgReceived(msg);
            }
            stream.Close();
        }
    }
}
