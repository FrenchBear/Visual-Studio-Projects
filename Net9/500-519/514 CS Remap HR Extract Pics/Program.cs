// 514 CS Remap HR Extract Pics
// Tool to reselct HR original pics based on a LR extract
//
// 2013-07-23	PV		Second version, the first one has been deleted by accident...
// 2021-09-26   PV      VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13

using System.Diagnostics;
using System.IO;
using static System.Console;

namespace CS514;

internal class Program
{
    private static void Main(string[] args)
    {
        const string extractLRPath = @"C:\PicturesSD\2011\2011-08 Florida (Extrait)";
        const string extractHRPath = @"D:\PicturesSkull\2011\2011-08 Florida (Extrait) HR";
        const string sourceHRPath = @"D:\PicturesSkull\2011\2011-08 Florida HR";

        var extractList = Directory.GetFiles(extractLRPath, "*.jpg");
        foreach (var extractFile in extractList)
        {
            var source = Path.Combine(sourceHRPath, Path.GetFileName(extractFile));
            var dest = Path.Combine(extractHRPath, Path.GetFileName(extractFile));

            if (!File.Exists(source))
                Debugger.Break();
            File.Copy(source, dest);
            WriteLine(extractFile);
        }
    }
}
