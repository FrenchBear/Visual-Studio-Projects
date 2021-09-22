' 21 VB Héritage visuel
' Essais d'héritage d'une feuille en VB
' 2001-01-27    PV
' 2012-02-25	PV  VS2010

Class MyApp

    Public Shared Sub Main()
        Dim m2 As New MyMsgBox2()
        m2.Info("Information quelconque affichée avec MyMsgBox2")
        Dim m3 As New MyMsgBox3()
        m3.Info("Z112", "Info plus spécialisée affichée avec MyMsgBox3")
    End Sub

End Class