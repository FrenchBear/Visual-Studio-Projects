// Play with IFormattable in C#
//
// 2001         PV
//
// 2006-10-01	PV		VS2005
// 2012-02-25	PV		VS2010
// 2021-09-18	PV		VS2022, Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13
// 2026-01-19	PV		Net10 C#14

using System;
using static System.Console;

internal readonly struct Complexe(double r, double i): IFormattable
{
    private readonly double r = r, i = i;

    public override string ToString() => $"({r},{i})";

    public string ToString(string sFormat, IFormatProvider fp)
    {
        if (sFormat != null)
            switch (sFormat.ToLower())
            {
                case "p":
                    //return "<Nombre " + ToString() + " en coordonnées pôlaires>";
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
