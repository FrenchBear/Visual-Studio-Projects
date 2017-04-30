// Essais de l'interface Reflection
// D'après mail de Jayanth Rajan@MICROSOFT.COM du 9/1/2001
// Résultat du programe:
// Void ibar.c() Interface Method: Void c() Interface: ibar
// Void ibar.b() Interface Method: Void b() Interface: ibar
// Void ifoo.a() Interface Method: Void a() Interface: ifoo
// 2001-08-11   PV  Adapté Beta2
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010

using System;
using System.Reflection;

public class GetMemberMethodImpl
{
    public static void Main()
    {
        Type t = typeof(bar);
        foreach (MethodInfo m in t.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly))
        {
            MethodInfo dm;

            Console.Write(m);
            Console.Write(" Interface Method: " + (dm = GetDeclaringMethod(m)));
            if (dm != null)
                Console.Write(" Interface: " + GetDeclaringMethod(m).DeclaringType);
            Console.WriteLine();
        }
        Console.ReadLine();
    }

    public static MethodInfo GetDeclaringMethod(MethodInfo m)
    {
        Type t = m.DeclaringType;
        foreach (Type i in t.GetInterfaces())
        {
            InterfaceMapping map = t.GetInterfaceMap(i);
            for (int j = 0; j < map.TargetMethods.Length; j++)
            {
                if (map.TargetMethods[j] == m)
                {
                    return map.InterfaceMethods[j];
                }
            }
        }
        return null;
    }
}


public class bar : ibar
{
    void ifoo.a() { Console.WriteLine("bar.a"); }
    void ibar.b() { Console.WriteLine("bar.b"); }
    void ibar.c() { Console.WriteLine("bar.c"); }
    //  void d() { }
}

public interface ifoo
{
    void a();
}

public interface ibar : ifoo
{
    void b();
    void c();
}
