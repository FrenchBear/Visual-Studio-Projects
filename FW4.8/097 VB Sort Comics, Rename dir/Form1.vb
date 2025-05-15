' Sort Comics
' Manipulation d'expressions r�gili�res et du filesystem
' 2004-07-14    PV
' 2006-10-01    PV  VS2005
' 2012-02-25	PV  VS2010

Imports System.IO
Imports System.Text.RegularExpressions

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
            components?.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requis par le Concepteur Windows Form
    Private ReadOnly components As System.ComponentModel.IContainer

    'REMARQUE�: la Procédure suivante est requise par le Concepteur Windows Form
    'Elle peut �tre modifi�e en utilisant le Concepteur Windows Form.
    'Ne la modifiez pas en utilisant l'�diteur de code.
    Friend WithEvents Button1 As Button

    Friend WithEvents Button2 As Button

    <DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button1 = New Button
        Me.Button2 = New Button
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New Point(24, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New Size(88, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Move Comics"
        '
        'Button2
        '
        Me.Button2.Location = New Point(24, 56)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New Size(88, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Rename dvpt"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New Size(5, 13)
        Me.ClientSize = New Size(292, 266)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Button1_Click(sender As System.Object, e As EventArgs) Handles Button1.Click
        Const sPath As String = "F:\Documents\comics"

        Dim diRoot As New DirectoryInfo(sPath)
        Dim nbFic, nbMatch, nbMove, nbDir As Integer
        Dim rePic As New Regex("^([a-z]+)[0-9]+\.(gif|jpg)$")
        For Each fi As FileInfo In diRoot.GetFiles
            nbFic += 1
            Dim m As Match = rePic.Match(fi.Name)
            If m.Success Then
                nbMatch += 1

                Dim sComics As String = m.Groups(1).ToString
                Dim diSub As DirectoryInfo
                Try
                    diSub = diRoot.GetDirectories(sComics)(0)
                Catch ex As Exception
                    nbDir += 1
                    diSub = diRoot.CreateSubdirectory(sComics)
                End Try
                fi.MoveTo(diSub.FullName & "\" & fi.Name)
                nbMove += 1
            End If
        Next
        MsgBox(nbFic & " fichiers trait�s" & vbCrLf & nbMatch & " images" & vbCrLf & nbMove & " d�placments" & vbCrLf & nbDir & " r�pertoires cr��s")
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As EventArgs) Handles Button2.Click
        Const sPath As String = "F:\Development\Visual Studio Projects\"

        Dim diRoot As New DirectoryInfo(sPath)
        Dim nbDir As Integer
        Dim reDir As New Regex("^[0-9]{2} .*")
        For Each sd As DirectoryInfo In diRoot.GetDirectories("*")
            If reDir.IsMatch(sd.Name) Then
                nbDir += 1
                Try
                    Directory.Move(sPath & sd.Name, sPath & "0" & sd.Name)
                Catch ex As Exception

                End Try
                'Debug.WriteLine(String.Format("{0}: {1}", nbDir, sd.Name))
            End If
        Next
        MsgBox(nbDir & " r�pertoires")
    End Sub

End Class