using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCCCommon.ModuleProtocol.Daq5509Protocol
{
    public class DaqException : Exception
    {
        public DaqException(string message)
            : base(message)
        { }
    }
}
