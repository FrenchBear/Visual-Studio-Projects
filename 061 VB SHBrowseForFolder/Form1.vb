' 61 VB SHBrowseForFolder
' Essais pour retouver la fonction en environnement .NET
' Complètement empirique...
' Et incomplet, on ne sait pas préciser le dossier de départ
' See: http://www.vbaccelerator.com/home/net/code/libraries/Shell_Projects/Folder_Browser/article.asp
' 2001-08-19    PV
' 2006-10-01    PV  VS2005
' 2012-02-25	PV  VS2010


Imports System.Windows.Forms.Design


Public Class frmTest
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents txtPath As System.Windows.Forms.TextBox

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtPath = New System.Windows.Forms.TextBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtPath
        '
        Me.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.txtPath.Location = New System.Drawing.Point(8, 8)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.Size = New System.Drawing.Size(280, 20)
        Me.txtPath.TabIndex = 0
        Me.txtPath.Text = "C:\"
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(8, 36)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.TabIndex = 1
        Me.btnBrowse.Text = "Browse"
        '
        'frmTest
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnBrowse, Me.txtPath})
        Me.Name = "frmTest"
        Me.Text = "Test SHBrowseForFolder"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        Dim b As New MyBrowser()
        txtPath.Text = b.Browse()
    End Sub
End Class


Class MyBrowser
    Inherits FolderNameEditor

    Function Browse() As String
        Dim b As New FolderBrowser()
        b.Description = "Sélectionnez le répertoire"
        b.Style = FolderNameEditor.FolderBrowserStyles.RestrictToFilesystem
        'b.StartLocation = FolderNameEditor.FolderBrowserFolder.Desktop
        b.StartLocation = FolderNameEditor.FolderBrowserFolder.MyComputer
        b.ShowDialog()
        Return b.DirectoryPath
    End Function
End Class

