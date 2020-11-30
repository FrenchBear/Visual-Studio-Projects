﻿// RI3 - Batch Pics Resize Tool v3.0 (WPF)
// Version 3.0, uses WPF to resize bitmaps, but don't support EXIF properties
//
// 2013-07-14   PV  First version 3, rewrite in C#, WPF anv MVVM

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Xml;
using Microsoft.VisualBasic.FileIO;
using System.Windows;
using System.Windows.Media;

namespace RI3
{

    public class Model
    {
        // Initialization
        public Model()
        {
            // Initialization for multitasking (Max number of // tasks)
            if (Environment.ProcessorCount > 4)
                MAX_PARALLISM = Environment.ProcessorCount - 2;
            else
                MAX_PARALLISM = Environment.ProcessorCount - 1;
            if (MAX_PARALLISM < 1) MAX_PARALLISM = 1;

            // Folders just for testing
            SourceFolder = @"C:\Users\Pierre\Desktop\2013-06 Vacances AK et YT (Extrait) HR";
            TargetFolder = @"C:\Users\Pierre\Desktop\2013-06 Vacances AK et YT (Extrait)";

            // Reasonable defaults
            LargeSideSize = 2000;       // 2000 for GoogleDrive (free storage up to 2048px!)
            JpegQuality = 90;           // Good compression without losing quality
        }


        // ViewModel
        private ViewModel vm;
        public void SetViewModel(ViewModel vm)
        {
            this.vm = vm;
        }


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

            progress.Report(new ProgressInfo(0, processedFilesList.Length, string.Format("Génération de {0} vignettes", processedFilesList.Length)));
            progress.Report(new ProgressInfo(0, processedFilesList.Length, string.Format("{0} --> {1}", SourceFolder, TargetFolder)));

            // List of tasks running in parallel
            var lt = new List<Task<string>>();

            // Will execute generation in a separate thread, no need for async/await since everything is done
            // in this thread, there is no final action to indicate that hashing is done, this is reported
            // through IProgress interface
            Task.Run(/* async */ () =>
            {
                int n = 0;      // Number of active hashing tasks
                int p = 0;      // Number of processed files

                // Hash MAX_PARALLISM files in parallel
                foreach (string file in processedFilesList)
                {
                    if (cancelToken.IsCancellationRequested) goto ExitGenerate;

                    string s = file.Remove(0, SourceFolder.Length + (SourceFolder.EndsWith("\\") ? 0 : 1));    // Avoid problems with loop variables
                    lt.Add(Task.Run(() => ConvertImage(s)));
                    n++;
                    if (n == MAX_PARALLISM)
                    {
                        //await Task.WhenAny(lt.ToArray());
                        Task.WaitAny(lt.ToArray());
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
                                lt.Remove(t);
                        }
                    }
                }

                // Wail all tasks to terminate
                while (n > 0)
                {
                    if (cancelToken.IsCancellationRequested) goto ExitGenerate;

                    //await Task.WhenAny(lt.ToArray());
                    Task.WaitAny(lt.ToArray());
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
                            lt.Remove(t);
                    }
                }

                ExitGenerate:
                ;

            }, cancelToken);

        }

        private string ConvertImage(string fileName)
        {
            string imagePath = Path.Combine(SourceFolder, fileName);
            string vignettePath = Path.Combine(TargetFolder, fileName);

            BitmapImage bi = new BitmapImage(new Uri(imagePath));

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

}
