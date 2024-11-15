' 2006-10-01 	PV		VS2005
' 2012-02-25	PV		VS2010
' 2021-09-19 	PV		VS2022, Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9

Imports System.ComponentModel
Imports Scripting

#Disable Warning IDE1006 ' Naming Styles

Public Class Form1
    Inherits Form

#Region " Code généré par le Concepteur Windows Form "

    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()

    End Sub

    'La méthode substituée Dispose du formulaire pour nettoyer la liste des composants.
    Protected Overloads Overrides Sub Dispose(disposing As Boolean)
        If disposing Then
            components?.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requis par le Concepteur Windows Form
    Private ReadOnly components As IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée en utilisant le Concepteur Windows Form.
    'Ne la modifiez pas en utilisant l'éditeur de code.
    Friend WithEvents Button1 As Button

    <DebuggerStepThrough()> Private Sub InitializeComponent()
        Button1 = New Button()
        SuspendLayout()
        '
        'Button1
        '
        Button1.Location = New Point(280, 16)
        Button1.Name = "Button1"
        Button1.TabIndex = 0
        Button1.Text = "Button1"
        '
        'Form1
        '
        AutoScaleBaseSize = New Size(5, 13)
        ClientSize = New Size(368, 302)
        Controls.AddRange(New Control() {Button1})
        Name = "Form1"
        Text = "Form1"
        ResumeLayout(False)

    End Sub

#End Region

    Private ReadOnly fs As New FileSystemObject()

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Debug.AutoFlush = True
        Debug.WriteLine("Début")
        Analyse("C:\Documents")
        Debug.WriteLine("Fin")
    End Sub

    Public Sub Analyse(sPath As String)
        Dim fo As Folder
        fo = fs.GetFolder(sPath)

        Dim sf As Folder
        For Each sf In fo.SubFolders
            Analyse(sf.Path)
        Next

        Dim fi As File
        For Each fi In fo.Files
            If Len(fi.Name) > 64 Then
                Debug.WriteLine("ren """ & sPath & "\" & fi.Name & """ """ & m64(fi.Name) & """")
            End If
        Next
    End Sub

    Private Function m64(s As String) As String
        Dim p As Integer
        p = InStrRev(s, ".")
        Return Microsoft.VisualBasic.Left(s, 64 - (Len(s) - p + 1)) & Mid(s, p)
    End Function

End Class
