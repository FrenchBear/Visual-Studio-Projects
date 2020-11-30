// 203 CS Inherited Events (Chien)
// 2012-02-04 PV   Translation of original VB code in C#

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS203
{
    class Program
    {
        // Clean example how to implement the equivalent of a WithEvents variable using
        // a property in C#
        private static Chien _withEventsFieldRex;

        public static Chien _rex
        {
            get { return _withEventsFieldRex; }
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

        static void Main(string[] args)
        {
            _rex = new Chien("Médor");
            _rex.Exciter();
            _rex.Enerver();
            _rex = null;

            Meute<Chien> mChiens = new Meute<Chien>(new Chien("Athos"));
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

            Console.WriteLine();
            Console.Write("(Pause)");
            Console.ReadLine();
        }

        private static void Rex_Aboyer()
        {
            Console.WriteLine("Rex aboie");
        }

        private static void Rex_Meurt()
        {
            Console.WriteLine("Rex est mort");
        }

        private static void Rex_Mordre()
        {
            Console.WriteLine("Rex a mordu");
        }

        private static void Rex_Nait()
        {
            Console.WriteLine("Rex est né le " + _rex.NéLe);
        }
    }


    public abstract class EtreVivant
    {
        public System.DateTime NéLe;
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

        private void EtreVivant_Meurt()
        {
            Console.WriteLine("Un être vivant est mort");
        }

        private void EtreVivant_Nait()
        {
            Console.WriteLine("Un être vivant est né");
        }
    }


    public class Animal : EtreVivant
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

        public void Enerver()
        {
            Mordre?.Invoke();
        }

        public virtual void Crier()
        {
            Console.WriteLine("Un animal de race " + Race + " crie.");
        }

        public virtual void Lécher()
        {
            Console.WriteLine("Un animal de race " + Race + " lèche.");
        }

        public void Jouer()
        {
            Console.WriteLine("Un animal de race " + Race + " joue.");
        }


        private void Animal_Meurt()
        {
            Console.WriteLine("Un animal de race " + Race + " est mort");
        }

        private void Animal_Mordre()
        {
            Console.WriteLine("Un animal de race " + Race + " a mordu");
        }

        private void Animal_Nait()
        {
            Console.WriteLine("Un animal de race " + Race + " est né");
        }
    }


    public class Chien : Animal
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

        public void Exciter()
        {
            Aboyer?.Invoke();
        }

        public override void Crier()
        {
            Console.WriteLine(Nom + ": Wouaf !");
        }

        public override sealed void Lécher()
        {
            Console.WriteLine("Le chien " + Nom + " lèche");
        }

        public new void Jouer()
        {
            Console.WriteLine("Le chien " + Nom + " joue.");
        }


        private void Chien_Aboyer()
        {
            Console.WriteLine("Le chien " + Nom + " a aboyé");
        }

        private void Chien_Meurt()
        {
            Console.WriteLine("Le chien " + Nom + " est mort");
        }

        private void Chien_Mordre()
        {
            Console.WriteLine("Le chien " + Nom + " a mordu");
        }

        private void Chien_Nait()
        {
            Console.WriteLine("Le chien " + Nom + " est né");
        }
    }


    class Chiot : Chien
    {
        public Chiot(string sNom)
            : base(sNom)
        {
        }

        public override void Crier()
        {
            Console.WriteLine(Nom + ": Wif !  Wif !");
        }

        public new void Jouer()
        {
            Console.WriteLine("Le chiot " + Nom + " joue.");
        }
    }


    internal class Loup : Animal
    {
        public Loup()
            : base("Lupus")
        {
        }
    }
}

