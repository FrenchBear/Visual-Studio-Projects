// CS 526 Nombres de Friedman
// Chapitre 'Déconcertantes conjectures' de 'Inventions mathématiques', Jean-Paul Delahaye
// Je voulais chercher le nombre 191 qui n'apparait pas dans les 1000 premiers nombres premiers...
// Mais la page https://oeis.org/A221869 indique qu'il faut 'Exactly 177789368686545736460055960459780707068552048703463291 iterations to find the first 1000 terms of this sequence'
// Bref, ça ne rentre pas dans un long :-)
//
// 2014-10-28   PV
// 2021-09-26   PV      VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13
// 2026-01-19	PV		Net10 C#14

using System.Collections.Generic;
using static System.Console;

namespace CS526;

internal class Program
{
    private static void Main()
    {
        // Nombres à deux chiffres
        for (var i = 1; i < 10; i++)
        {
            for (var j = 0; j < 10; j++)
            {
                foreach (var c in CombineTwoNumbers(i, j, false))
                {
                    if (10 * i + j == c)
                        WriteLine(c);
                }
            }
        }

        // Nombres à trois chiffres
        for (var i = 1; i < 10; i++)
        {
            for (var j = 0; j < 10; j++)
            {
                for (var k = 0; k < 10; k++)
                {
                    // ( i op j ) op k
                    foreach (var ij in CombineTwoNumbers(i, j, true))
                    {
                        foreach (var c in CombineTwoNumbers(ij, k, false))
                            if (100 * i + 10 * j + k == c)
                                Found(c);
                    }

                    // (i op k) op j
                    foreach (var ik in CombineTwoNumbers(i, k, true))
                    {
                        foreach (var c in CombineTwoNumbers(ik, j, false))
                            if (100 * i + 10 * j + k == c)
                                Found(c);
                    }

                    // (j op k) op i
                    foreach (var jk in CombineTwoNumbers(j, k, true))
                    {
                        foreach (var c in CombineTwoNumbers(jk, i, false))
                            if (100 * i + 10 * j + k == c)
                                Found(c);
                    }
                }
            }
        }
    }

    private static readonly HashSet<int> PreviousResults = [];

    private static void Found(int n)
    {
        if (!PreviousResults.Contains(n))
        {
            _ = PreviousResults.Add(n);
            Write("{0} ", n);
        }
    }

    private static IEnumerable<int> CombineTwoNumbers(int a, int b, bool isConcatAllowed)
    {
        if (isConcatAllowed)
        {
            if (b >= 0)
            {
                if (int.TryParse(a + b.ToString(), out var c))
                    yield return c;
            }
            if (a >= 0)
            {
                if (int.TryParse(b + a.ToString(), out var c))
                    yield return c;
            }
        }
        yield return a + b;
        // Negative numbers are allowed
        yield return a - b;
        yield return b - a;
        yield return a * b;
        if (b != 0 && a % b == 0)
            yield return a / b;
        if (a != 0 && b % a == 0)
            yield return b / a;
        // Negative powers are not supported
        // Le cas 0^0 n'est pas inclus, et pour les valeurs de la mantisse à 0, 0^exp = 0, or a*b a déjà retourné la valeur 0, pas la peine de refaire!
        if (a > 0 && b >= 0)
            yield return IntPow(a, b);
        if (a >= 0 && b > 0)
            yield return IntPow(b, a);
    }

    // From http://stackoverflow.com/questions/383587/how-do-you-do-integer-exponentiation-in-c
    // Negative powers are not handled
    // IntPow(0,0) returns 1 while it should be undefined or an error
    private static int IntPow(int x, int pow)
    {
        var ret = 1;
        while (pow != 0)
        {
            if ((pow & 1) == 1)
                ret *= x;
            x *= x;
            pow >>= 1;
        }
        return ret;
    }
}
