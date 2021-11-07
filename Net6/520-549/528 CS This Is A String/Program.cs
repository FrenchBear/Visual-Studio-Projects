// 528 CS This Is A String
// Example of use of Regex.Replace function with a lambda transforming each Match
//
// 19/04/2015   PV
// 2021-09-26   PV      VS2022; Net6

using System;
using System.Text.RegularExpressions;

namespace This_Is_A_String;

internal class Program
{
    private static void Main(string[] args)
    {
        string s = "this is a string";
        Regex r = new(@"(\s|^)\w");
        string t = r.Replace(s, m => m.Value.ToUpperInvariant());
        Console.WriteLine(t);
    }
}