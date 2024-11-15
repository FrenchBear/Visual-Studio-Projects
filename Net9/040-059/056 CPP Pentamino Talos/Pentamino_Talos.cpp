﻿// pentamino.cpp
// Résolution de problèmes de pentaminos (pavage)
//
// 1998-12-26	PV
// 2006-10-01	PV		VS2005
// 2012-02-25	PV		VS2010
// 2017-04-30	PV		VS2017 and Git
// 2017-06-05	PV		VS2017, simplification du code MSC/stdafx et version 4x4 pour The Talos Principle
// 2021-09-18	PV		VS2022, Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8
// 2024-11-15	PV		Net9 C#13


#include <stdio.h>
#include <time.h>
#include <memory.h>

// Rectangle à paver
const int MAXLIG = 5;
const int MAXCOL = 8;
const int MAXPIECE = 10;

const int MAXSOLUTION = 1000;


#include "Carre44.h"
#include "Piece.h"

int iNbSol = 0;
int iNbAppelPavage = 0;


// Plan de jeu
typedef char Jeu[MAXLIG][MAXCOL];

// Tableau de pointeurs sur les pentaminos à utiliser pour le problème
Piece *tP[MAXPIECE];


void Pavage(int lstart, int cstart, Jeu &jeu, int iMasquePieces)
{
	int l, c;
	int bTrouve = false;

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

			if (jeu[l][c] == 0)
			{
				bTrouve = true;
				break;
			}
		}
		if (bTrouve)
			break;
	}

	// Si on n'en a pas trouvé, c'est que le pavage est terminé !
	if (l == MAXLIG && c == MAXCOL)
	{
		iNbSol++;
	
		printf("Solution %d trouvée:\n", iNbSol);
		for (l=0 ; l<MAXLIG; l++)
		{
			for (c=0 ; c<MAXCOL ; c++)
				printf("%2d", tP[jeu[l][c]-1]->hNumPiece);
			printf("\n");
		}

		/*
		FILE *f = fopen("Solution pentamino.txt", "a");
		fprintf(f, "Solution %d trouvée:\n", iNbSol);
		for (l=0 ; l<MAXLIG; l++)
		{
		for (c=0 ; c<MAXCOL ; c++)
		fprintf(f, "%2d", tP[jeu[l][c]-1]->hNumPiece);
		fprintf(f, "\n");
		}
		fclose(f);
		*/
		return;
	}


	// On cherche parmi toutes les pieces qui restent une pièce pour couvrir la case vide
	int i, j;
	for (i = 0; i < MAXPIECE; i++)
		if (iMasquePieces & (1 << i))
			for (j = 0; j < tP[i]->iNbt; j++)	// Pour chacune des transformations
			{
				Carre44 &ca = tP[i]->c[j];
				int l2, c2;
				int bCollision;

				int bContinue = false;
				if (c + ca.cmax - ca.iOffsetCol > MAXCOL || // Trop large
					l + ca.lmax > MAXLIG ||					// Trop haut
					c < ca.iOffsetCol)						// Doit être décalée trop à gauche
					continue;

				bCollision = false;
				for (l2 = 0; l2 < ca.lmax; l2++)
				{
					for (c2 = 0; c2 < ca.cmax; c2++)
						if (ca.tMotif[l2][c2] && jeu[l + l2][c + c2 - ca.iOffsetCol])  // Case déjà occupée
						{
							bCollision = true;
							break;
						}
					if (bCollision)
						break;
				}

				if (!bCollision)
				{
					// Pièce valable ! On la place
					Jeu jeu2;
					memcpy(jeu2, jeu, sizeof(Jeu));

					for (l2 = 0; l2 < ca.lmax; l2++)
						for (c2 = 0; c2 < ca.cmax; c2++)
							if (ca.tMotif[l2][c2]) jeu2[l + l2][c + c2 - ca.iOffsetCol] = i + 1;

					// On continue avec les pièces qui restent
					Pavage(l, c, jeu2, iMasquePieces & ~(1 << i));
				}
			}
}


int main(int argc, char* argv[])
{
	// Préparation des pièces
	Piece P1(1, 'T', 1, 1, 1, 0, 0, 1, 0, 0);
	Piece P2(2, 'T', 1, 1, 1, 0, 0, 1, 0, 0);
	Piece P3(3, 'T', 1, 1, 1, 0, 0, 1, 0, 0);
	Piece P4(4, 'T', 1, 1, 1, 0, 0, 1, 0, 0);
	Piece P5(5, 'L', 1, 1, 1, 0, 1, 0, 0, 0);
	Piece P6(6, 'l', 1, 0, 0, 0, 1, 1, 1, 0);
	Piece P7(7, 'S', 0, 1, 1, 0, 1, 1, 0, 0);
	Piece P8(8, 'S', 0, 1, 1, 0, 1, 1, 0, 0);
	Piece P9(9, 's', 1, 1, 0, 0, 0, 1, 1, 0);
	Piece P10(10, 's', 1, 1, 0, 0, 0, 1, 1, 0);


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

	printf("(pause)");
	(void)getchar();

	if (MAXLIG*MAXCOL != Carre44::size * MAXPIECE)
	{
		printf("Constantes MAXLIG/MAXCOL/MAXPIECE incohérentes !\n");
		return 1;
	}

	// Plan à paver
	Jeu j{};
	int l, c;
	for (l = 0; l < MAXLIG; l++)
		for (c = 0; c < MAXCOL; c++)
			j[l][c] = 0;

	// Pieces a utiliser
	tP[0] = &P1;
	tP[1] = &P2;
	tP[2] = &P3;
	tP[3] = &P4;
	tP[4] = &P5;
	tP[5] = &P6;
	tP[6] = &P7;
	tP[7] = &P8;
	tP[8] = &P9;
	tP[9] = &P10;

	time_t t0 = time(0L);
	Pavage(0, 0, j, (1 << MAXPIECE) - 1);
	time_t t1 = time(0L);

	printf("%llds execution\n", t1 - t0);
	printf("%d solutions\n", iNbSol);
	printf("%d appels à Pavage\n", iNbAppelPavage);

	printf("\n(pause) ");
	(void)getchar();

	return 0;
}
