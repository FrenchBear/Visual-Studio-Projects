// 002 CS Stack+Delegates+Math
// Essais divers en C#
// Structure de pile, delegates
//
// 2001 PV
// 2006-10-01   PV  VS2005
// 2010-05-01   PV  VS2010
// 2021-09-17   PV  VS2022/Net6
// 2023-01-10	PV		Net7

using System;
using static System.Console;

namespace CS002;

public static class MyMath
{
    public delegate double FRéelle(double arg);

    public static double Intégrale(double binf, double bsup, FRéelle f)
    {
        int i;
        double v = 0;
        const int pas = 1000;

        for (i = 0; i < pas; i++)
            v += f(binf + (bsup - binf) * (i + 0.5) / pas);
        return v * (bsup - binf) / pas;
    }

    public static double Carré(double x) => x * x;
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

        WriteLine("Dépile: {0}", p.Dépile());
        WriteLine("Dépile: {0}", p.Dépile());

        try
        {
            WriteLine("Dépile: {0}", p.Dépile());
        }
        catch (Exception e)
        {
            WriteLine("Échec au dépile: {0}", e.Message);
        }
        finally
        {
            WriteLine("Bloc finally");
        }

        WriteLine("12.3² = {0}", MyMath.Carré(12.3));
        WriteLine("Intégrale x²|0,1: {0}", MyMath.Intégrale(0.0, 1.0, new MyMath.FRéelle(MyMath.Carré)));
        WriteLine("Intégrale sin(x)|0,pi: {0}", MyMath.Intégrale(0.0, Math.PI, new MyMath.FRéelle(Math.Sin)));
    }
}
