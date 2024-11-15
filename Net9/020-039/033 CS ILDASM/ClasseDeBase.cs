using static System.Console;

#pragma warning disable IDE0130 // Namespace doesn't match folder structure

namespace MaBibliotheque;

public abstract class MonOrigine
{
    public abstract void Action();
}

public class MaClasseDeBase: MonOrigine
{
    public override void Action() => WriteLine("MaClasseDeBase.Action(): iMembreDebase={0}", MembreDeBase);

    public int MembreDeBase { get; set; }

    // Constructeur par d�faut
    public MaClasseDeBase() => MembreDeBase = 0;

    // Constructeur copie
    public MaClasseDeBase(MaClasseDeBase b0) => MembreDeBase = b0.MembreDeBase;

    // Destructeur
#pragma warning disable CA1821 // Remove empty Finalizers
    ~MaClasseDeBase()
#pragma warning restore CA1821 // Remove empty Finalizers
    {
    }
}