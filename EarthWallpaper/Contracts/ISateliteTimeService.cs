using System;
using System.Collections.Generic;
using System.Text;

namespace EarthWallpaper.Contracts
{
    public interface ISateliteTimeService
    {
        DateTime FixDate(DateTime date, string targetTimezone);
    }
}
