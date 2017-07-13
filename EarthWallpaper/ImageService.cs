using EarthWallpaper.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Reflection;

namespace EarthWallpaper
{

    public class ImageService : IImageService
    {
        private readonly IConfigService configService;

        public ImageService(IConfigService configService)
        {
            this.configService = configService;
        }

        const int Dimension = 550;
        public string Merge(int rows, int columns, params string[] images)
        {
            DateTime now = DateTime.Now;
            string savePath =configService.BaseFolder +  now.ToFileTime() + ".png";
            if(images.Length == 1)
            {
                File.Copy(images[0], savePath, true);
                return savePath;
            }
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            string path = Path.GetFullPath("ExternalApp\\MergeImages.exe");
            startInfo.FileName =  "ExternalApp\\MergeImages.exe";
            startInfo.Arguments = $"{Dimension} {rows} {columns} {savePath} {images.Aggregate((i, j) => i + " " + j)}";

            try
            {
                using (Process mergeProcess = Process.Start(startInfo))
                {
                    mergeProcess.WaitForExit();
                }
            }
            catch (Exception)
            {
                throw;
            }
           
            return savePath;
        }
    }
}
