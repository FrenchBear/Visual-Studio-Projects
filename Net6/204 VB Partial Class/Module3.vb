' 2012-02-25	PV  VS2010

Class Toto
    Protected k As Long

    Sub zap()
        RaiseEvent e1()
    End Sub

    Private Sub Toto_e1() Handles Me.e1
        MsgBox("Toto_e1")
        RaiseEvent e1()         ' pas bien !!!
    End Sub

End Class