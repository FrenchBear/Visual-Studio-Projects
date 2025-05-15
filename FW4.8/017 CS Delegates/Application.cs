// 17 C# delegates
// Essai pour voir si un delegate sur une m�thode d'instance virtuelle
// fonctionne correctement.
// R�sultat Ok: le programme affiche MaDérivée.F(2)
// 2001-01-15   PV
// 2001-01-28   PV  Zap() pour voir en MSIL la diff�rence entre un delegate de m�thode statique
//                  et un delegate de m�thode d'instance
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010

using System;

internal class MaClasse
{
    public virtual void F(int i) => Console.WriteLine("MaClasse.F({0})", i);
}

internal class MaDérivée : MaClasse
{
    public override void F(int i) => Console.WriteLine("MaDérivée.F({0})", i);
}

internal delegate void MyDelegate(int x);

internal class Test
{
    public static void Main()
    {
        MaClasse o = new MaDérivée();
        var f = new MyDelegate(o.F);

        var g = new MyDelegate(Zap);

        f(132);
        g(133);

        Console.ReadLine();
    }

    private static void Zap(int iValeur) => Console.WriteLine("Zap({0})", iValeur);
}