﻿// 311 CS Extensions of IEnumerable(Of T)
// 2012-03-03   PV

using ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IEnumerable<int> r = Enumerable.Range(10, 10).DoubleListe();
            r.WriteLine();

            Console.ReadLine();
        }
    }
}