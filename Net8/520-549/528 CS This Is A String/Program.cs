// 528 CS This Is A String
// Example of use of Regex.Replace function with a lambda transforming each Match
//
// 19/04/2015   PV
// 2021-09-26   PV      VS2022; Net6
// 2023-01-10	PV		Net7

using System.Text.RegularExpressions;
using static System.Console;

namespace This_Is_A_String;

internal partial class Program
{
    private static void Main(string[] args)
    {
        var s = "this is a string";
        Regex r = MyRegex();
        var t = r.Replace(s, m => m.Value.ToUpperInvariant());
        WriteLine(t);
    }

    [GeneratedRegex("(\\s|^)\\w")]
    private static partial Regex MyRegex();
}
