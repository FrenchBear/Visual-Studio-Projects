// 426 CS Decimal To Fraction
// Stern-Brocot algorithm to transform a periodic decimal suite into a fraction
// Based on the fact that Stern-Brocot tree of fractions contains one and only once all fractions,
// a side property of Farey suites (Fn = ordered fractions with a denominator <= n)
//
// 2012-04-15   PV
// 2021-09-23   PV  VS2022; Net6

using System;
using System.Diagnostics;
using static System.Console;

namespace CS426;

internal class Program
{
    private static void Main()
    {
        WriteLine("Stern-Brocot algorithm to transform a periodic decimal suite into a fraction\n");
        double f = 0.1415926535;
        DoubleToFraction(f, out long rNum, out long rDen);
        WriteLine("{0} = {1}/{2}", f, rNum, rDen);

        f = 3.1415926535;
        DoubleToFraction(f, out rNum, out rDen);
        WriteLine("{0} = {1}/{2}", f, rNum, rDen);

        f = -0.1415926535;
        DoubleToFraction(f, out rNum, out rDen);
        WriteLine("{0} = {1}/{2}", f, rNum, rDen);

        f = -3.1415926535;
        DoubleToFraction(f, out rNum, out rDen);
        WriteLine("{0} = {1}/{2}", f, rNum, rDen);

        // Check we get expected results
        WriteLine("\nTesting 1 million fractions with n,d in [1..1000]");
        for (int i = 1; i <= 1000; i++)
        {
            for (int j = 1; j <= 1000; j++)
        {
            f = (double)i / (double)j;
            DoubleToFraction(f, out rNum, out rDen);
            int pgdc = Gcd(i, j);
            if (i != rNum * pgdc || j != rDen * pgdc)
                Debugger.Break();
        }
        }

        WriteLine("Test Ok!");
    }

    /// <summary>
    /// Return Greatest Common Divisor using Euclidean Algorithm
    /// </summary>
    private static int Gcd(int a, int b)
    {
        if (a <= 0 || b <= 0)
            throw new ArgumentException("Negative or zero argument not supported");
        while (b != 0)
            (a, b) = (b, a % b);
        return a;
    }

    private static void DoubleToFraction(double f, out long rNum, out long rDen)
    {
        const double epsilon = 1e-6;

        // Special case
        if (f == 0.0)
        {
            rNum = 0;
            rDen = 1;
            return;
        }

        int sign = 1;
        if (f < 0)
        {
            sign = -1;
            f = -f;
        }

        long off = (long)Math.Floor(f);
        f -= off;
        if (f <= epsilon)
        {
            rNum = off * sign;
            rDen = 1;
            return;
        }
        long infNum = 0; long infDen = 1;
        long supNum = 1; long supDen = 0;
        for (; ; )
        {
            rNum = infNum + supNum;
            rDen = infDen + supDen;

            double r = rNum / (double)rDen;
            if (Math.Abs(r - f) < epsilon)
            {
                rNum = (rNum + off * rDen) * sign;
                return;
            }
            if (r < f)
            {
                infNum = rNum;
                infDen = rDen;
            }
            else
            {
                supNum = rNum;
                supDen = rDen;
            }
        }
    }
}