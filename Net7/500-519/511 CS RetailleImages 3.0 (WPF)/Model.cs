// RI3 - Batch Pics Resize Tool v3.0 (WPF)
// Version 3.0, uses WPF to resize bitmaps, but don't support EXIF properties
//
// 2013-07-14   PV      First version 3, rewrite in C#, WPF and MVVM
// 2021-09-26   PV      VS2022; Net6
// 2023-01-10	PV		Net7

#pragma warning disable IDE0052 // Remove unread private members

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace RI3;

public class Model
{
    // Initialization
    public Model()
    {
        // Initialization for multitasking (Max number of // tasks)
        MAX_PARALLISM = Environment.ProcessorCount > 4 ? Environment.ProcessorCount - 2 : Environment.ProcessorCount - 1;
        if (MAX_PARALLISM < 1)
            MAX_PARALLISM = 1;

        // Folders just for testing
        SourceFolder = @"C:\Users\Pierre\Desktop\2013-06 Vacances AK et YT (Extrait) HR";
        TargetFolder = @"C:\Users\Pierre\Desktop\2013-06 Vacances AK et YT (Extrait)";

        // Reasonable defaults
        LargeSideSize = 2000;       // 2000 for GoogleDrive (free storage up to 2048px!)
        JpegQuality = 90;           // Good compression without losing quality
    }

    // ViewModel
    private ViewModel vm;

    public void SetViewModel(ViewModel vm) => this.vm = vm;

    // Variables exposed to ViewModel
    public string SourceFolder;

    public string TargetFolder;
    public int LargeSideSize;
    public int JpegQuality;

    // Processed files and cache
    private string[] processedFilesList;                // List of filenames being converted

    // Multitasking
    private readonly int MAX_PARALLISM;

    public void DoGenerate(CancellationToken cancelToken, IProgress<ProgressInfo> progress)
    {
        // Build the list of files to process
        processedFilesList = Directory.GetFiles(SourceFolder, "*.jpg");

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

                  var s = file.Remove(0, SourceFolder.Length + (SourceFolder.EndsWith("\\") ? 0 : 1));    // Avoid problems with loop variables
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

    private string ConvertImage(string fileName)
    {
        var imagePath = Path.Combine(SourceFolder, fileName);
        var vignettePath = Path.Combine(TargetFolder, fileName);

        BitmapImage bi = new(new Uri(imagePath));

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

        // WPF resizing and save
        var bi2 = ResizeBitmap(bi, newWidth, newHeight);
        JpegBitmapEncoder encoder = new()
        {
            QualityLevel = JpegQuality
        };
        encoder.Frames.Add(BitmapFrame.Create(bi2));
        using FileStream output = new(vignettePath, FileMode.Create);
        encoder.Save(output);

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

// For IProgress
public class ProgressInfo
{
    public ProgressInfo(int index, int total, string fileName)
    {
        Index = index;
        Total = total;
        FileName = fileName;
    }

    public int Index;
    public int Total;
    public string FileName;
}
