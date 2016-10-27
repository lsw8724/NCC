using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NCCCommon.ModuleProtocol
{
    public enum DataType
    {
        WaveDatas,
        VectorData,
        MeasureData,
        FFTDatas,
    }

    public enum MeasureCalcType
    {
        RMS,
        PP,
        PK,
    }

    public interface IWavesReceiver : IModuleConfig, ICancelableTask
    {
        event Action<IReceiveData[]> DatasReceived;
    }

    public interface IReceiveData
    {
        DataType Type { get;}
    }

    public interface IModuleConfig
    {
        object Module { get; }
        int ChannelCount { get; }
        int AsyncFMax{ get; }
        int AsyncLine{ get; }
    }

    public class WaveData : IReceiveData
    {
        public uint Idx;
        public int ChannelId;
        public int SaveType;
        public DateTime DateTime;
        public float Rpm;
        public int SyncDataCount;
        public int AsyncDataCount;
        public float[] SyncData;
        public float[] AsyncData;

        public DataType Type { get { return DataType.WaveDatas; } }
    }

    public class VectorData : IReceiveData
    {
        public uint Idx;
        public int ChannelId;
        public int SaveType;
        public UtcAndMiliseconds DateTime;
        public float Rpm;
        public float Gap;            
        public float Direct;
        public float OneXAmp;    
        public float OneXPhase;  
        public float TwoXAmp;    
        public float TwoXPhase;  
        public float NXAmp;      
        public float NXPhase;    
        public float Bandpass;   
        public float CrestFactor;

        public DataType Type { get { return DataType.VectorData; } }
    }

    public interface IMeasuredData : IReceiveData
    {
        int ChannelId { get; }
        float Scalar { get; }
        DateTime TimeStamp { get; }
        float Rpm { get; }
    }

    public class Measure_P2P : IMeasuredData
    {
        private float WaveRpm { get; set; }
        private int Ch { get; set; }
        public float Value { get; set; }
        public DateTime Time { get; set; }

        public Measure_P2P(WaveData wave)
        {
            WaveRpm = wave.Rpm;
            Ch = wave.ChannelId;
            Value = wave.AsyncData.Max() - wave.AsyncData.Min();
            Time = wave.DateTime;
        }

        public float Rpm { get { return WaveRpm; } }
        public int ChannelId { get { return Ch; } }
        public float Scalar { get { return Value; } }
        public DateTime TimeStamp { get { return Time; } }
        public DataType Type { get { return DataType.MeasureData; } }
    }

    public class Measure_Peak : IMeasuredData
    {
        private float WaveRpm { get; set; }
        private int Ch { get; set; }
        public float Value { get; set; }
        public DateTime Time { get; set; }

        public Measure_Peak(WaveData wave)
        {
            WaveRpm = wave.Rpm;
            Ch = wave.ChannelId;
            Value = wave.AsyncData.Max();
            Time = wave.DateTime;
        }

        public float Rpm { get { return WaveRpm; } }
        public int ChannelId { get { return Ch; } }
        public float Scalar { get { return Value; } }
        public DateTime TimeStamp { get { return Time; } }
        public DataType Type { get { return DataType.MeasureData; } }
    }

    public class Measure_RMS : IMeasuredData
    {
        private int Ch { get; set; }
        public float Value { get; set; }
        public DateTime Time { get; set; }
        private float WaveRpm { get; set; }

        public Measure_RMS() { }

        public Measure_RMS(SpectrumData spectrum, int low = 20, int high = 50)
        {
            WaveRpm = spectrum.WaveRpm;
            Ch = spectrum.ChannelId;
            double sum = 0;
            int lo = Convert.ToInt32(low*spectrum.Resolution);
            int hi = Convert.ToInt32(high*spectrum.Resolution);
            for (int i = lo; i < hi; i++)
                sum += spectrum.YValues[i] * spectrum.YValues[i];
            Value = (float)Math.Sqrt(sum / spectrum.XValues.Length);
            Time = spectrum.TimeStamp;
        }

        public float Rpm { get { return WaveRpm; } }
        public int ChannelId { get { return Ch; } }
        public float Scalar { get { return Value; } }
        public DateTime TimeStamp { get { return Time; } }
        public DataType Type { get { return DataType.MeasureData; } }
    }

    public class SpectrumData : IReceiveData
    {
        public float Resolution { get; set; }
        public int ChannelId { get; set; }
        public DateTime TimeStamp { get; set; }
        public float[] XValues { get; set; }
        public float[] YValues { get; set; }
        public float WaveRpm { get; set; }

        public SpectrumData(float res, WaveData wave)
        {
            WaveRpm = wave.Rpm;
            Resolution = res;
            ChannelId = wave.ChannelId;
            YValues = Array.ConvertAll(NadaMath.PositiveFFT(wave.AsyncData), x => (float)x);
            XValues = YValues.Select((x, i) => (float)i / res).ToArray();
            TimeStamp = wave.DateTime;
        }
        public DataType Type { get { return DataType.FFTDatas; } }
    }

    public interface ICancelableTask : IDisposable
    {
        void Start();
        void Stop();
    }

    public abstract class SingleTask : ICancelableTask
    {
        protected Task task = null;
        protected CancellationTokenSource cancelSource;

        public SingleTask()
        {
            this.cancelSource = new CancellationTokenSource();
        }

        public void Dispose()
        {
        }

        public void WriteLog(string msg)
        {
            Debug.WriteLine(msg);
        }

        public virtual void Start()
        {
            WriteLog("Start");
            if (task != null)
                return;

            task = Task.Factory.StartNew(OnStart, cancelSource.Token);
        }

        public virtual void Stop()
        {
            WriteLog("Stop");
            if (!cancelSource.IsCancellationRequested)
            {
                cancelSource.Cancel();
                cancelSource = new CancellationTokenSource();
            }
            if (task != null)
            {
                if (!task.IsCompleted)
                    task.Wait();
                task = null;
            }
        }

        private void OnStart()
        {
            try
            {
                WriteLog("Task Created");
                OnNewTask(cancelSource.Token);
                WriteLog("Task Exiting");
            }
            catch (Exception ex)
            {
                WriteLog("Error on new task - " + ex);
            }
        }

        protected abstract void OnNewTask(CancellationToken token);
    }
}
