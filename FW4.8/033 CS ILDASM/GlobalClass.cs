using System;

#pragma warning disable IDE0051 // Remove unused private members

internal class GlobalClass
{
    private class NestedClass
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

    static GlobalClass() => Console.WriteLine("Constructeur statique de GlobalClass");

    public static void Main(string[] arg)
    {
    }

    private static void MySub(int i)
    {
    }

    private static void MySub(out int i) => i = 0;
}