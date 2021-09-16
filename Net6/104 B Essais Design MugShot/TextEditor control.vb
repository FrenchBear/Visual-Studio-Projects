' TextEditor UserControl
' Text edit/view control
' 2006-04-13    PV  First version
' 2012-02-25	PV  VS2010

Option Compare Text

Public Class TextEditor
    Inherits GenericEditor

    ' Main entry point
    Public Overrides Sub DoEdit(ed As EditDoc)
        MyBase.DoEdit(ed)
        OpenDoc()
    End Sub

    ' Initial load of a clean document; also called on Revert action
    Private Sub OpenDoc()
        txtText.Text = My.Computer.FileSystem.ReadAllText(m_doc.sPathName)
        txtText.SelectionStart = txtText.Text.Length
        m_bDirty = False
        RefreshToolBar()
    End Sub

    ' Centralized ToolBar management
    Private Sub RefreshToolBar()
        If m_doc Is Nothing Then
            tsbSave.Enabled = False
            tsbRevertToSaved.Enabled = False
            tsbPrint.Enabled = False
        Else
            tsbSave.Enabled = m_bDirty
            tsbRevertToSaved.Enabled = m_bDirty
            tsbPrint.Enabled = Not m_bDirty
        End If
        tsMain.Refresh()
    End Sub

    ' Initial load, when no document is displayed
    Private Sub TextEditor_Load(sender As Object, e As EventArgs) Handles Me.Load
        RefreshToolBar()
    End Sub

    Private Sub tsbRevertToSaved_Click(sender As System.Object, e As EventArgs) Handles tsbRevertToSaved.Click
        OpenDoc()
    End Sub

    Private Sub tsbSave_Click(sender As System.Object, e As EventArgs) Handles tsbSave.Click
        My.Computer.FileSystem.WriteAllText(m_doc.sPathName, txtText.Text, False)
        m_bDirty = False
        RefreshToolBar()
    End Sub

    Private Sub txtText_TextChanged(sender As System.Object, e As EventArgs) Handles txtText.TextChanged
        If Not m_bDirty Then
            m_bDirty = True
            RefreshToolBar()
        End If
    End Sub

    Private Sub tsbPrint_Click(sender As System.Object, e As EventArgs) Handles tsbPrint.Click
        If m_bDirty Then
            MsgBox("Printing a modified file is not supported." & vbCrLf &
                   "Save file, or revert changes before printing.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        ShellPrint()
    End Sub

End Class