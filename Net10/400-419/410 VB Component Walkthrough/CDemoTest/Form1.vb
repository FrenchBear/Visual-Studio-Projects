' 2021-09-23 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
' 2026-01-19	PV		Net10


Imports CDemoLib

Public Class Form1

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Text = "CDemo instances: " & CDemo.InstanceCount
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim cd As CDemo
        Dim ct As Integer
        For ct = 1 To 10000
            cd = New CDemo
        Next
    End Sub

End Class
