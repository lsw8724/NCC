using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace NCCCommon.ModuleProtocol.OmapProtocol
{
    public class ModuleOptions
    {
        public string RobinChannelSendType { get; set; }

        public int RobinChannelSendBandLow { get; set; }

        public int RobinChannelSendBandHigh { get; set; }

        public ModuleOptions()
        {
            RobinChannelSendType = "ACC";
            RobinChannelSendBandLow = 10;
            RobinChannelSendBandHigh = 1000;
        }
    }

    public class ModuleCommandConnection : TcpConnection
    {
        protected ModuleOptions config;

        public bool EnableSendConfigOnConnect { get; set; }

        public event EventHandler ModuleInitialized;

        internal bool startOk = false;

        public OmapModule Module { get; set; }

        public ModuleCommandConnection(OmapModule module, int port, ModuleOptions config)
            : base(module.ModuleIp,port)
        {
            base.Connected += OnConnected;
            base.Errored += OnSocketErrored;
            this.Module = module;
            this.EnableSendConfigOnConnect = true;
        }

        private void OnSocketErrored(object sender, EventArgs e)
        {
        }

        private void OnConnected(object sender, EventArgs e)
        {
            try
            {
                //리얼타임 모드시 설정을 보내면, 설정도중 일반모드 서버의 접속으로 설정 미완 상태로 될 가능성 존재
                if (EnableSendConfigOnConnect && !Repository.RealtimeOption.Enabled)
                {
                    //SendConfigs();
                }
                else
                {
                    if (ModuleInitialized != null)
                        ModuleInitialized(this, null);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("SendConfigs Error - " + ex);
            }
            //Send(TsiMsg.MsgType.MsgType_Cmd_Start);
        }

        /// <summary>
        /// Sends the configurations.
        /// </summary>
        /// <remarks></remarks>
        public virtual void SendConfigs()
        {
            Send<ModuleConfig, OmapModule>(this, Module);

            Debug.WriteLine("ModuleConfig - Start : " + conn.Address);
            Send<Keyphasor, TsiDb.Keyphasor>(this, configDB.GetKeyphasors(moduleId, null).Where(k => k.Active));
            // Debug.WriteLine("Keyphasor");
            Send<DisChannel, TsiDb.DisChannel>(this, configDB, moduleId, ChannelType.Displacement);
            
            //기존 보드 펌웨어 호환성을 위해 TsiMsg.AccChannel으로 보냄
            //Send<TsiMsg.AccChannel, TsiDb.RobinChannel>(conn, configDB, moduleId, ChannelType.Robin);
            foreach (var row in configDB.GetChannels(moduleId, ChannelType.Robin))
            {
                if (config.RobinChannelSendType.ToUpper() == "ACC")
                {
                    var data = new TsiMsg.AccChannel();
                    TypeUtil.CopyPropertyToField(row as TsiDb.RobinChannel, ref data);
                    data.BandLow = config.RobinChannelSendBandLow;
                    data.BandHigh = config.RobinChannelSendBandHigh;

                    var msg = new TsiMsg.DspMessage();
                    msg.SetData(data);
                    conn.Send(msg);
                }
                else if (config.RobinChannelSendType.ToUpper() == "DIS")
                {
                    var data = new TsiMsg.DisChannel();
                    TypeUtil.CopyPropertyToField(row as TsiDb.RobinChannel, ref data);
                    data.BandLow = config.RobinChannelSendBandLow;
                    data.BandHigh = config.RobinChannelSendBandHigh;

                    var msg = new TsiMsg.DspMessage();
                    msg.SetData(data);
                    conn.Send(msg);
                }
            }

            // Debug.WriteLine("Channel");
            Send<SampleMode, TsiDb.SampleMode>(conn, configDB.GetModuleSampleModes(moduleId, false));
            // Debug.WriteLine("SampleMode");
            Send<SampleModeAmp, TsiDb.SampleModeAmp>(conn, configDB.GetModuleSampleModeAmps(moduleId));
            // Debug.WriteLine("SampleModeAmp");
            Send<HWAlarmConfig, TsiDb.HWAlarmConfig>(conn, configDB.GetModuleHWAlarmConfigs(moduleId));
            //Debug.WriteLine("HWAlarmConfig");
            Send<AlarmFunction, TsiDb.AlarmFunction>(conn, configDB.GetModuleAlarmFunctions(moduleId));
            //Debug.WriteLine("AlarmFunction");

            // Modbus & Record Out 설정정보를 송신
            Send<ModbusRecordOutput, TsiDb.SensorChannel>(conn, configDB, moduleId);
            Debug.WriteLine("ModbusRecordOutput");
            //Debug.WriteLine("ModuleConfig - End");
            // WriteLog(conn.Address + "SendConfigs - End");

            Thread.Sleep(2000);
            conn.Send(MsgType.MsgType_Cmd_Start);

            try
            {
                //TcpSocket tcp = new TcpSocket(socket);
                //var tcp = socket;
                //tcp.ReceiveTimeout = 3000;
                //tcp.SendTimeout = 0;

                var responseMsg = tcp.ReadDspMessage(); //DspMessage.ReadFrom(conn);
                var response = responseMsg.GetDataAsStruct<CommandResponse>();
                string responseString = response.Args;

                startOk = response.ResponseCode == (int)ResponseCodeTyoe.RCT_Ok;

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Received Response Error - " + ex);
            }

            if (ModuleInitialized != null)
                ModuleInitialized(this, null);

            Debug.WriteLine("SendConfigs OK - module:" + this.Module.Id);
        }

      
        protected static void Send<MsgType, DbType>(TcpConnection conn, IEnumerable<DbType> rows)
            where MsgType : struct
            where DbType : class, new()
        {
            //int nCount = 0;

            foreach (var row in rows)
            {
                var data = new MsgType();
                TypeUtil.CopyPropertyToField2(row, ref data);

                var msg = new TsiMsg.DspMessage();
                msg.SetData(data);

                //string sss = data.GetType().ToString();
                //Debug.WriteLine("Type : {0}", sss);

                //if(data.GetType().ToString().IndexOf("AlarmFunction") >= 0)
                //{
                //    Debug.WriteLine("Size : {0},  Data : {1}", msg.Size, msg.Data);
                //}
                //nCount++;
                conn.Send(msg);
            }

            //Debug.WriteLine("★★★★★★★★★★★★ Rows : {0},  Send : {1}", rows.Count(), nCount);
        }

        /// <summary>
        /// Sends the database entities.
        /// </summary>
        /// <param name="conn">The connection.</param>
        /// <param name="configDB">The config DB.</param>
        /// <param name="moduleId">The module id.</param>
        /// <param name="type">The channel type.</param>
        /// <remarks></remarks>
        protected static void Send<MsgType, DbType>(TcpConnection conn, TsiDb.ConfigContext configDB, int moduleId, ChannelType type)
            where MsgType : struct
            where DbType : TsiDb.TransducerChannel
        {
            foreach (var row in configDB.GetChannels(moduleId, type))
            {
                var data = new MsgType();
                TypeUtil.CopyPropertyToField(row as DbType, ref data);

                var msg = new TsiMsg.DspMessage();
                msg.SetData(data);
                conn.Send(msg);
            }
        }

        protected static void Send<MsgType, DbType>(TcpConnection conn, TsiDb.ConfigContext configDB, int moduleId)
            where MsgType : struct
            where DbType : TsiDb.SensorChannel
        {
            foreach (var row in configDB.GetChannels(moduleId))
            {
                var data = new MsgType();
                TypeUtil.CopyPropertyToField(row as DbType, ref data);

                var msg = new TsiMsg.DspMessage();
                msg.SetData(data);
                conn.Send(msg);
            }
        }
    }
}