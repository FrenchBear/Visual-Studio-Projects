// CS601 CS Visual Studio 2017 New Features
//
// 2016-09-05   PV      First version
// 2017-01-16   PV      Updated for Visual Studio 2017 RC
// 2021-09-26   PV      VS2022; Net6

using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using static System.Console;

#pragma warning disable IDE0059 // Unnecessary assignment of a value
#pragma warning disable CS0219 // Variable is assigned but its value is never used

namespace CS601;

internal class Program
{
    // throw expressions
    private readonly Point GlobalPoint = new Point(5, 6) ??
                                         throw new InvalidOperationException("Could not initialize " + nameof(GlobalPoint));

    private static void Main()
    {
        OutputEncoding = new UTF8Encoding();
        // Just to display φ, although it's shown as ϕ in Consolas (and Calibri), that's a known problem with old fonts...

        // From Wikipedia, https://en.wikipedia.org/wiki/Phi:
        // Prior to Unicode version 3.0 (1998), the glyph assignments in the Unicode code charts were the reverse,
        // and thus older fonts may still show a loopy form φ at U+03D5

        // From Unicode® Technical Report #25, Unicode Support for Mathematics http://unicode.org/reports/tr25/:
        // 2.3.1 Representative Glyphs for Greek Phi
        // With Unicode 3.0 and the concurrent second edition of ISO / IEC 10646 - 1, the representative
        // glyphs for U+03C6 GREEK LETTER SMALL PHI φ and U+03D5 GREEK PHI SYMBOL ϕ were exchanged.
        // In ordinary Greek text, the character U+03C6 φ is used exclusively, although this
        // character has considerable glyphic variation, sometimes represented with a glyph more like
        // the representative glyph shown for U+03C6(φ, the “loopy” form) and less often with a glyph
        // more like the representative glyph shown for U+03D5(ϕ, the “straight“ form).
        // See the Greek table in the character code charts http://www.unicode.org/charts/PDF/U0370.pdf

        WriteLine("Tests en C# 2017\n");

        // Tuples
        var t1 = (r: 3.14, i: -2.5);
        var t2 = (r: 2.718, j: 1.414);
        t1 = t2;        // This is allowed, contrary to tuples created with Tuple<>
        WriteLine("t1: " + t1);
        t1.r += 1.0;    // mutable...
        (string Alpha, string Beta) = ("Hello", "World");

        // Following conversions are not supported...
        //Tuple<int, int> myTuple1 = (3, 4);

        //Tuple<int, int> myTuple2 = (Tuple<int, int>)(3, 4);
        Tuple<int, int> myTuple3 = (3, 4).Construct();      // An extension method can be used

        // Actually, real type is ValueTuple
        ValueTuple<int, int> myValueTuple1 = (2, 7);
        //ValueTuple<int, int> myValueTuple2 = (once: 2, upon: 7);

        // Convoluted method to make a tuple enumerable, just to do it
        var t9 = ("once", "upon", "a", "time", "in", "a", "far", "away", "kingdom");
        foreach (string item in t9.GetT9Enumerator())
            Write(item + " ");
        WriteLine();

        // Binary literals and digit separators
        object[] numbers = { 0b1, 0b10, new object[] { 0b100, 0b1000 },     // binary literals
            "Tally_Test", null, 0b1_0000, 0b10_0000 };       // digit separators
        const double AvogadroConstant = 6.022_140_857_747_474e23;
        const decimal φ = 1.618_033_988_749_894_848_204_586_834_365_638_117_720_309_179M;
        WriteLine($"Avogadro: {AvogadroConstant}");
        WriteLine($"φ: {φ}");

        // Deconstruction
        var (sum, count) = Tally(numbers);                  // Tuple deconstruction
        WriteLine($"Sum: {sum}, Count: {count}");

        var p = new Point(3.14, 2.71);
        (double X, double Y) = p;                           // Class supporting a Deconstruct method
        WriteLine($"X={X}, Y={Y}");
        Tuple<int, int> t78 = new(7, 8);
        (int Z, int T) = t78;                               // Deconstruction using extension method
        WriteLine($"Z={Z}, T={T}");
        var (Z1, _) = t78;                                  // Discard element during deconstruction

        // Deconstruction using an extension method
        Complex z = new(3.0, 4.0);
        var (zr, zi) = z;
        WriteLine($"zr={zr}, zi={zi}");

        // Function returning a reference (but intellisense does not show it)
        string s1 = "Hello";
        string s2 = "World";
        Choose(true, ref s1, ref s2) = "Modified";
        WriteLine($"s1:{s1}, s2:{s2}");

        // Local ref
        ref string rs = ref s2;
        rs = "String";
        WriteLine($"After modifying rs, s2:{s2}");

        WriteLine();
        TestPatternMatching();

        // Pattern and try
        object o = "12";
        if (o is int i || (o is string s && int.TryParse(s, out i))) { /* use i */ }

        // Out variables declared in method call
        WriteLine(double.TryParse("3,1416", out double dval) ? $"dval={dval}" : "double.TryParse failed");
    }

