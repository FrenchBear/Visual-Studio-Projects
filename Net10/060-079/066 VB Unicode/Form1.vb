' 2006-10-01 	PV		VS2005
' 2012-02-25	PV		VS2010
' 2021-09-19 	PV		VS2022, Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
' 2026-01-19	PV		Net10

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim buf As String
        buf = "Hel" & ChrW(&H142S) & "o " & ChrW(&H3B1S) & ChrW(&H3B2S) & ChrW(&H3B3S) & ChrW(&H3B4S)
        TextBox1.Text = buf
        mnuFichier.Text = buf
    End Sub

    Private Sub QuitterCommand_Click(sender As Object, e As EventArgs) Handles QuitterCommand.Click
        Close()
    End Sub
End Class
