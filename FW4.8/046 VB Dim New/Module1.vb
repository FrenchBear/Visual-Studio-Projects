' Essais pour regarder quel code Génère un dim xxx as new
' Conclusion: contrairement au VB6, un dim new instancie imm�diatement
' et l'instanciation n'est pas recr��e automatiquement � chaque utilisation
' 2001-02-21    PV
' 2006-10-01    PV  VS2005
' 2012-02-25	PV  VS2010

Module Module1

    Sub Main()
        Console.WriteLine("D�but")

        Dim s As New Stack()

        s.Push(1)
        s.Push(2)

        Console.WriteLine("avant s=Nothing")
        s = Nothing

        s.Push(1)
        s.Push(2)

        Console.WriteLine("Fin")
    End Sub

End Module