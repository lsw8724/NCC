using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace NCCCommon.ModuleProtocol.OmapProtocol
{
    public class TcpConnection
    {
        public TcpSocket tcp;

        public string IP { get; set; }
        public int Port { get; set; }
        public string Name { get; set; }

        public bool IsConnected
        {
            get
            {
                try
                {
                    if (tcp == null || tcp.Socket == null)
                        return false;

                    return tcp.Socket.Connected;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        public string Address { get { return tcp.Address; } }

        public event EventHandler Connected;
        public event EventHandler Disconnected;
        public event EventHandler Errored;

        public TcpConnection(string ip, int port, string name = null)
        {
            IP = ip;
            Port = port;

            if (string.IsNullOrEmpty(name))
                name = ip + ":" + port;
            Name = name;
        }

        public bool Connect()
        {
            try
            {
                tcp = new TcpSocket();
                tcp.SendTimeout = 12000;
                tcp.ReceiveTimeout = 12000;
                tcp.Connect(IP, Port, new TimeSpan(0, 0, 5));
               
                if (Connected != null)
                    Connected(this, null);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void Disconnect()
        {
            try
            {
                //   WriteLog("Disconnect");
                if (tcp != null)
                {
                    tcp.Close();
                    tcp = null;
                }
                //   WriteLog("Disconnected");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Disconnect - " + ex);
            }
        }

        public void Send(MsgType type)
        {
            var msg = new DspMessage { Type = type, Size = 0 };
            Send(msg);
        }

        public void Send<T>(T body) where T : struct
        {
            var msg = new DspMessage();
            msg.SetData<T>(body);
            Send(msg);
        }

        public void Send(DspMessage msg)
        {
            try
            {
                //WriteLog("Send - Type:" + msg.Type + ", Size:" + msg.Size, LogLevel.Debug);
                //Debug.WriteLine("Send - Type:" + msg.Type + ", Size:" + msg.Size, LogLevel.Debug);
                tcp.Send(msg);
                //WriteLog("Sended - Type:" + msg.Type + ", Size:" + msg.Size);
                //Debug.WriteLine("Sended - Type:" + msg.Type + ", Size:" + msg.Size);
#if false
                //WriteLog("Send - Type:" + msg.Type + ", Size:" + msg.Size, LogLevel.Debug);
                //var buff = msg.ToBytes();
                //stream.Send(msg);
                if (socket.Poll(1000*100, SelectMode.SelectWrite))
                {
                    int sended = socket.Send(msg.ToBytes());
                    if (sended == 0)
                    {
                        //WriteLog("Send Fail. Disconnect");
                        Disconnect();
                    }
                }
                else
                    Disconnect();
                //WriteLog("Sended - Type:" + msg.Type + ", Size:" + msg.Size);
#endif
            }
            catch (Exception ex)
            {
                //WriteLog("Send Error - " + ex);
                Debug.WriteLine("Send Error - " + ex);
                //trace.Send("Error - " + ex);

                if (!IsConnected && Disconnected != null)
                    Disconnected(this, null);
            }
        }

        //public DspMessage ReceiveMessage()
        //{
        //    //return stream.Read();
        //}
    }

}
