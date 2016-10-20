using Ivi.Visa.Interop;
using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace NCCCommon
{
    public class VisaConnection
    {
        public FormattedIO488 VisaIo;
        public ResourceManager VisaRM;

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
                VisaIo = new FormattedIO488();
                VisaRM = new ResourceManager();
                VisaIo = new FormattedIO488() { IO = (IMessage)VisaRM.Open(usbId, AccessMode.NO_LOCK, 0, "") };
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
