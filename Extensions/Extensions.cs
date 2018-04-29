using System;

namespace LMSIS.Extensions
{
    public static class Extensions
    {
        public static string ToDateTime2(this DateTime dt)
        {
            string ret = dt.Year + "-" + dt.Month + "-" + dt.Day;
            return ret;
        }
    }
}