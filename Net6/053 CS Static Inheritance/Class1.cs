// 53 CS Héritage statique
// Test d'une remarque de la doc du CIL: Les champs statiques d'une classe ne sont pas hérités
// En fait en C# ça marche, mais le compilo génère bien une référence au champ statique de la classe de base...
// 2001-07-29   PV
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010

using System;

#pragma warning disable IDE0059 // Unnecessary assignment of a value

internal class Animal
{
    public static int Population;

    public Animal()
    {
        Console.WriteLine("Constructeur Animal");
        Population++;
    }
};

internal class Chien : Animal
{
    public string sRace;

    public Chien(string s)
    {
        sRace = s;
    }
}

internal class AppTest
{
    private static void Main()
    {
        Chien Pollux;

        Pollux = new Chien("Briard");
        Console.WriteLine("Pop: {0}", Chien.Population);

        //  Remarque: dans le ILDASM :
        //  IL_000b:  ldstr      "Pop: {0}"
        //  IL_0010:  ldsfld     int32 Animal::Population
        //  IL_0015:  box        [mscorlib]System.Int32
        //  IL_001a:  call       void [mscorlib]System.Console::WriteLine(string, object)

        Console.ReadLine();
    }
}