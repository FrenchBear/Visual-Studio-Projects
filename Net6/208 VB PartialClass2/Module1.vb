﻿Module Module1

    Sub Main()
        Dim v As MaClasse = New MaClasse With {
            .x = 1,
            .y = 2
        }

        Console.Write("(Pause)")
        Console.ReadLine()
    End Sub

End Module

Partial Class MaClasse
    Public x As Integer
End Class