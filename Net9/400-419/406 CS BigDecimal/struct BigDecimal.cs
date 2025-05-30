﻿// BigDecimal
// Implementation of an arbitrary precision decimal class based on BigInteger
// Actually should implement the same members as BigInteger struct itself
//
// 2011-07-04   PV
// 2012-02-02   PV      Refactoring; CompareTo, interfaces
// 2021-09-23   PV      VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13

using System;
using System.Numerics;
using System.Text;

namespace BigDecimalNS;

internal struct BigDecimal: IComparable<BigDecimal>, IComparable
{
    // Definition of precision
    public const int Digits = 750;                   // Number of decimals

    private static readonly BigInteger ScaleFactor = BigInteger.Pow(10, Digits);    // Scale factor for storage in a BigInteger

    private BigInteger n;                              // Value and sign * scale factor

    public static implicit operator BigDecimal(int i)
    {
        BigDecimal d;
        d.n = i * ScaleFactor;
        return d;
    }

    public static implicit operator BigDecimal(long l)
    {
        BigDecimal d;
        d.n = l * ScaleFactor;
        return d;
    }

    public BigDecimal(BigInteger bi) => n = bi * ScaleFactor;

    public BigDecimal(BigDecimal bn) => n = bn.n;

    public static BigDecimal operator +(BigDecimal b1, BigDecimal b2)
    {
        BigDecimal d;
        d.n = b1.n + b2.n;
        return d;
    }

    public static BigDecimal operator -(BigDecimal b1, BigDecimal b2)
    {
        BigDecimal d;
        d.n = b1.n - b2.n;
        return d;
    }

    public static BigDecimal operator *(BigDecimal b1, BigDecimal b2)
    {
        BigDecimal d;
        d.n = b1.n * b2.n / ScaleFactor;
        return d;
    }

    public static BigDecimal operator /(BigDecimal b1, BigDecimal b2)
    {
        BigDecimal d;
        d.n = ScaleFactor * b1.n / b2.n;
        return d;
    }

    public static bool operator ==(BigDecimal b1, BigDecimal b2) => b1.n == b2.n;

    public static bool operator !=(BigDecimal b1, BigDecimal b2) => b1.n != b2.n;

    public static bool operator >(BigDecimal b1, BigDecimal b2) => b1.n > b2.n;

    public static bool operator >=(BigDecimal b1, BigDecimal b2) => b1.n >= b2.n;

    public static bool operator <(BigDecimal b1, BigDecimal b2) => b1.n < b2.n;

    public static bool operator <=(BigDecimal b1, BigDecimal b2) => b1.n <= b2.n;

    // Standard string representation
    public override readonly string ToString()
    {
        var sb = new StringBuilder();
        if (n < 0)
            _ = sb.Append('-');
        _ = BigInteger.Abs(n) >= ScaleFactor ? sb.Append(BigInteger.Divide(BigInteger.Abs(n), ScaleFactor).ToString()) : sb.Append('0');
        var d = BigInteger.Remainder(BigInteger.Abs(n), ScaleFactor);
        if (d != 0)
        {
            _ = sb.Append('.');
            var sz = d.ToString();
            _ = sb.Append('0', Digits - sz.Length);
            _ = sb.Append(sz);
        }
        return sb.ToString();
    }

    // Otherwise C# compiler is not happy
    public override readonly bool Equals(object obj)
    {
        //Check for null and compare run-time types.
        if (obj == null || GetType() != obj.GetType())
            return false;

        var bd = (BigDecimal)obj;
        return n == bd.n;
    }

    // For free!
    // But Resharper indicates a warning: Non-readonly field referenced...
    public override readonly int GetHashCode() => n.GetHashCode();

    // For IComparable interface
    public readonly int CompareTo(object obj)
    {
        if (obj == null)
            return 1;

        try
        {
            var bd = (BigDecimal)obj;
            return CompareTo(bd);
        }
        catch (Exception)
        {
            throw new ArgumentException("Object is not a BigDecimal");
        }
    }

    /*
    // Explicit interface IComparable<BigDecimal> implementation
    int IComparable<BigDecimal>.CompareTo(BigDecimal other)
    {
        return n.CompareTo(other.n);
    }
    */

    // implicit interface IComparable<BigDecimal> implementation
    public readonly int CompareTo(BigDecimal other) => n.CompareTo(other.n);
}
