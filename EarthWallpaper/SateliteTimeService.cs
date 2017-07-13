using EarthWallpaper.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EarthWallpaper
{
    public class SateliteTimeService : ISateliteTimeService
    {
        public  DateTime FixDate(DateTime date, string targetTimezone)
        {
            date = TimeZoneInfo.ConvertTime(date, TimeZoneInfo.FindSystemTimeZoneById(targetTimezone));
            return new DateTime(date.Year, date.Month, date.Day - 1, date.Hour, (date.Minute / 10) * 10, 0);
        }
    }
}
