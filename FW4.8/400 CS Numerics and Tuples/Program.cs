// 400 CS Numerics and Tuples
// Tests with classes BigInteger and Tuple of .Net Framework 4
// 2010-02-24 FPVI

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Numerics;

#pragma warning disable IDE0059 // Unnecessary assignment of a value

internal class Program
{
    private static void Main(string[] args)
    {
        BigInteger number = Factorial(100);
        Console.WriteLine(number);
        Console.WriteLine();

        var z1 = new Complex(2, 3);
        Console.WriteLine(Complex.Sqrt(z1));
        Console.WriteLine();

        var primes = Tuple.Create(2, "three", 5, 7, 11, 13, 17, 19);
        Console.WriteLine(primes);
        Console.WriteLine();
        Tuple<int, string> t = MyFunction();
        Console.WriteLine("{0} {1}", t.Item1, t.Item2);
        Console.WriteLine();

        // Simple test on ReadOnlyCollection actually present since Framework 2.0...
        var l1 = new List<int> { 1, 2, 3, 4 };
        var l2 = new ReadOnlyCollection<int>(l1);
        var l3 = l2 as IList<int>;
        // l3.Add(5);       // Throws a run-time exception "not supported exception": Collection is read-only.

        Console.WriteLine();
        Console.Write("(Pause)");
        Console.ReadLine();
    }

    private static BigInteger Factorial(BigInteger n)
    {
        if (n <= 1)
            return 1;
        else
            return n * Factorial(n - 1);
    }

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