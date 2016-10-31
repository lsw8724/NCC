using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace NCCCommon.ModuleProtocol.Omap
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

        private void SendMsg<MsgType>(ref MsgType obj) where MsgType : struct
        {
            var msg = new DspMessage();
            msg.SetData<MsgType>(obj);
            TcpConnection conn = this;
            conn.Send(msg);
        }

        public virtual void SendConfigs()
        {
            var moduleConf = new DSPMsg_ModuleConfig() { AlarmBufferMode = (int)Module.AlarmBufferMode };
            SendMsg(ref moduleConf);

            SendMsg(ref Module.KeyPhasors[0]);
            SendMsg(ref Module.KeyPhasors[1]);

            for(int i=0; i<Module.Channels.Length; i++)
                SendMsg(ref Module.Channels[i]);
             
            Thread.Sleep(2000);
            Send(MsgType.MsgType_Cmd_Start);

            Console.WriteLine("SendConfigs OK");
        }
    }
}