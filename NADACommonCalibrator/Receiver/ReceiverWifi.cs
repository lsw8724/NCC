using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCCCommon.ModuleProtocol.WifiProtocol;
using NCCCommon.ModuleProtocol.OmapProtocol;
using NCCCommon.ModuleProtocol;
using NCCCommon;
using System.Threading;
using System.Net.Sockets;
using System.IO;

namespace NADACommonCalibrator.Receiver
{
    public class ReceiverWifi : SingleTask, IWavesReceiver
    {
        public WifiModule Module = new WifiModule();
        public TcpClient WfsClient = new TcpClient();
        List<float> RxDatas = new List<float>();

        public int AsyncFMax { get { return Module.AsyncFMax; } }
        public int AsyncLine { get { return Module.AsyncLine; } }
        private int DataCount;
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
                    Connect(Module.Ip, Module.Port, 5000);
                    SendConfig();
                    SendCmd("AT+START");
                    
                    ReadLoop(token);

                    SendCmd("AT+STOP");
                    DisConnect();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error - " + ex);
                    Thread.Sleep(100);
                    throw ex;
                }
            }
        }

        private void SendConfig()
        {
            int rateIdx = (int)Math.Log(AsyncFMax/100,2)+1;
            Console.WriteLine(rateIdx);
            SendCmd(string.Format("AT+SETRATE={0}", rateIdx));
            var buf = new byte[10];
            WfsClient.GetStream().Read(buf, 0, buf.Length);
            string receiveString = ToString(buf);
            if (!receiveString.Equals("\r\nOK\r\n"))
                throw new Exception("SendConfig Error - ReceiveMsg:" + receiveString);
            else
                Console.WriteLine("SendConfig - OK ReceiveMsg:" + receiveString);
            DataCount = (int)(Module.AsyncFMax * 2.56);
        }



        private void DisConnect()
        {
            WfsClient.GetStream().Close();
            WfsClient.Close();
        }

        private void SendCmd(string cmd)
        {
            if (!WfsClient.Connected) return;
            var bytes = Encoding.ASCII.GetBytes(cmd + "\r");
            WfsClient.GetStream().Write(bytes, 0, bytes.Length);
        }

        private RxPacket ReceivePacket()
        {
            RxPacket packet = new RxPacket();
            if (WfsClient == null || !WfsClient.Connected) return null;
            try
            {
                var ns = WfsClient.GetStream();
                ns.ReadTimeout = 2000;
                packet.Read(ns);
            }
            catch (Exception ex)
            {
                WriteLog(ex.Message);
                throw ex;
            }
            return packet;
        }

        public static string ToString(byte[] bytes)
        {
            int endStr = Array.IndexOf(bytes, (byte)'\0');
            return Encoding.ASCII.GetString(bytes.Where((x, i) => i < endStr).ToArray());
        }

        private void Connect(string ip, int port, int timeout)
        {
            WfsClient = new TcpClient();
            try
            {
                WfsClient.Connect(ip, port);
                Console.WriteLine("Connected");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Wifi Connection Error : " + ex.Message);
                WfsClient.Close();
                throw;
            }
        }

        private void ReadLoop(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    var packet = ReceivePacket();
                    RxDatas.AddRange(Array.ConvertAll(packet.Payload, x => (float)x/25000f));

                    if (RxDatas.Count >= DataCount)
                    {
                        WaveData wave = new WaveData()
                        {
                            DateTime = DateTime.Now,
                            AsyncDataCount = DataCount,
                            AsyncData = RxDatas.Where((x,i)=>i<DataCount).ToArray()
                        };
                        DatasReceived(new WaveData[] { wave });
                        RxDatas.RemoveRange(0, DataCount);
                    }
                }
                catch{}
            }
        }
    }
}
