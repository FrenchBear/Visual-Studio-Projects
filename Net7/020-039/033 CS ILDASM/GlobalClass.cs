using static System.Console;

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

    static GlobalClass() => WriteLine("Constructeur statique de GlobalClass");

    public static void ClassMain(string[] arg)
    {
    }

    private static void MySub(int i)
    {
    }

    private static void MySub(out int i) => i = 0;
}