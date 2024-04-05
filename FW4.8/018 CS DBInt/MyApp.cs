// Essais d'implmétation d'une classe d'entiers gérant NULL
// 2001-01-15   PV
// 2001-08-15   PV	Beta2, ToString
// 2006-10-01   PV  VS2005  Note that Framework 2 has a generic class Nullable(of T) that is a solution to this problem
// 2012-02-25   PV  VS2010

using System;

public readonly struct DBInt
{
    public static readonly DBInt Null = new DBInt();
    private readonly int value;
    private readonly bool defined;

    public bool IsNull => !defined;

    // Pas de constructeur sans paramètre car c'est un type struct
    private DBInt(int x)
    {
        value = x;
        defined = true;
    }

    public static DBInt operator +(DBInt x, DBInt y)
    {
        if (!x.defined || !y.defined) return Null;
        return new DBInt(x.value + y.value);
    }

    public static implicit operator DBInt(int x) => new DBInt(x);

    public static explicit operator int(DBInt x)
    {
        if (x.defined)
            return x.value;
        else
            throw new Exception("Valeur NULL");
    }

    public override string ToString()
    {
        if (defined)
            return value.ToString();
        else
            return "(Null)";
    }
}

internal class MyApp
{
    public static void Main()
    {
        DBInt x = 123;
        DBInt y = DBInt.Null;
        DBInt z = x + y;

        Console.WriteLine("x = {0}", x);
        Console.WriteLine("y = {0}", y);
        Console.WriteLine("z = {0}", z);

        Console.ReadLine();
    }
}