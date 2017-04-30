Imports CDemoLib

Public Class Form1

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.Text = "CDemo instances: " & CDemo.InstanceCount
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim cd As CDemo
        Dim ct As Integer
        For ct = 1 To 10000
            cd = New CDemo
        Next
    End Sub
End Class
