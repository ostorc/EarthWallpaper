using EarthWallpaper.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace EarthWallpaper
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            ServiceProvider.Init(serviceCollection);

            IApp app = ServiceProvider.Locator.GetService<IApp>();

            app.Run();
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IConfigService, ConfigService>();
            serviceCollection.AddScoped<ISateliteTimeService, SateliteTimeService>();
            serviceCollection.AddScoped<IDownloadService, DownloadService>();
            serviceCollection.AddScoped<IImageService, ImageService>();
            serviceCollection.AddScoped<IBackgroundService, BackgroundService>();
            serviceCollection.AddScoped<ISateliteService, HimawariService>();

            serviceCollection.AddSingleton<IApp, App>();

        }
    }
}