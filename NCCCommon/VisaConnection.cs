using Ivi.Visa.Interop;
using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace NCCCommon
{
    /* [Command Example]
     * Output:SYNC On
     * Output1 ON
     * Output1:Load INF
     * SOURCE1:Function Sin
     * SOURCE2:Volt:Offset -7.5
     * SOURCE2:Freq 100
     * SOURCE1:Volt:Unit Vpp
     * SOURCE1:Volt
     */
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
                VisaIo.IO = (IMessage)VisaRM.Open(usbId, AccessMode.NO_LOCK, 0, "");
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("An error occurred: " + e.Message);
            }
        }

        public void OpenByLANPort(string Ip)
        {
            try
            {
                VisaIo = new FormattedIO488();
                VisaRM = new ResourceManager();
                VisaIo.IO = (IMessage)VisaRM.Open("TCPIP0::"+Ip);
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
