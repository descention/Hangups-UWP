﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangupsCore.Helpers
{
    public static class DateTimeExtension
    {
        public static TimeSpan TimeIntervalSince1970(this DateTime date)
        {
            TimeSpan t = date - new DateTime(1970, 1, 1);
            return t;
        }

        public static DateTime FromMillisecondsSince1970(this DateTime date, double milliseconds)
        {
            date = new DateTime(1970, 1, 1, 0, 0, 0).AddMilliseconds(milliseconds);
            return date;
        }
    }
}
