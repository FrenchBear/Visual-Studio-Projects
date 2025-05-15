using System;
using static System.Console;

#pragma warning disable IDE0052 // Remove unread private members
#pragma warning disable IDE0051 // Remove unused private members

namespace MaBibliotheque;

public class MaClasseDerivee : MaClasseDeBase, IMonInterface
{
    private class MaSousClasse
    {
        private int a;

        public MaSousClasse(int a) => this.a = a;

        public int A
        {
            get => a;
            set => a = value;
        }

        public override string ToString() => a.ToString();

        [Obsolete("Ne plus utiliser !")]
        private void MethodeObsolete()
        {
        }
    }

    /// <summary>
    /// Implémentation de MonInterface, membre ordinaire
    /// </summary>
    /// <param name="iNbBip">Nombre d'événements Bip à déclencher</param>
    public void MaMethodeBruyante1(int iNbBip)
    {
        for (var i = 0; i < iNbBip; i++)
        {
            Bip(this, "MaMethodeBruyante1");
        }
    }

    /// <summary>
    /// Implémentation de MonInterface, membre explicite d'interface
    /// </summary>
    /// <param name="iNbBip">Nombre d'événements Bip à déclencher</param>
    void IMonInterface.MaMethodeBruyante2(int iNbBip)
    {
        for (var i = 0; i < iNbBip; i++)
        {
            Bip(this, "MaMethodeBruyante2");
        }
    }

    /// <summary>
    ///   Indexer de base: accès via un indice entier
    /// </summary>
    /// <param name="index">Rang de l'élément à récupérer</param>
    public string this[int index] => $"this[{index}]";

    public string this[string index] => $"this[\"{index}\"]";

    public string this[char index] => $"this['{index}']";

    public string this[int x, int y] => $"this[{x},{y}]";

    public string this[int x, string y] => $"this[{x},\"{y}\"]";

    public event GestionnaireDeBip Bip;

    int IMonInterface.MaPropriete
    {
        get => iProp;
        set => iProp = value;
    }

    // Héritage de MaClasseDeBase
    public override void Action()
    {
        WriteLine("MaClasseDerivee.Action()");
        base.Action();
    }

    public void MyBaseAction() => base.Action();

    // Eléments spécifiques à la classe
    private int iProp;

    protected int age;
    private readonly MaSousClasse sc;

    public MaClasseDerivee() => sc = new MaSousClasse(45);

    static MaClasseDerivee() => WriteLine("Constructeur statique de MaClasseDerivee");

    ~MaClasseDerivee()
    {
        WriteLine("~MaClasseDerivee()");
    }

    public int Age
    {
        get => age;
        set => age = value;
    }

    public static void TrucDangereux(int q)
    {
        try
        {
            WriteLine("MaClasseDerivee.TrucDangereux({0})", q);
            iCompteurGlobal = 10 / q;
        }
        catch (Exception e)
        {
            WriteLine("Problème dans TrucDangereux{0}: {1} --> On remonte l'erreur", q, e.Message);
            throw;
        }
        finally
        {
            WriteLine("Section finally de TrucDangereux{0}", q);
        }
        WriteLine("Fin normale de TrucDangereux{0}", q);
    }

    private static int iCompteurGlobal;

    public static void MaMethodeStatique() => iCompteurGlobal = 0;
}