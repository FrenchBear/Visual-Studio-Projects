// Essais d'héritage de classe WinForm en C#
// 2001-01-27   PV
// 2001-08-15   PV	Beta2
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010

internal class MyApp
{
    public static void Main()
    {
        MsgBox2 f = new MsgBox2();
        f.Info("Informations standard affichées avec MsgBox2");

        MsgBox3 g = new MsgBox3();
        g.Info("Informations spécialisées affichées avec MsgBox3");

        f = g;
        f.Info("Appel de la méthode Info d'un objet MsgBox3 via un pointeur MsgBox2: C'est l'affichage d'une MsgBox3, mais avec la fonction info de MsgBox2 si la fonction Info n'est pas virtuelle.");
        // Si MsgBox2.Info est virtual et MsgBox3.Info est override,
        // appelle MsgBox3.info

        // Si MsgBox2.Info est (rien) et MsgBox3.Info est (rien), Warning en compil
        // MsgBox3.cs(42): 'MsgBox3.Info(string)' hides inherited member 'MsgBox2.Info(string)'.
        // To make the current method override that implementation, add the override keyword. Otherwise add the new keyword.
        // appelle MsgBox2.info MAIS la fenêtre conserve la couleur de MsgBox3 (objet rémanent)
    }
}