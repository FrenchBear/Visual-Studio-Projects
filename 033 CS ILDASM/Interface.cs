using System;

#pragma warning disable 1591

namespace MaBibliotheque
{
    public delegate void GestionnaireDeBip(object sender, string sMsg);

    public interface MonInterface
    {
        void MaMethodeBruyante1(int x);			// M�thode
        void MaMethodeBruyante2(int x);			// M�thode
        int MaPropriete { get; set; }			// Propri�t�
        event GestionnaireDeBip Bip;			// Ev�nement
        string this[int index] { get; }		  	// Indexer
        string this[string index] { get; }		// Indexer
    }
}

