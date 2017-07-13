using System;
using System.Collections.Generic;
using System.Text;

namespace EarthWallpaper.Contracts
{
    public interface IImageService
    {
        string Merge(int rows, int columns, params string[] images);
    }
}
