' Essais pour regarder quel code génère un dim xxx as new
' Conclusion: contrairement au VB6, un dim new instancie immédiatement
' et l'instanciation n'est pas recréée automatiquement à chaque utilisation
'
' 2001-02-21    PV
' 2006-10-01    PV  VS2005
' 2012-02-25	PV  VS2010
' 2021-09-18    PV  VS2022, Net6
' 2023-01-10	PV		Net7

Module Module1

    Sub Main()
        WriteLine("Début")

        Dim s As New Stack()

        s.Push(1)
        s.Push(2)

        WriteLine("avant s=Nothing")
        s = Nothing

        s.Push(1)
        s.Push(2)

        WriteLine("Fin")
    End Sub

End Module
