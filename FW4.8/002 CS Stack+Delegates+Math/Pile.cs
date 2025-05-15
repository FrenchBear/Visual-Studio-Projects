// Pile.cs
// Implantation d'une classe pile tr�s simple
// 2001 PV
// 2010-05-01   PV  VS2010

using System;

public class Pile
{
    private class Noeud
    {
        public object élément;
        public Noeud suivant;

        public Noeud(object o, Noeud s)
        {
            suivant = s;
            élément = o;
        }
    }

    private Noeud tête = null;

    public object Dépile()
    {
        if (tête == null)
            throw new Exception("Dépile sur pile vide");
        else
        {
            Noeud temp = tête;
            tête = tête.suivant;
            return temp.élément;
        }
    }

    public void Empile(object o) => tête = new Noeud(o, tête);
}