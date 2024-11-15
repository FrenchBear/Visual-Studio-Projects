// Sort algorithm in O(n)
// From https://probablydance.com/2016/12/27/i-wrote-a-faster-sorting-algorithm/
//
// 2016-12-29   PV
// 2021-09-26   PV      VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13

using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace CS603;

internal class Program
{
    private const int maxVal = 50;
    private const int numElements = 1000;

    private static void Main(string[] args)
    {
        var rnd = new Random();
        var l = Enumerable.Range(1, numElements).Select(n => rnd.Next(0, maxVal)).ToArray();
        l.WriteLine();

        var ls = Sort(l);
        WriteLine("\nSorted:");
        ls.WriteLine();

        // Check
        Array.Sort(l);
        WriteLine("\nSorted using Array.Sort:");
        l.WriteLine();

        var diff = ls.Zip(l, (x1, x2) => x1 != x2).Any(b => b);
        WriteLine("\nLists are " + (diff ? "different" : "the same"));
    }

    // Sort algorithm in O(n)
    private static int[] Sort(int[] input)
    {
        var counts = new int[numElements];
        foreach (var item in input)
            counts[item]++;

        var total = 0;
        for (var i = 0; i < input.Length; i++)
        {
            var old_count = counts[i];
            counts[i] = total;
            total += old_count;
        }

        var output = new int[input.Length];
        foreach (var item in input)
            output[counts[item]++] = item;

        return output;
    }
}

internal static class Extensions
{
    // Quick-and-dirty prints a list
    public static void WriteLine<T>(this IEnumerable<T> liste)
    {
        var first = true;
        foreach (var item in liste)
        {
            if (first)
            {
                Write('{');
                first = false;
            }
            else
                Write(", ");

            Write(item);
        }
        Console.WriteLine('}');
    }
}
