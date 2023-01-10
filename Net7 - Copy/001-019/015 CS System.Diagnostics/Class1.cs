// Essais sur les variables locales non initialisées
// et sur StackTrace
// 2001-01-13   PV
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010
// 2021-09-17   PV  VS2022/Net6

using System;
using System.Diagnostics;
using static System.Console;

namespace CS015;

public static class InOut
{
    private static int Zap()
    {
        WriteLine("Stack\n{0}\n", new StackTrace());
        return -2;
    }

    public static void Main()
    {
        var i = 0;
        var j = i > Zap() ? 0 : 3;

        WriteLine("j: " + j);
        _ = Console.ReadLine();
    }
}