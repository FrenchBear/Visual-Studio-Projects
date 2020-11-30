// 317 CS Crible
// 2012-02-25   PV  VS2010

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Crible
{
    class Program
    {
        static void Main(string[] args)
        {
            const int n = 100_000_000;
            //2..100000000: 5761455 primes
            //Elapsed time: 00:00:01.8293659        Higgs (surface pro 3), Release
            Stopwatch sw = new Stopwatch();
            sw.Start();
            RunCrible(n);
            sw.Stop();
            Console.WriteLine("Elapsed time: " + sw.Elapsed);
            Console.WriteLine();
            Console.Write("(pause)");
            Console.ReadLine();
        }

        // tb 1 3 5 7 9 11 13
        //    0 1 2 3 4  5  6
        static void RunCrible(int n)
        {
            BitArray tb = new BitArray(n / 2 + 1);
            List<int> li = new List<int>
            {
                2
            };

            int nv = 3;
            while (nv <= n)
            {
                if (!tb[(nv - 1) / 2])
                {
                    li.Add(nv);
                    int nvr = nv + nv + nv;          // skip even numbers
                    while (nvr <= n)
                    {
                        // this test actually slows execution down about 20%
                        /* if (!tb[(nvr - 1) / 2]) */
                        tb[(nvr - 1) / 2] = true;
                        nvr += nv + nv;
                    }
                }
                nv += 2;
            }
            Console.WriteLine("2.." + n.ToString() + ": " + li.Count.ToString() + " primes");
        }
    }
}
