using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NCCCommon;

namespace NCCCommon.ModuleProtocol.Daq5509Protocol
{
    public class DaqChannel
    {
        public int Id { get; set; }
        public int PhysicalIndex { get; set; }
        public int AsyncFMax { get; set; }
        public int AsyncLine { get; set; }
        public bool ICP { get; set; }
        public DaqGain HWGain { get; set; }
        public float Sensitivity { get; set; }

        public float ScaleFactorByDisplayUnit() { return 1.0f; }
        public DaqChannel()
        {
            Sensitivity = 1.0f;
            AsyncFMax = 3200;
            AsyncLine = 3200;
            ICP = true;
            HWGain = DaqGain._1;
        }
    }
}
