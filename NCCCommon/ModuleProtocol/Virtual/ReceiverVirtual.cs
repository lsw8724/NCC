using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NCCCommon.ModuleProtocol.Virtual
{
    public class SinWave
    {
        public SinWave(float freq, float amp)
        {
            Freq = freq;
            Amplitude = amp;
        }
        public float Freq { get; set; }
        public float Amplitude { get; set; }
    }

    public class VirtualModule
    {
        public int AsyncFMax { get; set; }
        public int AsyncLine {  get; set; }
        public int DataCount { get { return Convert.ToInt32(AsyncFMax * 2.56); } }
        public float Resolution { get { return AsyncLine / (float)AsyncFMax; } }
    }

    public class ReceiverVirtual : SingleTask, IWavesReceiver
    {
        public VirtualModule Module = new VirtualModule();
        public event Action<IReceiveData[]> DatasReceived;
        public List<SinWave> SinWaves = new List<SinWave>();
        object IGetterRcvProperty.Module { get { return this.Module; } }
        public int AsyncFMax { get { return Module.AsyncFMax; } }
        public int AsyncLine { get { return Module.AsyncFMax; } }
        public int ChannelCount { get { return 8; } }

        public void AddSinWaves(float freq, float amp)
        {
            SinWaves.Add(new SinWave(freq,amp));
        }

        public void SingleSinWave(float freq, float amp)
        {
            SinWaves.Clear();
            SinWaves.Add(new SinWave(freq, amp));
        }

        public void ClearSinWaves()
        {
            SinWaves.Clear();
        }

        public override string ToString()
        {
            return "ReceiverVirtual";
        }

        protected override void OnNewTask(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    ReadLoop(token);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error - " + ex);
                    Thread.Sleep(100);
                }
            }
        }

        private void ReadLoop(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                WaveData[] waves = new WaveData[ChannelCount];
                var testData = SinWaves.FirstOrDefault();
                var testRPM = testData != null ? testData.Freq * 60 : 0;
                for (int i = 0; i < waves.Length; i++)
                {
                    waves[i] = new WaveData();
                    waves[i].Rpm = i < KpMap["Kp2"] ? testRPM : testRPM;
                    waves[i].ChannelId = i + 1;
                    waves[i].DateTime = DateTime.UtcNow;
                    waves[i].AsyncDataCount = Module.DataCount;
                    waves[i].AsyncData = CreateSimulateFloatDataArr(SinWaves);
                }
                if (waves != null)
                    DatasReceived(waves);

                Thread.Sleep(1000);
            }
        }

        private double CalcWaveMomentData(float freq, float amp, double t)
        {
            return (amp * Math.Sin(freq * 2 * Math.PI * t));
        }

        private float[] CreateSimulateFloatDataArr(List<SinWave> sinWaves)
        {
            float[] dataArr = new float[Module.DataCount];

            for (int i = 0; i < Module.DataCount; i++)
            {
                float time = (i / (float)Module.DataCount) * Module.Resolution;
                double sinSum = 0.0;
                for (int j = 0; j < sinWaves.Count; j++)
                {
                    sinSum += CalcWaveMomentData(sinWaves[j].Freq, sinWaves[j].Amplitude, time);
                }
                dataArr[i] = Convert.ToSingle(sinSum);
            }
            return dataArr;
        }

        public Dictionary<string, int> KpMap
        {
            get
            {
                return new Dictionary<string,int>()
                {
                    {"Kp1",0},
                    {"Kp2",2}
                };
            }
        }
    }
}
