// CS 524b Cordic HalfTrig
// Sine, Cosine calculations using CORDIC algorithm
//
// 2014-10-21   PV
// 2017-01-03   PV      Using cos/sin(half-angle) instead of built-in functions
// 2021-09-26   PV      VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-05-07	PV		Code clean-up
// 2024-07-06   PV      ComputeHalfTrigTable()

using System;
using static System.Console;

#pragma warning disable IDE0059 // Unnecessary assignment of a value
#pragma warning disable IDE0051 // Remove unused private members
#pragma warning disable CS0162 // Unreachable code detected

namespace CordicHalfTrig;

internal class Program
{
    const bool UsePrecalc = true;

    private static void Main(string[] args)
    {
        ComputeHalfTrigTable();

        for (var z = -9.75; z < 10.0; z += 0.25)
        {
            var s = SinCordic(z);
            WriteLine("sin({0,4:F1}) = {1,6:F3} {2}*", z, s, new string(' ', (int)(20 * (1 + s))));
        }
        WriteLine();

        // Take a random angle (0..Pi/2)
        var a0 = 1.1823614786;
        CordicCompute(a0, out var sin, out var cos);
        WriteLine("a={0}", a0);
        WriteLine("Math:   c={0}\t\t\ts={1}\t\t\t(Math.Cos and Math.Sin)", Math.Cos(a0), Math.Sin(a0));
        WriteLine("Cordic: c={0}\t\t\ts={1}\t\t\t(Cordic Cos and Sin)", cos, sin);
        WriteLine("Maple:  c=0.378740326955891541643393287014\ts=0.925502979323861698653734026619\n");

        // Testing with a very small angle
        a0 = 1.23456e-10;
        CordicCompute(a0, out sin, out cos);
        WriteLine("a={0}", a0);
        WriteLine("Math:   c={0}\t\t\ts={1}\t\t\t(Math.Cos and Math.Sin)", Math.Cos(a0), Math.Sin(a0));
        WriteLine("Cordic: c={0}\t\t\ts={1}\t\t\t(Cordic Cos and Sin)\n", cos, sin);

        // Just checking I'm not working at HP, sin(π) is zero :-)
        sin = SinCordic(Math.PI);
        WriteLine($"sin π:       {sin}");
        sin = SinCordic(1e-12);
        WriteLine($"sin 1e-12:   {sin}");

        // This is wrong at the 5th decimal, this is normal because sin(π-1e12) is computed as sin((π-1e12)-π),
        // and because of float rounding value, the result of (π-1e12)-π is 1.000088900582341e-12 and not 1e-12
        // so the result is 1.000088900582341e-12...
        sin = SinCordic(Math.PI-1e-12);
        WriteLine($"sin π-1e-12: {sin}");
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
            invertSign = !invertSign;
        }
        if (angle > Math.PI / 2)
            angle = Math.PI - angle;

        //CordicCompute(angle, out var sin, out var cos);
        CordicComputePrecalc(angle, out var sin, out var cos);

