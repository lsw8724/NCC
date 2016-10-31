using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCCCommon.ModuleProtocol.Wifi
{
    public class WifiModule
    {
        public string Ip { get; set; }
        public int Port = 25000;
        public int AsyncFMax { get; set; }
        public int AsyncLine { get; set; }
        public int SampleRate;
    }
}
