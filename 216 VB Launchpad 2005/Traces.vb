' 2012-02-25	PV  VS2010

Partial Class LaunchpadForm
    Sub Trace(ByVal sMsg As String)
        ListBox1.SelectedIndex = ListBox1.Items.Add(sMsg)
    End Sub

End Class
