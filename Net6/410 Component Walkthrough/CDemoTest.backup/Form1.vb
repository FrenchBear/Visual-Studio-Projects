Imports CDemoLib

Public Class Form1

    Private Sub Timer1_Tick(sender As System.Object, e As EventArgs) Handles Timer1.Tick
        Me.Text = "CDemo instances: " & CDemo.InstanceCount
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As EventArgs) Handles Button1.Click
        Dim cd As CDemo
        Dim ct As Integer
        For ct = 1 To 10000
            cd = New CDemo
        Next
    End Sub

End Class