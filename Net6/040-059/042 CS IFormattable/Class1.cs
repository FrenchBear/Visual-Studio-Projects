// Play with IFormattable in C#
//
// 2001         PV
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010
// 2021-09-18   PV  VS2022, Net6

using System;
using static System.Console;

internal struct Complexe : IFormattable
{
    private readonly double r, i;

    public Complexe(double r, double i)
    {
        this.r = r;
        this.i = i;
    }

    public override string ToString() => $"({r},{i})";

    public string ToString(string sFormat, IFormatProvider fp)
    {
        if (sFormat != null) 
            switch (sFormat.ToLower())
            {
                case "p":
                    //return "<Nombre " + ToString() + " en coordonn�es p�laires>";
                    return "[" + Math.Sqrt(i * i + r * r) + ";" + Math.Atan2(i, r) / Math.PI * 180 + "]";
            }
        return ToString();
    }
}

internal static class MyApp
{
    public static void Main()
    {
        WriteLine("{0:N0}", short.MaxValue);
        WriteLine("{0:N0}", int.MaxValue);
        WriteLine("{0:N0}", long.MaxValue);

        Complexe c = new(1, 1);
        WriteLine("{0}", c.ToString());
        WriteLine("{0}", c);
        WriteLine("{0:P}", c);

        //Console.ReadLine();
    }
}