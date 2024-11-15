// 203 CS Inherited Events (Chien)
//
// 2012-02-04	PV		Translation of original VB code in C#
// 2021-09-19	PV		VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13

using System;
using static System.Console;

#pragma warning disable IDE0059 // Unnecessary assignment of a value
#pragma warning disable CA1859 // Use concrete types when possible for improved performance

namespace CS203;

internal class Program
{
    // Clean example how to implement the equivalent of a WithEvents variable using
    // a property in C#
    private static Chien _withEventsFieldRex;

    public static Chien MyRex
    {
        get => _withEventsFieldRex;
        set
        {
            if (_withEventsFieldRex != null)
            {
                _withEventsFieldRex.Aboyer -= Rex_Aboyer;
                _withEventsFieldRex.Meurt -= Rex_Meurt;
                _withEventsFieldRex.Mordre -= Rex_Mordre;
                _withEventsFieldRex.Nait -= Rex_Nait;
            }
            _withEventsFieldRex = value;
            if (_withEventsFieldRex != null)
            {
                _withEventsFieldRex.Aboyer += Rex_Aboyer;
                _withEventsFieldRex.Meurt += Rex_Meurt;
                _withEventsFieldRex.Mordre += Rex_Mordre;
                _withEventsFieldRex.Nait += Rex_Nait;
            }
        }
    }

    private static void Main(string[] args)
    {
        MyRex = new Chien("Médor");
        MyRex.Exciter();
        MyRex.Enerver();
        MyRex = null;

        Meute<Chien> mChiens = new(new Chien("Athos"));
        mChiens.Add(new Chien("Pollux"));
        mChiens.Add(new Chien("Titus"));
        mChiens.Add(new Chiot("Pif"));
        mChiens.Enerver();

        Animal a1 = null;
        Animal a2 = null;
        a1 = new Chien("Athos");
        a2 = new Chiot("Pif");

        a1.Crier();
        a2.Crier();

        a1.Jouer();
        a2.Jouer();

        a1.Lécher();
        a2.Lécher();
    }

    private static void Rex_Aboyer() => WriteLine("Rex aboie");

    private static void Rex_Meurt() => WriteLine("Rex est mort");

    private static void Rex_Mordre() => WriteLine("Rex a mordu");

    private static void Rex_Nait() => WriteLine("Rex est né le " + MyRex.NéLe);
}

public abstract class EtreVivant
{
    public DateTime NéLe;

    public event NaitEventHandler Nait;

    public delegate void NaitEventHandler();

    public event MeurtEventHandler Meurt;

    public delegate void MeurtEventHandler();

    protected EtreVivant()
    {
        Nait += EtreVivant_Nait;
        Meurt += EtreVivant_Meurt;
        NéLe = DateTime.Now;
        Nait?.Invoke();
    }

    // Equivalent to protected void Finalize()
    ~EtreVivant()
    {
        Meurt?.Invoke();
    }

    private void EtreVivant_Meurt() => WriteLine("Un être vivant est mort");

    private void EtreVivant_Nait() => WriteLine("Un être vivant est né");
}

public class Animal: EtreVivant
{
    public string Race;

    public event MordreEventHandler Mordre;

    public delegate void MordreEventHandler();

    public Animal(string sRace)
        : base()
    {
        Nait += Animal_Nait;
        Mordre += Animal_Mordre;
        Meurt += Animal_Meurt;
        Race = sRace;
    }

    public void Enerver() => Mordre?.Invoke();

    public virtual void Crier() => WriteLine("Un animal de race " + Race + " crie.");

    public virtual void Lécher() => WriteLine("Un animal de race " + Race + " lèche.");

    public void Jouer() => WriteLine("Un animal de race " + Race + " joue.");

    private void Animal_Meurt() => WriteLine("Un animal de race " + Race + " est mort");

    private void Animal_Mordre() => WriteLine("Un animal de race " + Race + " a mordu");

    private void Animal_Nait() => WriteLine("Un animal de race " + Race + " est né");
}

public class Chien: Animal
{
    public Chien(string sNom)
        : base("Canis")
    {
        Nait += Chien_Nait;
        Mordre += Chien_Mordre;
        Meurt += Chien_Meurt;
        Aboyer += Chien_Aboyer;
        Nom = sNom;
    }

    protected string Nom;

    public event AboyerEventHandler Aboyer;

    public delegate void AboyerEventHandler();

    public void Exciter() => Aboyer?.Invoke();

    public override void Crier() => WriteLine(Nom + ": Wouaf !");

    public sealed override void Lécher() => WriteLine("Le chien " + Nom + " lèche");

    public new void Jouer() => WriteLine("Le chien " + Nom + " joue.");

    private void Chien_Aboyer() => WriteLine("Le chien " + Nom + " a aboyé");

    private void Chien_Meurt() => WriteLine("Le chien " + Nom + " est mort");

    private void Chien_Mordre() => WriteLine("Le chien " + Nom + " a mordu");

    private void Chien_Nait() => WriteLine("Le chien " + Nom + " est né");
}

internal class Chiot(string sNom): Chien(sNom)
{
    public override void Crier() => WriteLine(Nom + ": Wif !  Wif !");

    public new void Jouer() => WriteLine("Le chiot " + Nom + " joue.");
}

internal class Loup: Animal
{
    public Loup()
        : base("Lupus")
    {
    }
}
