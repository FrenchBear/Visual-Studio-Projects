Module Module1
    Sub Main()
        Dim v As maClasse = New maClasse
        v.x = 1
        v.y = 2

        Console.Write("(Pause)")
        Console.ReadLine()
    End Sub
End Module


Partial Class maClasse
    Public x As Integer
End Class

