// Carre44.cpp: implementation of the Carre44 class
// Représente une grille 4x4 et implante des transformations de base (rotation/symétrie)
// 1998-12-26	PV
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010
// 2017-06-05	PV	VS2017, simplification du code MSC/stdafx et version 4x4 pour The Talos Principle

#include <stdio.h>

#include "Carre44.h"


// Transformations
// 0: Identité
// 1: 90°  sens horaire
// 2: 180°
// 3: 270° sens horaire
// 4: miroir Hz
// 5: miroir Hz + 90°  sens horaire
// 6: miroir Hz + 180°
// 7: miroir Hz + 270° sens horaire

// Transformation de ligne  
int Carre44::TL(int iT, int l, int c)
{
	switch (iT)
	{
	case 1:  return c;
	case 2:  return l < lmax ? lmax - 1 - l : l;
	case 3:  return c < cmax ? cmax - 1 - c : c;
	case 4:  return l;
	case 5:  return c < cmax ? cmax - 1 - c : c;
	case 6:  return l < lmax ? lmax - 1 - l : c;
	case 7:  return c;
	}
	return l;	// cas 0
}

// Transformation de colonne
int Carre44::TC(int iT, int l, int c)
{
	switch (iT)
	{
	case 1:  return l < lmax ? lmax - 1 - l : l;
	case 2:  return c < cmax ? cmax - 1 - c : c;
	case 3:  return l;
	case 4:  return c < cmax ? cmax - 1 - c : c;
	case 5:  return l < lmax ? lmax - 1 - l : l;
	case 6:  return c;
	case 7:  return l;
	}
	return c;	// cas 0
}


Carre44 Carre44::Transformation(int iT)
{
	Carre44 ct;
	int		l, c;

	for (l = 0; l < lmax; l++)
		for (c = 0; c < cmax; c++)
			ct.tMotif[TL(iT, l, c)][TC(iT, l, c)] = tMotif[l][c];

	if (iT & 1)
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


void Carre44::Dessin()
{
	int l, c;

	for (l = 0; l < size; l++)
	{
		for (c = 0; c < size; c++)
			printf("%s", tMotif[l][c] ? "\xdb\xdb" : "\xfa\xfa");
		printf("\n");
	}
	printf("Offset: %d\n", iOffsetCol);
}
