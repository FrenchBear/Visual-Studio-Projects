// Pile.cs
// Implantation d'une classe pile tr�s simple
// 2001 PV
// 2010-05-01   PV  VS2010

using System;

public class Pile
{
    private class Noeud
    {
        public object �l�ment;
        public Noeud suivant;

        public Noeud(object o, Noeud s)
        {
            this.suivant = s;
            this.�l�ment = o;
        }
    }

    private Noeud t�te = null;

    public object D�pile()
    {
        if (t�te == null)
            throw new Exception("D�pile sur pile vide");
        else
        {
            Noeud temp = t�te;
            t�te = t�te.suivant;
            return temp.�l�ment;
        }
    }

    public void Empile(object o)
    {
        t�te = new Noeud(o, t�te);
    }
}