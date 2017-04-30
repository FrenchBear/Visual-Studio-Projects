// CS530 Hilbert Text in C#
// Small project to compare languages
// C# with recursive iterator rendering of a Hilbert curve
// 2015-06-10   PV

using System;
using System.Collections.Generic;

namespace CS530
{
    class Program
    {
        // All possible cells in output, based on blocks characters: horizointal, vertical, down right, ...
        enum blocks { hz, vt, dr, dl, ur, ul, xx };

        static void Main(string[] args)
        {
            int depth = 4;                  // Level 1 is the first drawing as an upside down U

            // L-System definition for Hilbert curve
            string axiom = "X";
            var rules = new Dictionary<char, string> { { 'X', "-YF+XFX+FY-" }, { 'Y', "+XF-YFY-FX+" } };

            // In Out cell cencoding matrix
            // Row = cell entrance orientation, 0..3 and 4 when there is no actual entrance (1st cell)
            // Column = cell exit orientation, 0..3 and 4 for the last cell
            // In the table xx=invalid combination, otherwise represent a box character (see box dictionary)
            blocks[,] io = new blocks[,] {
                {blocks.hz, blocks.ul, blocks.xx, blocks.dl, blocks.hz},
                {blocks.dr, blocks.vt, blocks.dl, blocks.xx, blocks.vt},
                {blocks.xx, blocks.ur, blocks.hz, blocks.dr, blocks.hz},
                {blocks.ur, blocks.xx, blocks.ul, blocks.vt, blocks.vt},
                {blocks.hz, blocks.vt, blocks.hz, blocks.vt, blocks.xx}
            };

            int side = (int)Math.Pow(2, depth);     // # side of output square grid
            blocks[,] tc = new blocks[side, side];  // Table of cells for output

            int a = 0;          // Current angular orientation: 0=East, 1=North, 2=West, 3=South
            int en = 4;         // Previous cell entrance, 4=no entrance (1st cell)
            int cx = 0;         // Current x
            int cy = side - 1;  // Current y

            // Scans the full instruchon chain returned by iterator and build output table tc
            foreach (char c in LSystemIterator(depth, axiom, rules))
                switch (c)      // Only process drawing instructions - + and F
                {
                    case '-': a = (a + 1) % 4; break;   // Rotate 90° anti clockwise = increment a (modulo 4)
                    case '+': a = (a + 3) % 4; break;   // Rotate 90° clockwise = decrement a (modulo 4)
                    case 'F':
                        // Compute next cell coordinates after drawing 1 unit in direction indicated by a
                        int nx = 0, ny = 0;
                        switch (a)
                        {
                            case 0: nx = cx + 1; ny = cy; break;
                            case 1: nx = cx; ny = cy - 1; break;
                            case 2: nx = cx - 1; ny = cy; break;
                            case 3: nx = cx; ny = cy + 1; break;
                        }
                        tc[cy, cx] = io[en, a];
                        cx = nx; cy = ny;
                        en = a;
                        break;
                }
            tc[cy, cx] = io[en, 4];          // Fill the last cell, since in the body we always fill previous cell

            // Unicode box characters
            var boxes = new Dictionary<blocks, string> {
                { blocks.hz, "\u2500\u2500"},   // Horizontal"
                { blocks.vt, "\u2502 "},        // Vertical
                { blocks.dr, "\u250c\u2500"},   // Down Right
                { blocks.dl, "\u2510 "},        // Down Left
                { blocks.ur, "\u2514\u2500"},   // Up Right
                { blocks.ul, "\u2518 "}         // Up Left
            };

            // Draw curve
            for (int y = 0; y < side; y++)
            {
                for (int x = 0; x < side; x++)
                    Console.Write(boxes[tc[y, x]]);
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.Write("(Pause)");
            Console.ReadLine();
        }




        // Implementation of LSystemProcessor processing using recursive iterators
        // Uses almost no memory for large output: memory use is linear(depth)
        public static IEnumerable<char> LSystemIterator(int depth, IEnumerable<char> axiom, IDictionary<char, string> rules)
        {
            // Special case, depth==0, simply returns axiom
            if (depth == 0)
            {
                foreach (char c in axiom)
                    yield return c;
                yield break;
            }

            // General case, apply transformation rules on depth-1 version
            foreach (char c in LSystemIterator(depth - 1, axiom, rules))
                if (rules.ContainsKey(c))
                    foreach (char c2 in rules[c])
                        yield return c2;
                else
                    yield return c;
        }
    }
}
