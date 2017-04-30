using System;

class GlobalClass
{
    class NestedClass
    {

    }

    public class PublicNestedClass
    {

    }

    internal class InternalNestedClass
    {

    }

    protected class ProtectedNestedClass
    {

    }

    protected internal class ProtectedInternalNestedClass
    {

    }

    private class PrivateNestedClass
    {

    }



    public GlobalClass()
    {

    }

    static GlobalClass()
    {
        Console.WriteLine("Constructeur statique de GlobalClass");
    }




    public static void Main(string[] arg)
    {

    }



    static void MySub(int i)
    {

    }


    static void MySub(out int i)
    {
        i = 0;
    }

}

