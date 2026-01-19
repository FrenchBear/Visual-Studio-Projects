// 53 CS Héritage statique
// Test d'une remarque de la doc du CIL: Les champs statiques d'une classe ne sont pas hérités
// En fait en C# ça marche, mais le compilo génère bien une référence au champ statique de la classe de base...
//
// 2001-07-29   PV
// 2006-10-01   PV      VS2005
// 2012-02-25   PV      VS2010
// 2021-09-18   PV      VS2022, Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13
// 2026-01-19	PV		Net10 C#14

using static System.Console;

#pragma warning disable IDE0059 // Unnecessary assignment of a value

internal class Animal
{
    public static int Population;

    public Animal()
    {
        WriteLine("Constructeur Animal");
        Population++;
    }
};

internal class Chien(string s): Animal
{
    public string sRace = s;
}

internal class AppTest
{
    private static void Main()
    {
        Chien Pollux;

        Pollux = new Chien("Briard");
        WriteLine("Pop: {0}", Animal.Population);

        //  Remarque: dans le ILDASM :
        //  IL_000b:  ldstr      "Pop: {0}"
        //  IL_0010:  ldsfld     int32 Animal::Population
        //  IL_0015:  box        [mscorlib]System.Int32
        //  IL_001a:  call       void [mscorlib]System.Console::WriteLine(string, object)

        //Console.ReadLine();
    }
}
