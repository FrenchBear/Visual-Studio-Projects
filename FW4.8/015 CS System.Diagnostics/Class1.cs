// Essais sur les variables locales non initialisées
// et sur StackTrace
// 2001-01-13   PV
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010

using System;
using System.Diagnostics;

public class InOut
{
    private static int Zap()
    {
        Console.WriteLine("Stack\n{0}\n", new StackTrace());
        return -2;
    }

    public static void Main()
    {
        int i = 0;
        int j;

        if (i > Zap())
        {
            j = 0;
        }
        else
            j = 3;

        Console.WriteLine("j: " + j);
        Console.ReadLine();
    }
}