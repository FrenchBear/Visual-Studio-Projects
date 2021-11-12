// Essais sur les variables locales non initialisées
// et sur StackTrace
// 2001-01-13   PV
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010
// 2021-09-17   PV  VS2022/Net6

using System;
using System.Diagnostics;

namespace CS015;

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

        j = i > Zap() ? 0 : 3;

        Console.WriteLine("j: " + j);
        _ = Console.ReadLine();
    }
}