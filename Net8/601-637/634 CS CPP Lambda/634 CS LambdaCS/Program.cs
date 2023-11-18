// LambdaCS
// Shows that a lambda can capture a local variable in C# without trouble
//
// 2017-07-09   PV
// 2021-09-26   PV      VS2022; Net6
// 2023-01-10	PV		Net7

using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace ConsoleApp1;

internal class Program
{
    private static readonly List<Predicate<int>> filters = [];

    private static void AddDivisorFilter(int d)
    {
        var divisor = Math.Min(d, 100);
        filters.Add(n => n % divisor == 0);
    }

    private static void WriteLine<T>(IEnumerable<T> list)
    {
        var first = true;
        foreach (var item in list)
        {
            if (first)
            {
                first = false;
                Write("[");
                Write(item);
            }
            else
            {
                Write(", ");
                Write(item);
            }
        }

        WriteLine("]");
    }

    private static void Main(string[] args)
    {
        AddDivisorFilter(5);
        AddDivisorFilter(11);

        IEnumerable<int> vi = new List<int> { 1, 2, 3, 5, 7, 11, 13, 17, 19 };
        WriteLine(vi);

        foreach (var item in filters)
            vi = vi.Where(n => !item(n));
        WriteLine(vi);
    }
}
