// Piece.cs
// Represent a pentamino over a 3x5 grid
//
// 2006-10-01   PV		VS 2005
// 2021-09-18	PV		VS2022, Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-05-01	PV		Constructor with bools, not int...
// 2024-11-15	PV		Net9 C#13
// 2026-01-19	PV		Net10 C#14

using System;
using System.Collections.Generic;
using System.Diagnostics;
using static System.Console;
using System.Linq;

internal class Piece
{
    public short Num;		                    // Number in Katamino game (not really useful here)
    public char Letter;	                        // Usual letter naming the piece
    public List<Carre55> Transformations = [];	// Up to 8 different transformations (rotations, symmetries)

    public Piece(short numPiece, char letterPiece,
                 bool b00, bool b01, bool b02, bool b03, bool b04,
                 bool b10, bool b11, bool b12, bool b13, bool b14,
                 bool b20, bool b21, bool b22, bool b23, bool b24,
                 int expectedTransformationsCount)
    {
        static int N(bool b) => Convert.ToInt32(b);

        if (N(b00) + N(b01) + N(b02) + N(b03) + N(b04) + N(b10) + N(b11) + N(b12) + N(b13) + N(b14) + N(b20) + N(b21) + N(b22) + N(b23) + N(b24) != 5)
            WriteLine($"Invalid definition of piece {letterPiece}({Num})");

        Num = numPiece;
        Letter = letterPiece;
        // Start with identity transformation
        var t0 = new Carre55(b00, b01, b02, b03, b04, b10, b11, b12, b13, b14, b20, b21, b22, b23, b24);
        Transformations.Add(t0);

        for (var i = 1; i < 8; i++)
        {
            var ct = t0.Transformation(i);

            // Check if a previous transformation is identical to current transformation
            var alreadySeen = Transformations.Any(t => Carre55.SameAs(t, ct));
            if (!alreadySeen)
                Transformations.Add(ct);
        }

        Debug.Assert(expectedTransformationsCount == Transformations.Count);
    }

    // For dev/debug traces
    public void Trace() => WriteLine($"Piece {Letter}({Num}) {Transformations.Count} transformation(s)");
}
