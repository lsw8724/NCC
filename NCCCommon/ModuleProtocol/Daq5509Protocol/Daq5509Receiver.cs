using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using TraceTool;

namespace NCCCommon.ModuleProtocol.Daq5509Protocol
{
    public class Daq5509Receiver : SingleTask, IWavesReceiver
    {
        public string ModuleIp { get; set; }
        private DaqClient Daq;

        public RobinChannel[] Channels { get; set; }
        private float[] scaleFactors;
        public DaqSamplingRate nSamplingRate;
        private int Fmax { get { return Channels[0].AsyncFMax; } }
        private int Line { get { return Channels[0].AsyncLine; } }
        private double AcquireSec { get { return (double)(Line / (double)Fmax); } }
        private TimeSpan TimeOffset { get; set; }

        public DaqInputType InputType { get; set; }
        WinWatch watch;
        int PacketCountFor1Sec = 16;
        public event Action<WaveData[]> WavesReceived;

        public Daq5509Receiver()
        {
            this.InputType = DaqInputType.AC;
            this.Channels = new RobinChannel[8];
            for (int i = 0; i < Channels.Length; i++)
            {
                Channels[i] = new RobinChannel() { PhysicalIndex = i, Id = i + 1 };
                if (i == 0) Channels[i].Active = true;
            }
          
            scaleFactors = new float[Channels.Length];
            foreach (var channel in Channels)
                scaleFactors[channel.PhysicalIndex] = channel.ScaleFactorByDisplayUnit();//channel.ScaleFactor;//db.GetChannel(ch + 1).ScaleFactor;

            if (!Enum.TryParse<DaqSamplingRate>("_" + (Channels[0].AsyncFMax * 2.56), out nSamplingRate))
                nSamplingRate = DaqSamplingRate._8192;
        }

        protected override void OnNewTask(CancellationToken token)
        {
            //ReconnectLoop
            while (!token.IsCancellationRequested)
            {
                try
                {
                    WriteLog("Connecting");

                    ConnectDaq();

                    ReadLoop(token);

                    CloseDaq();

                    WriteLog("Closing");
                }
                catch (Exception ex)
                {
                    WriteLog("Error - " + ex);
                    Thread.Sleep(100);
                }
            }
        }

        private void ConnectDaq()
        {
            CloseDaq();

            for (int i = 0; i < 5; i++)    //Connect 실패가 잦으니 여러번 시도
            {
                try
                {
                    var _daq = new DaqClient(scaleFactors);
                    _daq.PacketCountFor1Sec = PacketCountFor1Sec;
                    _daq.Connect(ModuleIp, 7000);
                    _daq.Stop(true);
                    //if (!_daq.Stop(true))
                    //    throw new Exception("Stop Failed");
                    Daq = _daq;
                    break;
                }
                catch (Exception) { Thread.Sleep(500); }
            }
            if (Daq == null)
                throw new Exception("Connect Failed - IP:" + ModuleIp);

            foreach (var channel in Channels)
            {
                Daq.SetInputType(channel.PhysicalIndex, channel.ICP, InputType);
                //daq.SetInputType(channel.PhysicalIndex, false, DaqInputType.AC);
                Daq.SetGain(channel.PhysicalIndex, false, channel.HWGain);
            }
            Daq.SetRunVariable();
            Daq.SetSampleMode(nSamplingRate);

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
                var data = Daq.FetchDatas((int)(8 * AcquireSec));
                var now = DateTime.Now.Add(TimeOffset);

                var waves = new WaveData[8];
                for (int i = 0; i < Channels.Length; i++)
                {
                    var ch = Channels[i];
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

                if (WavesReceived != null)
                    WavesReceived(waves);

            NEXT_READ:
                continue;
            }
        }
    }
}

   