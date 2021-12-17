// 317 CS Crible
//
// 2012-02-25   PV  VS2010
// 2021-09-20   PV  VS2022; Net6

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using static System.Console;

namespace Crible;

internal class Program
{
    private static void Main(string[] args)
    {
        const int n = 100_000_000;
        //2..100000000: 5761455 primes
        //Elapsed time: 00:00:01.8293659        Higgs (surface pro 3), Release
        Stopwatch sw = new();
        sw.Start();
        RunCrible(n);
        sw.Stop();
        WriteLine("Elapsed time: " + sw.Elapsed);
    }

    // tb 1 3 5 7 9 11 13
    //    0 1 2 3 4  5  6
    private static void RunCrible(int n)
    {
        BitArray tb = new(n / 2 + 1);
        List<int> li = new()
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
        WriteLine("2.." + n + ": " + li.Count + " primes");
    }
}