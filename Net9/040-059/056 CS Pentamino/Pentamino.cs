// Pentamino.cs
// Solver for paving a rectangle with pentaminos
//
// 1998-12-26	PV		Original C++ version
// 2001-08-11	PV		C# rewrite
// 2006-10-01	PV		VS2005
// 2012-02-25	PV		VS2010
// 2021-09-18	PV		VS2022, Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-05-01   PV      Use Span<byte> and stackalloc instead of class Jeu for better perf (Release: 1.29s Span, 1.84s class, 1.70s array)
// 2024-11-15	PV		Net9 C#13

using System;
using System.Diagnostics;
using static System.Console;

internal class Pentamino
{
    private const int LINES = 12;               // Number of lines of the surface to pave
    private const int COLS = 5;                 // Number of columns of the surface to pave
    private const int PIECES = 12;

    private const int MAXSOLUTION = 5000;       // Limit search time if needed

    private static int nbSolutions; //= 0;
    private static int nbPavingCalls; //= 0;

    // Table of pentaminos to use for the problem
    private static Piece[] lp;

    private static void Main(string[] args)
    {
        const bool X = true;
        const bool o = false;

        // Prepare pieces
        Piece P1 = new(1, 'I', X, X, X, X, X, o, o, o, o, o, o, o, o, o, o, 2);
        Piece P2 = new(2, 'L', X, X, X, X, o, o, o, o, X, o, o, o, o, o, o, 8);
        Piece P3 = new(3, 'Y', X, X, X, X, o, o, o, X, o, o, o, o, o, o, o, 8);
        Piece P4 = new(4, 'N', X, X, X, o, o, o, o, X, X, o, o, o, o, o, o, 8);
        Piece P5 = new(5, 'V', X, X, X, o, o, X, o, o, o, o, X, o, o, o, o, 4);
        Piece P6 = new(6, 'P', X, X, X, o, o, X, X, o, o, o, o, o, o, o, o, 8);
        Piece P7 = new(7, 'U', X, X, X, o, o, X, o, X, o, o, o, o, o, o, o, 4);
        Piece P8 = new(8, 'Z', X, X, o, o, o, o, X, o, o, o, o, X, X, o, o, 4);
        Piece P9 = new(9, 'F', X, X, o, o, o, o, X, X, o, o, o, X, o, o, o, 8);
        Piece P10 = new(10, 'T', X, X, X, o, o, o, X, o, o, o, o, X, o, o, o, 4);
        Piece P11 = new(11, 'W', X, X, o, o, o, o, X, X, o, o, o, o, X, o, o, 4);
        Piece P12 = new(12, 'X', o, X, o, o, o, X, X, X, o, o, o, X, o, o, o, 1);

        //P1.Trace();
        //P2.Trace();
        //P3.Trace();
        //P4.Trace();
        //P5.Trace();
        //P6.Trace();
        //P7.Trace();
        //P8.Trace();
        //P9.Trace();
        //P10.Trace();
        //P11.Trace();
        //P12.Trace();

        // Pieces to use, allowing easi indexed access (order is not meaningful)
        lp = [P2, P3, P6, P11, P8, P4, P5, P10, P9, P1, P7, P12];

        // Rectangle for paving, zero-initialized by default (https://stackoverflow.com/questions/8679052/initialization-of-memory-allocated-with-stackalloc)
        Span<byte> rect = stackalloc byte[LINES * COLS];

        // Paving
        var sw = Stopwatch.StartNew();
        Paving(0, 0, rect, (1 << PIECES) - 1);

        WriteLine($"Duration {sw.ElapsedMilliseconds / 1000.0:f3}s");
        WriteLine($"{nbSolutions} solutions");
        WriteLine($"{nbPavingCalls} calls to Paving()");
    }

    private static void Paving(int lstart, int cstart, Span<byte> rect, int piecesMask)
    {
        if (nbSolutions > MAXSOLUTION)
            return;

        nbPavingCalls++;

        // We are looking for an empty square to cover, from left to right, from top to bottom
        int l, c = 0;
        var found = false;
        for (l = 0; l < LINES; l++)
        {
            for (c = 0; c < COLS; c++)
            {
                if (l == 0 && c == 0)	  // Optimization, slart from last empty square found
                {
                    l = lstart;
                    c = cstart;
                }

                if (rect[l * COLS + c] == 0)
                {
                    found = true;
                    break;
                }
            }
            if (found)
                break;
        }

        // Not supposed to happen...
        if (!found)
            Debugger.Break();

        // Allocate one rect buffer for recursive call outside the loop, otherwise it will
        // allocate tons of memory, only released when the function exits.
        // It may do useless allocations if current call is a dead end, but it's supposed to be lightweight
        Span<byte> nextRect = stackalloc byte[LINES * COLS];

        // We search among all the pieces that remain for a piece to cover the empty square
        for (int i = 0; i < PIECES; i++)
            if ((piecesMask & (1 << i)) != 0)
                foreach (var ca in lp[i].Transformations)
                {
                    if (c + ca.Cmax - ca.OffsetCol > COLS ||	// Too wide
                        l + ca.Lmax > LINES ||				    // Too high
                        c < ca.OffsetCol)					    // Must be shifted too much on the lest
                        continue;

                    int l2, c2;
                    var collision = false;
                    for (l2 = 0; l2 < ca.Lmax; l2++)
                    {
                        for (c2 = 0; c2 < ca.Cmax; c2++)
                            if (ca.Motif[l2, c2] && rect[(l + l2) * COLS + c + c2 - ca.OffsetCol] != 0)  // Square already occupied
                            {
                                collision = true;
                                break;
                            }
                        if (collision)
                            break;
                    }

                    // If there is a collision for current piece current transformation, no need to proceed in depth calling Pavage again
                    // Just continue to next piece/transformation, that's it
                    if (!collision)
                    {
                        // Piece is Ok! Let's place it
                        rect.CopyTo(nextRect);

                        for (l2 = 0; l2 < ca.Lmax; l2++)
                            for (c2 = 0; c2 < ca.Cmax; c2++)
                                if (ca.Motif[l2, c2])
                                    nextRect[(l + l2) * COLS + c + c2 - ca.OffsetCol] = (byte)(i + 1);

                        // If there are no more pieces left, we found a solution!
                        var nextMask = piecesMask & ~(1 << i);
                        if (nextMask == 0)
                        {
                            nbSolutions++;
                            return;
                        }

                        // Continue recursively with remaining pieces up to a solution or a dead end
                        Paving(l, c, nextRect, nextMask);
                    }
                }
    }
}
