// 44 C# Attributes
// Essai d'utilisation des attributs en C#
// 2001-02-18   PV
// 2001-08-18   PV Beta2
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010

using System;
using System.Reflection;


[AttributeUsage(AttributeTargets.Class)]
public class MonAttribut : System.Attribute
{
    private int iPriv;
    private string sInfo;

    public MonAttribut(int iVal)
    {
        iPriv = iVal;
        sInfo = "";
    }

    public string Info
    {
        get
        {
            return sInfo;
        }
        set
        {
            sInfo = value;
        }
    }

    public int iFlags
    {
        get
        {
            return iPriv;
        }
    }
}


[MonAttribut(1, Info = "Info de MaClasse1")]
class MaClasse1
{

}



[MonAttribut(7)]
class MaClasse2
{

}



class MyApp
{
    public static void Main()
    {
        MaClasse1 o1 = new MaClasse1();
        MaClasse2 o2 = new MaClasse2();

        Zap(o1);
        Zap(o2);

        Console.ReadLine();
    }

    private static void Zap(object o)
    {
        Type t = o.GetType();
        Console.WriteLine(t.Name);

        MonAttribut m = (MonAttribut)t.GetCustomAttributes(typeof(MonAttribut), false)[0];
        Console.WriteLine("{0}, {1}", m.iFlags, m.Info);
    }
}
