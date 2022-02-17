// 542 CS Arrays ByRef
// Test that arrays are passed by reference in C#
//
// 2016-08-04   PV
// 2021-09-26   PV      VS2022; Net6

using System;

namespace CS542;

internal class Program
{
    private static void Main(string[] args)
    {
        var a = new int[] { 0, 1, 2, 3, 4, 5 };
        a.WriteLine();
        Test(a);
        a.WriteLine();
    }

    private static void Test(int[] a) => a[2] = 12;
}

internal static class Extensions
{
    public static void WriteLine<T>(this T[] a)
    {
        var bFirst = true;
        foreach (var e in a)
        {
            if (bFirst)
            {
                Console.Write("[");
                bFirst = false;
            }
            else
            {
                Console.Write(", ");
            }

            Console.Write(e);
        }
        Console.WriteLine("]");
    }
}