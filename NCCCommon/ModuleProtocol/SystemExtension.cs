using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCCCommon
{
    public static class SystemExtension
    {
        public static int ToUtcSeconds(this DateTime dt)
        {
            var diff = dt.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return (int)diff.TotalSeconds;
        }

        static DateTime epochTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        public static int ToUnixLocalSeconds(this DateTime dt)
        {
            var diff = dt - epochTime;
            return (int)diff.TotalSeconds;
        }
    }

}
