using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Sockets;
using System.IO;

namespace NCCCommon.ModuleProtocol.Wifi
{
    public class ReceiverWifi : SingleTask, IWavesReceiver
    {
        public WifiModule Module = new WifiModule();
        private WifiConnection Conn;
        List<float> RxDatas = new List<float>();

        object IGetterRcvProperty.Module { get { return this.Module; } }
        public int AsyncFMax { get { return Module.AsyncFMax; } }
        public int AsyncLine { get { return Module.AsyncLine; } }
        public int ChannelCount { get { return 1; } }

        public event Action<IReceiveData[]> DatasReceived;

        public override string ToString()
        {
            return "ReceiverWifi";
        }

        protected override void OnNewTask(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    Conn = new WifiConnection(Module);
                    Conn.Connect(Module.Ip, Module.Port, 5000);
                    Conn.SendRateConfig();
                    Conn.SendCmd("AT+START");
                    
                    ReadLoop(token);

                    Conn.SendCmd("AT+STOP");
                    Conn.DisConnect();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error - " + ex);
                    Thread.Sleep(100);
                    throw ex;
                }
            }
        }
     
        private void ReadLoop(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    var packet = Conn.ReceivePacket();
                    RxDatas.AddRange(Array.ConvertAll(packet.Payload, x => (float)x/25000f));

                    if (RxDatas.Count >= Module.SampleRate)
                    {
                        WaveData wave = new WaveData()
                        {
                            DateTime = DateTime.Now,
                            AsyncDataCount = Module.SampleRate,
                            AsyncData = RxDatas.Where((x, i) => i < Module.SampleRate).ToArray()
                        };
                        DatasReceived(new WaveData[] { wave });
                        RxDatas.RemoveRange(0, Module.SampleRate);
                    }
                }
                catch{}
            }
        }

        public Dictionary<string, int> KpMap
        {
            get
            {
                return null;
            }
        }
    }
}
