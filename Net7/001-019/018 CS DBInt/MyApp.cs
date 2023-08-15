// Essais d'implmétation d'une classe d'entiers gérant NULL
// 2001-01-15   PV
// 2001-08-15   PV	Beta2, ToString
// 2006-10-01	PV		VS2005  Note that Framework 2 has a generic class Nullable(of T) that is a solution to this problem
// 2012-02-25	PV		VS2010
// 2021-09-17	PV		VS2022/Net6
// 2023-01-10	PV		Net7

using System;
using static System.Console;

namespace CS018;

public readonly struct DBInt
{
    public static readonly DBInt Null = new();
    private readonly int value;
    private readonly bool defined;

    public bool IsNull => !defined;

    // Pas de constructeur sans paramètre car c'est un type struct
    private DBInt(int x)
    {
        value = x;
        defined = true;
    }

    public static DBInt operator +(DBInt x, DBInt y) => !x.defined || !y.defined ? Null : new DBInt(x.value + y.value);

    public static implicit operator DBInt(int x) => new(x);

    public static explicit operator int(DBInt x) => x.defined ? x.value : throw new Exception("Valeur NULL");

    public override string ToString() => defined ? value.ToString() : "(Null)";
}

internal static class MyApp
{
    public static void Main()
    {
        DBInt x = 123;
        var y = DBInt.Null;
        var z = x + y;

        WriteLine("x = {0}", x);
        WriteLine("y = {0}", y);
        WriteLine("z = {0}", z);

        _ = Console.ReadLine();
    }
}
