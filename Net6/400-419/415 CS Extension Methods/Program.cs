// 415 CS Extension Methods
// 2012-01-29 PV

using ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS415_Extension_Methods
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string s = "hello world";
            string t = s.Reverse().Concat();
            int n = s.WordCount();

            Console.WriteLine(t);
            Console.WriteLine(n);
        }
    }
}

namespace ExtensionMethods
{
    public static class MyExtensions
    {
        public static int WordCount(this String str) => str.Split(new char[] { ' ', '.', '?' },
                             StringSplitOptions.RemoveEmptyEntries).Length;

        public static String Concat(this IEnumerable<char> ie)
        {
            var sb = new StringBuilder();
            foreach (char c in ie)
                _ = sb.Append(c);
            return sb.ToString();
        }
    }
}