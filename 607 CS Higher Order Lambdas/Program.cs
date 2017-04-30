// 607 CS Higher Order Lambdas
// Adaptation of C++ example (551 CPP)
// 2017-01-14   PV

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS607
{
    class Program
    {
        static void Main(string[] args)
        {
            // The following code declares a lambda expression that returns 
            // another lambda expression that adds two numbers. 
            Func<int, Func<int, int>> addtwointegers = (x) => { return (y) => x + y; };

            // The following code declares a lambda expression that takes another
            // lambda expression as its argument.
            // The lambda expression applies the argument z to the function f
            // and multiplies by 2.
            Func<Func<int, int>, int, int> higherorder = (f, z) => 2 * f(z);

            // Call the lambda expression that is bound to higherorder
            var answer = higherorder(addtwointegers(7), 8);

            // Print the result, which is (7+8)*2.
            Console.WriteLine(answer);


            Console.WriteLine();
            Console.Write("(Pause)");
            Console.ReadLine();
        }
    }
}
