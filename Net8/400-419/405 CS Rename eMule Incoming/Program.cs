// 405 Rename eMule Incoming
//
// 2011-05-16   PV
// 2021-09-23	PV		VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12

using System.IO;
using System.Text.RegularExpressions;
using static System.Console;

namespace Rename_eMule_Incoming;

internal partial class Program
{
    private static void Main(string[] args)
    {
        var d = new DirectoryInfo(@"F:\eMule\Incoming");
        Regex r = MyRegex();

        foreach (var f in d.EnumerateFiles())
            if (string.Compare(f.Extension, ".avi", true) == 0 || string.Compare(f.Extension, ".mkv", true) == 0)
            {
                WriteLine(f.Name);
                var m = r.Match(Path.GetFileNameWithoutExtension(f.Name));
                if (m.Success)
                {
                    var newName = f.DirectoryName + "\\" + Clean(m.Groups["p"].Value) + " - " + m.Groups["e"].Value + " - " + Clean(m.Groups["s"].Value) + Path.GetExtension(f.Name);
                    if (newName != f.FullName)
                        File.Move(f.FullName, newName);
                }
            }
    }

    private static string Clean(string s)
        => s.Replace('.', ' ').Trim([' ', '-']);

    [GeneratedRegex("^(?<p>[^0-9]*)(?<e>[0-9]{1,2}x[0-9]{1,2})(?<s>.*)$", RegexOptions.IgnoreCase, "fr-FR")]
    private static partial Regex MyRegex();
}
