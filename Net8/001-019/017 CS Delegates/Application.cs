﻿// 17 C# delegates
// Essai pour voir si un delegate sur une méthode d'instance virtuelle
// fonctionne correctement.
// Résultat Ok: le programme affiche MaDérivée.F(2)
// 2001-01-15   PV
// 2001-01-28	PV		Zap() pour voir en MSIL la différence entre un delegate de méthode statique
//                  et un delegate de méthode d'instance
// 2006-10-01	PV		VS2005
// 2012-02-25	PV		VS2010
// 2021-09-17	PV		VS2022/Net6
// 2023-01-10	PV		Net7

using static System.Console;

internal class MaClasse
{
    public virtual void F(int i) => WriteLine("MaClasse.F({0})", i);
}

internal class MaDérivée: MaClasse
{
    public override void F(int i) => WriteLine("MaDérivée.F({0})", i);
}

internal delegate void MyDelegate(int x);

internal class Test
{
    public static void Main()
    {
        MaClasse o = new MaDérivée();
        MyDelegate f = new(o.F);

        MyDelegate g = new(Zap);

        f(132);
        g(133);

        _ = ReadLine();
    }

    private static void Zap(int iValeur) => WriteLine("Zap({0})", iValeur);
}
