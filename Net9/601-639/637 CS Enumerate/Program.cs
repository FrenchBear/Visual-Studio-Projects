// Enumerate extension method
// Similar to Python, to add an index to an existing enumeration with optional start
// Produces more compact/readable use than iterating over a range and using indexed access
//
// 2017-08-28   PV
// 2021-07-13   PV      .Net 4.8
// 2021-09-26   PV      VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13

using System.Collections.Generic;
using static System.Console;

namespace CS637;

class Program
{
    static void Main()
    {
        List<string> flavors = ["Chocolat", "Vanille", "Fraise", "Citron"];
        foreach (var (index, flavor) in flavors.Enumerate(1))
            WriteLine($"{index}: {flavor}");
    }
}

public static class ExtensionMethods
{
    public static IEnumerable<(int index, T item)> Enumerate<T>(this IEnumerable<T> e, int start = 0)
    {
        foreach (var item in e)
            yield return (start++, item);
    }
}
