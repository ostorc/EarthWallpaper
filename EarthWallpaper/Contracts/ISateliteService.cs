using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EarthWallpaper.Contracts
{
    public interface ISateliteService
    {
        Task<string> DownloadImage(DateTime date, bool fixDate = true);
        Task<string> DownloadCurrentImage(bool fixDate = true);
    }
}
