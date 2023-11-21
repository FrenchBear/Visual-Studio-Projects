// CS640 Enumerate extension methods for Net6
// Play with new extension methods introduced with Net6
//
// 2021-10-02   PV      Code skeleton
// 2023-01-10	PV		Net7

using System.Diagnostics;
using System.Linq;
using static CS640.Constellations;
using static System.Console;

namespace CS640;

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

