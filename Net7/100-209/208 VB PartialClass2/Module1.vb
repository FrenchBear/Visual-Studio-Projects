' 2021-09-19 	PV		VS2022; Net6
' 2023-01-10	PV		Net7

Module Module1

    Sub Main()
        Dim v As New MaClasse With {
            .x = 1,
            .y = 2
        }
    End Sub

End Module

Partial Class MaClasse
    Public x As Integer
End Class
