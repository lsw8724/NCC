using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCCCommon.ModuleProtocol.OmapProtocol
{
    public class OmapChannel
    {
        public int Id { get; set; }
        public int PhysicalCh { get; set; }
        public int Angle { get; set; }
        public ChannelType ChannelType { get; set; }
        public bool RecordOutActive { get; set; }
        public int MROType;
        public int MRORange;
        public int MRORangeLow;

        public OmapChannel()
        {
            ChannelType = ChannelType.Accelate;
            Angle = 45;
        }
    }
}
