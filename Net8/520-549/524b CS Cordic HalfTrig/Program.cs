// CS 524b Cordic HalfTrig
// Sine, Cosine calculations using CORDIC algorithm
//
// 2014-10-21   PV
// 2017-01-03   PV      Using cos/sin(half-angle) instead of built-in functions
// 2021-09-26   PV      VS2022; Net6
// 2023-01-10	PV		Net7

using System;
using static System.Console;

#pragma warning disable IDE0059 // Unnecessary assignment of a value

namespace CordicHalfTrig;

internal class Program
{
    private static void Main(string[] args)
    {
        const int n = 15;
        double[] ta, tsin, tcos;
        ta = new double[n];
        tsin = new double[n];
        tcos = new double[n];

        for (var z = -10.0; z < 10.0; z += 0.25)
        {
            var s = SinCordic(z);
            WriteLine("sin({0,4:F1}) = {1,6:F3} {2}*", z, s, new string(' ', (int)(20 * (1 + s))));
        }
        WriteLine();

        // Take a random angle (0..Pi/2)
        var a0 = 1.1823614786;
        CordicCompute(a0, out var sin, out var cos);

        WriteLine("a={0}", a0);
        WriteLine("Math:   c={0}\t\t\ts={1}", Math.Cos(a0), Math.Sin(a0));
        WriteLine("Cordic: c={0}\t\t\ts={1}", cos, sin);
        WriteLine("Maple:  c=0.378740326955891541643393287014\ts=0.925502979323861698653734026619");

        // Maple answer with 30 digits
        // cos =
        // sin =
    }

    private static double SinCordic(double angle)
    {
        var invertSign = false;

        if (angle < 0)
        {
            angle = -angle;
            invertSign = true;
        }
        if (angle >= Math.PI * 2)
            angle %= 2 * Math.PI;
        if (angle >= Math.PI)
        {
            angle -= Math.PI;
            invertSign ^= true;
        }
        if (angle > Math.PI / 2)
            angle = Math.PI - angle;

        CordicCompute(angle, out var sin, out var cos);

        return invertSign ? -sin : sin;
    }

#pragma warning disable IDE0051 // Remove unused private members

    private static double CosCordic(double angle) => SinCordic(angle + Math.PI / 2);

    // Actual computing algorithm, sin and cos at the same time
    // Angle must be between 0 and π/2
    // Note that angle is expressed in radians, but CORDIC algorithm do not care about it, just
    // change initial variable a to 45 to work in degrees for instance
    private static void CordicCompute(double angle, out double sin, out double cos)
    {
        sin = Math.Sin(angle);
        cos = Math.Cos(angle);

        // Start at π/4, with both sin and cos = (√2)/2
        var a = Math.PI / 4;             // Math.PI / 2;
        var s = Math.Sqrt(2.0) / 2.0;    // 1.0;
        var c = s;                       // 0.0;

        // Start with horizontal unitary vector for result
        cos = 1;
        sin = 0;
        for (; ; )
        {
            // If angle remaining to rotate is more than currently computed angle/s/c, we do the rotation
            if (angle >= a)
            {
                angle -= a;

                // Coordinates before rotation
                var x0 = cos;
                var y0 = sin;

                // Standard rotation matrix times vector (cos, sin)
                cos = x0 * c - y0 * s;
                sin = x0 * s + y0 * c;
            }

            // Compute sin and cos of half-angle for next step
            a /= 2.0;
            if (a < 1e-17)
                break;

            var c2 = c;
            c = Math.Sqrt((c + 1.0) / 2.0);
            s /= Math.Sqrt(2 * (1.0 + c2));
        }
    }
}
