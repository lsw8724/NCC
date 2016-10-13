using NADACommonCalibrator;
using NCCCommon.ModuleProtocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NADACommonCalibrator.Measure
{
    public class Measure_Peak : IMeasure
    {
        public float Scalar { get; set; }
        public DateTime TimeStamp { get; set; }

        public Measure_Peak(WaveData wave)
        {
            Scalar = wave.AsyncData.Max();
            TimeStamp = wave.DateTime;
        }

        public float GetScalar { get { return Scalar; } }
        public DateTime GetTimeStamp { get { return TimeStamp; } }
    }
}
