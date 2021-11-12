// 510 CS Rename Parentheses
//
// 2013-03-20   PV
// 2013-07-03   PV      Sophisticated algorithm to rename including a suffix a to z, aa to zz, aaa to zzz if new name already exists
// 2021-09-26   PV      VS2022; Net6

using System;
using System.IO;
using System.Text.RegularExpressions;

namespace RenameParen;

internal class Program
{
    private static void Main(string[] args)
    {
        Regex r = new(@"( *\([0-9]+\))\.");         // number between parentheses at the end of filename
        const string SearchRoot = @"C:\Music\Humour";

        foreach (string file in System.IO.Directory.GetFiles(SearchRoot, "*.*", System.IO.SearchOption.AllDirectories))
        {
            Match m = r.Match(file);
            if (m.Success)
            {
                Console.WriteLine(file);
                string newFile = r.Replace(file, "a");
                System.IO.File.Move(file, newFile);
                continue;

                // Ignore unreachable code warning
#pragma warning disable 0162
                // Rename mechanism
                const string replace = ".jpg";

                string newFile2 = r.Replace(file, replace);  // file; // file.Replace('(', '[').Replace(')', ']');
                char c0 = '`';
                char c1 = '`';
                char c2 = 'a';
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
                    {
                        c2++;
                    }
                }

                Console.WriteLine(file);
                Console.WriteLine(newFile);
                Console.WriteLine();
                System.IO.File.Move(file, newFile);
            }
        }

    }
}