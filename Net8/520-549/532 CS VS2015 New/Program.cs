// VS 2015 What's New
//
// 2015-07-22   PV
// 2021-09-26   PV      VS2022; Net6
// 2023-01-10	PV		Net7

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using static System.Console;                // Using Static

namespace CS532;

internal class Program
{
    private static void Main(string[] args)
    {
        // String interpolation and nameof
        WriteLine($"{nameof(ThreeTimes)}(1234) = {ThreeTimes(1234)}");

        // Dictionary initializer
        Dictionary<string, Person> directory = new()
        {
            ["Pierre"] = new Person { FirstName = "Pierre", LastName = "Violent" }
        };

        // Null-conditional operators ?[ and ?. (note that ?[ is useless on a dictionary since it'll raise an exception if the index does not exist...)
        var i = directory?["Pierre"].Company?.Length;

        var jsonText = @"{
                'ForegroundColor': {
                    'Error': 'Red',
                    'Warning': 'Red',
                    'Normal': 'Yellow',
                    'Verbose': 'White'
                    }
                }";

        var consoleColorConfiguration = JObject.Parse(jsonText);
        // Null-conditional operator ?[ since JSon indexer does not raise an exception
        var colorText = consoleColorConfiguration?["ForegroundColor"]?["Normal"]?.Value<string>();
        if (Enum.TryParse(colorText, out ConsoleColor color))
            ForegroundColor = color;
    }

    // Single expression (lambda) function body
    private static double ThreeTimes(double x) => 3 * x;
}

public struct Person(string first, string last, string company)
{
    public string FirstName { get; set; } = first;
    public string LastName { get; set; } = last;
    public string Company { get; set; } = company;
}
