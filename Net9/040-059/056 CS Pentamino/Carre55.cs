// Carre55.cs
// Represent a transformation (rotation, symmetry) of a pentamino over a 5x5 grid
//
// 2006-10-01   PV		VS 2005
// 2021-09-18	PV		VS2022, Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-04-30   PV      Use bools instead of ints; Simplified TL and TC (no need for ?:, result is valid in all cases)
// 2024-11-15	PV		Net9 C#13

using static System.Console;

#pragma warning disable IDE0045 // Convert to conditional expression

internal sealed class Carre55
{
    public bool[,] Motif;
    public int Lmax, Cmax;		// Piece bounding dimensions (rows/columns count), each 1..5
    public int OffsetCol;		// Décalage de colonne pour occuper la cellule [0, 0]

    private Carre55()
    {
        Motif = new bool[5, 5];
        for (var l = 0; l < 5; l++)
            for (var c = 0; c < 5; c++)
                Motif[l, c] = false;
        Lmax = Cmax = 0;
        OffsetCol = 0;
    }

    public Carre55(bool b00, bool b01, bool b02, bool b03, bool b04,
                   bool b10, bool b11, bool b12, bool b13, bool b14,
                   bool b20, bool b21, bool b22, bool b23, bool b24)
    {
        Motif = new bool[5, 5];

        Motif[0, 0] = b00;
        Motif[0, 1] = b01;
        Motif[0, 2] = b02;
        Motif[0, 3] = b03;
        Motif[0, 4] = b04;
        Motif[1, 0] = b10;
        Motif[1, 1] = b11;
        Motif[1, 2] = b12;
        Motif[1, 3] = b13;
        Motif[1, 4] = b14;
        Motif[2, 0] = b20;
        Motif[2, 1] = b21;
        Motif[2, 2] = b22;
        Motif[2, 3] = b23;
        Motif[2, 4] = b24;
        Motif[3, 0] = false;
        Motif[3, 1] = false;
        Motif[3, 2] = false;
        Motif[3, 3] = false;
        Motif[3, 4] = false;
        Motif[4, 0] = false;
        Motif[4, 1] = false;
        Motif[4, 2] = false;
        Motif[4, 3] = false;
        Motif[4, 4] = false;

        if (!(b10 || b11 || b12 || b13 || b14))
            Lmax = 1;
        else if (!(b20 || b21 || b22 || b23 || b24))
            Lmax = 2;
        else
            Lmax = 3;

        if (!(b01 || b11 || b21))
            Cmax = 1;
        else if (!(b02 || b12 || b22))
            Cmax = 2;
        else if (!(b03 || b13 || b23))
            Cmax = 3;
        else if (!(b04 || b14 || b24))
            Cmax = 4;
        else
            Cmax = 5;

        MkOffset();
    }

    // Determine the iOffsetCol property, i.e. the number of columns it
    // must translate the drawing to the left to occupy the cell [0, 0]
    private void MkOffset()
        => OffsetCol = Motif[0, 0] ? 0 : Motif[0, 1] ? 1 : Motif[0, 2] ? 2 : Motif[0, 3] ? 3 : 4;

    // Comparison operator
    // Simple static method is easier than operator == that requires operator != and override GetHashCode
    // and override Equals(object), none of this needed here
    public static bool SameAs(Carre55 l, Carre55 r)
        => l.Lmax == r.Lmax && l.Cmax == r.Cmax &&
            l.Motif[0, 0] == r.Motif[0, 0] && l.Motif[0, 1] == r.Motif[0, 1] && l.Motif[0, 2] == r.Motif[0, 2] && l.Motif[0, 3] == r.Motif[0, 3] && l.Motif[0, 4] == r.Motif[0, 4] &&
            l.Motif[1, 0] == r.Motif[1, 0] && l.Motif[1, 1] == r.Motif[1, 1] && l.Motif[1, 2] == r.Motif[1, 2] && l.Motif[1, 3] == r.Motif[1, 3] && l.Motif[1, 4] == r.Motif[1, 4] &&
            l.Motif[2, 0] == r.Motif[2, 0] && l.Motif[2, 1] == r.Motif[2, 1] && l.Motif[2, 2] == r.Motif[2, 2] && l.Motif[2, 3] == r.Motif[2, 3] && l.Motif[2, 4] == r.Motif[2, 4] &&
            l.Motif[3, 0] == r.Motif[3, 0] && l.Motif[3, 1] == r.Motif[3, 1] && l.Motif[3, 2] == r.Motif[3, 2] && l.Motif[3, 3] == r.Motif[3, 3] && l.Motif[3, 4] == r.Motif[3, 4] &&
            l.Motif[4, 0] == r.Motif[4, 0] && l.Motif[4, 1] == r.Motif[4, 1] && l.Motif[4, 2] == r.Motif[4, 2] && l.Motif[4, 3] == r.Motif[4, 3] && l.Motif[4, 4] == r.Motif[4, 4];

    // Transformations

    // Line transform
    private int TL(int tr, int l, int c)
        => tr switch
        {
            1 => c,
            2 => Lmax - 1 - l,
            3 => Cmax - 1 - c,
            4 => l,
            5 => Cmax - 1 - c,
            6 => Lmax - 1 - l,
            7 => c,
            _ => l,// cas 0
        };

    // Column transform
    private int TC(int tr, int l, int c)
        => tr switch
        {
            1 => Lmax - 1 - l,
            2 => Cmax - 1 - c,
            3 => l,
            4 => Cmax - 1 - c,
            5 => Lmax - 1 - l,
            6 => c,
            7 => l,
            _ => c,// cas 0
        };

    // Transformations
    // 0: Identity
    // 1: 90°  clockwise
    // 2: 180°
    // 3: 270° clockwise
    // 4: mirror Hz
    // 5: mirror Hz + 90°  clockwise
    // 6: mirror Hz + 180°
    // 7: mirror Hz + 270° clockwise

    public Carre55 Transformation(int tr)
    {
        Carre55 ct = new();
        int l, c;

        for (l = 0; l < Lmax; l++)
            for (c = 0; c < Cmax; c++)
                ct.Motif[TL(tr, l, c), TC(tr, l, c)] = Motif[l, c];

        if ((tr & 1) != 0)
            (ct.Lmax, ct.Cmax) = (Cmax, Lmax);
        else
            (ct.Lmax, ct.Cmax) = (Lmax, Cmax);

        ct.MkOffset();

        return ct;
    }

    // For dev/debug traces
    public void Trace(char lp, int tr)
    {
        WriteLine("-------------------------");
        WriteLine($"Piece {lp}, transformation {tr}");

        int l, c;

        for (l = 0; l < 5; l++)
        {
            for (c = 0; c < 5; c++)
                Write(Motif[l, c] ? "##" : ". ");
            WriteLine();
        }
        WriteLine($"Lmax={Lmax} Cmax={Cmax} Offset={OffsetCol}");
    }
}
