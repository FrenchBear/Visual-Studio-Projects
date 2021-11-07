// BigDecimal
// Example of calculation of sqrt(2) using an arbitrary precision decimal class based on BigInteger
//
// 2011-07-04   PV
// 2012-02-02   PV  Refactoring
// 2021-09-23   PV  VS2022; Net6

using System;

namespace BigDecimalNS;

internal class Program
{
    private static void Main(string[] args)
    {
        // Calcul of sqrt(r), Héron suite (u(n+1)=(u(n)+r/u(n))/2, u(0)=r/2, quadratics convergence
        BigDecimal r = 2;
        BigDecimal un;
        BigDecimal unp1 = r / 2;
        int nSteps = 0;
        do
        {
            un = unp1;
            unp1 = (un + r / un) / 2;
            nSteps++;
        } while (un != unp1);
        Console.WriteLine("Found sqr({0}) with {1} decimals in {2} step(s):", r.ToString(), BigDecimal.Digits, nSteps);
        Console.WriteLine(un.ToString());

        // Verification
        Console.WriteLine();
        Console.WriteLine((un * un - r).ToString());

    }
}