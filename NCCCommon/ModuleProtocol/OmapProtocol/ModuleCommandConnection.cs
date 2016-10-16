using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace NCCCommon.ModuleProtocol.OmapProtocol
{
    public class ModuleCommandConnection : TcpConnection
    {
        public OmapModule Module { get; set; }

        public ModuleCommandConnection(OmapModule module, int port)
            : base(module.Ip, port)
        {
            base.Connected += OnConnected;
            base.Errored += OnSocketErrored;
            this.Module = module;
        }

        private void OnSocketErrored(object sender, EventArgs e)
        {
        }

        private void OnConnected(object sender, EventArgs e)
        {
        }

        private void SendMsg<MsgType>(MsgType obj) where MsgType : struct
        {
            var msg = new DspMessage();
            msg.SetData<MsgType>(obj);
            TcpConnection conn = this;
            conn.Send(msg);
        }

        public virtual void SendConfigs()
        {
            SendMsg(new ModuleConfig() { AlarmBufferMode = (int)Module.AlarmBufferMode});

            SendMsg(Module.KeyPhasors[0]);
            SendMsg(Module.KeyPhasors[1]);

            foreach (var ch in Module.Channels)
                SendMsg(ch);

            Thread.Sleep(2000);
            Send(MsgType.MsgType_Cmd_Start);

            Console.WriteLine("SendConfigs OK");
        }
    }
}