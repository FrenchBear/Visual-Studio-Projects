// Carre44.h: interface for the Carre44 class.
//
// 2017-06-05	PV	VS2017, simplification du code MSC/stdafx et version 4x4 pour The Talos Principle

class Carre44
{
public:
	static const int size = 4;

	char	tMotif[size][size];
	int	lmax, cmax;		// Encombrement de la pièce
	int	iOffsetCol;		// Décalage de colonne pour occuper la cellule [0][0]


	Carre44()
	{
		int l, c;
		for (l = 0; l < size; l++)
			for (c = 0; c < size; c++)
				tMotif[l][c] = 0;
		lmax = cmax = 0;
		iOffsetCol = 0;
	}

	Carre44(int i00, int i01, int i02, int i03, int i10, int i11, int i12, int i13)
	{
		tMotif[0][0] = i00; tMotif[0][1] = i01; tMotif[0][2] = i02; tMotif[0][3] = i03;
		tMotif[1][0] = i10; tMotif[1][1] = i11; tMotif[1][2] = i12; tMotif[1][3] = i13;
		tMotif[2][0] = 0;   tMotif[2][1] = 0;   tMotif[2][2] = 0;   tMotif[2][3] = 0;
		tMotif[3][0] = 0;   tMotif[3][1] = 0;   tMotif[3][2] = 0;   tMotif[3][3] = 0;  

		lmax = 2;
		if (i10 + i11 + i12 + i13 == 0) lmax = 1;

		cmax = 4;
		if (i03 + i13 == 0) cmax = 3;
		if (i02 + i12 == 0) cmax = 2;
		if (i01 + i11 == 0) cmax = 1;

		MkOffset();
	}


	// Détermine la propriété iOffsetCol, c'est à dire le nombre de colonnes qu'il
	// faut translater le dessin à gauche pour occuper la cellule [0][0]
	void MkOffset()
	{
		if (tMotif[0][0])
			iOffsetCol = 0;
		else if (tMotif[0][1])
			iOffsetCol = 1;
		else if (tMotif[0][2])
			iOffsetCol = 2;
		else 
			iOffsetCol = 3;
	}


	// Opérateur de comparaison
	int operator == (const Carre44 &k)
	{
		return lmax == k.lmax && cmax == k.cmax &&
			tMotif[0][0] == k.tMotif[0][0] && tMotif[0][1] == k.tMotif[0][1] && tMotif[0][2] == k.tMotif[0][2] && tMotif[0][3] == k.tMotif[0][3] &&
			tMotif[1][0] == k.tMotif[1][0] && tMotif[1][1] == k.tMotif[1][1] && tMotif[1][2] == k.tMotif[1][2] && tMotif[1][3] == k.tMotif[1][3] &&
			tMotif[2][0] == k.tMotif[2][0] && tMotif[2][1] == k.tMotif[2][1] && tMotif[2][2] == k.tMotif[2][2] && tMotif[2][3] == k.tMotif[2][3] &&
			tMotif[3][0] == k.tMotif[3][0] && tMotif[3][1] == k.tMotif[3][1] && tMotif[3][2] == k.tMotif[3][2] && tMotif[3][3] == k.tMotif[3][3];
	}

	// Transformations
	int TL(int iT, int l, int c);
	int TC(int iT, int l, int c);
	Carre44 Transformation(int iT);

	void Dessin();
};

