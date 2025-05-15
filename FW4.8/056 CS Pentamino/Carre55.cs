// 01/10/2006 PV VS 2005

using System;

internal class Carre55
{
    public bool[,] tMotif;
    public int lmax, cmax;		// Encombrement de la pièce
    public int iOffsetCol;		// Décalage de colonne pour occuper la cellule [0, 0]

    private bool B(int x) => x != 0;

    private Carre55()
    {
        tMotif = new bool[5, 5];
        for (int l = 0; l < 5; l++)
            for (int c = 0; c < 5; c++)
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
    {
        if (tMotif[0, 0])
            iOffsetCol = 0;
        else if (tMotif[0, 1])
            iOffsetCol = 1;
        else if (tMotif[0, 2])
            iOffsetCol = 2;
        else if (tMotif[0, 3])
            iOffsetCol = 3;
        else
            iOffsetCol = 4;
    }

    // Opérateur de comparaison
    public static bool Egalite(Carre55 l, Carre55 k) => l.lmax == k.lmax && l.cmax == k.cmax &&
        l.tMotif[0, 0] == k.tMotif[0, 0] && l.tMotif[0, 1] == k.tMotif[0, 1] && l.tMotif[0, 2] == k.tMotif[0, 2] && l.tMotif[0, 3] == k.tMotif[0, 3] && l.tMotif[0, 4] == k.tMotif[0, 4] &&
        l.tMotif[1, 0] == k.tMotif[1, 0] && l.tMotif[1, 1] == k.tMotif[1, 1] && l.tMotif[1, 2] == k.tMotif[1, 2] && l.tMotif[1, 3] == k.tMotif[1, 3] && l.tMotif[1, 4] == k.tMotif[1, 4] &&
        l.tMotif[2, 0] == k.tMotif[2, 0] && l.tMotif[2, 1] == k.tMotif[2, 1] && l.tMotif[2, 2] == k.tMotif[2, 2] && l.tMotif[2, 3] == k.tMotif[2, 3] && l.tMotif[2, 4] == k.tMotif[2, 4] &&
        l.tMotif[3, 0] == k.tMotif[3, 0] && l.tMotif[3, 1] == k.tMotif[3, 1] && l.tMotif[3, 2] == k.tMotif[3, 2] && l.tMotif[3, 3] == k.tMotif[3, 3] && l.tMotif[3, 4] == k.tMotif[3, 4] &&
        l.tMotif[4, 0] == k.tMotif[4, 0] && l.tMotif[4, 1] == k.tMotif[4, 1] && l.tMotif[4, 2] == k.tMotif[4, 2] && l.tMotif[4, 3] == k.tMotif[4, 3] && l.tMotif[4, 4] == k.tMotif[4, 4];

    // Transformations

    // Transformation de ligne
    private int TL(int iT, int l, int c)
    {
        switch (iT)
        {
            case 1: return c;
            case 2: return l < lmax ? lmax - 1 - l : l;
            case 3: return c < cmax ? cmax - 1 - c : c;
            case 4: return l;
            case 5: return c < cmax ? cmax - 1 - c : c;
            case 6: return l < lmax ? lmax - 1 - l : c;
            case 7: return c;
        }
        return l;	// cas 0
    }

    // Transformation de colonne
    private int TC(int iT, int l, int c)
    {
        switch (iT)
        {
            case 1: return l < lmax ? lmax - 1 - l : l;
            case 2: return c < cmax ? cmax - 1 - c : c;
            case 3: return l;
            case 4: return c < cmax ? cmax - 1 - c : c;
            case 5: return l < lmax ? lmax - 1 - l : l;
            case 6: return c;
            case 7: return l;
        }
        return c;	// cas 0
    }

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
        var ct = new Carre55();
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
            Console.WriteLine();
        }
        Console.WriteLine("Offset: {0}", iOffsetCol);
    }
}