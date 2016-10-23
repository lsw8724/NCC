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

        public int AsyncFMax { get { return 3200; } }
        public int AsyncLine { get { return 3200; } }
        public int ChannelCount { get { return 1; } }

        public event Action<IReceiveData[]> DatasReceived;

        public override string ToString()
        {
            return "ReceiverWifi";
        }

        protected override void OnNewTask(CancellationToken token)
        {
            //Module.Init();
            Module.Ip = "192.168.7.1";
            Module.Port = 25000;

            while (!token.IsCancellationRequested)
            {
                try
                {
                    Connect(Module.Ip, Module.Port, 5000);
                    SendCmd("AT+START");

                    ReadLoop(token);

                    SendCmd("AT+STOP");
                    DisConnect();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error - " + ex);
                    Thread.Sleep(100);
                }
            }
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
                    RxDatas.AddRange(Array.ConvertAll(packet.Payload, x => (float)x - 22000));

                    if (RxDatas.Count >= 8192)
                    {
                        WaveData wave = new WaveData();
                        wave.DateTime = DateTime.Now;
                        wave.AsyncDataCount = 8192;
                        wave.AsyncData = RxDatas.Where((x,i) => i < 8192).ToArray();
                        RxDatas.Clear();
                        DatasReceived(new WaveData[] { wave });
                        Thread.Sleep(1000);
                    }
                }
                catch
                {
                }
            }
        }
    }
}
