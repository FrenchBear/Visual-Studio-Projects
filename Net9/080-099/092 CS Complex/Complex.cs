// Classe Complex
//
// 2004-01-25   PV
// 2006-10-01	PV		VS2005
// 2012-02-04	PV		VS2010
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13

using System;
using System.Globalization;

namespace CS092;

public readonly struct Complex
{
    private readonly double r;
    private readonly double i;

    //public Complex() { r = 0.0;  i = 0.0; }
    public Complex(double r0) { r = r0; i = 0.0; }

    public Complex(double r0, double i0)
    {
        r = r0;
        i = i0;
    }

    public static implicit operator Complex(double d) => new(d);

    //	public static explicit operator Complex(double d)
    //	{
    //		return new Complex(d);
    //	}

    public static Complex operator +(Complex a, Complex b) => new(a.r + b.r, a.i + b.i);

    public static Complex operator -(Complex a, Complex b) => new(a.r - b.r, a.i - b.i);

    public static Complex operator -(Complex a) => new(-a.r, -a.i);

    public static Complex operator *(Complex a, Complex b) => new(a.r * b.r - a.i * b.i, a.r * b.i + a.i * b.r);

    public static Complex operator *(Complex a, double d) => new(a.r * d, a.i * d);

    public static Complex operator *(double d, Complex a) => new(a.r * d, a.i * d);

    public static Complex operator /(Complex a, Complex b) => 1 / (b.r * b.r + b.i * b.i) * new Complex(a.r * b.r + a.i * b.i, a.i * b.r - a.r * b.i);

    public static Complex operator /(Complex a, double d) => new(a.r / d, a.i / d);

    public static Complex operator /(double d, Complex c) => d / (c.r * c.r + c.i * c.i) * new Complex(c.r, -c.i);

    public static Complex Pow(double x, double y) => Math.Pow(x, y);

    public static Complex Pow(Complex c, double p) => Exp(p * Ln(c));

    public static Complex Ln(Complex c) => new(Math.Log(Math.Sqrt(c.r * c.r + c.i * c.i)), Math.Atan2(c.i, c.r));

    public static Complex Exp(Complex c) => Math.Exp(c.r) * new Complex(Math.Cos(c.i), Math.Sin(c.i));

    public static Complex Sqrt(Complex c) => Exp(0.5 * Ln(c));

    public override string ToString() => r.ToString(CultureInfo.InvariantCulture) + "+" + i.ToString(CultureInfo.InvariantCulture) + "i";
}
