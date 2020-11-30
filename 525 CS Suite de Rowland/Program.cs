// CS 525 Suites de Rowland
// Chapitre 'Déconcertantes conjectures' de 'Inventions mathématiques', Jean-Paul Delahaye
// Je voulais chercher le nombre 191 qui n'apparait pas dans les 1000 premiers nombres premiers...
// Mais la page https://oeis.org/A221869 indique qu'il faut 'Exactly 177789368686545736460055960459780707068552048703463291 iterations to find the first 1000 terms of this sequence'
// Bref, ça ne rentre pas dans un long :-)
// Démonstration du fait que la suite ne génère que 1 et des nombres premiers:
// https://cs.uwaterloo.ca/journals/JIS/VOL11/Rowland/rowland21.pdf
// 2014-10-28   PV

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS525
{
    class Program
    {
        static void Main(string[] args)
        {
            //Debug.Assert(gcd(5, 7) == 1);
            //Debug.Assert(gcd(7, 5) == 1);
            //Debug.Assert(gcd(6, 9) == 3);
            //Debug.Assert(gcd(9, 6) == 3);
            //Debug.Assert(gcd(2*3*5*7*11, 2*3*5*7*13) == 2*3*5*7);

            long fn = 7;
            long n;
            for (n = 2; n < 100000000; n++)
            {
                long fnp1 = fn + Gcd(n, fn);
                long gn = fnp1 - fn;
                if (gn == 191) Debugger.Break();
                if (gn > 1)
                    Console.Write("{0} ", fnp1 - fn);
                fn = fnp1;
            }

            Console.WriteLine();
            Console.Write("(Pause)");
            Console.ReadLine();
        }


        static long Gcd(long a, long b)
        {
            for (;;)
            {
                if (b > a)
                {
                    long t = a;
                    a = b;
                    b = t;
                }
                long c = a % b;
                if (c == 0) return b;
                a = b;
                b = c;
            }
        }
    }
}
