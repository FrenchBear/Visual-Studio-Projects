// 401 CS SortedSet
// Tests with new generic structure SortedSet of .Net Framework 4
//
// 2010-02-24   PV
// 2021-09-23	PV		VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13
// 2026-01-19	PV		Net10 C#14

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
            Write(s);
            Write(" ");
        }
        WriteLine();
    }
}
