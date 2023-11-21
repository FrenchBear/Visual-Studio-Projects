// 310 CS Lambda functions and Select projections
//
// 2012-03-04   PV
// 2021-09-20	PV		VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12

using System.Linq;
using static System.Console;

namespace CS310;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] fruits = [
            "apple",
            "passionfruit",
            "banana",
            "mango",
            "orange",
            "blueberry",
            "grape",
            "strawberry"];

        // Project the length of each string and
        // put the length values into an enumerable object.
        //IEnumerable<int> lengths;
        // With a lambda function
        var lengths = fruits.Select(fruit => fruit.Length);

        // With a generic delegate
        // Note: a custom delegate does not work since there are no delegates conversions
        var selector = LengthOfString;
        lengths = fruits.Select(selector);

        // Display the results.
        System.Text.StringBuilder output = new();
        foreach (var length in lengths)
            _ = output.AppendLine(length.ToString());

        WriteLine(output.ToString());
    }

    private static int LengthOfString(string s)
        => s.Length;
}
