// 415 CS Extension Methods
// 2012-01-29 PV

using ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;

namespace CS415_Extension_Methods
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var s = "hello world";
            string t = s.Reverse().Concat();
            int n = s.WordCount();

            WriteLine(t);
            WriteLine(n);
        }
    }
}

namespace ExtensionMethods
{
    public static class MyExtensions
    {
        public static int WordCount(this string str) => str.Split(new char[] { ' ', '.', '?' },
                             StringSplitOptions.RemoveEmptyEntries).Length;

        public static string Concat(this IEnumerable<char> ie)
        {
            var sb = new StringBuilder();
            foreach (var c in ie)
                _ = sb.Append(c);
            return sb.ToString();
        }
    }
}