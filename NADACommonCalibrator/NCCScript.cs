using Ivi.Visa.Interop;
using NADACommonCalibrator.Receiver;
using NCCCommon;
using NCCCommon.ModuleProtocol;
using NCCCommon.ModuleProtocol.Daq5509Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NADACommonCalibrator
{
    public class ReceiverUtil
    {
        public static IWavesReceiver GetReceiver(ReceiverType type)
        {
            switch (type)
            {
                case ReceiverType.Daq5509: return new Receiver_5509(new DaqModule());
                default: return null;
            }
        }
    }
    public class VisaConnection
    {
        public FormattedIO488 VisaIo { get; private set; }
        public ResourceManager VisaRM { get; set; }

        public void Send(string cmd)
        {
            if (VisaIo != null)
                VisaIo.WriteString(cmd);
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

        public void OpenByUSBPort(string usbId)
        {
            try
            {
                VisaIo = new FormattedIO488() { IO = (IMessage)VisaRM.Open(usbId, AccessMode.NO_LOCK, 2000, "") };
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("An error occurred: " + e.Message);
            }
        }

        public void Close()
        {
            try
            {
                VisaIo.IO.Close();
                Marshal.ReleaseComObject(VisaIo);
                Marshal.FinalReleaseComObject(VisaIo);
                Marshal.ReleaseComObject(VisaRM);
                Marshal.FinalReleaseComObject(VisaRM);
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("An error occurred: " + e.Message);
            }
        }
    }
}
