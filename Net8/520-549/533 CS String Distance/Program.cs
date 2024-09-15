// 2021-09-26   PV      VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12

using System;
using System.IO;
using System.Linq;
using static System.Console;
using static System.Math;
using static System.Threading.Interlocked;

namespace StringDistance;

internal class Program
{
    private static void Main(string[] args)
    {
        /*
        Debug.Assert(StringDistance("abcd", "abce", 1));
        Debug.Assert(StringDistance("abcde", "abcd", 1));
        Debug.Assert(StringDistance("bcd", "abcd", 1));
        Debug.Assert(StringDistance("abcde", "abe", 2));
        */

        var fileList = Directory.GetFiles(@"C:\MusicGD\MP3P\Chansons Intl", "*.mp3", SearchOption.AllDirectories);
        WriteLine($"{fileList.Length} files analyzis started");
        var nb = 0;
        fileList.AsParallel().ForAll(f =>
        {
            _ = Increment(ref nb);
            Write("{0:P1}\r", (double)nb / fileList.Length);
            for (var i = Array.IndexOf(fileList, f) + 1; i < fileList.Length; i++)
            {
                if (f == fileList[i])
                    WriteLine($"Duplicate: {f}");
                if (StringDistance(f, fileList[i], 1))
                    WriteLine($"Dist 1: {f}  {fileList[i]}");
                if (StringDistance(f, fileList[i], 2))
                    WriteLine($"Dist 2: {f}  {fileList[i]}");
            }
        });
    }

    private static bool StringDistance(string s1, string s2, int distance = 1)
    {
        if (Abs(s1.Length - s2.Length) > distance)
            return false;

        if (distance == 0)
            return s1 == s2;

        // delete 1 char from s1
        if (s1.Length > s2.Length)
            for (var i = 0; i < s1.Length; i++)
            {
                var s1b = s1.Remove(i, 1);
                if (StringDistance(s1b, s2, distance - 1))
                    return true;
            }
        // delete 1 char from s2
        if (s2.Length > s1.Length)
            for (var i = 0; i < s2.Length; i++)
            {
                var s2b = s2.Remove(i, 1);
                if (StringDistance(s1, s2b, distance - 1))
                    return true;
            }
        // replace 1 char
        if (s1.Length == s2.Length)
            for (var i = 0; i < s1.Length; i++)
            {
                var s1b = s1[..i] + s2[i] + s1[(i + 1)..];
                if (StringDistance(s1b, s2, distance - 1))
                    return true;
            }

        return false;
    }
}
