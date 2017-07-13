using EarthWallpaper.Contracts;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace EarthWallpaper
{
    

    public class BackgroundService : IBackgroundService
    {
        //public enum Style : int
        //{
        //    Center, Stretch, Fill, Fit, Tile
        //}

        public const int SetDesktopWallpaper = 20;
        public const int UpdateIniFile = 0x01;
        public const int SendWinIniChange = 0x02;
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
        public void SetBackground(string file/*, Style style*/)
        {
            SystemParametersInfo(SetDesktopWallpaper, 0, file, UpdateIniFile | SendWinIniChange);
            //RegistryKey key = S.CurrentUser.OpenSubKey("Control Panel\\Desktop", true);
            //switch (style)
            //{
            //    case Style.Tile:
            //        key.SetValue(@"WallpaperStyle", "0");
            //        key.SetValue(@"TileWallpaper", "1");
            //        break;
            //    case Style.Center:
            //        key.SetValue(@"WallpaperStyle", "0");
            //        key.SetValue(@"TileWallpaper", "0");
            //        break;
            //    case Style.Stretch:
            //        key.SetValue(@"WallpaperStyle", "2");
            //        key.SetValue(@"TileWallpaper", "0");
            //        break;
            //    case Style.Fill:
            //        key.SetValue(@"WallpaperStyle", "10");
            //        key.SetValue(@"TileWallpaper", "0");
            //        break;
            //    case Style.Fit:
            //        key.SetValue(@"WallpaperStyle", "6");
            //        key.SetValue(@"TileWallpaper", "0");
            //        break;
            //}
            //key.Close();
        }
    }
}
