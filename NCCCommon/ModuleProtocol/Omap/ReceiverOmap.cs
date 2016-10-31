using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace NCCCommon.ModuleProtocol.Omap
{
    public class ReceiverOmap : SingleTask, IWavesReceiver
    {       
        public OmapModule Module = new OmapModule();
        private ModuleCommandConnection Conn;
        private Queue<WaveData> WavesQueue = new Queue<WaveData>();
        private Queue<VectorData> VectorsQueue = new Queue<VectorData>();

        object IModuleConfig.Module { get { return this.Module; } }
        public int AsyncFMax { get { return Module.AsyncFMax; } }
        public int AsyncLine { get { return Module.AsyncLine; } }
        public int ChannelCount { get { return 8; } }

        public event Action<IReceiveData[]> DatasReceived;

        public override string ToString()
        {
            return "ReceiverOmap";
        }

        void ReceiverOmap_MsgReceived(DspMessage msg)
        {
            switch (msg.Type)
            {
                case MsgType.MsgType_Data_VectorData:
                    var vector = msg.GetDataAsStruct<DSPMsg_VectorData>();
                    if ((DataSaveType)vector.SaveType != DataSaveType.TimeSave)
                    {
                        var vectors = new VectorData[8];
                        foreach (var vec in VectorsQueue)
                            vectors[vec.ChannelId - 4] = vec;
                        DatasReceived(vectors);
                        VectorsQueue.Clear();
                    }
                    break;

                case MsgType.MsgType_Data_WaveData:
                    WavesQueue.Enqueue(DSPMsg_WaveData.ParseWave(msg));
                    if (WavesQueue.Count >= ChannelCount)
                    {
                        var waves = new WaveData[8];
                        foreach(var wave in WavesQueue)
                            waves[wave.ChannelId - 4] = wave;
                        DatasReceived(waves);
                        WavesQueue.Clear();
                    }
                    break;
            }
        }      

        protected override void OnNewTask(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    Module.Init();
                    var vectorReceiver = new OmapDataReceiver(Module, SessionType.SessionType_Vector, Module.DataPort);
                    var waveReceiver = new OmapDataReceiver(Module, SessionType.SessionType_Wave, Module.DataPort + 1);
                    Conn = new ModuleCommandConnection(Module, Module.CommandPort);
                    waveReceiver.MsgReceived += ReceiverOmap_MsgReceived;
                    vectorReceiver.MsgReceived += ReceiverOmap_MsgReceived;
                    if (!Conn.Connect())
                    {
                        Thread.Sleep(1000);
                        continue;
                    }
                    Conn.SendConfigs();

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
                Conn.Send(MsgType.MsgType_Cmd_RealTime);
            }
        }
    } 
}
