using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace NCCCommon.ModuleProtocol.OmapProtocol
{
    public class OmapDataReceiver : SingleTask
    {
        public OmapModule module;
        private TcpClient tcp;
        public event Action<DspMessage> MsgReceived;
        public SessionType SessionType { get; private set; }
        public int Port { get; private set; }

        public OmapDataReceiver(OmapModule module, SessionType sessionType, int port)
        {
            this.module = module;
            this.SessionType = sessionType;
            this.Port = port;
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
            stream.SendAsDspMessage(new DSPMsg_SessionInit { InitType = (int)SessionType });
            while (!token.IsCancellationRequested)
            {
                var msg = stream.ReadDspMessage();
                MsgReceived(msg);
            }
            stream.Close();
        }
    }
}
