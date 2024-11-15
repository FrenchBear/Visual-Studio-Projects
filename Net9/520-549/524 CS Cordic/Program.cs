// CS 524 Cordic
// Sine, Cosine calculations using CORDIC algorithm
//
// 2014-10-21   PV
// 2021-09-26   PV      VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13

using System;
using static System.Console;

namespace CS524;

internal class Program
{
    private static void Main(string[] args)
    {
        const int n = 15;
        var ta = new double[n];
        var tsin = new double[n];
        var tcos = new double[n];

        // Build a table of cos and sin for 1, 0.1, 0.01, 0.001, ...
        // Of course, for the real algorithm, we should use predefined constants
        // and probably better distributed than that -- now what's the optimal?
        var a = 1.0;
        for (var i = 0; i < n; i++)
        {
            ta[i] = a;
            tsin[i] = Math.Sin(a);
            tcos[i] = Math.Cos(a);
            a /= 10.0;
        }

        // Take a random angle (0..Pi/2)
        var a0 = 1.1823614786;

        a = a0;
        // Start with non-rotated vector (1,0)
        var x = 1.0;
        var y = 0.0;
        // Do incremental rotation of 1, 0.1, 0.01.. to rotate the value of a
        for (var i = 0; i < n; i++)
            while (a >= ta[i])
            {
                // Coordinates before rotation
                var x0 = x;
                var y0 = y;

                // We do an incremental rotation of ta[i]
                a -= ta[i];

                // Standard rotation matrix times vector (x,y)
                x = x0 * tcos[i] - y0 * tsin[i];
                y = x0 * tsin[i] + y0 * tcos[i];
            }

        WriteLine("a={0}", a0);
        WriteLine("c={0}\ts={1}\t(Math.cos and Math.sin)", Math.Cos(a0), Math.Sin(a0));
        WriteLine("x={0}\ty={1}\t(Cordic cos and sin)", x, y);

        // Maple answer with 30 digits
        // cos = 0.378740326955891541643393287014
        // sin = 0.925502979323861698653734026619
    }
}
