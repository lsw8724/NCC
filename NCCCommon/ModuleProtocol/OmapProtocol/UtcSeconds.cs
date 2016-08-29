using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace NCCCommon.ModuleProtocol.OmapProtocol
{
    [StructLayout(LayoutKind.Sequential)]
    public struct UtcAndMiliseconds
    {
        public int UtcSeconds;
        public int Miliseconds;

        public UtcAndMiliseconds(DateTime localTime)
        {
            DateTime time = localTime.ToUniversalTime();
            UtcSeconds = time.ToUtcSeconds();
            Miliseconds = time.Millisecond * 1000;
        }

        public UtcAndMiliseconds(DateTime localTime, bool noUTC)
        {
            if (noUTC)
            {
                UtcSeconds = localTime.ToUnixLocalSeconds();
                Miliseconds = localTime.Millisecond * 1000;
            }
            else
            {
                UtcSeconds = localTime.ToUtcSeconds();
                Miliseconds = localTime.Millisecond * 1000;
            }
        }

        public DateTime ToUtcDateTime()
        {
            var datetime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(UtcSeconds).AddMilliseconds(Miliseconds / 1000);

            return datetime;
        }

        public DateTime ToLocalDateTime()
        {
            var utctime = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(UtcSeconds).AddMilliseconds(Miliseconds / 1000);

            return utctime.ToLocalTime();
        }

        public void SetZero()
        {
            UtcSeconds = 0; Miliseconds = 0;
        }

        public bool IsZero { get { return UtcSeconds == 0 && Miliseconds == 0; } }

        public static bool operator ==(UtcAndMiliseconds a, UtcAndMiliseconds b)
        {
            return a.UtcSeconds == b.UtcSeconds && a.Miliseconds == b.Miliseconds;
        }

        public static bool operator !=(UtcAndMiliseconds a, UtcAndMiliseconds b)
        {
            return !(a == b);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Utcseconds
    {
        public int UtcSeconds;
        //public int Miliseconds;

        public Utcseconds(DateTime localTime)
        {
            var utcTime = localTime.ToUniversalTime();
            UtcSeconds = utcTime.ToUtcSeconds();
            //Miliseconds = utcTime.Millisecond * 1000;
        }

        public DateTime ToUtcDateTime()
        {
            var datetime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(UtcSeconds);//.AddMilliseconds(Miliseconds / 1000);

            return datetime;
        }

        public DateTime ToLocalDateTime()
        {
            var utctime = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(UtcSeconds);//.AddMilliseconds(Miliseconds / 1000);

            return utctime.ToLocalTime();
        }
    }
}
