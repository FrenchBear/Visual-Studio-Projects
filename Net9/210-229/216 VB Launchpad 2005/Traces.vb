' 2012-02-25	PV		VS2010
' 2021-09-19 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9

Partial Public Class LaunchpadForm
    Public Sub Trace(sMsg As String)
        ListBox1.SelectedIndex = ListBox1.Items.Add(sMsg)
    End Sub

End Class
