// Enumerate extension method
// Similar to Python, to add an index to an existing enumeration with optional start
// Produces more compact/readable use than iterating over a range and using indexed access
//
// 2017-08-28   PV
// 2021-07-13   PV      .Net 4.8

using System;
using System.Collections.Generic;

namespace EnumerateApp
{
    class Program
    {
        static void Main()
        {
            var flavors = new List<string> { "Chocolat", "Vanille", "Fraise", "Citron" };
            foreach (var (index, flavor) in flavors.Enumerate(1))
            {
                Console.WriteLine($"{index}: {flavor}");
            }

            Console.WriteLine();
            Console.Write("(Pause)");
            Console.ReadLine();
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
}
