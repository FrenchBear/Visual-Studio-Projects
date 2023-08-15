' Essais sur la classe String
'
' 2001-01-28    PV
' 2006-10-01 	PV		VS2005
' 2012-02-25	PV		VS2010
' 2021-09-18 	PV		VS2022, Net6
' 2023-01-10	PV		Net7

Module TestsSurString

    Sub Main()

        Dim s, t, u, v, w, x As String

        s = "  espaces autour  "
        t = s.Trim()
        u = ("où ça ?").ToUpper()
        v = ("SILLIKER").ToLower()
        w = ("Bonjour").PadRight(30, CType("*", Char))
        x = String.Concat("Il ", "était ", "une ", "fois...")

        WriteLine("s: ""{0}""", s)
        WriteLine("t: ""{0}""", t)
        WriteLine("u: ""{0}""", u)
        WriteLine("v: ""{0}""", v)
        WriteLine("w: ""{0}""", w)
        WriteLine("x: ""{0}""", x)

        Dim p As Integer
        p = x.IndexOf("une")
        WriteLine("x.IndexOf(""une""): {0}", p)
        p = x.IndexOf("Une")
        WriteLine("x.IndexOf(""Une""): {0}", p)

        Console.ReadLine()
    End Sub

End Module
