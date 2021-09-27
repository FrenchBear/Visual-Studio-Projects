' 2012-02-25	PV  VS2010
' 2021-09-19    PV  VS2022; Net6

Partial Class LaunchpadForm

    Sub Trace(sMsg As String)
        ListBox1.SelectedIndex = ListBox1.Items.Add(sMsg)
    End Sub

End Class