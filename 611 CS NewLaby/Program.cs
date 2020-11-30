// CS611 NewLaby
// Labyrinth using recursive dividing algorithm
// But the result is not as good as digging algorithm, since there are plenty visible long halls,
// and long walls are also visible (first divisions)
//
// 2017-01-26   PV  First version
// 2017-04-30   PV  Refactoring using Laby class

using System;
using static System.Console;


/*
C:\DevelopmentGD\Visual Studio Projects\611 CS NewLaby\bin\Debug>NewLaby.exe
+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+  +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
|                                         |  |                                                     |              |     |
+--+--+--+--+--+--+--+--+--+  +--+--+--+--+  +--+  +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+  +--+  +  +
|                                            |                 |                                   |           |  |  |  |
+  +--+--+--+--+--+--+--+--+  +--+--+--+--+  +  +--+--+--+--+  +--+--+--+  +--+--+--+--+--+--+  +--+--+  +--+--+  +  +  +
|           |                             |                 |                                |                    |  |  |
+--+--+--+--+--+--+  +--+--+--+--+--+--+--+--+--+  +--+--+--+--+--+--+--+--+--+--+  +--+--+--+--+--+  +--+  +--+  +  +  +
|              |  |                          |                 |                                   |     |     |  |  |  |
+--+  +--+--+--+  +  +--+--+--+--+--+--+  +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+  +--+--+--+--+--+--+--+  +  +
|                 |           |              |        |                                                           |  |  |
+--+  +--+  +--+  +  +--+--+--+--+--+--+--+--+  +  +--+  +--+--+--+  +--+--+--+  +--+--+--+--+--+  +--+--+--+--+--+  +--+
|        |     |  |                    |     |  |     |        |        |                 |                       |  |  |
+--+--+  +--+--+--+--+--+  +--+--+--+--+  +  +  +--+--+--+  +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+  +--+--+  +  +
|     |           |  |                    |  |                          |                             |           |  |  |
+  +  +--+  +--+--+  +  +--+--+--+--+--+  +--+  +--+  +  +--+--+--+  +--+  +--+--+--+--+--+  +--+--+--+  +--+  +--+  +  +
|  |                                   |     |     |  |  |              |  |                             |        |  |  |
+  +--+  +--+  +--+  +--+  +--+--+  +--+  +  +--+  +--+--+--+--+--+--+--+--+--+--+  +--+--+--+--+--+--+  +--+--+--+  +  +
|     |  |        |  |           |     |  |  |                          |                             |           |  |  |
+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+  +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+  +  +
|  |                                   |                 |  |                 |                       |           |  |  |
+  +  +  +  +--+--+--+--+--+--+--+  +--+--+  +--+--+  +--+  +--+--+--+--+  +--+--+--+  +--+--+--+--+--+  +--+--+  +  +  +
|  |  |  |              |        |     |           |     |              |  |  |     |                 |        |  |  |  |
+  +  +--+--+--+  +--+--+  +--+--+  +--+--+  +--+--+--+--+  +  +--+  +--+  +  +  +--+  +--+--+  +--+--+--+  +--+--+  +  +
|     |                 |        |        |              |  |     |     |  |  |  |  |        |        |  |     |  |  |  |
+  +--+--+  +--+--+--+--+  +  +  +  +  +  +  +  +--+--+--+  +--+--+  +--+  +  +  +  +--+--+  +--+--+--+  +  +--+  +  +  +
|  |                    |  |  |     |  |     |           |  |  |  |  |  |     |  |  |                             |  |  |
+--+--+--+--+--+--+  +--+  +--+  +  +  +  +--+--+  +--+--+  +  +  +  +  +  +  +  +  +--+  +--+--+  +  +  +  +  +  +  +  +
|  |                    |     |  |  |  |  |              |  |           |  |  |                 |  |  |  |  |  |  |  |  |
+  +  +--+--+--+--+  +--+  +--+--+--+--+--+--+--+--+--+--+  +  +  +  +  +  +  +  +  +--+  +--+  +  +--+  +--+  +--+  +  +
|  |        |           |                       |           |  |  |  |     |  |  |  |        |  |     |  |        |  |  |
+  +--+  +--+--+--+--+--+--+  +--+--+--+--+  +--+  +--+  +  +  +--+  +  +  +--+--+--+--+--+--+  +--+--+--+--+--+--+  +  +
|  |     |              |        |              |     |  |  |     |  |  |     |                                   |  |  |
+  +  +  +  +--+--+  +--+--+--+--+  +--+--+--+--+  +--+--+  +--+  +--+  +  +  +  +--+--+  +--+--+--+  +--+--+--+--+  +  +
|     |     |           |                                |  |        |  |  |  |        |     |                 |  |  |  |
+  +  +--+--+--+  +--+--+  +  +--+--+--+--+--+--+  +  +--+--+  +--+--+--+--+--+--+--+  +--+--+  +--+--+--+  +--+  +  +  +
|  |     |              |  |                    |  |     |                                   |           |        |  |  |
+--+--+--+--+--+--+--+--+--+--+--+  +--+--+--+--+--+--+--+  +--+--+--+  +--+--+--+  +--+--+  +--+--+--+--+  +--+  +  +  +
|                                                        |        |           |           |  |                 |        |
+--+--+--+--+--+--+--+--+--+--+  +--+--+--+--+--+--+  +--+--+--+--+--+--+  +--+--+--+--+--+--+--+--+--+--+--+--+--+  +  +
|                                                  |     |                                                        |  |  |
+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+  +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+

Compare to digging algorithm:
C:\DevelopmentGD\Visual Studio Projects\612 CPP Laby\Debug>"612 CPP Laby.exe" -a -m -r 20 -c 40
rows: 20, cols: 40
+--+--+--+--+--+--+--+--+--+  +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
|  |        |        |                 |           |     |     |     |  |     |                    |     |        |     |
+  +  +--+  +  +--+  +  +  +--+--+--+  +  +  +--+  +  +  +--+  +  +  +  +  +  +  +--+  +--+--+--+  +  +--+  +  +  +  +--+
|  |  |  |     |  |  |  |  |        |     |  |  |     |     |  |  |        |     |  |  |  |        |        |  |        |
+  +  +  +--+--+  +  +--+  +  +  +--+--+--+  +  +--+  +--+  +  +  +--+--+--+--+--+  +  +  +  +--+--+  +--+--+  +--+--+  +
|     |           |     |  |  |              |        |        |  |     |        |     |  |     |     |     |     |     |
+  +--+--+--+  +--+--+  +  +  +--+--+--+--+--+  +--+--+  +--+--+  +--+  +  +--+  +--+--+  +--+  +  +--+--+  +--+  +  +--+
|  |        |  |     |     |     |  |     |  |  |     |  |     |        |     |              |     |     |     |  |     |
+  +  +--+  +  +  +--+--+--+--+  +  +  +  +  +  +  +  +--+  +  +--+--+--+  +--+--+--+  +  +  +--+--+  +  +--+  +  +  +  +
|     |  |     |     |        |  |  |  |     |  |  |        |           |  |     |     |  |  |     |  |        |  |  |  |
+--+--+  +--+  +--+  +  +--+--+  +  +  +--+  +  +  +--+--+  +--+--+--+  +  +  +--+  +--+--+  +  +  +  +  +--+--+  +  +  +
|     |     |        |        |        |  |  |  |        |  |        |  |  |        |  |     |  |     |           |  |  |
+  +  +  +  +--+--+  +--+--+  +--+--+--+  +  +--+--+  +  +--+  +--+  +--+  +  +--+--+  +  +  +  +--+  +--+--+--+--+  +  +
|  |     |        |  |                    |     |  |  |  |     |  |        |  |        |  |  |  |  |  |     |     |  |  |
+  +--+--+--+--+  +  +--+--+  +--+--+--+--+--+  +  +  +  +  +--+  +--+--+  +  +--+--+  +  +--+  +  +  +  +--+  +  +  +--+
|        |     |  |  |     |  |        |        |  |  |     |        |  |  |  |     |              |  |  |     |  |     |
+--+--+  +--+  +  +  +  +  +  +  +--+  +  +--+--+  +  +--+--+--+--+  +  +  +  +  +  +--+--+--+--+--+  +  +  +--+  +--+  +
|     |     |     |     |     |  |     |     |     |     |        |        |     |     |     |     |     |  |  |     |  |
+  +  +--+  +--+--+--+--+--+  +  +--+--+--+  +--+  +--+  +  +--+  +--+--+--+--+  +--+  +--+  +  +  +--+--+  +  +--+  +  +
|  |     |  |  |     |     |     |     |  |              |     |              |     |        |  |  |     |  |     |  |  |
+  +--+  +  +  +  +  +--+  +--+--+  +  +  +--+--+--+  +--+--+  +--+--+--+--+  +--+  +--+--+--+  +  +--+  +  +--+  +  +  +
|  |     |  |     |        |     |  |     |     |           |  |     |     |  |  |        |     |  |              |  |  |
+  +  +--+  +--+  +--+--+  +  +  +  +  +--+  +  +  +--+--+  +  +  +  +  +  +  +  +--+--+  +  +--+  +  +--+--+  +  +  +  +
|  |     |     |  |           |  |  |        |  |  |     |  |     |     |  |  |  |        |     |  |     |     |  |     |
+  +--+  +--+  +--+  +--+--+--+  +  +--+--+--+--+  +  +  +--+--+--+--+--+--+  +  +  +--+--+--+  +--+--+  +  +--+  +--+--+
|  |  |     |     |     |     |  |                 |  |     |     |     |     |  |  |        |        |  |     |     |  |
+  +  +--+  +  +  +--+  +--+  +  +--+--+--+  +--+--+  +--+  +--+  +  +  +  +  +  +  +  +--+  +--+--+  +  +--+--+--+  +  +
|  |  |        |     |        |  |  |        |        |           |  |     |     |  |     |           |           |     |
+  +  +  +  +--+--+  +--+--+--+  +  +  +--+--+  +--+  +--+--+--+--+--+--+  +--+--+  +  +--+--+--+--+--+  +--+  +--+--+  +
|  |     |        |     |        |     |        |  |        |           |  |     |  |           |        |  |        |  |
+  +--+  +--+--+--+--+  +  +--+--+--+  +  +  +--+  +--+--+  +--+--+--+  +  +  +  +--+--+--+--+  +  +  +--+  +--+--+  +  +
|     |     |              |           |  |           |           |     |     |  |     |     |     |  |     |     |  |  |
+--+  +--+--+  +--+--+--+--+--+--+--+--+  +--+--+--+  +  +--+--+  +  +  +--+--+  +  +--+  +  +--+--+--+  +--+  +  +  +  +
|  |  |     |  |  |     |              |  |     |     |  |     |     |     |  |  |        |                 |  |     |  |
+  +  +  +  +  +  +  +  +  +--+--+--+  +--+  +--+  +--+--+  +  +--+--+  +  +  +  +  +--+  +  +--+--+--+--+  +--+--+--+  +
|  |  |  |  |        |     |                 |     |        |  |        |  |     |  |     |     |        |  |           |
+  +  +  +--+--+--+--+  +--+--+--+--+--+--+--+  +--+  +--+--+  +--+--+--+  +  +  +  +--+--+  +  +  +--+  +  +  +--+--+--+
|  |  |     |        |  |     |              |  |     |     |           |     |  |  |     |  |  |  |  |  |     |  |     |
+  +  +  +  +  +--+  +  +  +  +--+  +--+--+  +  +  +--+  +  +--+--+  +  +--+--+  +--+  +  +  +  +  +  +  +  +--+  +  +  +
|        |     |     |     |              |        |     |           |        |        |     |     |     |           |  |
+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+  +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+

*/


