' 21 VB H�ritage visuel
' Essais d'h�ritage d'une feuille en VB
' 2001-01-27    PV
' 2012-02-25	PV  VS2010

Class MyApp

    Public Shared Sub Main()
        Dim m2 As New MyMsgBox2()
        m2.Info("Information quelconque affich�e avec MyMsgBox2")
        Dim m3 As New MyMsgBox3()
        m3.Info("Z112", "Info plus sp�cialis�e affich�e avec MyMsgBox3")
    End Sub

End Class