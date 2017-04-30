using System;

#pragma warning disable 1591

namespace MaBibliotheque
{
    public delegate void GestionnaireDeBip(object sender, string sMsg);

    public interface MonInterface
    {
        void MaMethodeBruyante1(int x);			// Méthode
        void MaMethodeBruyante2(int x);			// Méthode
        int MaPropriete { get; set; }			// Propriété
        event GestionnaireDeBip Bip;			// Evénement
        string this[int index] { get; }		  	// Indexer
        string this[string index] { get; }		// Indexer
    }
}

