// Pile.cs
// Implantation d'une classe pile très simple
//
// 2001 PV
//
// 2010-05-01	PV		VS2010
// 2021-09-17	PV		VS2022/Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13

using System;

namespace NS002;

public class Pile
{
    private sealed class Noeud(object o, Noeud s)
    {
        public object élément = o;
        public Noeud suivant = s;
    }

    private Noeud tête; // = null;

    public object Dépile()
    {
        if (tête == null)
            throw new Exception("Dépile sur pile vide");
        else
        {
            var temp = tête;
            tête = tête.suivant;
            return temp.élément;
        }
    }

    public void Empile(object o) => tête = new Noeud(o, tête);
}
