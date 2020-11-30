// App.cs
// Essais pour ILDasm
// 2001-02-03   PV
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010

using System;
using MaBibliotheque;


namespace EssaisILDasm
{

    class MyApp
    {
        public static void Main(String[] args)
        {
            MaClasseDerivee.MaMethodeStatique();

            MaClasseDerivee d;
            d = new MaClasseDerivee();
            d.Bip += new GestionnaireDeBip(D_Bip);

            // Try+Catch
            try
            { d.TrucDangereux(35); }
            catch
            { Console.WriteLine("Echec a l'appel de d.TrucDangereux(35)"); }

            try
            { d.TrucDangereux(0); }
            catch (Exception e)
            { Console.WriteLine("Échec à l'appel de d.TrucDangereux(0): {0}", e.Message); }
            Console.WriteLine();

            // Appel de méthodes virtuelles
            ActionBase(d, 2);
            d.MyBaseAction();
            MaClasseDeBase b = new MaClasseDeBase(d);
            b.Action();
            Console.WriteLine();

            // Evénements
            d.MaMethodeBruyante1(3);
            ActionInterface(d);
            Console.WriteLine();

            // Indexers
            Console.WriteLine("Index 0: {0}", d[0]);
            Console.WriteLine("Index \"A\": {0}", d["A"]);
            Console.WriteLine("Index 'A': {0}", d['A']);
            Console.WriteLine("Index 3,4: {0}", d[3, 4]);
            Console.WriteLine("Index 3,\"Z\": {0}", d[3, "Z"]);
            Console.WriteLine();

            // Enum
            Jour j = Jour.Mardi;
            Console.WriteLine("j = {0}", j);
            j++;
            Console.WriteLine("j = {0}", j);
            Console.WriteLine();

            // Types valeur
            DBInt x = 123;
            DBInt y = DBInt.Null;
            DBInt z = x + y;
            Console.WriteLine("x = {0}", x);
            Console.WriteLine("y = {0}", y);
            Console.WriteLine("z = {0}", z);


            Console.ReadLine();
        }


        protected static void ActionBase(MaClasseDeBase b, int iVal)
        {
            b.MembreDeBase = iVal;
            b.Action();
        }

        public static void ActionInterface(MonInterface IMI)
        {
            IMI.MaMethodeBruyante1(1);
            IMI.MaMethodeBruyante2(1);
        }

        private static void D_Bip(object e, string sMsg)
        {
            Console.WriteLine("D_Bip(): {0}", sMsg);
        }
    }
}

