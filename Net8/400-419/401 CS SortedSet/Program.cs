// 401 CS SortedSet
// Tests with new generic structure SortedSet of .Net Framework 4
//
// 2010-02-24   PV
// 2021-09-23	PV		VS2022; Net6
// 2023-01-10	PV		Net7

using System;
using System.Collections.Generic;
using static System.Console;

internal class Program
{
    private static void Main(string[] args)
    {
        // petit est présent deux fois
        SortedSet<string> myStringSet = new(["Il", "était", "un", "petit", "petit", "navire"]);

        foreach (var s in myStringSet)
        {
            Console.Write(s);
            Console.Write(" ");
        }
        WriteLine();
    }
}
