// 006 C# Héritage
// Essais d'héritage simple en C#
//
// 2001-01-27   PV
// 2006-10-01   PV      VS2005
// 2012-02-25   PV      VS2010
// 2021-09-17   PV      VS2022/Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12

using static System.Console;

#pragma warning disable IDE0059 // Unnecessary assignment of a value

internal abstract class B
{
    protected B() => WriteLine("B.ctor");

    protected virtual void SomeVirtualMethod()
    {
    }

    protected abstract void AnAbstractMehod();

    protected static void NonVirtualMethod()
    {
    }
}

internal class D: B
{
    public D() => WriteLine("D.ctor");

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

internal static class MyApp
{
    public static void Main()
    {
        D d = new();
    }
}
