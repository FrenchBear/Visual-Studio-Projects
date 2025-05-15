// 059 CS ByRef Fields+Inheritance
// 2001-08-17   PV  Essai de transmission de champ et de propri�t� par r�f�rence (ne marche pas en VB6)
//                  + essais m�thodes/classes abstraites, scell�es, virtuelles...
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010  sealed is an equivalent for methods to VB NotOverridable

using System;

public abstract class Zap
{
    public Zap() => Console.WriteLine("Zap.New()");

    public void MH() => Console.WriteLine("Zap.MH()");

    public virtual void OV1() => Console.WriteLine("Zap.OV1()");

    public virtual void OV2() => Console.WriteLine("Zap.OV2()");

    public abstract void MO1();

    public abstract void MO2();
}

public class Couleur : Zap
{
    // Si la variable n'est pas static, �a provoque un d�bordement de pile
    // Non d�tect� par le compilo
    protected static Couleur Bleu = new Couleur(0, 0, 255);

    public int R, G, B;
    private int m_A;

    public Couleur()
        : this(0, 0, 0) => Console.WriteLine("Couleur.New()");

    public Couleur(int rr, int gg, int bb)
    {
        Console.WriteLine("Couleur.New({0},{1},{2})", rr, gg, bb);
        R = rr;
        G = gg;
        B = bb;
        m_A = 0;
    }

    public override string ToString() => "{" + m_A.ToString() + ", " + R.ToString() + ", " + G.ToString() + ", " + B.ToString() + "}";

    public int A
    {
        get => m_A;
        set => m_A = value;
    }

    // New slot
    public virtual void S1() => Console.WriteLine("Couleur.S1()");

    // Pas trouv� l'�quivalent de NotOverridable en VB (=final en MSIL)
    // 2012-02-25: NotOverridable = sealed, also applicable to a method
    public sealed override void MO1() => Console.WriteLine("Couleur.MO1()");

    public override void MO2() => Console.WriteLine("Couleur.MO2()");

    // Pas trouv� l'�quivalent de NotOverridable en VB
    public /* NotOverridable */ override void OV1() => Console.WriteLine("Couleur.OV1()");
}

public sealed class CouleurClaire : Couleur
{
    public CouleurClaire() => Console.WriteLine("CouleurClaire.New()");

    public new void S1() => Console.WriteLine("CouleurClaire.S1()");

    public override void MO2() => Console.WriteLine("CouleurClaire.MO2()");

    public new void OV1() => Console.WriteLine("CouleurClaire.OV1()");
}

public class Module1
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Module1.Main()");

        var c = new Couleur(128, 80, 200);
        Console.WriteLine("c = {0}", c);
        Complément255(ref c.G);
        Console.WriteLine("c = {0}", c);

        // Le compilo VB sait passer une propri�t� par r�f�rence !
        int __tmp = c.A;
        Complément255(ref __tmp);
        c.A = __tmp;

        Console.WriteLine("c = {0}", c);
        Console.WriteLine();

        var cc = new CouleurClaire();
        Console.WriteLine();

        Zap zc = c;
        Console.WriteLine("Appels avec un objet Couleur et une variable Zap");
        zc.MH();
        zc.MO1();
        zc.MO2();
        zc.OV1();
        zc.OV2();
        Console.WriteLine();

        Zap zcc = cc;
        Console.WriteLine("Appels avec un objet CouleurClaire et une variable Zap");
        zcc.MH();
        zcc.MO1();
        zcc.MO2();
        zcc.OV1();
        zcc.OV2();
        Console.WriteLine();

        Couleur c2 = cc;
        Console.WriteLine("Appels avec un objet CouleurClaire et une variable Couleur");
        c2.MH();
        c2.MO1();
        c2.MO2();
        c2.OV1();
        c2.OV2();
        c2.S1();
        Console.WriteLine();

        Console.WriteLine("Appels avec un objet CouleurClaire et une variable CouleurClaire");
        cc.MH();
        cc.MO1();
        cc.MO2();
        cc.OV1();
        cc.OV2();
        cc.S1();

        Console.ReadLine();
    }

    private static void Complément255(ref int x) => x = 255 - x;
}