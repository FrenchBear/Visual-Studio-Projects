﻿' Sort Comics
' Manipulation d'expressions régilières et du filesystem
'
' 2004-07-14    PV
' 2006-10-01 	PV		VS2005
' 2012-02-25	PV		VS2010
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9

Imports System.ComponentModel
Imports System.IO
Imports System.Text.RegularExpressions

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

    Friend WithEvents Button2 As Button

    <DebuggerStepThrough()> Private Sub InitializeComponent()
        Button1 = New Button
        Button2 = New Button
        SuspendLayout()
        '
        'Button1
        '
        Button1.Location = New Point(24, 16)
        Button1.Name = "Button1"
        Button1.Size = New Size(88, 23)
        Button1.TabIndex = 0
        Button1.Text = "Move Comics"
        '
        'Button2
        '
        Button2.Location = New Point(24, 56)
        Button2.Name = "Button2"
        Button2.Size = New Size(88, 23)
        Button2.TabIndex = 1
        Button2.Text = "Rename dvpt"
        '
        'Form1
        '
        AutoScaleBaseSize = New Size(5, 13)
        ClientSize = New Size(292, 266)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Name = "Form1"
        Text = "Form1"
        ResumeLayout(False)

    End Sub

#End Region

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
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
        MsgBox(nbFic & " fichiers traités" & vbCrLf & nbMatch & " images" & vbCrLf & nbMove & " déplacments" & vbCrLf & nbDir & " répertoires créés")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
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
        MsgBox(nbDir & " répertoires")
    End Sub

End Class
