// 311 CS Extensions of IEnumerable(Of T)
// 2012-03-03   PV

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExtensionMethods;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> r = Enumerable.Range(10, 10).DoubleListe();
            r.WriteLine();

            Console.ReadLine();
        }
    }
}
