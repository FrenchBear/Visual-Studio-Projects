using System;

#pragma warning disable 1591

namespace MaBibliotheque
{
    public class Pile
    {
        private class Noeud
        {
            public object element;
            public Noeud suivant;

            public Noeud(object o, Noeud s)
            {
                suivant = s;
                element = o;
            }
        }

        private Noeud tete = null;

        public object Depile()
        {
            if (tete == null)
                throw new Exception("Depile sur pile vide");
            else
            {
                Noeud temp = tete;
                tete = tete.suivant;
                return temp.element;
            }
        }

        public void Empile(object o) => tete = new Noeud(o, tete);
    }
}