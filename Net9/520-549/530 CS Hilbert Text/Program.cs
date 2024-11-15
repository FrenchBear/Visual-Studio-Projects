// CS530 Hilbert Text in C#
// Small project to compare languages
// C# with recursive iterator rendering of a Hilbert curve
//
// 2015-06-10   PV
// 2021-09-26   PV      VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13

using System;
using System.Collections.Generic;
using static System.Console;

namespace CS530;

internal class Program
{
    // All possible cells in output, based on blocks characters: horizointal, vertical, down right, ...
    private enum Blocks
    { hz, vt, dr, dl, ur, ul, xx };

    private static void Main(string[] args)
    {
        var depth = 4;                  // Level 1 is the first drawing as an upside down U

        // L-System definition for Hilbert curve
        var axiom = "X";
        var rules = new Dictionary<char, string> { { 'X', "-YF+XFX+FY-" }, { 'Y', "+XF-YFY-FX+" } };

        // In Out cell cencoding matrix
        // Row = cell entrance orientation, 0..3 and 4 when there is no actual entrance (1st cell)
        // Column = cell exit orientation, 0..3 and 4 for the last cell
        // In the table xx=invalid combination, otherwise represent a box character (see box dictionary)
        var io = new Blocks[,] {
            {Blocks.hz, Blocks.ul, Blocks.xx, Blocks.dl, Blocks.hz},
            {Blocks.dr, Blocks.vt, Blocks.dl, Blocks.xx, Blocks.vt},
            {Blocks.xx, Blocks.ur, Blocks.hz, Blocks.dr, Blocks.hz},
            {Blocks.ur, Blocks.xx, Blocks.ul, Blocks.vt, Blocks.vt},
            {Blocks.hz, Blocks.vt, Blocks.hz, Blocks.vt, Blocks.xx}
        };

        var side = (int)Math.Pow(2, depth);     // # side of output square grid
        var tc = new Blocks[side, side];  // Table of cells for output

        var a = 0;          // Current angular orientation: 0=East, 1=North, 2=West, 3=South
        var en = 4;         // Previous cell entrance, 4=no entrance (1st cell)
        var cx = 0;         // Current x
        var cy = side - 1;  // Current y

        // Scans the full instruchon chain returned by iterator and build output table tc
        foreach (var c in LSystemIterator(depth, axiom, rules))
        {
            switch (c)      // Only process drawing instructions - + and F
            {
                case '-':
                    a = (a + 1) % 4;
                    break;   // Rotate 90° anti clockwise = increment a (modulo 4)
                case '+':
                    a = (a + 3) % 4;
                    break;   // Rotate 90° clockwise = decrement a (modulo 4)
                case 'F':
                    // Compute next cell coordinates after drawing 1 unit in direction indicated by a
                    int nx = 0, ny = 0;
                    switch (a)
                    {
                        case 0:
                            nx = cx + 1;
                            ny = cy;
                            break;
                        case 1:
                            nx = cx;
                            ny = cy - 1;
                            break;
                        case 2:
                            nx = cx - 1;
                            ny = cy;
                            break;
                        case 3:
                            nx = cx;
                            ny = cy + 1;
                            break;
                    }
                    tc[cy, cx] = io[en, a];
                    cx = nx;
                    cy = ny;
                    en = a;
                    break;
            }
        }

        tc[cy, cx] = io[en, 4];          // Fill the last cell, since in the body we always fill previous cell

        // Unicode box characters
        var boxes = new Dictionary<Blocks, string> {
            { Blocks.hz, "\u2500\u2500"},   // Horizontal"
            { Blocks.vt, "\u2502 "},        // Vertical
            { Blocks.dr, "\u250c\u2500"},   // Down Right
            { Blocks.dl, "\u2510 "},        // Down Left
            { Blocks.ur, "\u2514\u2500"},   // Up Right
            { Blocks.ul, "\u2518 "}         // Up Left
        };

        // Draw curve
        for (var y = 0; y < side; y++)
        {
            for (var x = 0; x < side; x++)
                Write(boxes[tc[y, x]]);
            WriteLine();
        }
    }

    // Implementation of LSystemProcessor processing using recursive iterators
    // Uses almost no memory for large output: memory use is linear(depth)
    public static IEnumerable<char> LSystemIterator(int depth, IEnumerable<char> axiom, IDictionary<char, string> rules)
    {
        // Special case, depth==0, simply returns axiom
        if (depth == 0)
        {
            foreach (var c in axiom)
                yield return c;
            yield break;
        }

        // General case, apply transformation rules on depth-1 version
        foreach (var c in LSystemIterator(depth - 1, axiom, rules))
        {
            if (rules.TryGetValue(c, out string value))
            {
                foreach (var c2 in value)
                    yield return c2;
            }
            else
                yield return c;
        }
    }
}
