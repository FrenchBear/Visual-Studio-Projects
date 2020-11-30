// 504 CS Closure Example
// Example of closure
// 2013-01-02   PV

using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var pos = Adder();
            var neg = Adder();
            for (int i = 0; i < 10; i++)
                Console.WriteLine("{0}, {1}", pos(i), neg(-2 * i));

            Console.WriteLine();
            Console.Write("(Pause)");
            Console.ReadLine();
        }

        static Func<int, int> Adder()
        {
            int sum = 0;
            return (int x) =>
            {
                sum += x;
                return sum;
            };
        }

        //delegate int FuncInt(int x);
        //static FuncInt adder2()
        //{
        //    int sum = 0;
        //    return (int x) =>
        //    {
        //        sum += x;
        //        return sum;
        //    };
        //}

        //static FuncInt adder3()
        //{
        //    int sum = 0;
        //    return delegate(int x)
        //    {
        //        sum += x;
        //        return sum;
        //    };
        //}

    }
}
