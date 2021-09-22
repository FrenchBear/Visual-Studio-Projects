' 2006-10-01    PV  VS2005
' 2012-02-25	PV  VS2010
' 2021-09-19    PV  VS2022, Net6

Imports Scripting

#Disable Warning IDE1006 ' Naming Styles

Public Class Form1
    Inherits Form

#Region " Code g�n�r� par le Concepteur Windows Form "

    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque apr�s l'appel InitializeComponent()

    End Sub

    'La m�thode substitu�e Dispose du formulaire pour nettoyer la liste des composants.
    Protected Overloads Overrides Sub Dispose(disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requis par le Concepteur Windows Form
    Private ReadOnly components As System.ComponentModel.IContainer

    'REMARQUE�: la proc�dure suivante est requise par le Concepteur Windows Form
    'Elle peut �tre modifi�e en utilisant le Concepteur Windows Form.
    'Ne la modifiez pas en utilisant l'�diteur de code.
    Friend WithEvents Button1 As Button

    <DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button1 = New Button()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New Point(280, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New Size(5, 13)
        Me.ClientSize = New Size(368, 302)
        Me.Controls.AddRange(New Control() {Me.Button1})
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    ReadOnly fs As New FileSystemObject()

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Debug.AutoFlush = True
        System.Diagnostics.Debug.WriteLine("D�but")
        Analyse("C:\Documents")
        System.Diagnostics.Debug.WriteLine("Fin")
    End Sub

    Sub Analyse(sPath As String)
        Dim fo As Folder
        fo = fs.GetFolder(sPath)

        Dim sf As Folder
        For Each sf In fo.SubFolders
            Analyse(sf.Path)
        Next

        Dim fi As File
        For Each fi In fo.Files
            If Len(fi.Name) > 64 Then
                System.Diagnostics.Debug.WriteLine("ren """ & sPath & "\" & fi.Name & """ """ & m64(fi.Name) & """")
            End If
        Next
    End Sub

    Private Function m64(s As String) As String
        Dim p As Integer
        p = InStrRev(s, ".")
        Return Microsoft.VisualBasic.Left(s, 64 - (Len(s) - p + 1)) & Mid(s, p)
    End Function

End Class