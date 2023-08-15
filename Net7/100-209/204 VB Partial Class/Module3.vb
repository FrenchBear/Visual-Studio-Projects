' 2012-02-25	PV		VS2010
' 2021-09-19 	PV		VS2022; Net6
' 2021-09-19 	PV		VS2022; Net6
' 2023-01-10	PV		Net7

Class Toto
    Protected k As Long

    Sub Zap()
        RaiseEvent e1()
    End Sub

    Private Sub Toto_e1() Handles Me.e1
        MsgBox("Toto_e1")
        RaiseEvent e1()         ' pas bien !!!
    End Sub

End Class
