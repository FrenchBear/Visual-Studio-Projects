' 2012-02-25	PV  VS2010

Public Class FrmTest

    Private Sub frmTest_Load(sender As System.Object, e As EventArgs) Handles MyBase.Load
        lvNewDocuments.Items.Add(New ListViewItemDoc("C:\Pictures\Titus\Photo 039.jpg"))
        lvNewDocuments.Items.Add(New ListViewItemDoc("C:\Pictures\Titus\Photo 040.jpg"))
        lvNewDocuments.Items.Add(New ListViewItemDoc("C:\Pictures\Titus\Photo 041.jpg"))
        lvNewDocuments.Items.Add(New ListViewItemDoc("C:\Pictures\Titus\Photo 042.jpg"))
    End Sub

    Private Sub lvNewDocuments_DoubleClick(sender As Object, e As EventArgs) Handles lvNewDocuments.DoubleClick
        If lvNewDocuments.SelectedItems.Count <> 1 Then Exit Sub
        Dim ld As ListViewItemDoc
        ld = CType(lvNewDocuments.SelectedItems(0), ListViewItemDoc)

        Dim ed As New EditDoc With {
            .sPathName = ld.sPathName
        }

        Dim f As New frmImageTool
        f.OpenEditDoc(ed)
    End Sub

End Class

Class ListViewItemDoc
    Inherits ListViewItem

    Private ReadOnly m_sPathName

    Public Sub New(sPath As String)
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