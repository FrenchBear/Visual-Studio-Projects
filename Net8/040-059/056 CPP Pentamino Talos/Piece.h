// Piece.h: interface for the Piece class.
//
// 2017-06-05	PV		VS2017, simplification du code MSC/stdafx et version 4x4 pour The Talos Principle

class Piece
{
public:
	short	hNumPiece;		// N° dans le jeu Katamino
	char	cPiece;			// Lettre
	Carre44 c[8];			// 8 transformations maxi
	int		iNbt;			// Nb de transformations


	Piece::Piece(short hNP, char cP,
		int i00, int i01, int i02, int i03,
		int i10, int i11, int i12, int i13);
	void Dessin();
};
