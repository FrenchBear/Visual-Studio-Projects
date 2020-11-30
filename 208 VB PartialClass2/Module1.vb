Module Module1
    Sub Main()
        Dim v As maClasse = New maClasse With {
            .x = 1,
            .y = 2
        }

        Console.Write("(Pause)")
        Console.ReadLine()
    End Sub
End Module


Partial Class maClasse
    Public x As Integer
End Class

