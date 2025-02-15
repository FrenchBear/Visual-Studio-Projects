﻿// CS639 Enumerate extension methods for Net6
// Play with new extension methods introduced with Net6
//
// 2021-10-02   PV      Code skeleton
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13

using System.Diagnostics;
using System.Linq;
using static CS639.Constellations;
using static System.Console;

namespace CS639;

class Program
{
    static void Main() => TextMaxBy();

    // MaxBy returns the actual element of the list for which selector function is the maximum,
    // while Max just returns the maximum
    private static void TextMaxBy()
    {
        var cons = GetConstellations();

        var k = cons.MaxBy(c => c.Constellation.Length);
        Debug.Assert(k != null);
        WriteLine($"Constellation with longest name: {k.Constellation}, Fr={k.FrenchName}, En={k.EnglishName}");
    }
}
