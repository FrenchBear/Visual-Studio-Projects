using System;

#pragma warning disable IDE0130 // Namespace doesn't match folder structure

namespace MaBibliotheque;

public class Pile
{
    private class Noeud(object o, Noeud s)
    {
        public object element = o;
        public Noeud suivant = s;
    }

    private Noeud tete; //= null;

    public object Depile()
    {
        if (tete == null)
            throw new Exception("Depile sur pile vide");
        else
        {
            var temp = tete;
            tete = tete.suivant;
            return temp.element;
        }
    }

    public void Empile(object o) => tete = new Noeud(o, tete);
}