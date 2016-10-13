using NADACommonCalibrator;
using NCCCommon.ModuleProtocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NADACommonCalibrator.Measure
{
    public interface IMeasure
    {
        float GetScalar { get; }
        DateTime GetTimeStamp { get; }
    }

    public class Measure_RMS : IMeasure
    {
        public float Scalar { get; set; }
        public DateTime TimeStamp { get; set; }

        public Measure_RMS(SpectrumData spectrum, int low = 20, int high = 3200)
        {
            double sum = 0;
            for (int i = low; i < high; i++)
                sum += spectrum.YValues[i] * spectrum.YValues[i];
            Scalar = (float)Math.Sqrt(sum / spectrum.XValues.Length);
            TimeStamp = spectrum.TimeStamp;
        }

        public float GetScalar { get { return Scalar; } }
        public DateTime GetTimeStamp { get { return TimeStamp; } }
    }
}
