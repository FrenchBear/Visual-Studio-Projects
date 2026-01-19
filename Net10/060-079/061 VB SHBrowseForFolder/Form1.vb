' 61 VB SHBrowseForFolder
' Essais pour retouver la fonction en environnement .NET
' Complètement empirique...
' Et incomplet, on ne sait pas préciser le dossier de départ
' See: http://www.vbaccelerator.com/home/net/code/libraries/Shell_Projects/Folder_Browser/article.asp
'
' 2001-08-19    PV
' 2006-10-01 	PV		VS2005
' 2012-02-25	PV		VS2010
' 2021-09-19 	PV		VS2022, Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
' 2026-01-19	PV		Net10

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
            components?.Dispose()
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
        txtPath = New TextBox()
        btnBrowse = New Button()
        SuspendLayout()
        '
        'txtPath
        '
        txtPath.Anchor = AnchorStyles.Top Or AnchorStyles.Left _
                    Or AnchorStyles.Right
        txtPath.Location = New Point(8, 8)
        txtPath.Name = "txtPath"
        txtPath.Size = New Size(280, 20)
        txtPath.TabIndex = 0
        txtPath.Text = "C:\"
        '
        'btnBrowse
        '
        btnBrowse.Location = New Point(8, 36)
        btnBrowse.Name = "btnBrowse"
        btnBrowse.TabIndex = 1
        btnBrowse.Text = "Browse"
        '
        'frmTest
        '
        AutoScaleBaseSize = New Size(5, 13)
        ClientSize = New Size(292, 273)
        Controls.AddRange(New Control() {btnBrowse, txtPath})
        Name = "frmTest"
        Text = "Test SHBrowseForFolder"
        ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Dim b As New MyBrowser()
        txtPath.Text = MyBrowser.Browse()
    End Sub

End Class

Friend Class MyBrowser
    Inherits FolderNameEditor

    Public Shared Function Browse() As String
        'b.StartLocation = FolderNameEditor.FolderBrowserFolder.Desktop
        Dim b As New FolderBrowser With {
            .Description = "Sélectionnez le répertoire",
            .Style = FolderBrowserStyles.RestrictToFilesystem,
            .StartLocation = FolderBrowserFolder.MyComputer
        }
        b.ShowDialog()
        Return b.DirectoryPath
    End Function

End Class
