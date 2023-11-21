// BigDecimal
// Example of calculation of sqrt(2) using an arbitrary precision decimal class based on BigInteger
//
// 2011-07-04   PV
// 2012-02-02	PV		Refactoring
// 2021-09-23	PV		VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12

using static System.Console;

namespace BigDecimalNS;

internal class Program
{
    private static void Main(string[] args)
    {
        // Calcul of sqrt(r), Héron suite (u(n+1)=(u(n)+r/u(n))/2, u(0)=r/2, quadratics convergence
        BigDecimal r = 2;
        BigDecimal un;
        var unp1 = r / 2;
        var nSteps = 0;
        do
        {
            un = unp1;
            unp1 = (un + r / un) / 2;
            nSteps++;
        } while (un != unp1);
        WriteLine("Found sqr({0}) with {1} decimals in {2} step(s):", r.ToString(), BigDecimal.Digits, nSteps);
        WriteLine(un.ToString());

        // Verification
        WriteLine();
        WriteLine((un * un - r).ToString());

    }
}
