' 2012-02-25	PV		VS2010
' 2021-09-19 	PV		VS2022; Net6
' 2021-09-19 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
' 2026-01-19	PV		Net10

Public Class Toto
    Protected k As Long

    Public Sub Zap()
        RaiseEvent e1()
    End Sub

    Private Sub Toto_e1() Handles Me.e1
        MsgBox("Toto_e1")
        RaiseEvent e1()         ' pas bien !!!
    End Sub

End Class
