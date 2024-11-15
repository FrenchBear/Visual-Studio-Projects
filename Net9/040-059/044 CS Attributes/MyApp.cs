// 44 C# Attributes
// Essai d'utilisation des attributs en C#
//
// 2001-02-18   PV
// 2001-08-18   PV Beta2
// 2006-10-01	PV		VS2005
// 2012-02-25	PV		VS2010
// 2021-09-18	PV		VS2022, Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13

using System;
using static System.Console;

namespace CS044;

[AttributeUsage(AttributeTargets.Class)]
public class MonAttribut(int iVal): Attribute
{
    private readonly int iPriv = iVal;
    private string sInfo = "";

    public string Info
    {
        get => sInfo;
        set => sInfo = value;
    }

    public int IFlags => iPriv;
}

[MonAttribut(1, Info = "Info de MaClasse1")]
internal class MaClasse1
{
}

[MonAttribut(7)]
internal class MaClasse2
{
}

internal static class MyApp
{
    public static void Main()
    {
        MaClasse1 o1 = new();
        MaClasse2 o2 = new();

        Zap(o1);
        Zap(o2);

        //Console.ReadLine();
    }

    private static void Zap(object o)
    {
        var t = o.GetType();
        WriteLine(t.Name);

        var m = (MonAttribut)t.GetCustomAttributes(typeof(MonAttribut), false)[0];
        WriteLine("{0}, {1}", m.IFlags, m.Info);
    }
}
