using NADACommonCalibrator;
using NCCCommon.ModuleProtocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NADACommonCalibrator.Measure
{
    public class Measure_P2P : IMeasure
    {
        public float Scalar { get; set; }
        public DateTime TimeStamp { get; set; }

        public Measure_P2P(WaveData wave)
        {
            Scalar = wave.AsyncData.Max() - wave.AsyncData.Min();
            TimeStamp = wave.DateTime;
        }

        public float GetScalar { get { return Scalar; } }
        public DateTime GetTimeStamp { get { return TimeStamp; } }
    }
}
