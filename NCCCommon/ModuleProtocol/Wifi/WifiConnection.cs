using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace NCCCommon.ModuleProtocol.Wifi
{
    public class WifiConnection : TcpClient
    {
        private WifiModule Module;
        private Dictionary<int, int> FMaxIdices = new Dictionary<int, int>();

        public WifiConnection(WifiModule module)
        {
            FMaxIdices.Add(100, 1);
            FMaxIdices.Add(200, 2);
            FMaxIdices.Add(400, 3); 
            FMaxIdices.Add(800, 4); 
            FMaxIdices.Add(1600, 5); 
            FMaxIdices.Add(3200, 6);
            FMaxIdices.Add(6400, 7); 
            FMaxIdices.Add(12800, 8);
            FMaxIdices.Add(25600, 9); 
            this.Module = module;
        }

        public void SendRateConfig()
        {
            SendCmd("AT+STOP");
            if (!FMaxIdices.ContainsKey(Module.AsyncFMax)) return;
            string rcvMsg = SendCmd(string.Format("AT+SETRATE={0}", FMaxIdices[Module.AsyncFMax]));

            if (!rcvMsg.Equals("\r\nOK\r\n"))
                throw new Exception("SendConfig Error - ReceiveMsg:" + rcvMsg);
            else
                Console.WriteLine("SendConfig - OK ReceiveMsg:" + rcvMsg);
            Module.SampleRate = (int)(Module.AsyncFMax * 2.56);
        }

        public void Connect(string ip, int port, int timeout)
        {
            try
            {
                Connect(ip, port);
                Console.WriteLine("Connected");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Wifi Connection Error : " + ex.Message);
                Close();
                throw;
            }
        }

        public void DisConnect()
        {
            SendTimeout = 4000;
            ReceiveTimeout = 4000;
            Close();
        }

        public string SendCmd(string cmd)
        {
            if (!Connected) 
                return "Not Connected";

            var bytes = Encoding.ASCII.GetBytes(cmd + "\r");
            GetStream().Write(bytes, 0, bytes.Length);
            
            var rcvBuf = new byte[10];
            GetStream().Read(rcvBuf, 0, rcvBuf.Length);

            return ToString(rcvBuf);
        }

        public RxPacket ReceivePacket()
        {
            RxPacket packet = new RxPacket();
            if (!Connected) return null;
            try
            {
                var ns = GetStream();
                ns.ReadTimeout = 2000;
                packet.Read(ns);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return packet;
        }

        public static string ToString(byte[] bytes)
        {
            int endStr = Array.IndexOf(bytes, (byte)'\0');
            return Encoding.ASCII.GetString(bytes.Where((x, i) => i < endStr).ToArray());
        }
    }
}
