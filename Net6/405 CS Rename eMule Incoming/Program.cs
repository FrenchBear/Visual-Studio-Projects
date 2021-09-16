// 405 Rename eMule Incoming
// 2011-05-16   PV

using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Rename_eMule_Incoming
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var d = new DirectoryInfo(@"F:\eMule\Incoming");
            Regex r = new Regex(@"^(?<p>[^0-9]*)(?<e>[0-9]{1,2}x[0-9]{1,2})(?<s>.*)$", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            foreach (FileInfo f in d.EnumerateFiles())
                if (string.Compare(f.Extension, ".avi", true) == 0 || string.Compare(f.Extension, ".mkv", true) == 0)
                {
                    Console.WriteLine(f.Name);
                    Match m = r.Match(Path.GetFileNameWithoutExtension(f.Name));
                    if (m.Success)
                    {
                        string newName = f.DirectoryName + "\\" + Clean(m.Groups["p"].Value) + " - " + m.Groups["e"].Value + " - " + Clean(m.Groups["s"].Value) + Path.GetExtension(f.Name);
                        if (newName != f.FullName)
                            File.Move(f.FullName, newName);
                    }
                }

            Console.WriteLine();
            Console.Write("(Pause)");
            Console.ReadLine();
        }

        private static string Clean(string s)
        {
            return s.Replace('.', ' ').Trim(new char[] { ' ', '-' });

            /*
            s = s.Replace('.', ' ');
            while(s.StartsWith(" ") || s.StartsWith("-"))
                s = s.Remove(0,1);
            while (s.EndsWith(" ") || s.EndsWith("-"))
                s = s.Remove(s.Length-1);
            return s;
            */
        }
    }
}