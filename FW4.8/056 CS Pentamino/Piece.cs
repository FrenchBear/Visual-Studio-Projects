// 01/10/2006 PV VS 2005

using System;

internal class Piece
{
    public short hNumPiece;		// N� dans le jeu Katamino
    public char cPiece;			// Lettre
    public Carre55[] c;			// 8 transformations maxi
    public int iNbt;			// Nb de transformations

    //////////////////////////////////////////////////////////////////////
    // Construction/Destruction
    //////////////////////////////////////////////////////////////////////

    public Piece(short hNP, char cP,
                  int i00, int i01, int i02, int i03, int i04,
                  int i10, int i11, int i12, int i13, int i14,
                  int i20, int i21, int i22, int i23, int i24)
    {
        c = new Carre55[8];
        hNumPiece = hNP;
        cPiece = cP;
        c[0] = new Carre55(i00, i01, i02, i03, i04, i10, i11, i12, i13, i14, i20, i21, i22, i23, i24);
        iNbt = 1;
        if (i00 + i01 + i02 + i03 + i04 + i10 + i11 + i12 + i13 + i14 + i20 + i21 + i22 + i23 + i24 != 5)
            Console.WriteLine("Définition de la pi�ce {0} incorrecte", hNP);

        for (int i = 1; i < 8; i++)
        {
            Carre55 ct = c[0].Transformation(i);
            bool bDejaVu = false;

            for (int j = 0; j < iNbt; j++)
                if (Carre55.Egalite(c[j], ct))
                {
                    bDejaVu = true;
                    break;
                }
            if (!bDejaVu)
                c[iNbt++] = ct;
        }
    }

    // Traces
    public void Dessin() => Console.WriteLine("Pi�ce {0} {1} iNbt={2}", hNumPiece, cPiece, iNbt);
}