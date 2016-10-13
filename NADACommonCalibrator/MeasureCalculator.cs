using NCCCommon;
using NCCCommon.ModuleProtocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NADACommonCalibrator.Measure;

namespace NADACommonCalibrator
{
    public class MeasureCalculator
    {
        public static event Action<SpectrumData[]> AfterFFT;
        public static event Action<IMeasure[]> AfterMeasureCalc;
        public MeasureCalculator()
        {
            MainForm.WavesReceived += (waves) =>
                {
                    if (AfterFFT != null)
                        AfterFFT(waves.Select(x => new SpectrumData(1, x)).ToArray());
                };
            AfterFFT += (fft) =>
                {
                    if (AfterMeasureCalc != null)
                        AfterMeasureCalc(fft.Select(x => new Measure_RMS(x)).ToArray());
                };
        }
    }

    public class SpectrumData
    {
        public DateTime TimeStamp { get; set; }
        public float[] XValues { get; set; }
        public float[] YValues { get; set; }

        public SpectrumData(float res, WaveData wave)
        {
            YValues = Array.ConvertAll(NadaMath.PositiveFFT(wave.AsyncData), x => (float)x);
            XValues = YValues.Select((x, i) => (float)i / res).ToArray();
            TimeStamp = wave.DateTime;
        }
    }
}
