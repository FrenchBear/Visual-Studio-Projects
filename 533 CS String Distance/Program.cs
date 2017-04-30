using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using static System.Math;
using static System.Console;
using static System.Threading.Interlocked;
using static System.Threading.Tasks.Parallel;


namespace String_Distance
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Debug.Assert(StringDistance("abcd", "abce", 1));
            Debug.Assert(StringDistance("abcde", "abcd", 1));
            Debug.Assert(StringDistance("bcd", "abcd", 1));
            Debug.Assert(StringDistance("abcde", "abe", 2));
            */

            string[] fileList = Directory.GetFiles(@"C:\MusicGD\MP3P\Chansons Intl", "*.mp3", SearchOption.AllDirectories);
            WriteLine($"{fileList.Length} files analyzis started");
            int nb = 0;
            fileList.AsParallel().ForAll(f =>
                {
                    Increment(ref nb);
                    Write("{0:P1}\r", ((double)nb) / fileList.Length);
                    for (int i = Array.IndexOf(fileList, f) + 1; i < fileList.Length; i++)
                    {
                        if (f == fileList[i])
                            WriteLine($"Duplicate: {f}");
                        if (StringDistance(f, fileList[i], 1))
                            WriteLine($"Dist 1: {f}  {fileList[i]}");
                        if (StringDistance(f, fileList[i], 2))
                            WriteLine($"Dist 2: {f}  {fileList[i]}");
                    }
                });

            Console.WriteLine();
            Console.Write("(Pause)");
            Console.ReadLine();
        }

        static bool StringDistance(string s1, string s2, int distance = 1)
        {
            if (Abs(s1.Length - s2.Length) > distance)
                return false;

            if (distance == 0)
                return s1 == s2;

            // delete 1 char from s1
            if (s1.Length > s2.Length)
                for (int i = 0; i < s1.Length; i++)
                {
                    string s1b = s1.Remove(i, 1);
                    if (StringDistance(s1b, s2, distance - 1)) return true;
                }
            // delete 1 char from s2
            if (s2.Length > s1.Length)
                for (int i = 0; i < s2.Length; i++)
                {
                    string s2b = s2.Remove(i, 1);
                    if (StringDistance(s1, s2b, distance - 1)) return true;
                }
            // replace 1 char
            if (s1.Length == s2.Length)
                for (int i = 0; i < s1.Length; i++)
                {
                    string s1b = s1.Substring(0, i) + s2[i] + s1.Substring(i + 1);
                    if (StringDistance(s1b, s2, distance - 1)) return true;
                }
            return false;
        }
    }


}
