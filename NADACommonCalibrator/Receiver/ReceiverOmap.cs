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

        public ReceiverOmap(OmapModule module)
        {
            Module = module;
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
}
