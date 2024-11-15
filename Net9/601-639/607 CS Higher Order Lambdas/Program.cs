// 607 CS Higher Order Lambdas
// Adaptation of C++ example (551 CPP)
//
// 2017-01-14   PV
// 2021-09-26   PV      VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13

using System;
using static System.Console;

namespace CS607;

internal class Program
{
    private static void Main(string[] args)
    {
        // The following code declares a lambda expression that returns
        // another lambda expression that adds two numbers.
        //Func<int, Func<int, int>> addtwointegers = (x) => { return (y) => x + y; };
        Func<int, int> addtwointegers(int x) => (y) => x + y;

        // The following code declares a lambda expression that takes another
        // lambda expression as its argument.
        // The lambda expression applies the argument z to the function f
        // and multiplies by 2.
        //Func<Func<int, int>, int, int> higherorder = (f, z) => 2 * f(z);
        int higherorder(Func<int, int> f, int z) => 2 * f(z);

        // Call the lambda expression that is bound to higherorder
        var answer = higherorder(addtwointegers(7), 8);

        // Print the result, which is (7+8)*2.
        WriteLine(answer);
    }
}
