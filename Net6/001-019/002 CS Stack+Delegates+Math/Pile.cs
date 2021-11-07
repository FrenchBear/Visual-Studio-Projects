// Pile.cs
// Implantation d'une classe pile très simple
//
// 2001 PV
// 2010-05-01   PV  VS2010
// 2021-09-17   PV  VS2022/Net6

using System;

namespace CS002;

public class Pile
{
    private class Noeud
    {
        public object élément;
        public Noeud suivant;

        public Noeud(object o, Noeud s)
        {
            this.suivant = s;
            this.élément = o;
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

    public void Empile(object o)
    {
        tête = new Noeud(o, tête);
    }
}