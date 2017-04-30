// 012 CS Operators: Essais d'op�rateurs et de finalizers
// Ne fonctionne plus avec la B�ta 2...
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010

using System;

class Complexe
{
    protected double r, i;

    /// <summary>Constructeur de Complexe � partir d'une paire de r�els</summary>
    /// <param name="r">Partie r�elle</param>
    /// <param name="i">Partie imaginaire</param>
    public Complexe(double r, double i)
    {
        this.r = r;
        this.i = i;
        Console.WriteLine("Constructeur {0}", this);
    }

    public Complexe(double r) : this(r, 0) { }


    ~Complexe()
    {
        Console.WriteLine("Destructeur {0}", this);
    }


    public static implicit operator Complexe(double d)
    {
        return new Complexe(d);
    }

    override public string ToString()
    {
        return "(" + r.ToString() + ";" + i.ToString() + ")";
    }


    public static Complexe operator +(Complexe a, Complexe b)
    {
        return new Complexe(a.r + b.r, a.i + b.i);
    }
};



class MyApp
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
        Complexe a = new Complexe(1, 2);
        Console.WriteLine("TestsComplexes.2 Mem: {0}", System.GC.GetTotalMemory(false));
        Complexe b = new Complexe(1);
        Console.WriteLine("TestsComplexes.3 Mem: {0}", System.GC.GetTotalMemory(false));
        Complexe c = a + b;

        // Gr�ce � l'op�rateur Complexe(double d)
        Complexe d = 2;
        Complexe e = a + 1;
        Complexe f = (byte)2;
    }
}
