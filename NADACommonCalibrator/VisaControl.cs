using CSScriptLibrary;
using Ivi.Visa.Interop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NADACommonCalibrator
{
    public interface IVisaScript
    {
        string Name { get; }
        string Run(VisaControl visa);
    }

    public class VisaControl
    {
        public FormattedIO488 Visa { get; private set; }
        public VisaControl(FormattedIO488 visa)
        {
            this.Visa = visa;
        }

        public void Send(string cmd)
        {
            if (Visa != null)
                Visa.WriteString(cmd);
        }

        public void Send(string cmd, int delayMiliseconds)
        {
            Send(cmd);
            Delay(delayMiliseconds);
        }

        public void Delay(int miliseconds)
        {
            Thread.Sleep(miliseconds);
        }
    }
}
