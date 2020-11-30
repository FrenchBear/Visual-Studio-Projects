using System;

#pragma warning disable 1591
#pragma warning disable IDE0052 // Remove unread private members
#pragma warning disable IDE0051 // Remove unused private members

namespace MaBibliotheque
{

    public class MaClasseDerivee : MaClasseDeBase, MonInterface
    {

        private class MaSousClasse
        {
            private readonly int a;

            public MaSousClasse(int a)
            {
                this.a = a;
            }

            public int A
            {
                get { return a; }
                set { A = value; }
            }

            public override string ToString()
            {
                return a.ToString();
            }

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
            for (int i = 0; i < iNbBip; i++)
            {
                Bip(this, "MaMethodeBruyante1");
            }
        }

        /// <summary>
        /// Implémentation de MonInterface, membre explicite d'interface
        /// </summary>
        /// <param name="iNbBip">Nombre d'événements Bip à déclencher</param>
        void MonInterface.MaMethodeBruyante2(int iNbBip)
        {
            for (int i = 0; i < iNbBip; i++)
            {
                Bip(this, "MaMethodeBruyante2");
            }
        }

        /// <summary>
        ///   Indexer de base: accès via un indice entier
        /// </summary>
        /// <param name="index">Rang de l'élément à récupérer</param>
        public string this[int index]
        {
            get { return String.Format("this[{0}]", index); }
        }

        public string this[string index]
        {
            get { return String.Format("this[\"{0}\"]", index); }
        }

        public string this[char index]
        {
            get { return String.Format("this['{0}']", index); }
        }

        public string this[int x, int y]
        {
            get { return String.Format("this[{0},{1}]", x, y); }
        }

        public string this[int x, string y]
        {
            get { return String.Format("this[{0},\"{1}\"]", x, y); }
        }

        public event GestionnaireDeBip Bip;

        int MonInterface.MaPropriete
        {
            get { return iProp; }
            set { iProp = value; }
        }



        // Héritage de MaClasseDeBase
        public override void Action()
        {
            Console.WriteLine("MaClasseDerivee.Action()");
            base.Action();
        }

        public void MyBaseAction()
        {
            base.Action();
        }



        // Eléments spécifiques à la classe
        private int iProp;
        protected int age;
        private readonly MaSousClasse sc;

        public MaClasseDerivee()
        {
            sc = new MaSousClasse(45);
        }

        static MaClasseDerivee()
        {
            Console.WriteLine("Constructeur statique de MaClasseDerivee");
        }


        ~MaClasseDerivee()
        {
            Console.WriteLine("~MaClasseDerivee()");
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public void TrucDangereux(int q)
        {
            try
            {
                Console.WriteLine("MaClasseDerivee.TrucDangereux({0})", q);
                iCompteurGlobal = 10 / q;
            }
            catch (Exception e)
            {
                Console.WriteLine("Problème dans TrucDangereux{0}: {1} --> On remonte l'erreur", q, e.Message);
                throw e;
            }
            finally
            {
                Console.WriteLine("Section finally de TrucDangereux{0}", q);
            }
            Console.WriteLine("Fin normale de TrucDangereux{0}", q);
        }

        private static int iCompteurGlobal;
        public static void MaMethodeStatique()
        {
            iCompteurGlobal = 0;
        }
    }
}
