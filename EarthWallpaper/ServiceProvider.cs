using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace EarthWallpaper
{
    public class ServiceProvider
    {
        public static IServiceProvider Locator { get; private set; }

        private ServiceProvider(IServiceCollection serviceCollection)
        {
            ConfigureServices(serviceCollection);
            Locator = serviceCollection.BuildServiceProvider();
        }

        public static void Init(IServiceCollection serviceCollection = null)
        {
            new ServiceProvider(serviceCollection ?? new ServiceCollection());
        }

        private void ConfigureServices(IServiceCollection serviceCollection)
        {
            // Třeba sem dát logování, ale...
        }
    }
}
