// RI3 - Batch Pics Resize Tool v3
// Version 3.1, uses GDI to resize bitmaps, and preserve EXIF info from original pic
//
// 2013-07-14   PV  First version 3, rewrite in C#, WPF anv MVVM, Multitasking
// 2013-07-15   PV  Use GDI instead of WPF for image resize and save to preserve EXIF info from original image
// 2013-07-23   PV  When processing subfolders, remove "HR suffix"

using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

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
            else if (Environment.ProcessorCount > 2)
                MAX_PARALLISM = Environment.ProcessorCount - 1;
            else
                MAX_PARALLISM = Environment.ProcessorCount;
            if (MAX_PARALLISM < 1) MAX_PARALLISM = 1;

            // Folders just for testing
            SourceFolder = "";  // @"D:\A_Copier\2013-06 Vacances AK et YT (Extrait) HR Test";
            TargetFolder = "";  // @"C:\Temp\2013-06 Vacances AK et YT (Extrait)";

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
            processedFilesList = Directory.GetFiles(SourceFolder, "*.jpg", IncludeSubFolders ? System.IO.SearchOption.AllDirectories : System.IO.SearchOption.TopDirectoryOnly);

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

        public string ConvertImage(string fileName)
        {
            string fileNameHRStripped;
            if (Path.GetDirectoryName(fileName).EndsWith(" HR", StringComparison.InvariantCultureIgnoreCase))
            {
                string d = Path.GetDirectoryName(fileName);
                fileNameHRStripped = Path.Combine(d.Remove(d.Length - 3, 3), Path.GetFileName(fileName));
            }
            else
                fileNameHRStripped = fileName;

            string imagePath = Path.Combine(SourceFolder, fileName);
            string vignettePath = Path.Combine(TargetFolder, fileNameHRStripped);

            // Using GDI
            System.Drawing.Image image = new System.Drawing.Bitmap(imagePath);

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
            // Preserve origiginal image EXIF attributes
            foreach (PropertyItem propItem in image.PropertyItems)
                vignette.SetPropertyItem(propItem);

            EncoderParameters eps = new EncoderParameters(1);
            eps.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, JpegQuality);
            ImageCodecInfo ici = GetEncoderInfo("image/jpeg");

            if (!Directory.Exists(Path.GetDirectoryName(vignettePath)))
                Directory.CreateDirectory(Path.GetDirectoryName(vignettePath));
            vignette.Save(vignettePath, ici, eps);

            return fileName;
        }

        private ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j <= encoders.Length; j++)
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            return null;
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