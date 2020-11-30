// 2001 PV
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010

using System;

internal struct Complexe : IFormattable
{
    private readonly double r, i;

    public Complexe(double r, double i)
    {
        this.r = r;
        this.i = i;
    }

    public override string ToString()
    {
        return String.Format("({0},{1})", r, i);
    }

    public String ToString(String sFormat, IFormatProvider fp)
    {
        if (sFormat != null) switch (sFormat.ToLower())
            {
                case "p":
                    //return "<Nombre " + ToString() + " en coordonnées pôlaires>";
                    return "[" + Math.Sqrt(i * i + r * r) + ";" + Math.Atan2(i, r) / Math.PI * 180 + "]";
            }
        return ToString();
    }
}

internal class MyApp
{
    public static void Main()
    {
        Console.WriteLine("{0:N0}", Int16.MaxValue);
        Console.WriteLine("{0:N0}", Int32.MaxValue);
        Console.WriteLine("{0:N0}", Int64.MaxValue);

        Complexe c = new Complexe(1, 1);
        Console.WriteLine("{0}", c.ToString());
        Console.WriteLine("{0}", c);
        Console.WriteLine("{0:P}", c);

        Console.ReadLine();
    }
}