// Essais sur les interfaces
// 2001-08-11   PV
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010
// 2021-09-18   PV  VS2022, Net6

using static System.Console;

#pragma warning disable IDE0052 // Remove unread private members
#pragma warning disable IDE0051 // Remove unused private members
#pragma warning disable CA1822 // Mark members as static

internal class MaClasse
{
    private static void Main(string[] args)
    {
        TestInterface();
        WriteLine("---------------------");
        TestDecimal();
        WriteLine("---------------------");
        TestEgalite();

        //Console.ReadLine();
    }

    private static void TestEgalite()
    {
        var s1 = "hello";
#pragma warning disable CS0618 // Type or member is obsolete
        var s2 = string.Copy(s1);
#pragma warning restore CS0618 // Type or member is obsolete
        WriteLine("s1==s2: {0}", s1 == s2);
        WriteLine("(object)s1==(object)s2: {0}", (object)s1 == (object)s2);
        //	WriteLine("s1 is s2: {0}", s1 is s2);
        WriteLine("s1.Equals(s2): {0}", s1.Equals(s2));

        var a = 3.14.ToString();
        WriteLine(a);

        var b = new int[5];
    }

    private static void TestInterface()
    {
        Cla2 C2 = new();
        Cla1 C1 = C2;
        C1.H();

        C2.F();
        ((IInter)C2).F();
    }

    private static void TestDecimal()
    {
        decimal d = 0;
        for (var i = 0; i < 100; i++)
            d += 0.01m;
        WriteLine("decimal: {0}\t{1}", d, d - 1m);

        double r = 0;
        for (var i = 0; i < 100; i++)
            r += 0.01d;
        WriteLine("double: {0}\t{1}", r, r - 1.0d);

        float f = 0;
        for (var i = 0; i < 100; i++)
            f += 0.01f;
        WriteLine("float: {0}\t{1}", f, f - 1.0f);

        var d2 = 12345678901234567890123456789m;
        WriteLine("d2:{0}", d2);
        WriteLine("d3:{0}", decimal.MaxValue);
    }
}

internal enum Couleur
{ bleu, blanc, rouge };

internal struct Complex
{ private readonly double x, y; private Complex(double r)
    {
        x = r; y = r;
    }
}

internal interface IInter
{ void F(); }

internal interface IDeriv : IInter
{ void G(); }

internal class Cla1
{
    public virtual void H() => WriteLine("cla1.H()");
}

internal class Cla2 : Cla1, IInter
{
    public override void H() => WriteLine("cla2.H()");

    public void F() => WriteLine("cla2.F()");

    void IInter.F() => WriteLine("cla2.inter.F()");
}