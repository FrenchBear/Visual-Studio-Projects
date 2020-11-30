// Essais sur les interfaces
// 2001-08-11   PV
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010

using System;

class MaClasse
{
    static void Main(string[] args)
    {
        TestInterface();
        Console.WriteLine("---------------------");
        TestDecimal();
        Console.WriteLine("---------------------");
        TestEgalite();

        Console.ReadLine();
    }

    static void TestEgalite()
    {
        string s1 = "hello";
        string s2 = string.Copy(s1);
        Console.WriteLine("s1==s2: {0}", s1 == s2);
        Console.WriteLine("(object)s1==(object)s2: {0}", (object)s1 == (object)s2);
        //	Console.WriteLine("s1 is s2: {0}", s1 is s2);
        Console.WriteLine("s1.Equals(s2): {0}", s1.Equals(s2));

        string a = 3.14.ToString();
        Console.WriteLine(a);

        int[] b = new int[5];
    }

    static void TestInterface()
    {
        cla2 C2 = new cla2();
        cla1 C1 = C2;
        C1.H();

        C2.F();
        ((inter)C2).F();
    }

    static void TestDecimal()
    {
        decimal d = 0;
        for (int i = 0; i < 100; i++)
            d += 0.01m;
        Console.WriteLine("decimal: {0}\t{1}", d, d - 1m);

        double r = 0;
        for (int i = 0; i < 100; i++)
            r += 0.01d;
        Console.WriteLine("double: {0}\t{1}", r, r - 1.0d);

        float f = 0;
        for (int i = 0; i < 100; i++)
            f += 0.01f;
        Console.WriteLine("float: {0}\t{1}", f, f - 1.0f);

        decimal d2 = 12345678901234567890123456789m;
        Console.WriteLine("d2:{0}", d2);
        Console.WriteLine("d3:{0}", decimal.MaxValue);
    }
}


enum couleur { bleu, blanc, rouge };
struct complex { readonly double x, y; complex(double r) { x = r; y = r; } }
interface inter { void F(); }
interface deriv : inter { void G(); }
class cla1 { public virtual void H() { Console.WriteLine("cla1.H()"); } }
class cla2 : cla1, inter
{
    public override void H() { Console.WriteLine("cla2.H()"); }
    public void F() { Console.WriteLine("cla2.F()"); }
    void inter.F() { Console.WriteLine("cla2.inter.F()"); }
}
