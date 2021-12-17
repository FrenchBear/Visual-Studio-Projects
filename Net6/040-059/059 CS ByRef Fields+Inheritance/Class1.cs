// 059 CS ByRef Fields+Inheritance
//
// 2001-08-17   PV  Essai de transmission de champ et de propriété par référence (ne marche pas en VB6)
//                  + essais méthodes/classes abstraites, scellées, virtuelles...
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010  sealed is an equivalent for methods to VB NotOverridable
// 2021-09-18   PV  VS2022, Net6

#pragma warning disable CA1050 // Declare types in namespaces
#pragma warning disable CA1822 // Mark members as static
#pragma warning disable CA2211 // Non-constant fields should not be visible

using static System.Console;

public abstract class Zap
{
    public Zap() => WriteLine("Zap.New()");

    public void MH() => WriteLine("Zap.MH()");

    public virtual void OV1() => WriteLine("Zap.OV1()");

    public virtual void OV2() => WriteLine("Zap.OV2()");

    public abstract void MO1();

    public abstract void MO2();
}

public class Couleur : Zap
{
    // Si la variable n'est pas static, ça provoque un débordement de pile
    // Non détecté par le compilo
    protected static Couleur Bleu = new(0, 0, 255);

    public int R, G, B;
    private int m_A;

    public Couleur()
        : this(0, 0, 0) => WriteLine("Couleur.New()");

    public Couleur(int rr, int gg, int bb)
    {
        WriteLine("Couleur.New({0},{1},{2})", rr, gg, bb);
        R = rr;
        G = gg;
        B = bb;
        m_A = 0;
    }

    public override string ToString() => "{" + m_A + ", " + R + ", " + G + ", " + B + "}";

    public int A
    {
        get => m_A;
        set => m_A = value;
    }

    // New slot
    public virtual void S1() => WriteLine("Couleur.S1()");

    // Pas trouvé l'équivalent de NotOverridable en VB (=final en MSIL)
    // 2012-02-25: NotOverridable = sealed, also applicable to a method
    public sealed override void MO1() => WriteLine("Couleur.MO1()");

    public override void MO2() => WriteLine("Couleur.MO2()");

    // Pas trouvé l'équivalent de NotOverridable en VB
    public /* NotOverridable */ override void OV1() => WriteLine("Couleur.OV1()");
}

public sealed class CouleurClaire : Couleur
{
    public CouleurClaire() => WriteLine("CouleurClaire.New()");

    public new void S1() => WriteLine("CouleurClaire.S1()");

    public override void MO2() => WriteLine("CouleurClaire.MO2()");

    public new void OV1() => WriteLine("CouleurClaire.OV1()");
}

public class Module1
{
    private static void Main(string[] args)
    {
        WriteLine("Module1.Main()");

        Couleur c = new(128, 80, 200);
        WriteLine("c = {0}", c);
        Complément255(ref c.G);
        WriteLine("c = {0}", c);

        // Le compilo VB sait passer une propriété par référence !
        int __tmp = c.A;
        Complément255(ref __tmp);
        c.A = __tmp;

        WriteLine("c = {0}", c);
        WriteLine();

        CouleurClaire cc = new();
        WriteLine();

        Zap zc = c;
        WriteLine("Appels avec un objet Couleur et une variable Zap");
        zc.MH();
        zc.MO1();
        zc.MO2();
        zc.OV1();
        zc.OV2();
        WriteLine();

        Zap zcc = cc;
        WriteLine("Appels avec un objet CouleurClaire et une variable Zap");
        zcc.MH();
        zcc.MO1();
        zcc.MO2();
        zcc.OV1();
        zcc.OV2();
        WriteLine();

        Couleur c2 = cc;
        WriteLine("Appels avec un objet CouleurClaire et une variable Couleur");
        c2.MH();
        c2.MO1();
        c2.MO2();
        c2.OV1();
        c2.OV2();
        c2.S1();
        WriteLine();

        WriteLine("Appels avec un objet CouleurClaire et une variable CouleurClaire");
        cc.MH();
        cc.MO1();
        cc.MO2();
        cc.OV1();
        cc.OV2();
        cc.S1();

        //Console.ReadLine();
    }

    private static void Complément255(ref int x) => x = 255 - x;
}