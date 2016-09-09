﻿using System;
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
        public DaqModule Module;
        private DaqClient Daq;
        
        public ReceiverDaq5509(string ip)
        {
            Module = new DaqModule() { ModuleIp = ip };
        }

        public event Action<WaveData[]> WavesReceived;

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
                    var _daq = new DaqClient(Module.scaleFactors) { PacketCountFor1Sec = Module.PacketCountFor1Sec };
                    _daq.Connect(Module.ModuleIp, 7000);
                    _daq.Stop(true);
                    Daq = _daq;
                    break;
                }
                catch (Exception) { Thread.Sleep(500); }
            }
            if (Daq == null)
                throw new Exception("Connect Failed - IP:" + Module.ModuleIp);

            foreach (var channel in Module.Channels)
            {
                Daq.SetInputType(channel.PhysicalIndex, channel.ICP, Module.InputType);
                Daq.SetGain(channel.PhysicalIndex, false, channel.HWGain);
            }
            Daq.SetRunVariable();
            Daq.SetSampleMode(Module.nSamplingRate);

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

                if (WavesReceived != null)
                    WavesReceived(waves);

            NEXT_READ:
                continue;
            }
        }
    }
}