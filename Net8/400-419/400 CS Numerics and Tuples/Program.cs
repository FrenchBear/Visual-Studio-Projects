// 400 CS Numerics and Tuples
// Tests with classes BigInteger and Tuple of .Net Framework 4
//
// 2010-02-24   PV
// 2021-09-23	PV		VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Numerics;
using static System.Console;

internal class Program
{
    private static void Main(string[] args)
    {
        var number = Factorial(100);
        WriteLine(number);
        WriteLine();

        Complex z1 = new(2, 3);
        WriteLine(Complex.Sqrt(z1));
        WriteLine();

        var primes = Tuple.Create(2, "three", 5, 7, 11, 13, 17, 19);
        WriteLine(primes);
        WriteLine();
        var t = MyFunction();
        WriteLine("{0} {1}", t.Item1, t.Item2);
        WriteLine();

        // Simple test on ReadOnlyCollection actually present since Framework 2.0...
        List<int> l1 = [1, 2, 3, 4];
        ReadOnlyCollection<int> l2 = new(l1);
        var l3 = l2 as IList<int>;
        // l3.Add(5);       // Throws a run-time exception "not supported exception": Collection is read-only.
    }

    private static BigInteger Factorial(BigInteger n) => n <= 1 ? 1 : n * Factorial(n - 1);

    // Example of function returning two values in a Tuple
    private static Tuple<int, string> MyFunction()
    {
        var t = new Tuple<int, string>(5, "hello");
        return t;

        //var v = default(Tuple<byte, StringBuilder>);
        //int i;
        //i = null;
    }
}
