' 2012-02-25	PV		VS2010
' 2021-09-19 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
Imports System.IO

#Disable Warning IDE1006 ' Naming Styles

Public Class TestForm

    Private Sub TestForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim loc As String = "C:\Users\Pierr\OneDrive\PicturesODMisc\Animals\Dogs\Titus"
        lvNewDocuments.Items.Add(New ListViewItemDoc(loc + "\Photo 039.jpg"))
        lvNewDocuments.Items.Add(New ListViewItemDoc(loc + "\Photo 040.jpg"))
        lvNewDocuments.Items.Add(New ListViewItemDoc(loc + "\Photo 041.jpg"))
        lvNewDocuments.Items.Add(New ListViewItemDoc(loc + "\Photo 033.jpg"))
    End Sub

    Private Sub lvNewDocuments_DoubleClick(sender As Object, e As EventArgs) Handles lvNewDocuments.DoubleClick
        If lvNewDocuments.SelectedItems.Count <> 1 Then Exit Sub
        Dim ld As ListViewItemDoc
        ld = CType(lvNewDocuments.SelectedItems(0), ListViewItemDoc)

        Dim ed As New EditDoc With {
            .sPathName = ld.PathName
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
        Me.Text = Path.GetFileName(sPath)
        Me.SubItems.Add(FileLen(sPath).ToString)
        Me.SubItems.Add(FileDateTime(sPath).ToString)
    End Sub

    Public ReadOnly Property PathName() As String
        Get
            PathName = m_sPathName
        End Get
    End Property

End Class

Public Class EditDoc
    Public sPathName As String
End Class
