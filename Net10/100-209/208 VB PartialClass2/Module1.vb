' 2021-09-19 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
' 2026-01-19	PV		Net10

Friend Module Module1
    Public Sub Main()
        Dim v As New MaClasse With {
            .x = 1,
            .y = 2
        }
    End Sub

End Module

Partial Friend Class MaClasse
    Public x As Integer
End Class
