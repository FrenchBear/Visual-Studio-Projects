// RI3 - Batch Pics Resize Tool v3
// Version 3.1, uses GDI to resize bitmaps, and preserve EXIF info from original pic
//
// 2013-07-14   PV      First version 3, rewrite in C#, WPF and MVVM, Multitasking
// 2013-07-15   PV      Use GDI instead of WPF for image resize and save to preserve EXIF info from original image
// 2013-07-23   PV      When processing subfolders, remove "HR suffix"
// 2021-09-26   PV      VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13

using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace RI3;

#pragma warning disable IDE0305 // Simplify collection initialization

public class Model
{
    // Initialization
    public Model()
    {
        // Initialization for multitasking (Max number of // tasks)
        MAX_PARALLISM = Environment.ProcessorCount > 4
            ? Environment.ProcessorCount - 2
            : Environment.ProcessorCount > 2 ? Environment.ProcessorCount - 1 : Environment.ProcessorCount;
        if (MAX_PARALLISM < 1)
            MAX_PARALLISM = 1;

        // Folders just for testing
        SourceFolder = "";  // @"D:\A_Copier\2013-06 Vacances AK et YT (Extrait) HR Test";
        TargetFolder = "";  // @"C:\Temp\2013-06 Vacances AK et YT (Extrait)";

        // Reasonable defaults
        LargeSideSize = 2000;       // 2000 for GoogleDrive (free storage up to 2048px!)
        JpegQuality = 90;           // Good compression without losing quality
    }

    // ViewModel
#pragma warning disable IDE0052 // Remove unread private members
    private ViewModel vm;
#pragma warning restore IDE0052 // Remove unread private members

    public void SetViewModel(ViewModel vm) => this.vm = vm;

    // Variables exposed to ViewModel
    public string SourceFolder;

    public string TargetFolder;
    public bool IncludeSubFolders;
    public int LargeSideSize;
    public int JpegQuality;

    // Processed files and cache
    private string[] processedFilesList;                // List of filenames being converted

    // Multitasking
    private readonly int MAX_PARALLISM;

    public void DoGenerate(CancellationToken cancelToken, IProgress<ProgressInfo> progress)
    {
        // Build the list of files to process
        processedFilesList = Directory.GetFiles(SourceFolder, "*.jpg", IncludeSubFolders ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);

        progress.Report(new ProgressInfo(0, processedFilesList.Length,
            $"Génération de {processedFilesList.Length} vignettes"));
        progress.Report(new ProgressInfo(0, processedFilesList.Length, $"{SourceFolder} --> {TargetFolder}"));

        // List of tasks running in parallel
        var lt = new List<Task<string>>();

        // Will execute generation in a separate thread, no need for async/await since everything is done
        // in this thread, there is no final action to indicate that hashing is done, this is reported
        // through IProgress interface
        _ = Task.Run(/* async */ () =>
          {
              var n = 0;      // Number of active hashing tasks
              var p = 0;      // Number of processed files

              // Hash MAX_PARALLISM files in parallel
              foreach (var file in processedFilesList)
              {
                  if (cancelToken.IsCancellationRequested)
                      goto ExitGenerate;

                  var s = file.Remove(0, SourceFolder.Length + (SourceFolder.EndsWith('\\') ? 0 : 1));    // Avoid problems with loop variables
                  lt.Add(Task.Run(() => ConvertImage(s)));
                  n++;
                  if (n == MAX_PARALLISM)
                  {
                      //await Task.WhenAny(lt.ToArray());
                      _ = Task.WaitAny(lt.ToArray());
                      lock (lt)
                      {
                          var lf = new List<Task<string>>();
                          foreach (var t in lt)
                              if (t.IsCompleted)
                              {
                                  lf.Add(t);
                                  n--;
                                  progress.Report(new ProgressInfo(++p, processedFilesList.Length, t.Result));
                              }
                          foreach (var t in lf)
                              _ = lt.Remove(t);
                      }
                  }
              }

              // Wail all tasks to terminate
              while (n > 0)
              {
                  if (cancelToken.IsCancellationRequested)
                      goto ExitGenerate;

                  //await Task.WhenAny(lt.ToArray());
                  _ = Task.WaitAny(lt.ToArray());
                  lock (lt)
                  {
                      var lf = new List<Task<string>>();
                      foreach (var t in lt)
                          if (t.IsCompleted)
                          {
                              lf.Add(t);
                              n--;
                              progress.Report(new ProgressInfo(++p, processedFilesList.Length, t.Result));
                          }
                      foreach (var t in lf)
                          _ = lt.Remove(t);
                  }
              }

          ExitGenerate:
              ;
          }, cancelToken);
    }

    public string ConvertImage(string fileName)
    {
        string fileNameHRStripped;
        if (Path.GetDirectoryName(fileName).EndsWith(" HR", StringComparison.InvariantCultureIgnoreCase))
        {
            var d = Path.GetDirectoryName(fileName);
            fileNameHRStripped = Path.Combine(d.Remove(d.Length - 3, 3), Path.GetFileName(fileName));
        }
        else
            fileNameHRStripped = fileName;

        var imagePath = Path.Combine(SourceFolder, fileName);
        var vignettePath = Path.Combine(TargetFolder, fileNameHRStripped);

        // Using GDI
        System.Drawing.Image image = new System.Drawing.Bitmap(imagePath);

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
                newHeight = (int)(LargeSideSize / (double)originalWidth * originalHeight);
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
                newWidth = (int)(LargeSideSize / (double)originalHeight * originalWidth);
            }
        }

        // GDI
        System.Drawing.Image vignette = new System.Drawing.Bitmap(image, newWidth, newHeight);
        // Preserve origiginal image EXIF attributes
        foreach (var propItem in image.PropertyItems)
            vignette.SetPropertyItem(propItem);

        EncoderParameters eps = new(1);
        eps.Param[0] = new EncoderParameter(Encoder.Quality, JpegQuality);
        var ici = GetEncoderInfo("image/jpeg");

        if (!Directory.Exists(Path.GetDirectoryName(vignettePath)))
            _ = Directory.CreateDirectory(Path.GetDirectoryName(vignettePath));
        vignette.Save(vignettePath, ici, eps);

        return fileName;
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
}

// For IProgress
public class ProgressInfo(int index, int total, string fileName)
{
    public int Index = index;
    public int Total = total;
    public string FileName = fileName;
}
