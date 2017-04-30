' 2012-02-25	PV  VS2010

Public Class frmTest
    Private Sub frmTest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lvNewDocuments.Items.Add(New ListViewItemDoc("C:\Pictures\Titus\Photo 039.jpg"))
        lvNewDocuments.Items.Add(New ListViewItemDoc("C:\Pictures\Titus\Photo 040.jpg"))
        lvNewDocuments.Items.Add(New ListViewItemDoc("C:\Pictures\Titus\Photo 041.jpg"))
        lvNewDocuments.Items.Add(New ListViewItemDoc("C:\Pictures\Titus\Photo 042.jpg"))
        lvNewDocuments.Items.Add(New ListViewItemDoc("C:\Documents\Eurofins\USA\Visit to Des Moines in 2003-12\Documents US\Green Card.pdf"))
        lvNewDocuments.Items.Add(New ListViewItemDoc("C:\Documents\Eurofins\Italy\Systems.txt"))
    End Sub


    Dim WithEvents ge As GenericEditor

    Private Sub lvNewDocuments_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvNewDocuments.Click
        '    Private Sub lvNewDocuments_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvNewDocuments.DoubleClick
        If lvNewDocuments.SelectedItems.Count <> 1 Then Exit Sub
        Dim ld As ListViewItemDoc
        ld = CType(lvNewDocuments.SelectedItems(0), ListViewItemDoc)

        Dim ed As New EditDoc
        ed.sPathName = ld.sPathName

        ge = Nothing
        Select Case System.IO.Path.GetExtension(ed.sPathName)
            Case ".jpg"
                myTextEditor.Visible = False
                myPDFEditor.Visible = False
                ge = myImageEditor
            Case ".txt"
                myImageEditor.Visible = False
                myPDFEditor.Visible = False
                ge = myTextEditor
            Case ".pdf"
                myTextEditor.Visible = False
                myImageEditor.Visible = False
                ge = myPDFEditor
            Case Else
                MsgBox("Type de fichier inconnu:" & vbCrLf & ed.sPathName)
        End Select

        If Not ge Is Nothing Then
            ge.Dock = DockStyle.Fill
            ge.Visible = True
            ge.DoEdit(ed)
        End If
    End Sub

    Public Sub ge_DirtyChanged() Handles ge.DirtyChanged
        'MsgBox("Dirty: " & ge.m_bDirty)
        gbNewDocuments.Enabled = Not ge.m_bDirty
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        OpenFileDialog1.CheckFileExists = True
        OpenFileDialog1.Filter = "All files (*.*)|*.*"
        OpenFileDialog1.FilterIndex = 1
        OpenFileDialog1.RestoreDirectory = True
        OpenFileDialog1.FileName = ""
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            lvNewDocuments.Items.Add(New ListViewItemDoc(OpenFileDialog1.FileName))
        End If
    End Sub

End Class


Class ListViewItemDoc
    Inherits Windows.Forms.ListViewItem

    Private m_sPathName

    Public Sub New(ByVal sPath As String)
        m_sPathName = sPath
        Me.Text = System.IO.Path.GetFileName(sPath)
        Me.SubItems.Add(FileLen(sPath).ToString)
        Me.SubItems.Add(FileDateTime(sPath).ToString)
    End Sub

    Public ReadOnly Property sPathName() As String
        Get
            sPathName = m_sPathName
        End Get
    End Property
End Class

Public Class EditDoc
    Public sPathName As String
End Class