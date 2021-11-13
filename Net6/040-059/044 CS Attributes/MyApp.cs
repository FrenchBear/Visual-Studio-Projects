// 44 C# Attributes
// Essai d'utilisation des attributs en C#
//
// 2001-02-18   PV
// 2001-08-18   PV Beta2
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010
// 2021-09-18   PV  VS2022, Net6

using System;

namespace CS44;

[AttributeUsage(AttributeTargets.Class)]
public class MonAttribut : Attribute
{
    private readonly int iPriv;
    private string sInfo;

    public MonAttribut(int iVal)
    {
        iPriv = iVal;
        sInfo = "";
    }

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

internal class MyApp
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
        Type t = o.GetType();
        Console.WriteLine(t.Name);

        MonAttribut m = (MonAttribut)t.GetCustomAttributes(typeof(MonAttribut), false)[0];
        Console.WriteLine("{0}, {1}", m.IFlags, m.Info);
    }
}