// BigDecimal
// Implementation of an arbitrary precision decimal class based on BigInteger
// Actually should implement the same members as BigInteger struct itself
//
// 2011-07-04   PV
// 2012-02-02   PV  Refactoring; CompareTo, interfaces
// 2021-09-23   PV  VS2022; Net6

using System;
using System.Numerics;
using System.Text;

namespace BigDecimalNS;

internal struct BigDecimal : IComparable<BigDecimal>, IComparable
{
    // Definition of precision
    public const int Digits = 750;                   // Number of decimals

    static private readonly BigInteger ScaleFactor = BigInteger.Pow(10, Digits);    // Scale factor for storage in a BigInteger

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

    static public BigDecimal operator +(BigDecimal b1, BigDecimal b2)
    {
        BigDecimal d;
        d.n = b1.n + b2.n;
        return d;
    }

    static public BigDecimal operator -(BigDecimal b1, BigDecimal b2)
    {
        BigDecimal d;
        d.n = b1.n - b2.n;
        return d;
    }

    static public BigDecimal operator *(BigDecimal b1, BigDecimal b2)
    {
        BigDecimal d;
        d.n = b1.n * b2.n / ScaleFactor;
        return d;
    }

    static public BigDecimal operator /(BigDecimal b1, BigDecimal b2)
    {
        BigDecimal d;
        d.n = ScaleFactor * b1.n / b2.n;
        return d;
    }

    static public bool operator ==(BigDecimal b1, BigDecimal b2) => b1.n == b2.n;

    static public bool operator !=(BigDecimal b1, BigDecimal b2) => b1.n != b2.n;

    static public bool operator >(BigDecimal b1, BigDecimal b2) => b1.n > b2.n;

    static public bool operator >=(BigDecimal b1, BigDecimal b2) => b1.n >= b2.n;

    static public bool operator <(BigDecimal b1, BigDecimal b2) => b1.n < b2.n;

    static public bool operator <=(BigDecimal b1, BigDecimal b2) => b1.n <= b2.n;

    // Standard string representation
    public override string ToString()
    {
        var sb = new StringBuilder();
        if (n < 0) _ = sb.Append('-');
        _ = BigInteger.Abs(n) >= ScaleFactor ? sb.Append(BigInteger.Divide(BigInteger.Abs(n), ScaleFactor).ToString()) : sb.Append('0');
        BigInteger d = BigInteger.Remainder(BigInteger.Abs(n), ScaleFactor);
        if (d != 0)
        {
            _ = sb.Append('.');
            string sz = d.ToString();
            _ = sb.Append('0', Digits - sz.Length);
            _ = sb.Append(sz);
        }
        return sb.ToString();
    }

    // Otherwise C# compiler is not happy
    public override bool Equals(Object obj)
    {
        //Check for null and compare run-time types.
        if (obj == null || GetType() != obj.GetType()) return false;

        BigDecimal bd = (BigDecimal)obj;
        return n == bd.n;
    }

    // For free!
    // But Resharper indicates a warning: Non-readonly field referenced...
    public override int GetHashCode() => n.GetHashCode();

    // For IComparable interface
    public int CompareTo(object obj)
    {
        if (obj == null) return 1;

        try
        {
            BigDecimal bd = (BigDecimal)obj;
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
    public int CompareTo(BigDecimal other) => n.CompareTo(other.n);
}