    // Local function and tuples
    public static int Fibonacci(int x)
    {
        return x < 0 ? throw new ArgumentException("Less negativity please!", nameof(x)) : Fib(x).current;

        static (int current, int previous) Fib(int i)
        {
            if (i == 0) return (1, 0);
            var (p, pp) = Fib(i - 1);
            return (p + pp, p);
        }
    }

    private static (int sum, int count) Tally(object[] values)      // tuple types
    {
        var r = (s: 0, c: 0);                               // tuple literals
        void Add(int s, int c) => r = (r.s + s, r.c + c);   // local functions
        foreach (var v in values)
        {
            switch (v)                                      // switch on any value
            {
                case int i:                                 // type patterns
                    Add(i, 1);
                    break;

                case string s:                              // Just a stupid test
                    WriteLine(s);
                    break;

                case object[] {Length: > 0} a:          // case conditions
                    var (sum, count) = Tally(a);
                    Add(sum, count);
                    break;

                case null:                                  // A null value does not match a type expression, ex: null string
                    break;
                //throw new ArgumentNullException();

                default:
                    //throw new InvalidOperationException("unknown item type");
                    break;
            }
        }
        return r;
    }

    // function returning a reference
    public static ref TValue Choose<TValue>(bool condition, ref TValue left, ref TValue right) => ref condition ? ref left : ref right;

    static public void TestPatternMatching()
    {
        // Type pattern: no promotion, no conversion...
        int? i1 = 100, i2 = null;
        if (i1 is int i) WriteLine($"i1 is int {i}");
        //if (i1 is short h) WriteLine($"i1 is short {h}");
        if (i2 is int ibis) WriteLine($"i2 is int {ibis}");

        short? h1 = 1024;
        //if (h1 is int half) WriteLine($"h1 is int {half}");

        float? f1 = 3.1416e10F;
        if (f1 is float f) WriteLine($"f1 is float {f}");
        //if (f1 is double d1) WriteLine($"f1 is double {d1}");
        //if (f1 is decimal d2) WriteLine($"f1 is decimal {d2}");

        // Constant pattern (match if expression==constant is true)
        if (i1 is 100) WriteLine($"i1 is 100");
        if (i1 is 101) WriteLine($"i1 is 101");

        // var pattern (always succeeds)
        if (i1 is var v) WriteLine($"i1 is var {v}");

        // Wildcard pattern (always a match, but not accepted here, useless in a 'is' construction anyway)
        // if (i1 is *) WriteLine($"i1 is *");

        // Positional Pattern (doesn't work)
        var r = (i: 12, j: 25);
        // if (r is (int x, int y)) WriteLine();
    }
}

// Example of class supporting Tuple deconstruction
public class Point
{
    public double X { get; }
    public double Y { get; }

    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }

    // Deconstruct method provides a set of out arguments for each of the properties you want to extract
    public void Deconstruct(out double x, out double y)
    {
        x = X;
        y = Y;
    }
}

public static class ExtensionMethods
{
    public static void Deconstruct(this Tuple<int, int> t, out int Left, out int Right)
    {
        Left = t.Item1;
        Right = t.Item2;
    }

    // Also show expression-bodied member
    public static Tuple<int, int> Construct(this (int x, int y) pair) =>
        new(pair.x, pair.y);

    // Idem
    public static T9Enumerator<T> GetT9Enumerator<T>(this (T s1, T s2, T s3, T s4, T s5, T s6, T s7, T s8, T s9) bigTuple) =>
        new(bigTuple);

    // Deconstruct a complex
    public static void Deconstruct(this Complex z, out double r, out double i)
    {
        r = z.Real;
        i = z.Imaginary;
    }
}

public class T9Enumerator<T> : IEnumerable<T>
{
    private (T s1, T s2, T s3, T s4, T s5, T s6, T s7, T s8, T s9) localTuple;

    public T9Enumerator((T s1, T s2, T s3, T s4, T s5, T s6, T s7, T s8, T s9) bigTuple) =>
        localTuple = bigTuple;

    private IEnumerator<T> MyEnumerator()
    {
        yield return localTuple.s1;
        yield return localTuple.s2;
        yield return localTuple.s3;
        yield return localTuple.s4;
        yield return localTuple.s5;
        yield return localTuple.s6;
        yield return localTuple.s7;
        yield return localTuple.s8;
        yield return localTuple.s9;
        yield break;
    }

    public IEnumerator<T> GetEnumerator() => MyEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => MyEnumerator();
}