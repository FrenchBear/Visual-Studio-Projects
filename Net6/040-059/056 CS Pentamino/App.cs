// pentamino.cpp
// Résolution de problèmes de pentaminos (pavage)
//
// 1998-12-26   PV  Version originale en C++
// 2001-08-11   PV  Réécriture en C#
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010
// 2021-09-18   PV  VS2022, Net6

using System;
using static System.Console;

internal class Pentamino
{
    private const int MAXLIG = 12;
    private const int MAXCOL = 5;
    private const int MAXPIECE = 12;

    private const int MAXSOLUTION = 1000;

    private static int iNbSol = 0;
    private static int iNbAppelPavage = 0;

    // Plan de jeu
    private class Jeu
    {
        private readonly byte[,] grille;

        public Jeu() => grille = new byte[MAXLIG, MAXCOL];

        public Jeu(Jeu j) => grille = (byte[,])j.grille.Clone();

        public byte this[int l, int c]
        {
            get => grille[l, c];
            set => grille[l, c] = value;
        }
    }

    // Tableau des pentaminos à utiliser pour le problème
    private static Piece[] tP;

    private static void Main(string[] args)
    {
        // Préparation des pièces
        Piece P1 = new(1, 'I', 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        Piece P2 = new(2, 'L', 1, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0);
        Piece P3 = new(3, 'Y', 1, 1, 1, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0);
        Piece P4 = new(4, 'N', 1, 1, 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0);
        Piece P5 = new(5, 'V', 1, 1, 1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0);
        Piece P6 = new(6, 'P', 1, 1, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0);
        Piece P7 = new(7, 'U', 1, 1, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0);
        Piece P8 = new(8, 'Z', 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 0, 0);
        Piece P9 = new(9, 'F', 1, 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 0, 0);
        Piece P10 = new(10, 'T', 1, 1, 1, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0);
        Piece P11 = new(11, 'W', 1, 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 0, 0);
        Piece P12 = new(12, 'X', 0, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 0, 0, 0);

        /*
        P1.Dessin();
        P2.Dessin();
        P3.Dessin();
        P4.Dessin();
        P5.Dessin();
        P6.Dessin();
        P7.Dessin();
        P8.Dessin();
        P9.Dessin();
        P10.Dessin();
        P11.Dessin();
        P12.Dessin();
        _ = Console.ReadLine();
        */

        /*
            if (MAXLIG*MAXCOL!=5*MAXPIECE)
            {
              WriteLine("Constantes MAXLIG/MAXCOL/MAXPIECE incohérentes !");
              return;
            }
        */

        // Pieces a utiliser
        tP = new Piece[12];

        tP[0] = P2;
        tP[1] = P3;
        tP[2] = P6;
        tP[3] = P11;
        tP[4] = P8;
        tP[5] = P4;
        tP[6] = P5;
        tP[7] = P10;
        tP[8] = P9;
        tP[9] = P1;
        tP[10] = P7;
        tP[11] = P12;

        // Plan à paver
        Jeu j = new();

        // Pavage
        var t0 = DateTime.Now;
        Pavage(0, 0, j, (1 << MAXPIECE) - 1);
        var t1 = DateTime.Now;
        var t = t1.Subtract(t0);

        WriteLine("{0} pour {1} solutions\n", t, iNbSol);
        WriteLine("{0} appels à Pavage\n", iNbAppelPavage);

        //Console.ReadLine();
    }

    private static void Pavage(int lstart, int cstart, Jeu jeu, int iMasquePieces)
    {
        int l, c = 0;
        var bTrouvé = false;

        if (iNbSol > MAXSOLUTION) return;

        iNbAppelPavage++;

        // On cherche une case vide à couvrir, de gauche à droite, de haut en bas
        for (l = 0; l < MAXLIG; l++)
        {
            for (c = 0; c < MAXCOL; c++)
            {
                if (l == 0 && c == 0)	  // Accélération, on part de la dernière case vide trouvée
                {
                    l = lstart;
                    c = cstart;
                }

                if (jeu[l, c] == 0)
                {
                    bTrouvé = true;
                    break;
                }
            }
            if (bTrouvé)
                break;
        }

        // Si on n'en a pas trouvé, c'est que le pavage est terminé !
        if (l == MAXLIG && c == MAXCOL)
        {
            iNbSol++;

            /*
            WriteLine("Solution {0} trouvée", iNbSol);
            for (l=0 ; l<MAXLIG; l++)
            {
              for (c=0 ; c<MAXCOL ; c++)
                Write("{0:D2} ", tP[jeu[l, c]-1].hNumPiece);
              WriteLine();
            }
            WriteLine();
            _ = Console.ReadLine();
            */

            return;
        }

        // On cherche parmi toutes les pieces qui restent une pièce pour couvrir la case vide
        int i, j;
        for (i = 0; i < MAXPIECE; i++)
            if ((iMasquePieces & (1 << i)) != 0)
                for (j = 0; j < tP[i].iNbt; j++)	// Pour chacune des transformations
                {
                    var ca = tP[i].c[j];
                    int l2, c2;
                    var bCollision = false;

                    if (c + ca.cmax - ca.iOffsetCol > MAXCOL ||	  // Trop large
                        l + ca.lmax > MAXLIG ||				  // Trop haut
                        c < ca.iOffsetCol)					  // Doit être décalée trop à gauche
                        continue;

                    for (l2 = 0; l2 < ca.lmax; l2++)
                    {
                        for (c2 = 0; c2 < ca.cmax; c2++)
                            if (ca.tMotif[l2, c2] && jeu[l + l2, c + c2 - ca.iOffsetCol] != 0)  // Case déjà occupée
                            {
                                bCollision = true;
                                break;
                            }
                        if (bCollision)
                            break;
                    }

                    if (!bCollision)
                    {
                        // Pièce valable! On la place
                        Jeu jeu2 = new(jeu);

                        for (l2 = 0; l2 < ca.lmax; l2++)
                            for (c2 = 0; c2 < ca.cmax; c2++)
                                if (ca.tMotif[l2, c2]) jeu2[l + l2, c + c2 - ca.iOffsetCol] = (byte)(i + 1);

                        // On continue avec les pièces qui restent
                        Pavage(l, c, jeu2, iMasquePieces & ~(1 << i));
                    }
                }
    }
}