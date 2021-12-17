// 012 CS Operators: Essais d'opérateurs et de finalizers
// Ne fonctionne plus avec la Béta 2...
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010
// 2021-09-17   PV  VS2022/Net6

using System;
using static System.Console;

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
        WriteLine("Constructeur {0}", this);
    }

    public Complexe(double r) : this(r, 0)
    {
    }

    ~Complexe()
    {
        WriteLine("Destructeur {0}", this);
    }

    public static implicit operator Complexe(double d) 
        => new(d);

    override public string ToString() 
        => "(" + r + ";" + i + ")";

    public static Complexe operator +(Complexe a, Complexe b) 
        => new(a.r + b.r, a.i + b.i);
};

internal class MyApp
{
    public static void Main()
    {
        WriteLine("Main.1 Mem: {0}", GC.GetTotalMemory(false));
        TestsComplexes();
        WriteLine("Main.2 Mem: {0}", GC.GetTotalMemory(false));
        GC.Collect();
        GC.WaitForPendingFinalizers();
        WriteLine("Main.3 Mem: {0}", GC.GetTotalMemory(false));
        _ = ReadLine();
    }

    private static void TestsComplexes()
    {
        WriteLine("TestsComplexes.1 Mem: {0}", GC.GetTotalMemory(false));
        Complexe a = new(1, 2);
        WriteLine("TestsComplexes.2 Mem: {0}", GC.GetTotalMemory(false));
        Complexe b = new(1);
        WriteLine("TestsComplexes.3 Mem: {0}", GC.GetTotalMemory(false));
        Complexe c = a + b;

        // Grâce à l'opérateur Complexe(double d)
        Complexe d = 2;
        Complexe e = a + 1;
        Complexe f = (byte)2;
    }
}