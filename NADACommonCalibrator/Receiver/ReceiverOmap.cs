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
    public class ReceiverOmap : SingleTask, IWavesReceiver
    {       
        public OmapModule Module = new OmapModule();
        private ModuleCommandConnection conn;
        private Queue<WaveData> WavesQueue = new Queue<WaveData>();

        public event Action<WaveData[]> WavesReceived;

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
                    WavesQueue.Enqueue(OmapWaveData.ParseWave(msg));
                    if (WavesQueue.Count >= 8)
                    {
                        var waves = new WaveData[8];
                        foreach(var wave in WavesQueue)
                            waves[wave.ChannelId - 4] = wave;
                        WavesReceived(waves);
                        WavesQueue.Clear();
                    }
                    break;
            }
        }      

        protected override void OnNewTask(CancellationToken token)
        {
            Module.Init();
            var vectorReceiver = new OmapDataReceiver(Module, SessionType.SessionType_Vector, Module.DataPort);
            var waveReceiver = new OmapDataReceiver(Module, SessionType.SessionType_Wave, Module.DataPort + 1);
            conn = new ModuleCommandConnection(Module, Module.CommandPort);

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
}
