using System;

#pragma warning disable 1591

namespace MaBibliotheque
{
    public abstract class MonOrigine
    {
        public abstract void Action();
    }

    public class MaClasseDeBase : MonOrigine
    {
        private int iMembreDeBase;

        public override void Action() => Console.WriteLine("MaClasseDeBase.Action(): iMembreDebase={0}", iMembreDeBase);

        public int MembreDeBase
        {
            get => iMembreDeBase;
            set => iMembreDeBase = value;
        }

        // Constructeur par d�faut
        public MaClasseDeBase() => iMembreDeBase = 0;

        // Constructeur copie
        public MaClasseDeBase(MaClasseDeBase b0) => iMembreDeBase = b0.iMembreDeBase;

        // Destructeur
        ~MaClasseDeBase()
        {
        }
    }
}