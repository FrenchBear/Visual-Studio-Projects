using System;

#pragma warning disable IDE0130 // Namespace doesn't match folder structure

namespace MaBibliotheque;

public readonly struct DBInt
{
    public static readonly DBInt Null; //= new();
    private readonly int Value;
    private readonly bool Defined;

    public bool IsNull => !Defined;

    private DBInt(int x)
    {
        Value = x;
        Defined = true;
    }

    public static DBInt operator +(DBInt x, DBInt y) => !x.Defined || !y.Defined ? Null : new DBInt(x.Value + y.Value);

    public static implicit operator DBInt(int x) => new(x);

    public static explicit operator int(DBInt x) => x.Defined ? x.Value : throw new Exception("Valeur NULL");

    public override string ToString() => Defined ? Value.ToString() : "<NULL>";
}