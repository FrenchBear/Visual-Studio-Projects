// 415 CS Extension Methods
//
// 2012-01-29 PV
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;

namespace CS415_Extension_Methods;
internal class Program
{
    private static void Main(string[] args)
    {
        var s = "hello world";
        string t = s.Reverse().Concat();
        int n = s.WordCount();

        WriteLine(t);
        WriteLine(n);
    }
}

public static class MyExtensions
{
    private static readonly char[] separator = [' ', '.', '?'];

    public static int WordCount(this string str)
        => str.Split(separator, StringSplitOptions.RemoveEmptyEntries).Length;

    public static string Concat(this IEnumerable<char> ie)
    {
        var sb = new StringBuilder();
        foreach (var c in ie)
            _ = sb.Append(c);
        return sb.ToString();
    }
}
