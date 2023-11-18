' ComboDoubleClic and just-on-time fill
' From http://www.dreamincode.net/forums/showtopic39350.htm
'
' 2008-05-11    PV
' 2012-02-25	PV		VS2010
' 2021-09-20 	PV		VS2022; Net6
' 2023-01-10	PV		Net7

Public Class Form1

    ' Record the last click with the current time
    Dim lastClick As Date = Now

    Private Sub ComboBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles ComboBox1.MouseClick
        ' Test if in the last time plus the milliseconds it takes for a double click
        ' there was another click, activate the code (there was a double click)
        If Now < lastClick.AddMilliseconds(SystemInformation.DoubleClickTime) Then

            ' Create our second form and show it modal
            Dim form As New Form2
            form.ShowDialog()

        End If

        ' Record the last click as now again
        lastClick = Now
    End Sub

    ' Just-in-time fill
    Private Sub ComboBox1_DropDown(sender As Object, e As EventArgs) Handles ComboBox1.DropDown
        If ComboBox1.Items.Count = 0 Then
            For i As Integer = 1 To 100
                ComboBox1.Items.Add(i.ToString)
            Next
        End If
    End Sub

End Class
