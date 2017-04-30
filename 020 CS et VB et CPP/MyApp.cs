// 20 C#
// Projet mixte C#, VB et C++
// La classe de base B est définie en VB
// La classe de base C est définie en C++ managé
// Les classes dérivées D1 et D2 sont définie en C#
// 2001-01-27   PV
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010, tout forcé en 32 bit et ciblant le Framework .Net 4 (à cause du C++)
// 2017-04-30   PV  VS2017, Git

using System;


namespace Mixte20
{
    class MyApp
    {
        public static void Main()
        {
            D1 d1 = new D1();
            D2 d2 = new D2();

            Console.Write("(pause) ");
            Console.ReadLine();
        }
    }



    class D1 : B
    {
        public D1()
        {
            Console.WriteLine("D1.ctor");
        }
    }


    class D2 : C
    {
        public D2()
        {
            Console.WriteLine("D2.ctor");
        }
    }

}

