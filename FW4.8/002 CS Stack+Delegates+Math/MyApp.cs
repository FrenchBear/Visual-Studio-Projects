// 002 CS Stack+Delegates+Math
// Essais divers en C#
// Structure de pile, delegates
// 2001 PV
// 2006-10-01   PV  VS2005
// 2010-05-01   PV  VS2010

using System;

public class MyMath
{
    public delegate double FRéelle(double arg);

    public static double Intégrale(double binf, double bsup, FRéelle f)
    {
        int i;
        double v;
        const int PAS = 1000;

        v = 0;
        for (i = 0; i < PAS; i++)
            v += f(binf + (bsup - binf) * (i + 0.5) / PAS);
        return v * (bsup - binf) / PAS;
    }

    public static double Carré(double x) => x * x;
}

public class MyApp
{
    private static void F(params int[] targ)
    {
        Console.WriteLine("# of arguments: {0}", targ.Length);
        for (int i = 0; i < targ.Length; i++)
        {
            Console.WriteLine("\tArg[{0}] = {1}", i, targ[i]);
        }
    }

    private static void Swap(ref object x, ref object y) => (y, x) = (x, y);

    public static void Main()
    {
        Console.WriteLine("System.Int64.MaxValue = {0}", System.Int64.MaxValue);

        F();
        F(1, 2);
        F(new int[] { 1, 2, 3 });

        int a = 1, b = 2;

        Console.WriteLine("a={0}, b={1}", a, b);

        object oa = a;
        object ob = b;
        Swap(ref oa, ref ob);
        a = (int)oa;
        b = (int)ob;

        Console.WriteLine("a={0}, b={1}", a, b);

        var p = new Pile();
        p.Empile(1);
        p.Empile(2);
        p.Empile(3);

        Console.WriteLine("Dépile: {0}", p.Dépile());
        Console.WriteLine("Dépile: {0}", p.Dépile());

        try
        {
            Console.WriteLine("Dépile: {0}", p.Dépile());
        }
        catch (Exception e)
        {
            Console.WriteLine("�chec au Dépile: {0}", e.Message);
        }
        finally
        {
            Console.WriteLine("Bloc finally");
        }

        Console.WriteLine("12.3� = {0}", MyMath.Carré(12.3));
        Console.WriteLine("Intégrale x�|0,1: {0}", MyMath.Intégrale(0.0, 1.0, new MyMath.FRéelle(MyMath.Carré)));
        Console.WriteLine("Intégrale sin(x)|0,pi: {0}", MyMath.Intégrale(0.0, Math.PI, new MyMath.FRéelle(Math.Sin)));

        Console.WriteLine();
        Console.Write("(Pause)");
        Console.ReadLine();
    }
}