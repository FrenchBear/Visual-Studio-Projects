// 20 C#
// Projet mixte C#, VB et C++
// La classe de base B est définie en VB
// La classe de base C est définie en C++ managé
// Les classes dérivées D1 et D2 sont définie en C#
//
// 2001-01-27   PV
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010, tout forcé en 32 bit et ciblant le Framework .Net 4 (à cause du C++)
// 2017-04-30   PV  VS2017, Git
// 2021-09-18   PV  VS2022, Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12

using System;

#pragma warning disable IDE0059 // Unnecessary assignment of a value

namespace Mixte20;

internal class MyApp
{
    public static void Main()
    {
        D1 d1 = new();
        D2 d2 = new();
    }
}

internal class D1 : B
{
    public D1()
    {
        Console.WriteLine("D1.ctor");
    }
}

internal class D2 : C
{
    public D2()
    {
        Console.WriteLine("D2.ctor");
    }
}