        // No flipsign function in C#
        // && sin!=0 avoids returning -0 for sin(Math.Pi)!
        return (invertSign && sin != 0) ? -sin : sin;
    }

    private static double CosCordic(double angle) => SinCordic(angle + Math.PI / 2);

    // Actual computing algorithm, sin and cos at the same time
    // Angle must be between 0 and π/2
    // Note that the table of decreasing sin/cos (π/2, π/4, π/8, ...) should be calculated only one time
    // for efficiency, not recomputed each time as in this learning code --> CordicCompute2
    private static void CordicCompute(double angle, out double sin, out double cos)
    {
        if (UsePrecalc)
            CordicComputePrecalc(angle, out sin, out cos);
        else
            CordicComputeSimple(angle, out sin, out cos);
    }

    private static void CordicComputeSimple(double angle, out double sin, out double cos)
    {
        // Note that angle is expressed in radians, but CORDIC algorithm does not care about it, just
        // change initial variable a to 45 to work in degrees for instance

        // For very small angles, we have sin(x)=x and cos(x)=1
        if (angle < 5E-08)
        {
            sin = angle;
            cos = 1.0;
            return;
        }

        // Start at π/4, with both sin and cos = (√2)/2, can use constants instead of calculation
        var a = Math.PI / 4;             // Alt: Math.PI / 2;
        var s = Math.Sqrt(2.0) / 2.0;    // Alt: 1.0;
        var c = s;                       // Alt: 0.0;

        // Start with horizontal unitary vector for result
        cos = 1;
        sin = 0;

        for (; ; )
        {
            // If angle remaining to rotate is more than currently computed angle/s/c, we do the rotation
            if (angle >= a)
            {
                angle -= a;
                // Standard rotation matrix times vector (cos, sin)
                (sin, cos) = (cos * s + sin * c, cos * c - sin * s);
            }

            // Compute sin and cos of half-angle for next step
            a /= 2.0;
            if (a < 1e-17 || angle < 1e-17)
                break;

            // Half-trig computation, sin(a/2) and cos(a/2)
            if (a < 5e-8)
            {
                s = a;
                c = 1;
            }
            else
            {
                var c2 = c;
                c = Math.Sqrt((c + 1.0) / 2.0);
                s /= Math.Sqrt(2 * (1.0 + c2));
            }
        }
    }

    // ---------------------------------------------------------------------
    // New version, with precomputation

    record ASC(double Angle, double Sine, double Cosine);
    const int ASCCount = 25;        // For angles smaller than (π/4)/2^25, we use sin(a)=a and cos(a)=1
    static readonly ASC[] tASC = new ASC[ASCCount];

    private static void ComputeHalfTrigTable()
    {
        // Start at π/4, with both sin and cos = (√2)/2
        var a = Math.PI / 4;
        var s = Math.Sqrt(2.0) / 2.0;
        var c = s;

        tASC[0] = new ASC(a, s, c);

        for (int i = 1; i < ASCCount; i++)
        {
            a /= 2.0;

            // Half-trig computation, sin(a/2) and cos(a/2)
            var c2 = c;
            c = Math.Sqrt((c + 1.0) / 2.0);
            s /= Math.Sqrt(2 * (1.0 + c2));

            tASC[i] = new ASC(a, s, c);
        }
    }

    // Actual computing algorithm, sin and cos at the same time
    // Angle must be between 0 and π/2
    // Trig table precomputed, Optimization for better precision
    private static void CordicComputePrecalc(double angle, out double sin, out double cos)
    {
        // Note that angle is expressed in radians, but CORDIC algorithm does not care about it, just
        // change initial variable a to 45 to work in degrees for instance

        // For very small angles, we have sin(x)=x and cos(x)=1
        // Also take care of angle=0
        if (angle < tASC[ASCCount - 1].Angle)
        {
            sin = angle;
            cos = 1.0;
            return;
        }

        // Do rotations for "large angles"
        (sin, cos) = (0, 1);    // Start with horizontal unitary vector for result
        for (int i = 0; i < ASCCount; i++)
        {
            if (angle >= tASC[i].Angle)
            {
                angle -= tASC[i].Angle;
                (sin, cos) = (cos * tASC[i].Sine + sin * tASC[i].Cosine, cos * tASC[i].Cosine - sin * tASC[i].Sine);
            }
        }

        // Do rotations for "small angles", 
        var a = tASC[ASCCount - 1].Angle;
        var Sine = tASC[ASCCount - 1].Sine;
        var Cosine = tASC[ASCCount - 1].Cosine;
        while (angle>1e-17)
        {
            a /= 2;
            if (angle >= a)
            {
                angle -= a;
                (sin, cos) = (cos * angle + sin, cos - sin * a);
            }
        }

    }
}
