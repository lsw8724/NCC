using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace NCCCommon.ModuleProtocol.Omap
{
    public static class TcpSocketExtension
    {
        /// <summary>
        /// OnIdle이 호출됨에 주의
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static DspMessage ReadDspMessage(this TcpSocket s)
        {
            var headerBuffer = s.Read(DspMessage.HeaderSize);

            int i = 0;
            int prefix1 = ByteUtil.ReadInt32(headerBuffer, i);
            i += 4;
            int prefix2 = ByteUtil.ReadInt32(headerBuffer, i);
            i += 4;

            if (prefix1 != DspMessage.Prefix1 || prefix2 != DspMessage.Prefix2)
                throw new Exception("Wrong Prefix - "+ prefix1 + ", " + prefix2);

            var msgType = (MsgType)ByteUtil.ReadInt32(headerBuffer, i);
            i += 4;

            int msgSize = ByteUtil.ReadInt32(headerBuffer, i);
            i += 4;

            //Debug.WriteLine("DspMsg Read - type:" + msgType + ", size:" + msgSize);

            DspMessage msg;
            if (msgSize <= 0)
            {
                msg = new DspMessage { Type = msgType, Size = msgSize };
            }
            else
            {
                var payload = new byte[msgSize];
                s.Read(payload, payload.Length);
                msg = new DspMessage { Type = msgType, Size = msgSize, Data = payload };
            }

            return msg;
        }

        public static void SendAsDspMessage<T>(this TcpSocket s, T body) where T : struct
        {
            var msg = new DspMessage();
            msg.SetData<T>(body);
            //s.Send(msg.ToBytes());
            s.Send(msg);
        }

        public static void SendAsDspMessage<T>(this NetworkStream s, T body) where T : struct
        {
            var msg = new DspMessage();
            msg.SetData<T>(body);
            var bytes = msg.ToBytes();
            s.Write(bytes, 0, bytes.Length);
        }
    }

    public static class NetStreamExtension
    {
        public static byte[] Read(this Stream stream, int size)
        {
            var data = new byte[size];
            int totalRead = 0;
            while (totalRead < data.Length)
            {
                totalRead += stream.Read(data, totalRead, data.Length - totalRead);
            }
            return data;
        }

        public static DspMessage ReadDspMessage(this Stream s)
        {
            var headerBuffer = s.Read(DspMessage.HeaderSize);

            int i = 0;
            int prefix1 = ByteUtil.ReadInt32(headerBuffer, i);
            i += 4;
            int prefix2 = ByteUtil.ReadInt32(headerBuffer, i);
            i += 4;

            if (prefix1 != DspMessage.Prefix1 || prefix2 != DspMessage.Prefix2)
                throw new Exception("Wrong Prefix - " + prefix1 + ", " + prefix2);

            var msgType = (MsgType)ByteUtil.ReadInt32(headerBuffer, i);
            i += 4;

            int msgSize = ByteUtil.ReadInt32(headerBuffer, i);
            i += 4;

            //Debug.WriteLine("DspMsg Read - type:" + msgType + ", size:" + msgSize);

            DspMessage msg;
            if (msgSize <= 0)
            {
                msg = new DspMessage { Type = msgType, Size = msgSize };
            }
            else
            {
                var payload = s.Read(msgSize);
                msg = new DspMessage { Type = msgType, Size = msgSize, Data = payload };
            }

            return msg;
        }


        public static void SendAsDspMessage<T>(this Stream s, T body) where T : struct
        {
            var msg = new DspMessage();
            msg.SetData<T>(body);
            var bytes = msg.ToBytes();
            s.Write(bytes, 0, bytes.Length);
        }
    }

    public class TcpSocket : IDisposable
    {
        Socket socket;

        public Action<TcpSocket> PollIdleEvent;
        public Action<TcpSocket> PollSendIdleEvent;

        public Socket Socket { get { return socket; } }

        public string Address { get { return socket.RemoteEndPoint.ToString(); } }

        public int SendTimeout { get; set; }
        public int ReceiveTimeout { get; set; }

        int pollTime = 500;

        bool closed = false;

        DateTime lastRead = DateTime.UtcNow;
        DateTime lastSend = DateTime.UtcNow;

        public TcpSocket()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            SendTimeout = 10000;
            ReceiveTimeout = 10000;
        }

        public TcpSocket(Socket s)
        {
            socket = s;
            SendTimeout = 10000;
            ReceiveTimeout = 10000;
        }

        public void Dispose()
        {
            try
            {
                Close();
                socket = null;
                PollIdleEvent = null;
                PollSendIdleEvent = null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Dispose Error - " + ex);
            }
        }

        public bool PollConnected()
        {
            try
            {
                //return socket.IsConnected();
                //return !(socket.Poll(1, SelectMode.SelectRead) && socket.Available == 0);
                if (socket == null || !socket.Connected)
                    return false;

                bool connected = socket.Poll(1, SelectMode.SelectWrite) && socket.Poll(1, SelectMode.SelectRead) && !socket.Poll(1, SelectMode.SelectError);
                //return !(connected && socket.Available == 0);
                return connected;
            }
            catch (SocketException) { return false; }
        }

        public void Connect(string ip, int port, TimeSpan timeout)
        {
            socket.Connect(ip, port);
            closed = false;
        }

        public void Connect(string ip, int port)
        {
            socket.Connect(ip, port);
            closed = false;
        }

        public void Disconnect(bool reuse = false)
        {
            socket.Disconnect(reuse);
        }

        public void Close()
        {
            if (closed)
                return;

            try
            {
                //if (socket.Connected)
                {
                    socket.Shutdown(SocketShutdown.Both);

                }
            }
            catch (Exception ex)
            {
            }

            try
            {
                socket.Disconnect(false);
            }
            catch (Exception ex) { }

            socket.Close();
            closed = true;
        }

        private byte[] tempSendBuffer = new byte[10240];
        public int Send(IBytesConvertable msg)
        {
            //return socket.Send(msg.ToBytes());

            if (msg.BytesCount.HasValue)
            {
                if (tempSendBuffer.Length < msg.BytesCount)
                    tempSendBuffer = new byte[msg.BytesCount.Value];

                int dataSize = msg.ToBytes(tempSendBuffer);
                return Send(tempSendBuffer, dataSize);
            }
            else
            {
                return Send(msg.ToBytes());
            }
        }

        public int Send(byte[] bytes)
        {
            return Send(bytes, bytes.Length);
        }

        public int Send(byte[] bytes, int dataSize)
        {
            lastSend = DateTime.UtcNow;

            int sent = 0;
            while (sent < dataSize)
            {
                if (socket.Poll(pollTime, SelectMode.SelectWrite))
                {
                    if (socket.Connected)
                    {
                        lastSend = DateTime.UtcNow;
                        int sended = socket.Send(bytes, sent, dataSize - sent, SocketFlags.None);
                        sent += sended;
                        if (sended == 0)
                            throw new Exception("Send Error");
                        continue;
                    }
                }

                var elapsed = DateTime.UtcNow - lastSend;
                if (SendTimeout > 0 && elapsed.TotalMilliseconds > SendTimeout)
                    throw new Exception("No Sending Detected - Time:" + SendTimeout + "ms");

                if (PollSendIdleEvent != null)
                    PollSendIdleEvent(this);
            }

            return sent;
        }

        private byte[] tempReadBuffer = new byte[10240];
        public byte[] Read(int totalRead)
        {
            if (tempReadBuffer.Length < totalRead)
                tempReadBuffer = new byte[totalRead];
            Read(tempReadBuffer, totalRead);
            return tempReadBuffer;
        }

        //정해진 사이즈만큼 읽음
        public void Read(byte[] emptyBuff, int totalRead)
        {
            var s = socket;
            lastRead = DateTime.UtcNow;

            //var buff = new byte[totalRead];
            var buff = emptyBuff;

            int readed = 0;
            while (readed < totalRead)
            {
                int nowRead = 0;
                //if (!s.PollConnected())
                //    throw new Exception("Disconnect Detected");

                if (s.Poll(pollTime, SelectMode.SelectRead))
                {
                    //if (s.Available == 0 || !s.Connected)
                    //    throw new Exception("Disconnected! - Available:" + s.Available);
                    if (s.Connected && s.Available > 0)
                    {
                        lastRead = DateTime.UtcNow;
                        nowRead = s.Receive(buff, readed, totalRead - readed, System.Net.Sockets.SocketFlags.None);
                        readed += nowRead;
                        //continue;
                    }
                }

                if (s.Poll(pollTime, SelectMode.SelectError))
                {
                    throw new Exception("Error detected by poll");
                }

                if (nowRead == 0)
                {
                    var elapsed = DateTime.UtcNow - lastRead;
                    if (ReceiveTimeout > 0 && elapsed.TotalMilliseconds > ReceiveTimeout)
                        throw new Exception("No Reading Detected - Time:" + ReceiveTimeout + "ms");
                }

                if (PollIdleEvent != null)
                    PollIdleEvent(this);

                Thread.Sleep(0);
            }
        }

    }
}
