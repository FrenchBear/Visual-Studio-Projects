// 012 CS Operators: Essais d'opérateurs et de finalizers
// Ne fonctionne plus avec la Béta 2...
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010

using System;

#pragma warning disable IDE0059 // Unnecessary assignment of a value

internal class Complexe
{
    protected double r, i;

    /// <summary>Constructeur de Complexe à partir d'une paire de réels</summary>
    /// <param name="r">Partie réelle</param>
    /// <param name="i">Partie imaginaire</param>
    public Complexe(double r, double i)
    {
        this.r = r;
        this.i = i;
        Console.WriteLine("Constructeur {0}", this);
    }

    public Complexe(double r) : this(r, 0)
    {
    }

    ~Complexe()
    {
        Console.WriteLine("Destructeur {0}", this);
    }

    public static implicit operator Complexe(double d) => new Complexe(d);

    override public string ToString() => "(" + r.ToString() + ";" + i.ToString() + ")";

    public static Complexe operator +(Complexe a, Complexe b) => new Complexe(a.r + b.r, a.i + b.i);
};

internal class MyApp
{
    public static void Main()
    {
        Console.WriteLine("Main.1 Mem: {0}", System.GC.GetTotalMemory(false));
        TestsComplexes();
        Console.WriteLine("Main.2 Mem: {0}", System.GC.GetTotalMemory(false));
        System.GC.Collect();
        System.GC.WaitForPendingFinalizers();
        Console.WriteLine("Main.3 Mem: {0}", System.GC.GetTotalMemory(false));
        Console.ReadLine();
    }

    private static void TestsComplexes()
    {
        Console.WriteLine("TestsComplexes.1 Mem: {0}", System.GC.GetTotalMemory(false));
        var a = new Complexe(1, 2);
        Console.WriteLine("TestsComplexes.2 Mem: {0}", System.GC.GetTotalMemory(false));
        var b = new Complexe(1);
        Console.WriteLine("TestsComplexes.3 Mem: {0}", System.GC.GetTotalMemory(false));
        Complexe c = a + b;

        // Grâce à l'opérateur Complexe(double d)
        Complexe d = 2;
        Complexe e = a + 1;
        Complexe f = (byte)2;
    }
}