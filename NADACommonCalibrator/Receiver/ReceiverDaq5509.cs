using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCCCommon.ModuleProtocol.Daq5509Protocol;
using NCCCommon.ModuleProtocol;
using NCCCommon;
using System.Threading;

namespace NADACommonCalibrator.Receiver
{
    public class ReceiverDaq5509 : SingleTask, IWavesReceiver
    {
        public DaqModule Module = new DaqModule();
        private DaqClient Daq;
  
        public int AsyncFMax { get { return Module.AsyncFMax; } }
        public int AsyncLine { get { return Module.AsyncLine; } }
        public int ChannelCount { get { return 8; } }

        public event Action<IReceiveData[]> DatasReceived;

        public override string ToString()
        {
            return "ReceiverDaq5509";
        }

        protected override void OnNewTask(CancellationToken token)
        {
            Module.Init();

            while (!token.IsCancellationRequested)
            {
                try
                {
                    ConnectDaq();

                    ReadLoop(token);

                    CloseDaq();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error - " + ex);
                    Thread.Sleep(100);
                }
            }
        }

        private void ConnectDaq()
        {
            CloseDaq();

            for (int i = 0; i < 100; i++)    //Connect 실패가 잦으니 여러번 시도
            {
                try
                {
                    var _daq = new DaqClient(Module.Channels.Select(x => x.ScaleFactors).ToArray()) { PacketCountFor1Sec = Module.PacketCountFor1Sec };
                    _daq.Connect(Module.Ip, 7000);
                    _daq.Stop(true);
                    Daq = _daq;
                    break;
                }
                catch { Thread.Sleep(100); }
            }
            if (Daq == null)
                throw new Exception("Connect Failed - IP:" + Module.Ip);

            foreach (var channel in Module.Channels)
            {
                Daq.SetInputType(channel.PhysicalIndex, channel.ICP, Module.InputType);
                Daq.SetGain(channel.PhysicalIndex, false, channel.HWGain);
            }
            Daq.SetRunVariable();
            Daq.SetSampleMode(Module.SamplingRate);

            Daq.Start();
        }
        private void CloseDaq()
        {
            if (Daq != null)
            {
                try
                {
                    Daq.Stop();
                    Daq.Close();
                }
                catch (Exception) { }
                Daq = null;
            }
        }

        private void ReadLoop(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                var data = Daq.FetchDatas((int)(8 * Module.AcquireSec));
                var now = DateTime.Now.Add(Module.TimeOffset);

                var waves = new WaveData[8];
                for (int i = 0; i < Module.Channels.Length; i++)
                {
                    var ch = Module.Channels[i];
                    var asyncs = data.ChannelsAsyncs[i];
                    var acquireSec = ch.AsyncLine / ch.AsyncFMax;
                    var dataSize = (int)(ch.AsyncFMax * 2.56 * acquireSec);
                    if (asyncs.Length != dataSize)
                    {
                        System.Diagnostics.Trace.WriteLine("5509 Read Error - CH:" + ch.Id + ", AsyncSize:" + asyncs.Length + ", Expect:" + dataSize);
                        goto NEXT_READ;
                    }

                    var wave = new WaveData();
                    wave.ChannelId = ch.Id;
                    wave.DateTime = now;
                    wave.Rpm = data.Rpm1;
                    wave.AsyncData = asyncs;
                    wave.AsyncDataCount = asyncs.Length;
                    waves[i] = wave;
                }

                if (DatasReceived != null)
                    DatasReceived(waves);

            NEXT_READ:
                continue;
            }
        }
    }
}
