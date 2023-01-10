// 2021-09-26   PV      VS2022; Net6
// 2023-01-10	PV		Net7

using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static System.Console;

namespace CreateVignette;

internal class Program
{
    private static void Main(string[] args)
    {
        var testc = new Test();
        _ = testc.ConvertImage("DSC_09785.JPG");
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
        var imagePath = Path.Combine(SourceFolder, fileName);
        var vignettePath = Path.Combine(TargetFolder, fileName);

        //List<string> arrHeaders = new List<string>();
        //var shell = new Shell32.Shell();
        ////Shell32.Folder objFolder;
        //var objFolder = shell.NameSpace(@"C:\temp\F1");
        //for (int i = 0; i < short.MaxValue; i++)
        //{
        //    string header = objFolder.GetDetailsOf(null, i);
        //    if (String.IsNullOrEmpty(header))
        //        break;
        //    arrHeaders.Add(header);
        //}

        //foreach (Shell32.FolderItem2 item in objFolder.Items())
        //{
        //    for (int i = 0; i < arrHeaders.Count; i++)
        //    {
        //        WriteLine("{0}\t{1}: {2}", i, arrHeaders[i], objFolder.GetDetailsOf(item, i));
        //    }
        //}
        //Debugger.Break();

        // Using GDI
        System.Drawing.Image image = new System.Drawing.Bitmap(imagePath);
        var propItems = image.PropertyItems;
        var count = 0;
        foreach (var propItem in propItems)
        {
            WriteLine("Property {0}, Id {1:X}, Type {2}, Len {3} ", count, propItem.Id, propItem.Type.ToString(), propItem.Len.ToString());
            count++;
        }

        //BitmapImage bi = new BitmapImage(new Uri(imagePath));

        var originalWidth = image.Width;
        var originalHeight = image.Height;
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

        foreach (var propItem in propItems)
            vignette.SetPropertyItem(propItem);

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

    private static ImageCodecInfo GetEncoderInfo(string mimeType)
    {
        int j;
        var encoders = ImageCodecInfo.GetImageEncoders();
        for (j = 0; j <= encoders.Length; j++)
        {
            if (encoders[j].MimeType == mimeType)
                return encoders[j];
        }

        return null;
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
