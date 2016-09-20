using NCCCommon.ModuleProtocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NADACommonCalibrator.Receiver
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

    public class ReceiverVirtual : IWavesReceiver
    {
        public event Action<WaveData[]> WavesReceived;
        private System.Timers.Timer Timer;
        private int DataCount { get; set; }
        public float Resolution { get; set; }
        public List<SinWave> SinWaves;
        
        public ReceiverVirtual()
        {
            SinWaves = new List<SinWave>();
            Resolution = 1;
            DataCount = 8192;
        }

        //public void SetConfig(int ayncLine, int asyncFMax)
        //{
        //    Resolution = ayncLine/(float)asyncFMax;
        //    DataCount = (int)(8192 * Resolution);
        //}

        public void AddSinWaves(float freq, float amp)
        {
            SinWaves.Add(new SinWave(freq,amp));
        }

        private void TimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            WaveData[] waves = new WaveData[8];
            for (int i = 0; i < waves.Length; i++)
            {
                waves[i] = new WaveData();
                waves[i].ChannelId = i + 1;
                waves[i].DateTime = DateTime.UtcNow;
                waves[i].AsyncDataCount = DataCount;
                waves[i].AsyncData = CreateSimulateFloatDataArr(SinWaves);
            }
            if (waves != null)
                WavesReceived(waves);
        }

        public void Start()
        {
            Timer = new System.Timers.Timer();
            Timer.Interval = 1000;
            Timer.Elapsed += TimerElapsed;
            Timer.Start();
        }

        public void Stop()
        {
            if (Timer == null) return;
            Timer.Stop();
            Timer.Dispose();
            Timer = null;
        }

        private double CalcWaveMomentData(float freq, float amp, double t)
        {
            return (amp * Math.Sin(freq * 2 * Math.PI * t));
        }

        private float[] CreateSimulateFloatDataArr(List<SinWave> sinWaves)
        {
            float[] dataArr = new float[DataCount];

            for (int i = 0; i < DataCount; i++)
            {
                float time = (i / (float)DataCount) * Resolution;
                double sinSum = 0.0;
                for (int j = 0; j < sinWaves.Count; j++)
                {
                    sinSum += CalcWaveMomentData(sinWaves[j].Freq, sinWaves[j].Amplitude, time);
                }
                dataArr[i] = Convert.ToSingle(sinSum);
            }
            return dataArr;
        }

        public void Dispose()
        {
        }
    }
}