namespace NewLaby
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = 15;
            int cols = 30;

            var l = new Laby(rows, cols, false);
            l.PrintLabyrinth();

            Console.WriteLine();
            Console.Write("(Pause)");
            Console.ReadLine();
        }
    }

    public class Laby
    {
        private readonly int rows, cols;
        private readonly int[,] Cells;

        private readonly bool isDetailedBuild;

        // Bitmask for walls in Cells
        const int right = 1;
        const int bottom = 2;

        private static readonly Random rnd = new Random();


        public Laby(int rows, int cols, bool isDetailedBuild)
        {
            this.rows = rows;
            this.cols = cols;
            this.isDetailedBuild = isDetailedBuild;

            for (int i = 0; i < 1; i++)
            {
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

        }

        public void PrintLabyrinth()
        {
            for (int r = 0; r <= rows; r++)
            {
                if (r > 0)
                {
                    for (int c = 0; c <= cols; c++)
                    {
                        if ((Cells[r, c] & right) != 0)
                            Write("  |");
                        else
                            Write("   ");
                    }
                    WriteLine();
                }
                for (int c = 0; c <= cols; c++)
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
            if (isDetailedBuild)
                WriteLine($"BuildWall cmin={cmin}, cmax={cmax}, rmin={rmin}, rmax={rmax}, " + (isVertical ? "Vertical" : "Horizontal"));

            if (rmin == rmax || cmin == cmax)
            {
                if (isDetailedBuild)
                    WriteLine("rmin==rmax or cmin==cmax, nothing to do\r\n");
                return;
            }

            if (isVertical)
            {
                if (cmax > cmin)
                {
                    int c = rnd.Next(cmin, cmax);
                    int rHole = rnd.Next(rmin, rmax);
                    for (int r = rmin; r <= rmax; r++)
                        if (r != rHole)
                            Cells[r, c] |= right;
                    if (isDetailedBuild)
                    {
                        WriteLine($"Vertical wall at c={c} between rows {rmin} and {rmax} with a hole at r={rHole}");
                        PrintLabyrinth();
                    }
                    BuildWall(cmin, c, rmin, rmax, false);
                    BuildWall(c + 1, cmax, rmin, rmax, false);
                }
                else
                if (isDetailedBuild)
                    WriteLine("No vertical build since cmin==cmax");
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
                    if (isDetailedBuild)
                    {
                        WriteLine($"Horizontal wall at r={r} between cols {cmin} and {cmax} with a hole at c={cHole}");
                        PrintLabyrinth();
                    }
                    BuildWall(cmin, cmax, rmin, r, true);
                    BuildWall(cmin, cmax, r + 1, rmax, true);
                }
                else
                if (isDetailedBuild)
                    WriteLine("No horizontal build since rmin==rmax");
            }
        }
    }
}
