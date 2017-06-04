// Piece.cpp: implementation of the Piece class.
// Gestion "haut niveau" d'un pentomino
// 1998-12-26	PV
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010
// 2017-06-05	PV	VS2017, simplification du code MSC/stdafx et version 4x4 pour The Talos Principle

#include <stdio.h>

#include "Carre44.h"
#include "Piece.h"


//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

Piece::Piece(short hNP, char cP,
	int i00, int i01, int i02, int i03,
	int i10, int i11, int i12, int i13)
{
	hNumPiece = hNP;
	cPiece = cP;
	c[0] = Carre44(i00, i01, i02, i03, i10, i11, i12, i13);
	iNbt = 1;
	if (i00 + i01 + i02 + i03 + i10 + i11 + i12 + i13 != Carre44::size)
		printf("Définition de la pièce %d incorrecte\n", hNP);

	// On génère le tableau des transformations possibles
	int i, j;

	// For talos, symmetries are not needed -> only transformations 0 to 3 (the 4 rotations)
	for (i = 1; i < 4; i++)
	{
		Carre44 ct = c[0].Transformation(i);
		int bDejaVu = false;

		for (j = 0; j < iNbt; j++)
			if (c[j] == ct)
			{
				bDejaVu = true;
				break;
			}
		if (!bDejaVu)
			c[iNbt++] = ct;
	}
}



// Traces
void Piece::Dessin()
{
	printf("Pièce %d %c iNbt=%d\n", hNumPiece, cPiece, iNbt);
	c[0].Dessin();
	printf("\n");
}
