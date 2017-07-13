using System;
using System.Collections.Generic;
using System.Text;
using EarthWallpaper.Contracts;

namespace EarthWallpaper
{
    public class ConfigService : IConfigService
    {
        const string BasePath = "D:\\Temp\\";
        public string BaseFolder
        {
            get
            {
                return BasePath;
            }
        }
    }
}
