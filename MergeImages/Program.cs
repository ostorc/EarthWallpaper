using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MergeImages
{
    class Program
    {
        static void Main(string[] args)
        {
            int baseSize = int.Parse(args[0]);
            int rows = int.Parse(args[1]);
            int columns = int.Parse(args[2]);
            string savePath = (args[3]);

            var images = Make2DArray(args.Skip(4).ToArray(), rows, columns);

            using (Bitmap bmp = new Bitmap(baseSize * columns, baseSize * columns))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < columns; j++)
                        {
                            using (Image img = Image.FromFile(images[i, j]))
                            {
                                g.DrawImage(img, i * baseSize, j * baseSize, baseSize, baseSize);
                            }
                        }
                    }
                }
                bmp.Save(savePath);
            }
        }

        private static T[,] Make2DArray<T>(T[] input, int height, int width)
        {
            T[,] output = new T[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    output[i, j] = input[i * width + j];
                }
            }
            return output;
        }
    }


}
