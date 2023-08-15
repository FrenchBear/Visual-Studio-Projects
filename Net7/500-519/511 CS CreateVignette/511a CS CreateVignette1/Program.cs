// 2021-09-26   PV      VS2022; Net6
// 2023-01-10	PV		Net7

using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

#pragma warning disable IDE0059 // Unnecessary assignment of a value

namespace CreateVignette;

internal class Program
{
    private static void Main(string[] args)
    {
        var testc = new Test();
        _ = testc.ConvertImage("DSC_09786.JPG");
    }
}

internal class Test
{
    private readonly string SourceFolder = @"C:\temp\F1";
    private readonly string TargetFolder = @"D:\Temp";
    private readonly int LargeSideSize = 2500;
    private readonly int JpegQuality = 90;

    public string ConvertImage(string fileName)
    {
        var imagePath = Path.Combine(SourceFolder, fileName);
        var vignettePath = Path.Combine(TargetFolder, fileName);

        BitmapImage bi = new(new Uri(imagePath));

        /* Check MetaData, but unfortunately always null, whether it's EXIF
         * properties or Shell extended attributes
         */
        JpegBitmapDecoder decoder = new(new Uri(imagePath), BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
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

        var bi2 = ResizeBitmap(bi, newWidth, newHeight);
        JpegBitmapEncoder encoder = new()
        {
            QualityLevel = JpegQuality
        };
        encoder.Frames.Add(BitmapFrame.Create(bi2));
        using FileStream output = new(vignettePath, FileMode.Create);
        encoder.Save(output);

        //Debugger.Break();

        return fileName;
    }

    public static BitmapSource ResizeBitmap(BitmapSource source, int nWidth, int nHeight)
    {
        TransformedBitmap tbBitmap = new(source,
            new ScaleTransform((double)nWidth / (double)source.PixelWidth,
                (double)nHeight / (double)source.PixelHeight,
                0, 0));
        return tbBitmap;
    }
}
