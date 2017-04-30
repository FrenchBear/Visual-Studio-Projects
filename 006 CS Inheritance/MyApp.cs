// 006 C# Héritage
// Essais d'héritage simple en C#
// 2001-01-27   PV
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010


using System;

abstract class B
{
    protected B()
    {
        Console.WriteLine("B.ctor");
    }

    protected virtual void SomeVirtualMethod()
    {

    }

    protected abstract void AnAbstractMehod();

    protected void NonVirtualMethod()
    {

    }
}

class D : B
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

    protected new void NonVirtualMethod()
    {

    }
}


class MyApp
{
    public static void Main()
    {
        D d = new D();
        Console.ReadLine();
    }
}
