// 528 CS This Is A String
// Example of use of Regex.Replace function with a lambda transforming each Match
// 19/04/2015   PV

using System;
using System.Text.RegularExpressions;

namespace This_Is_A_String
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string s = "this is a string";
            Regex r = new Regex(@"(\s|^)\w");
            string t = r.Replace(s, m => m.Value.ToUpperInvariant());
            Console.WriteLine(t);

            Console.WriteLine();
            Console.Write("(Pause)");
            Console.ReadLine();
        }
    }
}