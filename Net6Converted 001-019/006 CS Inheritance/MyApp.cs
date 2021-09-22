// 006 C# Héritage
// Essais d'héritage simple en C#
// 2001-01-27   PV
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010
// 2021-09-17   PV  VS2022/Net6

using System;

internal abstract class B
{
    protected B()
    {
        Console.WriteLine("B.ctor");
    }

    protected virtual void SomeVirtualMethod()
    {
    }

    protected abstract void AnAbstractMehod();

    protected static void NonVirtualMethod()
    {
    }
}

internal class D : B
{
    public D()
    {
        Console.WriteLine("D.ctor");
    }

    protected override void SomeVirtualMethod()
    {
    }

    protected override void AnAbstractMehod()
    {
    }

    protected new static void NonVirtualMethod()
    {
    }
}

internal class MyApp
{
    public static void Main()
    {
#pragma warning disable IDE0059 // Unnecessary assignment of a value
        D d = new();
#pragma warning restore IDE0059 // Unnecessary assignment of a value

        //Console.Write("(pause)");
        //Console.ReadLine();
    }
}