// DupMP3
// Find duplicate MP3 files
// 2013-09-07 PV
//
// Find filenames that have only 1 or 2 characters different (case always insignificant)

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace DupMP31
{
    internal class AString
    {
        public string FullPath;     // only for main objects
        public string Name;

        private List<AString> reducedList;

        public List<AString> ReducedList
        {
            get
            {
                if (reducedList == null)
                {
                    var l = new List<AString>();
                    for (int i = 0; i < Name.Length; i++)
                        l.Add(new AString { Name = this.Name.Remove(i, 1) });
                    reducedList = l;
                }
                return reducedList;
            }
        }
    }

    internal class Program
    {
        private const string folder = @"C:\MusicGD\MP3P\Divers\Noël";
        private const int dist = 2;

        private static void Main(string[] args)
        {
            List<AString> AStringsList = new List<AString>();

            // Retrieve list of files first and build ListAFiles
            foreach (string item in Directory.GetFiles(folder, "*.mp3", SearchOption.AllDirectories))
                AStringsList.Add(new AString { FullPath = item, Name = Path.GetFileName(item) });

            var sw = Stopwatch.StartNew();

            for (int i = 0; i < AStringsList.Count; i++)
                for (int j = i + 1; j < AStringsList.Count; j++)
                    if (IsCloseEnough(AStringsList[i], AStringsList[j], dist))
                        Console.WriteLine("{0}\r\n{1}\r\n", AStringsList[i].FullPath, AStringsList[j].FullPath);

            sw.Stop();
            Console.WriteLine("time={0}", sw.Elapsed);

            Console.WriteLine();
            Console.Write("(Pause)");
            Console.ReadLine();
        }

        private static bool IsCloseEnough(AString as1, AString as2, int dist)
        {
            string s1 = as1.Name;
            string s2 = as2.Name;

            // Quick exit
            if (Math.Abs(s1.Length - s2.Length) > dist) return false;

            // strings are equal?
            if (StringComparer.InvariantCultureIgnoreCase.Compare(s1, s2) == 0)
                return true;

            // If we look for an exact match, we're done
            if (dist == 0)
                return false;

            // One character is different?
            if (dist == 1 && s1.Length == s2.Length)
            {
                for (int i = 0; i < s1.Length - 1; i++)
                    if (as1.ReducedList[i].Name == as2.ReducedList[i].Name)
                        return true;
            }

            // s1 is always the longest chain
            if (s2.Length > s1.Length)
            {
                AString t = as1;
                as1 = as2;
                as2 = t;
            }

            // dist>1: remove 1 char from s1 and do it recursively with dist-1
            for (int i = 0; i < s1.Length; i++)
                if (IsCloseEnough(as1.ReducedList[i], as2, dist - 1))
                    return true;

            // Ok, strings are definitely different
            return false;
        }
    }
}