' 041 VB Enumerator
' Essai d'utilisation d'un énumérateur en VB
' 2001-02-18    PV
' 2006-10-01    PV  VS2005
' 2012-02-25	PV  VS2010  Il faudra attendre VS2011 pour yield return!

Module Module1

    Sub Main()
        Dim t1 As New TroisEntiers(1, 2, 3)

        Dim i As Integer
        For Each i In t1
            Console.WriteLine(i)
        Next

        Console.ReadLine()
    End Sub

End Module
