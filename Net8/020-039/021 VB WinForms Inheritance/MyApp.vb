' 21 VB Héritage visuel
' Essais d'héritage d'une feuille en VB
'
' 2001-01-27    PV
' 2012-02-25	PV		VS2010
' 2021-09-18 	PV		VS2022, Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8

Class MyApp

    Public Shared Sub Main()
        Dim m2 As New MyMsgBox2()
        m2.Info("Information quelconque affichée avec MyMsgBox2")
        Dim m3 As New MyMsgBox3()
        m3.Info("Z112", "Info plus spécialisée affichée avec MyMsgBox3")
    End Sub

End Class
