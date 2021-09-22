' 61 VB SHBrowseForFolder
' Essais pour retouver la fonction en environnement .NET
' Complètement empirique...
' Et incomplet, on ne sait pas préciser le dossier de départ
' See: http://www.vbaccelerator.com/home/net/code/libraries/Shell_Projects/Folder_Browser/article.asp
' 2001-08-19    PV
' 2006-10-01    PV  VS2005
' 2012-02-25	PV  VS2010
' 2021-09-19    PV  VS2022, Net6

Imports System.Windows.Forms.Design

#Disable Warning IDE1006 ' Naming Styles

Public Class frmTest
    Inherits Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    Friend WithEvents btnBrowse As Button
    Friend WithEvents txtPath As TextBox

    'Required by the Windows Form Designer
    Private ReadOnly components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtPath = New TextBox()
        Me.btnBrowse = New Button()
        Me.SuspendLayout()
        '
        'txtPath
        '
        Me.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.txtPath.Location = New Point(8, 8)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.Size = New Size(280, 20)
        Me.txtPath.TabIndex = 0
        Me.txtPath.Text = "C:\"
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New Point(8, 36)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.TabIndex = 1
        Me.btnBrowse.Text = "Browse"
        '
        'frmTest
        '
        Me.AutoScaleBaseSize = New Size(5, 13)
        Me.ClientSize = New Size(292, 273)
        Me.Controls.AddRange(New Control() {Me.btnBrowse, Me.txtPath})
        Me.Name = "frmTest"
        Me.Text = "Test SHBrowseForFolder"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Dim b As New MyBrowser()
        txtPath.Text = MyBrowser.Browse()
    End Sub

End Class

Class MyBrowser
    Inherits FolderNameEditor

    Shared Function Browse() As String
        'b.StartLocation = FolderNameEditor.FolderBrowserFolder.Desktop
        Dim b As New FolderBrowser With {
            .Description = "Sélectionnez le répertoire",
            .Style = FolderNameEditor.FolderBrowserStyles.RestrictToFilesystem,
            .StartLocation = FolderNameEditor.FolderBrowserFolder.MyComputer
        }
        b.ShowDialog()
        Return b.DirectoryPath
    End Function

End Class