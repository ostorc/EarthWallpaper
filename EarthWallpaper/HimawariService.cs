using EarthWallpaper.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EarthWallpaper
{
    public class HimawariService : ISateliteService
    {
        // Powers of 2, max 16
        const int Quality = 1;
        /// <summary>
        /// <para>
        /// 0 - Qualtity
        /// </para>
        /// <para>
        /// 1 - Year
        /// </para>
        /// <para>
        /// 2 - Month
        /// </para>
        /// <para>
        /// 3 - Day
        /// </para>
        /// <para>
        /// 4 - Hour
        /// </para>
        /// <para>
        /// 5 - Minute
        /// </para>
        /// <para>
        /// 6 - Y
        /// </para>
        /// <para>
        /// 7 - X
        /// </para>
        /// </summary>
        const string BaseUrl = @"http://himawari8-dl.nict.go.jp/himawari8/img/D531106/{0}d/550/{1}/{2}/{3}/{4}{5}00_{6}_{7}.png";

        private readonly ISateliteTimeService timeService;
        private readonly IDownloadService downloadService;
        private readonly IImageService imageService;
        private readonly IConfigService configService;

        public HimawariService(ISateliteTimeService timeService, IDownloadService downloadService, IImageService imageService, IConfigService configService)
        {
            this.timeService = timeService;
            this.downloadService = downloadService;
            this.imageService = imageService;
            this.configService = configService; 
        }

        public Task<string> DownloadCurrentImage(bool fixDate = true)
        {
            return DownloadImage(DateTime.Now, fixDate);
        }

        public async Task<string> DownloadImage(DateTime date, bool fixDate = true)
        {
            date = fixDate ? timeService.FixDate(date, "Tokyo Standard Time") : date;

            List<string> partialImages = new List<string>();

            for (int i = 0; i < Quality; i++)
            {
                for (int j = 0; j < Quality; j++)
                {
                    try
                    {
                        string path = await downloadService.Get(GetUrl(date, i, j), ($"{configService.BaseFolder}{i}_{j}.png"));
                        partialImages.Add(path);
                    }
                    catch (Exception e)
                    {

                        throw e;
                    }
                }
            }

            return imageService.Merge(Quality, Quality, partialImages.ToArray());
        }

        private string GetUrl(DateTime date, int y, int x)
        {
            return string.Format(BaseUrl, Quality, date.Year, date.Month.ToString("00"), date.Day.ToString("00"), date.Hour.ToString("00"), date.Minute.ToString("00"), y, x);
        }
    }
}
