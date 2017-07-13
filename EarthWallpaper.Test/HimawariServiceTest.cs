using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.DependencyInjection;
using EarthWallpaper.Contracts;

namespace EarthWallpaper.Test
{
    [TestClass]
    public class HimawariServiceTest
    {
        [TestMethod]
        public void TestFixDate()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddScoped<ISateliteTimeService, SateliteTimeService>();
            ServiceProvider.Init(services);

            ISateliteTimeService sateliteService = ServiceProvider.Locator.GetService<ISateliteTimeService>();

            DateTime now = DateTime.Now;
            DateTime fixedDate =  sateliteService.FixDate(now, "A");

            Assert.IsTrue(fixedDate.Minute % 10 == 0);
        }

        [TestMethod]
        public void TestMerge()
        {
            const string Image1 = "Resources\\0-0.png";
            const string Image2 = "Resources\\0-1.png";
            const string Image3 = "Resources\\1-0.png";
            const string Image4 = "Resources\\1-1.png";

            IServiceCollection services = new ServiceCollection();
            services.AddScoped<IImageService, ImageService>();
            ServiceProvider.Init(services);

            IImageService mergeService = ServiceProvider.Locator.GetService<IImageService>();

            mergeService.Merge(2, 2, Image1, Image2, Image3, Image4);
        }

        [TestMethod]
        public void TestDownload()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddScoped<IDownloadService, DownloadService>();
            ServiceProvider.Init(services);

            IDownloadService downloadService = ServiceProvider.Locator.GetService<IDownloadService>();

            downloadService.Get("http://ssps.cz/images/logo.png", "logo.png").GetAwaiter().GetResult();
            downloadService.Get("http://himawari8-dl.nict.go.jp/himawari8/img/D531106/1d/550/2017/07/10/101000_0_0.png", "earth.png").GetAwaiter().GetResult();
        }
    }
}
