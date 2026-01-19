// 504 CS Closure Example
// Example of closure
//
// 2013-01-02   PV
// 2021-09-26   PV      VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13
// 2026-01-19	PV		Net10 C#14

using System;
using static System.Console;

namespace CS504;

internal class Program
{
    private static void Main(string[] args)
    {
        var pos = Adder();
        var neg = Adder();
        for (var i = 0; i < 10; i++)
            WriteLine("{0}, {1}", pos(i), neg(-2 * i));
    }

    private static Func<int, int> Adder()
    {
        var sum = 0;
        return x =>
        {
            sum += x;
            return sum;
        };
    }

    //delegate int FuncInt(int x);
    //static FuncInt adder2()
    //{
    //    int sum = 0;
    //    return (int x) =>
    //    {
    //        sum += x;
    //        return sum;
    //    };
    //}

    //static FuncInt adder3()
    //{
    //    int sum = 0;
    //    return delegate(int x)
    //    {
    //        sum += x;
    //        return sum;
    //    };
    //}
}
