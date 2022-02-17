// 002 CS Stack+Delegates+Math
// Essais divers en C#
// Structure de pile, delegates
//
// 2001 PV
// 2006-10-01   PV  VS2005
// 2010-05-01   PV  VS2010
// 2021-09-17   PV  VS2022/Net6

using System;
using static System.Console;

namespace CS002;

public static class MyMath
{
    public delegate double FR�elle(double arg);

    public static double Int�grale(double binf, double bsup, FR�elle f)
    {
        int i;
        double v = 0;
        const int pas = 1000;

        for (i = 0; i < pas; i++)
            v += f(binf + (bsup - binf) * (i + 0.5) / pas);
        return v * (bsup - binf) / pas;
    }

    public static double Carr�(double x) => x * x;
}

public class MyApp
{
    private static void F(params int[] targ)
    {
        WriteLine("# of arguments: {0}", targ.Length);
        for (var i = 0; i < targ.Length; i++)
        {
            WriteLine("\tArg[{0}] = {1}", i, targ[i]);
        }
    }

    private static void Swap(ref object x, ref object y) => (x, y) = (y, x);

    public static void Main()
    {
        WriteLine("System.Int64.MaxValue = {0}", long.MaxValue);

        F();
        F(1, 2);
        F(new int[] { 1, 2, 3 });

        int a = 1, b = 2;

        WriteLine("a={0}, b={1}", a, b);

        object oa = a;
        object ob = b;
        Swap(ref oa, ref ob);
        a = (int)oa;
        b = (int)ob;

        WriteLine("a={0}, b={1}", a, b);

        Pile p = new();
        p.Empile(1);
        p.Empile(2);
        p.Empile(3);

        WriteLine("D�pile: {0}", p.D�pile());
        WriteLine("D�pile: {0}", p.D�pile());

        try
        {
            WriteLine("D�pile: {0}", p.D�pile());
        }
        catch (Exception e)
        {
            WriteLine("�chec au d�pile: {0}", e.Message);
        }
        finally
        {
            WriteLine("Bloc finally");
        }

        WriteLine("12.3� = {0}", MyMath.Carr�(12.3));
        WriteLine("Int�grale x�|0,1: {0}", MyMath.Int�grale(0.0, 1.0, new MyMath.FR�elle(MyMath.Carr�)));
        WriteLine("Int�grale sin(x)|0,pi: {0}", MyMath.Int�grale(0.0, Math.PI, new MyMath.FR�elle(Math.Sin)));
    }
}