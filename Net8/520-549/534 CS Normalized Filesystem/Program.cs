// 2021-09-26   PV      VS2022; Net6
// 2023-01-10	PV		Net7

using System;
using System.IO;
using System.Text;
using static System.Console;

namespace Normalized_Filesystem;

internal class Program
{
    private static readonly string normalizedName = @"Où ça, là!.txt";
    private static string denormalizedName;

    private static void Main(string[] args)
    {
        denormalizedName = normalizedName.Normalize(NormalizationForm.FormD);

        using (var fs = File.Create(Path.Combine(@"c:\temp", normalizedName)))
        {
            var info = new UTF8Encoding(true).GetBytes("This is some text in the file.");
            fs.Write(info, 0, info.Length);
        }

        if (File.Exists(Path.Combine(@"c:\temp", denormalizedName)))
        {
            WriteLine("Denormalized exists");
        }
        else
        {
            WriteLine("Denormalized does not exist");
            using var fs = File.Create(Path.Combine(@"c:\temp", denormalizedName));
            var info = new UTF8Encoding(true).GetBytes("Another file.");
            fs.Write(info, 0, info.Length);
        }

        WriteLine(string.Compare(normalizedName, denormalizedName, StringComparison.CurrentCulture));
        WriteLine(string.Compare(normalizedName, denormalizedName, StringComparison.CurrentCultureIgnoreCase));
        WriteLine(string.Compare(normalizedName, denormalizedName, StringComparison.InvariantCulture));
        WriteLine(string.Compare(normalizedName, denormalizedName, StringComparison.InvariantCultureIgnoreCase));
        WriteLine(string.Compare(normalizedName, denormalizedName, StringComparison.Ordinal));
        WriteLine(string.Compare(normalizedName, denormalizedName, StringComparison.OrdinalIgnoreCase));
    }
}
