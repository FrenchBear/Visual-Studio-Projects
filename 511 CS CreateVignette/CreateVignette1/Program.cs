using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using System.Drawing.Imaging;

namespace CreateVignette
{
    class Program
    {
        static void Main(string[] args)
        {
            var testc = new Test();
            testc.ConvertImage("DSC_09786.JPG");

            Console.WriteLine();
            Console.Write("(Pause)");
            Console.ReadLine();
        }
    }

    class Test
    {
        readonly string SourceFolder = @"C:\temp\F1";
        readonly string TargetFolder = @"D:\Temp";
        readonly int LargeSideSize = 2500;
        readonly int JpegQuality = 90;

        public string ConvertImage(string fileName)
        {
            string imagePath = Path.Combine(SourceFolder, fileName);
            string vignettePath = Path.Combine(TargetFolder, fileName);

            BitmapImage bi = new BitmapImage(new Uri(imagePath));

            /* Check MetaData, but unfortunately always null, whether it's EXIF
             * properties or Shell extended attributes
             */
            JpegBitmapDecoder decoder = new JpegBitmapDecoder(new Uri(imagePath), BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            var v = decoder.Metadata;
            Debugger.Break();

            int newWidth, newHeight;
            if (bi.PixelWidth > bi.PixelHeight)
            {
                if (bi.PixelWidth < LargeSideSize)
                {
                    // smaller images keep their size
                    newWidth = bi.PixelWidth;
                    newHeight = bi.PixelHeight;
                }
                else
                {
                    newWidth = LargeSideSize;
                    newHeight = (int)((double)LargeSideSize / (double)bi.PixelWidth * (double)bi.PixelHeight);
                }
            }
            else
            {
                if (bi.PixelHeight < LargeSideSize)
                {
                    // smaller images keep their size
                    newWidth = bi.PixelWidth;
                    newHeight = bi.PixelHeight;
                }
                else
                {
                    newHeight = LargeSideSize;
                    newWidth = (int)((double)LargeSideSize / (double)bi.PixelHeight * (double)bi.PixelWidth);
                }
            }

            BitmapSource bi2 = ResizeBitmap(bi, newWidth, newHeight);
            JpegBitmapEncoder encoder = new JpegBitmapEncoder
            {
                QualityLevel = JpegQuality
            };
            encoder.Frames.Add(BitmapFrame.Create(bi2));
            using (FileStream output = new FileStream(vignettePath, FileMode.Create))
            {
                encoder.Save(output);
            }

            //Debugger.Break();

            return fileName;
        }

        public static BitmapSource ResizeBitmap(BitmapSource source, int nWidth, int nHeight)
        {
            TransformedBitmap tbBitmap = new TransformedBitmap(source,
                                                      new ScaleTransform((double)nWidth / (double)source.PixelWidth,
                                                                         (double)nHeight / (double)source.PixelHeight,
                                                                         0, 0));
            return tbBitmap;
        }
    }
}
