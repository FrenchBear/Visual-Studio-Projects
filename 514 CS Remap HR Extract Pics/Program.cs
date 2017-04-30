// 514 CS Remap HR Extract Pics
// Tool to reselct HR original pics based on a LR extract
// 2013-07-23   PV  Second version, the first one has been deleted by accident...

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace _514_CS_Remap_HR_Extract_Pics
{
    class Program
    {
        static void Main(string[] args)
        {
            const string extractLRPath = @"C:\PicturesSD\2011\2011-08 Florida (Extrait)";
            const string extractHRPath = @"D:\PicturesSkull\2011\2011-08 Florida (Extrait) HR";
            const string sourceHRPath = @"D:\PicturesSkull\2011\2011-08 Florida HR";

            var extractList = Directory.GetFiles(extractLRPath, "*.jpg");
            foreach (string extractFile in extractList)
            {
                string source = Path.Combine(sourceHRPath, Path.GetFileName(extractFile));
                string dest = Path.Combine(extractHRPath, Path.GetFileName(extractFile));

                if (!File.Exists(source))
                    Debugger.Break();
                File.Copy(source, dest);
                Console.WriteLine(extractFile);
            }


            Console.WriteLine();
            Console.Write("(Pause)");
            Console.ReadLine();
        }
    }
}
