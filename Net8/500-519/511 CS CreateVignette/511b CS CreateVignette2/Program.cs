// 2021-09-26   PV      VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12

using System;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static System.Console;

namespace CS511b;

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
    private readonly string SourceFolder = @"C:\Temp\F1";
    private readonly string TargetFolder = @"D:\Temp";
    private readonly int LargeSideSize = 2500;
    private readonly int JpegQuality = 90;

    public string ConvertImage(string fileName)
    {
        var imagePath = Path.Combine(SourceFolder, fileName);
        var vignettePath = Path.Combine(TargetFolder, fileName);

        // Using GDI
        System.Drawing.Image image = new System.Drawing.Bitmap(imagePath);
        DumpPropItems(image);

        var originalWidth = image.Width;
        var originalHeight = image.Height;
        int newWidth, newHeight;
        if (originalWidth > originalHeight)
            if (originalWidth < LargeSideSize)
            {
                // smaller images keep their size
                newWidth = originalWidth;
                newHeight = originalHeight;
            }
            else
            {
                newWidth = LargeSideSize;
                newHeight = (int)(LargeSideSize / (double)originalWidth * originalHeight);
            }
        else
            if (originalHeight < LargeSideSize)
        {
            // smaller images keep their size
            newWidth = originalWidth;
            newHeight = originalHeight;
        }
        else
        {
            newHeight = LargeSideSize;
            newWidth = (int)(LargeSideSize / (double)originalHeight * originalWidth);
        }

        // GDI
        System.Drawing.Image vignette = new System.Drawing.Bitmap(image, newWidth, newHeight);

        // Transfer original EXIF attributes
        foreach (var propItem in image.PropertyItems)
            vignette.SetPropertyItem(propItem);
        //vignette.SetPropertyItem(image.PropertyItems[0]);
        //DumpPropItems(vignette);

        EncoderParameters eps = new(1);
        eps.Param[0] = new EncoderParameter(Encoder.Quality, JpegQuality);
        var ici = GetEncoderInfo("image/jpeg");

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

    private static void DumpPropItems(System.Drawing.Image image)
    {
        var propItems = image.PropertyItems;
        var count = 0;
        foreach (var propItem in propItems)
        {
            Write("Property {0}, Id {1:X}, Type {2}, Len {3}, ", count, propItem.Id, propItem.Type.ToString(), propItem.Len.ToString());
            for (var j = 0; j < propItem.Len; j++)
            {
                var b = propItem.Value[j];
                Write(b is >= 32 and <= 127 ? (char)b : '?');
            }
            WriteLine();
            count++;
        }
    }

    private static ImageCodecInfo GetEncoderInfo(string mimeType)
    {
        int j;
        var encoders = ImageCodecInfo.GetImageEncoders();
        for (j = 0; j <= encoders.Length; j++)
            if (encoders[j].MimeType == mimeType)
                return encoders[j];

        return null;
    }

    public static BitmapSource ResizeBitmap(BitmapSource source, int nWidth, int nHeight)
    {
        TransformedBitmap tbBitmap = new(source,
            new ScaleTransform(nWidth / (double)source.PixelWidth,
                nHeight / (double)source.PixelHeight,
                0, 0));
        return tbBitmap;
    }
}
