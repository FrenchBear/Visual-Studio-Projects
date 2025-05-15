using System;

#pragma warning disable 1591
#pragma warning disable IDE0052 // Remove unread private members
#pragma warning disable IDE0051 // Remove unused private members

namespace MaBibliotheque
{
    public class MaClasseDerivee : MaClasseDeBase, IMonInterface
    {
        private class MaSousClasse
        {
            private readonly int a;

            public MaSousClasse(int a) => this.a = a;

            public int A
            {
                get => a;
                set => A = value;
            }

            public override string ToString() => a.ToString();

            [Obsolete("Ne plus utiliser !")]
            private void MethodeObsolete()
            {
            }
        }

        /// <summary>
        /// Impl�mentation de MonInterface, membre ordinaire
        /// </summary>
        /// <param name="iNbBip">Nombre d'�v�nements Bip � d�clencher</param>
        public void MaMethodeBruyante1(int iNbBip)
        {
            for (int i = 0; i < iNbBip; i++)
            {
                Bip(this, "MaMethodeBruyante1");
            }
        }

        /// <summary>
        /// Impl�mentation de MonInterface, membre explicite d'interface
        /// </summary>
        /// <param name="iNbBip">Nombre d'�v�nements Bip � d�clencher</param>
        void IMonInterface.MaMethodeBruyante2(int iNbBip)
        {
            for (int i = 0; i < iNbBip; i++)
            {
                Bip(this, "MaMethodeBruyante2");
            }
        }

        /// <summary>
        ///   Indexer de base: acc�s via un indice entier
        /// </summary>
        /// <param name="index">Rang de l'élément � Récup�rer</param>
        public string this[int index] => String.Format("this[{0}]", index);

        public string this[string index] => String.Format("this[\"{0}\"]", index);

        public string this[char index] => String.Format("this['{0}']", index);

        public string this[int x, int y] => String.Format("this[{0},{1}]", x, y);

        public string this[int x, string y] => String.Format("this[{0},\"{1}\"]", x, y);

        public event GestionnaireDeBip Bip;

        int IMonInterface.MaPropriete
        {
            get => iProp;
            set => iProp = value;
        }

        // H�ritage de MaClasseDeBase
        public override void Action()
        {
            Console.WriteLine("MaClasseDerivee.Action()");
            base.Action();
        }

        public void MyBaseAction() => base.Action();

        // El�ments sp�cifiques � la classe
        private int iProp;

        protected int age;
        private readonly MaSousClasse sc;

        public MaClasseDerivee() => sc = new MaSousClasse(45);

        static MaClasseDerivee() => Console.WriteLine("Constructeur statique de MaClasseDerivee");

        ~MaClasseDerivee()
        {
            Console.WriteLine("~MaClasseDerivee()");
        }

        public int Age
        {
            get => age;
            set => age = value;
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

        public static void MaMethodeStatique() => iCompteurGlobal = 0;
    }
}