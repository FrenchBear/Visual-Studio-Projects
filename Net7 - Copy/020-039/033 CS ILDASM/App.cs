// App.cs
// Essais pour ILDasm
//
// 2001-02-03   PV
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010
// 2021-09-18   PV  VS2022, Net6

using MaBibliotheque;
using System;
using static System.Console;

namespace EssaisILDasm;

internal class MyApp
{
    public static void Main(string[] args)
    {
        MaClasseDerivee.MaMethodeStatique();

        var d = new MaClasseDerivee();
        d.Bip += new GestionnaireDeBip(D_Bip);

        // Try+Catch
        try
        { MaClasseDerivee.TrucDangereux(35); }
        catch
        { WriteLine("Echec a l'appel de d.TrucDangereux(35)"); }

        try
        { MaClasseDerivee.TrucDangereux(0); }
        catch (Exception e)
        { WriteLine("Échec à l'appel de d.TrucDangereux(0): {0}", e.Message); }
        WriteLine();

        // Appel de méthodes virtuelles
        ActionBase(d, 2);
        d.MyBaseAction();
        MaClasseDeBase b = new(d);
        b.Action();
        WriteLine();

        // Evénements
        d.MaMethodeBruyante1(3);
        ActionInterface(d);
        WriteLine();

        // Indexers
        WriteLine("Index 0: {0}", d[0]);
        WriteLine("Index \"A\": {0}", d["A"]);
        WriteLine("Index 'A': {0}", d['A']);
        WriteLine("Index 3,4: {0}", d[3, 4]);
        WriteLine("Index 3,\"Z\": {0}", d[3, "Z"]);
        WriteLine();

        // Enum
        var j = Jour.Mardi;
        WriteLine("j = {0}", j);
        j++;
        WriteLine("j = {0}", j);
        WriteLine();

        // Types valeur
        DBInt x = 123;
        var y = DBInt.Null;
        var z = x + y;
        WriteLine("x = {0}", x);
        WriteLine("y = {0}", y);
        WriteLine("z = {0}", z);

        _ = ReadLine();
    }

    protected static void ActionBase(MaClasseDeBase b, int iVal)
    {
        b.MembreDeBase = iVal;
        b.Action();
    }

    public static void ActionInterface(IMonInterface IMI)
    {
        IMI.MaMethodeBruyante1(1);
        IMI.MaMethodeBruyante2(1);
    }

    private static void D_Bip(object e, string sMsg) => WriteLine("D_Bip(): {0}", sMsg);
}