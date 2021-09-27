' 217 VB Layout Forms
'
' 2012-02-25	PV  VS2010
' 2021-09-19    PV  VS2022; Net6

Public Class FormMain

    Private Sub Button1_Click(sender As System.Object, e As EventArgs) Handles Button1.Click
        Dim x As New BasicDataEntryForm
        x.Show()
    End Sub

    Private Sub Button11_Click(sender As System.Object, e As EventArgs) Handles Button11.Click
        'Nop
    End Sub

    Private Sub Button7_Click(sender As System.Object, e As EventArgs) Handles Button7.Click
        Dim f2 As New Form2
        f2.Show()
    End Sub

End Class