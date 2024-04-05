// CS611 NewLaby
// Labyrinth using recursive dividing algorithm
// But the result is not as good as digging algorithm, since there are plenty visible long halls,
// and long walls are also visible (first divisions)
//
// 2017-01-26   PV  First version
// 2017-03-02   PV  Restructure code in a class to test VS2017 live unit testing

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace NewLaby
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MethodToTest();

            Console.WriteLine();
            Console.Write("(Pause)");
            Console.ReadLine();
        }

        public static void MethodToTest()
        {
            var l = new Laby(10, 20);
            l.Print();
        }
    }

    public class Laby
    {
        // Bitmask for walls in Cells
        const int right = 1;
        const int bottom = 2;

        private Random rnd = new Random();

        private int rows, cols;
        private int[,] Cells;

        public Laby(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            Cells = new int[rows + 1, cols + 1];

            // Build bordering walls
            for (int r = 1; r <= rows; r++)
            {
                Cells[r, 0] |= right;
                Cells[r, cols] |= right;
            }
            for (int c = 1; c <= cols; c++)
            {
                Cells[0, c] |= bottom;
                Cells[rows, c] |= bottom;
            }

            BuildWall(1, cols, 1, rows, true);

            // Open 1 cell on the 1st and last rows
            Cells[0, 1 + rnd.Next(cols)] &= ~bottom;
            Cells[rows, 1 + rnd.Next(cols)] &= ~bottom;
        }

        public void Print()
        {
            for (int r = 0; r <=rows; r++)
            {
                if (r > 0)
                {
                    for (int c = 0; c <=cols; c++)
                    {
                        if ((Cells[r, c] & right) != 0)
                            Write("  |");
                        else
                            Write("   ");
                    }
                    WriteLine();
                }
                for (int c = 0; c <=cols; c++)
                {
                    if ((Cells[r, c] & bottom) != 0)
                        Write("--+");
                    else
                        Write("  +");
                }
                WriteLine();
            }
            WriteLine();
            WriteLine();
        }

        // Recursively draw a random vertical wall with a random opening, then
        // a random horizontal wall in the two areas, and repeat until width or
        // height of the area is only 1 row or column
        private void BuildWall(int cmin, int cmax, int rmin, int rmax, bool isVertical)
        {
            if (rmin == rmax || cmin == cmax)
                return;

            if (isVertical)
            {
                if (cmax > cmin)
                {
                    int c = rnd.Next(cmin, cmax);
                    int rHole = rnd.Next(rmin, rmax);
                    for (int r = rmin; r <= rmax; r++)
                        if (r != rHole)
                            Cells[r, c] |= right;
                    BuildWall(cmin, c, rmin, rmax, false);
                    BuildWall( c + 1, cmax, rmin, rmax, false);
                }
            }
            else
            {
                if (rmax > rmin)
                {
                    int r = rnd.Next(rmin, rmax);
                    int cHole = rnd.Next(cmin, cmax);
                    for (int c = cmin; c <= cmax; c++)
                        if (c != cHole)
                            Cells[r, c] |= bottom;
                    BuildWall(cmin, cmax, rmin, r, true);
                    BuildWall(cmin, cmax, r + 1, rmax, true);
                }
            }
        }
    }
}