' 2012-02-25	PV		VS2010
' 2021-09-19 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
' 2026-01-19	PV		Net10
Imports System.IO

#Disable Warning IDE1006 ' Naming Styles

Public Class frmTest

    Private Sub frmTest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim loc As String = "C:\Users\Pierr\OneDrive\PicturesODMisc\Animals\Dogs\Titus"
        lvNewDocuments.Items.Add(New ListViewItemDoc(loc + "\Photo 039.jpg"))
        lvNewDocuments.Items.Add(New ListViewItemDoc(loc + "\Photo 040.jpg"))
        lvNewDocuments.Items.Add(New ListViewItemDoc(loc + "\Photo 041.jpg"))
        lvNewDocuments.Items.Add(New ListViewItemDoc(loc + "\Photo 033.jpg"))
        lvNewDocuments.Items.Add(New ListViewItemDoc("C:\Users\Pierr\OneDrive\Eurofins J3ZG 2018\Eurofins Docs\USA\Visit to Des Moines in 2003-12\Documents US\Green Card.pdf"))
        lvNewDocuments.Items.Add(New ListViewItemDoc("C:\Development\Icons\Office 2016 icons\ImageMSO2016\License.txt"))
    End Sub

    Public WithEvents ge As GenericEditor

    Private Sub lvNewDocuments_Click(sender As Object, e As EventArgs) Handles lvNewDocuments.Click
        '    Private Sub lvNewDocuments_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvNewDocuments.DoubleClick
        If lvNewDocuments.SelectedItems.Count <> 1 Then Exit Sub
        Dim ld As ListViewItemDoc
        ld = CType(lvNewDocuments.SelectedItems(0), ListViewItemDoc)

        Dim ed As New EditDoc With {
            .sPathName = ld.PathName
        }

        ge = Nothing
        Select Case Path.GetExtension(ed.sPathName)
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

        If ge IsNot Nothing Then
            ge.Dock = DockStyle.Fill
            ge.Visible = True
            ge.DoEdit(ed)
        End If
    End Sub

    Public Sub ge_DirtyChanged() Handles ge.DirtyChanged
        'MsgBox("Dirty: " & ge.m_bDirty)
        gbNewDocuments.Enabled = Not ge.m_bDirty
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        OpenFileDialog1.CheckFileExists = True
        OpenFileDialog1.Filter = "All files (*.*)|*.*"
        OpenFileDialog1.FilterIndex = 1
        OpenFileDialog1.RestoreDirectory = True
        OpenFileDialog1.FileName = ""
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            lvNewDocuments.Items.Add(New ListViewItemDoc(OpenFileDialog1.FileName))
        End If
    End Sub

End Class

Friend Class ListViewItemDoc
    Inherits ListViewItem

    Private ReadOnly m_sPathName

    Public Sub New(sPath As String)
        m_sPathName = sPath
        Text = Path.GetFileName(sPath)
        SubItems.Add(FileLen(sPath).ToString)
        SubItems.Add(FileDateTime(sPath).ToString)
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
