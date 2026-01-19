// 510 CS Rename Parentheses
//
// 2013-03-20   PV
// 2013-07-03   PV      Sophisticated algorithm to rename including a suffix a to z, aa to zz, aaa to zzz if new name already exists
// 2021-09-26   PV      VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13
// 2026-01-19	PV		Net10 C#14

using System.IO;
using System.Text.RegularExpressions;
using static System.Console;

namespace RenameParen;

internal partial class Program
{
    private static void Main(string[] args)
    {
        Regex r = MyRegex();         // number between parentheses at the end of filename
        const string SearchRoot = @"C:\Music\Humour";

        foreach (var file in Directory.GetFiles(SearchRoot, "*.*", SearchOption.AllDirectories))
        {
            var m = r.Match(file);
            if (m.Success)
            {
                WriteLine(file);
                var newFile = r.Replace(file, "a");
                File.Move(file, newFile);
                continue;

                // Ignore unreachable code warning
#pragma warning disable 0162
                // Rename mechanism
                const string replace = ".jpg";

                var newFile2 = r.Replace(file, replace);  // file; // file.Replace('(', '[').Replace(')', ']');
                var c0 = '`';
                var c1 = '`';
                var c2 = 'a';
                while (File.Exists(newFile))
                {
                    newFile = c0 != '`'
                        ? r.Replace(file, new string(c0, 1) + new string(c1, 1) + new string(c2, 1) + replace)
                        : c1 != '`' ? r.Replace(file, new string(c1, 1) + new string(c2, 1) + replace) : r.Replace(file, c2 + replace);

                    if (c2 == 'z')
                    {
                        c2 = 'a';
                        c1++;
                        if (c1 == 'z')
                        {
                            c1 = 'a';
                            c0++;
                        }
                    }
                    else
                        c2++;
                }

                WriteLine(file);
                WriteLine(newFile);
                WriteLine();
                File.Move(file, newFile);
            }
        }

    }

    [GeneratedRegex("( *\\([0-9]+\\))\\.")]
    private static partial Regex MyRegex();
}
