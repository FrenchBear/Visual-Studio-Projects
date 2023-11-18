// Essais de l'interface Reflection
// D'après mail de Jayanth Rajan@MICROSOFT.COM du 9/1/2001
// Résultat du programe:
// Void ibar.c() Interface Method: Void c() Interface: ibar
// Void ibar.b() Interface Method: Void b() Interface: ibar
// Void ifoo.a() Interface Method: Void a() Interface: ifoo
// 2001-08-11	PV		Adapté Beta2
// 2006-10-01	PV		VS2005
// 2012-02-25	PV		VS2010
// 2021-09-17	PV		VS2022/Net6
// 2023-01-10	PV		Net7

using System;
using System.Reflection;
using static System.Console;

namespace CS014;

public class GetMemberMethodImpl
{
    public static void Main()
    {
        var t = typeof(Bar);
        foreach (var m in t.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly))
        {
            MethodInfo dm;

            Console.Write(m);
            Console.Write(" Interface Method: " + (dm = GetDeclaringMethod(m)));
            if (dm != null)
                Console.Write(" Interface: " + GetDeclaringMethod(m).DeclaringType);
            WriteLine();
        }
        _ = Console.ReadLine();
    }

    public static MethodInfo GetDeclaringMethod(MethodInfo m)
    {
        var t = m.DeclaringType;
        foreach (var i in t.GetInterfaces())
        {
            var map = t.GetInterfaceMap(i);
            for (var j = 0; j < map.TargetMethods.Length; j++)
            {
                if (map.TargetMethods[j] == m)
                    return map.InterfaceMethods[j];
            }
        }
        return null;
    }
}

public class Bar: IBar
{
    void IFoo.A() => WriteLine("bar.a");

    void IBar.B() => WriteLine("bar.b");

    void IBar.C() => WriteLine("bar.c");

    //  void d() { }
}

public interface IFoo
{
    void A();
}

public interface IBar: IFoo
{
    void B();

    void C();
}
