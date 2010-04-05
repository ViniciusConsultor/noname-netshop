using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoName.Utility
{
    public class UnixTimestamp
    {
        protected static readonly DateTime unixTPStart =
            TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
        public static long ToUTP(DateTime dt)
        {
            TimeSpan toNow = dt.Subtract(unixTPStart);
            return (long)Math.Round(toNow.TotalSeconds);
        }
        public static DateTime FromUTP(long tp)
        {
            return unixTPStart.Add(new TimeSpan(tp * 10000000));
        }
    }
}
