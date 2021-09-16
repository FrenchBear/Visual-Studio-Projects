' Essais sur la classe String
' 2001-01-28    PV
' 2006-10-01    PV  VS2005
' 2012-02-25	PV  VS2010

Module TestsSurString

    Sub Main()

        Dim s, t, u, v, w, x As String

        s = "  espaces autour  "
        t = s.Trim()
        u = ("o� �a ?").ToUpper()
        v = ("SILLIKER").ToLower()
        w = ("Bonjour").PadRight(30, CType("*", Char))
        x = String.Concat("Il ", "�tait ", "une ", "fois...")

        Console.WriteLine("s: ""{0}""", s)
        Console.WriteLine("t: ""{0}""", t)
        Console.WriteLine("u: ""{0}""", u)
        Console.WriteLine("v: ""{0}""", v)
        Console.WriteLine("w: ""{0}""", w)
        Console.WriteLine("x: ""{0}""", x)

        Dim p As Integer
        p = x.IndexOf("une")
        Console.WriteLine("x.IndexOf(""une""): {0}", p)
        p = x.IndexOf("Une")
        Console.WriteLine("x.IndexOf(""Une""): {0}", p)

        Console.ReadLine()
    End Sub

End Module