// 543 CS Arrays
// Play with arrays in C#
// 2016-08-05   PV

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Diagnostics;

namespace ConsoleApplication3
{
    class CSArrays
    {
        static void Main(string[] args)
        {
            int[,,] mat3 = new int[2, 3, 4];
            int[][] jag2 = new int[2][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6, 7, 8, 9 } };


            Write($"mat3: {mat3.Length} = ");
            for (int i = 0; i < mat3.Rank; i++)
            {
                if (i > 0) Write(" * ");
                Write(mat3.GetLength(i));
            }
            WriteLine();

            mat3[1, 1, 1] = 111;
            mat3[0, 1, 2] = 12;
            foreach (int m in mat3)
                Write($"{m} ");
            WriteLine();

            Write($"jag2: {jag2.Length}: ");
            for (int i = 0; i < jag2.Length; i++)
            {
                Write($"[{i}] = {jag2[i].Length}  ");
            }
            WriteLine();


            Console.WriteLine();
            Console.Write("(Pause)");
            Console.ReadLine();
        }
    }
}
