﻿// CS611 NewLaby
// Labyrinth using recursive dividing algorithm
// But the result is not as good as digging algorithm, since there are plenty visible long halls,
// and long walls are also visible (first divisions)
//
// 2017-01-26   PV      First version
// 2017-04-30   PV      Refactoring using Laby class
// 2021-09-26   PV      VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13

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

namespace NewLaby;

internal class Program
{
    private static void Main()
    {
        var rows = 15;
        var cols = 30;

        var l = new Laby(rows, cols, false);
        l.PrintLabyrinth();
    }
}

public class Laby
{
    private readonly int rows, cols;
    private readonly int[,] Cells;

    private readonly bool isDetailedBuild;

    // Bitmask for walls in Cells
    private const int right = 1;
    private const int bottom = 2;

    private static readonly Random rnd = new();

    public Laby(int rows, int cols, bool isDetailedBuild)
    {
        this.rows = rows;
        this.cols = cols;
        this.isDetailedBuild = isDetailedBuild;

        Cells = new int[rows + 1, cols + 1];

        // Build bordering walls
        for (var r = 1; r <= rows; r++)
        {
            Cells[r, 0] |= right;
            Cells[r, cols] |= right;
        }
        for (var c = 1; c <= cols; c++)
        {
            Cells[0, c] |= bottom;
            Cells[rows, c] |= bottom;
        }

        BuildWall(1, cols, 1, rows, true);

        // Open 1 cell on the 1st and last rows
        Cells[0, 1 + rnd.Next(cols)] &= ~bottom;
        Cells[rows, 1 + rnd.Next(cols)] &= ~bottom;
    }

    public void PrintLabyrinth()
    {
        for (var r = 0; r <= rows; r++)
        {
            if (r > 0)
            {
                for (var c = 0; c <= cols; c++)
                {
                    Write((Cells[r, c] & right) != 0 ? "  |" : "   ");
                }
                WriteLine();
            }
            for (var c = 0; c <= cols; c++)
            {
                Write((Cells[r, c] & bottom) != 0 ? "--+" : "  +");
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
                var c = rnd.Next(cmin, cmax);
                var rHole = rnd.Next(rmin, rmax);
                for (var r = rmin; r <= rmax; r++)
                {
                    if (r != rHole)
                        Cells[r, c] |= right;
                }

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
            {
                WriteLine("No vertical build since cmin==cmax");
            }
        }
        else
        {
            if (rmax > rmin)
            {
                var r = rnd.Next(rmin, rmax);
                var cHole = rnd.Next(cmin, cmax);
                for (var c = cmin; c <= cmax; c++)
                {
                    if (c != cHole)
                        Cells[r, c] |= bottom;
                }

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
            {
                WriteLine("No horizontal build since rmin==rmax");
            }
        }
    }
}
