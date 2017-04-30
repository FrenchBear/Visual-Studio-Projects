// Sort algorithm in O(n)
// 2016-12-29   PV
// From https://probablydance.com/2016/12/27/i-wrote-a-faster-sorting-algorithm/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace Sort_On
{
    class Program
    {
        const int maxVal = 50;
        const int numElements = 1000;
        static void Main(string[] args)
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

            var diff = Enumerable.Zip(ls, l, (x1, x2) => x1 != x2).Any(b => b);
            WriteLine("\nLists are " + (diff ? "different" : "the same"));


            WriteLine();
            Write("(Pause)");
            ReadLine();
        }

        // Sort algorithm in O(n)
        static int[] Sort(int[] input)
        {
            int[] counts = new int[numElements];
            foreach (int item in input)
                counts[item]++;

            int total = 0;
            for (int i = 0; i < input.Length; i++)
            {
                int old_count = counts[i];
                counts[i] = total;
                total += old_count;
            }

            int[] output = new int[input.Length];
            foreach (int item in input)
                output[counts[item]++] = item;

            return output;
        }
    }


    static class Extensions
    {
        // Quick-and-dirty prints a list
        public static void WriteLine<T>(this IEnumerable<T> liste)
        {
            bool first = true;
            foreach (T item in liste)
            {
                if (first)
                {
                    Console.Write('{');
                    first = false;
                }
                else
                    Console.Write(", ");
                Console.Write(item);
            }
            Console.WriteLine('}');
        }

    }
}
