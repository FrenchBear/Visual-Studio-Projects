using System;

namespace MaBibliotheque;

public struct DBInt
{
    public static readonly DBInt Null = new();
    private readonly int value;
    private readonly bool defined;

    public bool IsNull => !defined;

    private DBInt(int x)
    {
        value = x;
        defined = true;
    }

    public static DBInt operator +(DBInt x, DBInt y) => !x.defined || !y.defined ? Null : new DBInt(x.value + y.value);

    public static implicit operator DBInt(int x) => new(x);

    public static explicit operator int(DBInt x) => x.defined ? x.value : throw new Exception("Valeur NULL");

    public override string ToString() => defined ? value.ToString() : "<NULL>";
}