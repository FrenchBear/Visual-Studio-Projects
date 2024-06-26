﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CreateVignette
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var testc = new Test();
            testc.ConvertImage("DSC_09785.JPG");

            Console.WriteLine();
            Console.Write("(Pause)");
            Console.ReadLine();
        }
    }

    internal class Test
    {
        private readonly string SourceFolder = @"D:\A_Copier\2013-06 Vacances AK et YT (Extrait) HR";
        private readonly string TargetFolder = @"C:\Temp";
        private readonly int LargeSideSize = 2500;
        private readonly int JpegQuality = 90;

        public string ConvertImage(string fileName)
        {
            string imagePath = Path.Combine(SourceFolder, fileName);
            string vignettePath = Path.Combine(TargetFolder, fileName);

            var arrHeaders = new List<string>();
            var shell = new Shell32.Shell();
            //Shell32.Folder objFolder;
            var objFolder = shell.NameSpace(@"C:\temp\F1");
            for (int i = 0; i < short.MaxValue; i++)
            {
                string header = objFolder.GetDetailsOf(null, i);
                if (String.IsNullOrEmpty(header))
                    break;
                arrHeaders.Add(header);
            }

            foreach (Shell32.FolderItem2 item in objFolder.Items())
            {
                for (int i = 0; i < arrHeaders.Count; i++)
                {
                    Console.WriteLine("{0}\t{1}: {2}", i, arrHeaders[i], objFolder.GetDetailsOf(item, i));
                }
            }
            Debugger.Break();

            // Using GDI
            System.Drawing.Image image = new System.Drawing.Bitmap(imagePath);
            PropertyItem[] propItems = image.PropertyItems;
            int count = 0;
            foreach (PropertyItem propItem in propItems)
            {
                Console.WriteLine("Property {0}, Id {1:X}, Type {2}, Len {3} ", count, propItem.Id, propItem.Type.ToString(), propItem.Len.ToString());
                count++;
            }

            //BitmapImage bi = new BitmapImage(new Uri(imagePath));

            int originalWidth = image.Width;
            int originalHeight = image.Height;
            int newWidth, newHeight;
            if (originalWidth > originalHeight)
            {
                if (originalWidth < LargeSideSize)
                {
                    // smaller images keep their size
                    newWidth = originalWidth;
                    newHeight = originalHeight;
                }
                else
                {
                    newWidth = LargeSideSize;
                    newHeight = (int)((double)LargeSideSize / (double)originalWidth * (double)originalHeight);
                }
            }
            else
            {
                if (originalHeight < LargeSideSize)
                {
                    // smaller images keep their size
                    newWidth = originalWidth;
                    newHeight = originalHeight;
                }
                else
                {
                    newHeight = LargeSideSize;
                    newWidth = (int)((double)LargeSideSize / (double)originalHeight * (double)originalWidth);
                }
            }

            // GDI
            System.Drawing.Image vignette = new System.Drawing.Bitmap(image, newWidth, newHeight);

            foreach (PropertyItem propItem in propItems)
                vignette.SetPropertyItem(propItem);

            var eps = new EncoderParameters(1);
            eps.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, JpegQuality);
            ImageCodecInfo ici = GetEncoderInfo("image/jpeg");

            vignette.Save(vignettePath, ici, eps);
            Debugger.Break();

            /*
             * // WPF
            BitmapSource bi2 = ResizeBitmap(bi, newWidth, newHeight);
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.QualityLevel = JpegQuality;
            encoder.Frames.Add(BitmapFrame.Create(bi2));
            using (FileStream output = new FileStream(vignettePath, FileMode.Create))
            {
                encoder.Save(output);
            }
            */

            return fileName;
        }

        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j <= encoders.Length; j++)
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            return null;
        }

        public static BitmapSource ResizeBitmap(BitmapSource source, int nWidth, int nHeight)
        {
            var tbBitmap = new TransformedBitmap(source,
                                                      new ScaleTransform((double)nWidth / (double)source.PixelWidth,
                                                                         (double)nHeight / (double)source.PixelHeight,
                                                                         0, 0));
            return tbBitmap;
        }
    }
}