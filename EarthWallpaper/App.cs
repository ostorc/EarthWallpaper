using EarthWallpaper.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EarthWallpaper
{
    public class App : IApp
    {
        private readonly ISateliteService sateliteService;
        private readonly IBackgroundService backgroundService;

        public App(ISateliteService sateliteService, IBackgroundService backgroundService)
        {
            this.sateliteService = sateliteService;
            this.backgroundService = backgroundService;
        }

        public async void Run()
        {
            //DateTime first = new DateTime(2017, 7, 9, 14, 50, 00);
            //DateTime last = new DateTime(2017, 7, 10, 14, 30, 00);
            //List<DateTime> dates = new List<DateTime>();
            //dates.Add(first);
            //do
            //{
            //    dates.Add(dates.Last().AddMinutes(10));
            //} while (dates.Last() < last && dates.Count < 160000000);

            //List<string> images = new List<string>();

            //foreach (var date in dates)
            //{
            //    images.Add(await sateliteService.DownloadImage(date, false));
            //    Console.Clear();
            //    Console.WriteLine(dates.IndexOf(date)/dates.Count);
            //    Console.WriteLine(dates.IndexOf(date));


            //}

            var images = System.IO.Directory.GetFiles(@"D:\Temp");

            using (ImageMagick.MagickImageCollection coll = new ImageMagick.MagickImageCollection())
            {
                try
                {
                    for (int i = 0; i < images.Length; i++)
                    {
                        coll.Add(new ImageMagick.MagickImage(images[i]));
                        coll[i].AnimationDelay = 5;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                
                //coll.OptimizePlus();

                coll.Write("D:\\earth2.gif");
            }
        }
    }
}
