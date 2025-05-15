// 01/10/2006   PV  VS 2005
// 2021-09-18   PV  VS2022, Net6

using System;
using static System.Console;

#pragma warning disable CA1822 // Mark members as static

internal class Carre55
{
    public bool[,] tMotif;
    public int lmax, cmax;		// Encombrement de la pièce
    public int iOffsetCol;		// Décalage de colonne pour occuper la cellule [0, 0]

    private bool B(int x) 
        => x != 0;

    private Carre55()
    {
        tMotif = new bool[5, 5];
        for (var l = 0; l < 5; l++)
            for (var c = 0; c < 5; c++)
                tMotif[l, c] = false;
        lmax = cmax = 0;
        iOffsetCol = 0;
    }

    public Carre55(int i00, int i01, int i02, int i03, int i04,
            int i10, int i11, int i12, int i13, int i14,
            int i20, int i21, int i22, int i23, int i24)
    {
        tMotif = new bool[5, 5];

        tMotif[0, 0] = B(i00); tMotif[0, 1] = B(i01); tMotif[0, 2] = B(i02); tMotif[0, 3] = B(i03); tMotif[0, 4] = B(i04);
        tMotif[1, 0] = B(i10); tMotif[1, 1] = B(i11); tMotif[1, 2] = B(i12); tMotif[1, 3] = B(i13); tMotif[1, 4] = B(i14);
        tMotif[2, 0] = B(i20); tMotif[2, 1] = B(i21); tMotif[2, 2] = B(i22); tMotif[2, 3] = B(i23); tMotif[2, 4] = B(i24);
        tMotif[3, 0] = B(0); tMotif[3, 1] = B(0); tMotif[3, 2] = B(0); tMotif[3, 3] = B(0); tMotif[3, 4] = B(0);
        tMotif[4, 0] = B(0); tMotif[4, 1] = B(0); tMotif[4, 2] = B(0); tMotif[4, 3] = B(0); tMotif[4, 4] = B(0);

        lmax = 3;
        if (i20 + i21 + i22 + i23 + i24 == 0) lmax = 2;
        if (i10 + i11 + i12 + i13 + i14 == 0) lmax = 1;

        cmax = 5;
        if (i04 + i14 + i24 == 0) cmax = 4;
        if (i03 + i13 + i23 == 0) cmax = 3;
        if (i02 + i12 + i22 == 0) cmax = 2;
        if (i01 + i11 + i21 == 0) cmax = 1;

        MkOffset();
    }

    // Détermine la propriété iOffsetCol, c'est à dire le nombre de colonnes qu'il
    // faut translater le dessin à gauche pour occuper la cellule [0, 0]
    private void MkOffset() 
        => iOffsetCol = tMotif[0, 0] ? 0 : tMotif[0, 1] ? 1 : tMotif[0, 2] ? 2 : tMotif[0, 3] ? 3 : 4;

    // Opérateur de comparaison
    public static bool Egalite(Carre55 l, Carre55 k) 
        => l.lmax == k.lmax && l.cmax == k.cmax &&
            l.tMotif[0, 0] == k.tMotif[0, 0] && l.tMotif[0, 1] == k.tMotif[0, 1] && l.tMotif[0, 2] == k.tMotif[0, 2] && l.tMotif[0, 3] == k.tMotif[0, 3] && l.tMotif[0, 4] == k.tMotif[0, 4] &&
            l.tMotif[1, 0] == k.tMotif[1, 0] && l.tMotif[1, 1] == k.tMotif[1, 1] && l.tMotif[1, 2] == k.tMotif[1, 2] && l.tMotif[1, 3] == k.tMotif[1, 3] && l.tMotif[1, 4] == k.tMotif[1, 4] &&
            l.tMotif[2, 0] == k.tMotif[2, 0] && l.tMotif[2, 1] == k.tMotif[2, 1] && l.tMotif[2, 2] == k.tMotif[2, 2] && l.tMotif[2, 3] == k.tMotif[2, 3] && l.tMotif[2, 4] == k.tMotif[2, 4] &&
            l.tMotif[3, 0] == k.tMotif[3, 0] && l.tMotif[3, 1] == k.tMotif[3, 1] && l.tMotif[3, 2] == k.tMotif[3, 2] && l.tMotif[3, 3] == k.tMotif[3, 3] && l.tMotif[3, 4] == k.tMotif[3, 4] &&
            l.tMotif[4, 0] == k.tMotif[4, 0] && l.tMotif[4, 1] == k.tMotif[4, 1] && l.tMotif[4, 2] == k.tMotif[4, 2] && l.tMotif[4, 3] == k.tMotif[4, 3] && l.tMotif[4, 4] == k.tMotif[4, 4];

    // Transformations

    // Transformation de ligne
    private int TL(int iT, int l, int c) 
        => iT switch
        {
            1 => c,
            2 => l < lmax ? lmax - 1 - l : l,
            3 => c < cmax ? cmax - 1 - c : c,
            4 => l,
            5 => c < cmax ? cmax - 1 - c : c,
            6 => l < lmax ? lmax - 1 - l : c,
            7 => c,
            _ => l,// cas 0
        };

    // Transformation de colonne
    private int TC(int iT, int l, int c) 
        => iT switch
        {
            1 => l < lmax ? lmax - 1 - l : l,
            2 => c < cmax ? cmax - 1 - c : c,
            3 => l,
            4 => c < cmax ? cmax - 1 - c : c,
            5 => l < lmax ? lmax - 1 - l : l,
            6 => c,
            7 => l,
            _ => c,// cas 0
        };

    // Transformations
    // 0: Identité
    // 1: 90°  sens horaire
    // 2: 180°
    // 3: 270° sens horaire
    // 4: miroir Hz
    // 5: miroir Hz + 90°  sens horaire
    // 6: miroir Hz + 180°
    // 7: miroir Hz + 270° sens horaire

    public Carre55 Transformation(int iT)
    {
        Carre55 ct = new();
        int l, c;

        for (l = 0; l < lmax; l++)
            for (c = 0; c < cmax; c++)
                ct.tMotif[TL(iT, l, c), TC(iT, l, c)] = tMotif[l, c];

        if ((iT & 1) != 0)
        {
            ct.lmax = cmax;
            ct.cmax = lmax;
        }
        else
        {
            ct.lmax = lmax;
            ct.cmax = cmax;
        }

        ct.MkOffset();

        return ct;
    }

    public void Dessin()
    {
        int l, c;

        for (l = 0; l < 5; l++)
        {
            for (c = 0; c < 5; c++)
                Console.Write(tMotif[l, c] ? "\xdb\xdb" : "\xfa\xfa");
            WriteLine();
        }
        WriteLine("Offset: {0}", iOffsetCol);
    }
}