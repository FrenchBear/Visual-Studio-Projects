// 311 CS Extensions of IEnumerable(Of T)
//
// 2012-03-03   PV
// 2021-09-20   PV  VS2022; Net6

using ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1;

internal class Program
{
    private static void Main(string[] args)
    {
        IEnumerable<int> r = Enumerable.Range(10, 10).DoubleListe();
        r.WriteLine();
    }
}