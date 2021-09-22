// 542 CS Arrays ByRef
// Test that arrays are passed by reference in C#
// 2016-08-04   PV

using System;

namespace ConsoleApplication1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int[] a = new int[] { 0, 1, 2, 3, 4, 5 };
            a.WriteLine();
            Test(a);
            a.WriteLine();

            Console.WriteLine();
            Console.Write("(Pause)");
            Console.ReadLine();
        }

        private static void Test(int[] a)
        {
            a[2] = 12;
        }
    }

    internal static class Extensions
    {
        public static void WriteLine<T>(this T[] a)
        {
            bool bFirst = true;
            foreach (T e in a)
            {
                if (bFirst)
                {
                    Console.Write("[");
                    bFirst = false;
                }
                else
                    Console.Write(", ");
                Console.Write(e);
            }
            Console.WriteLine("]");
        }
    }
}