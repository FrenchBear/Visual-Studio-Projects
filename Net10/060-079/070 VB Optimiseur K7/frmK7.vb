' 2006-10-01 	PV		VS2005
' 2012-02-25	PV		VS2010
' 2021-09-19 	PV		VS2022, Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
' 2026-01-19	PV		Net10

Imports System.ComponentModel
Imports System.IO

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
    Friend WithEvents Label1 As Label

    Friend WithEvents txtFichierPLS As TextBox
    Friend WithEvents btnRecherche As Button
    Friend WithEvents btnLire As Button
    Friend WithEvents lvFichiers As ListView
    Friend WithEvents colDurée As ColumnHeader
    Friend WithEvents colFichier As ColumnHeader

    <DebuggerStepThrough()> Private Sub InitializeComponent()
        Label1 = New Label()
        txtFichierPLS = New TextBox()
        btnRecherche = New Button()
        btnLire = New Button()
        lvFichiers = New ListView()
        colFichier = New ColumnHeader()
        colDurée = New ColumnHeader()
        SuspendLayout()
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New Point(8, 8)
        Label1.Name = "Label1"
        Label1.Size = New Size(65, 13)
        Label1.TabIndex = 0
        Label1.Text = "Fichier .pls :"
        '
        'txtFichierPLS
        '
        txtFichierPLS.Location = New Point(8, 24)
        txtFichierPLS.Name = "txtFichierPLS"
        txtFichierPLS.Size = New Size(288, 20)
        txtFichierPLS.TabIndex = 1
        txtFichierPLS.Text = "C:\pl.pls"
        '
        'btnRecherche
        '
        btnRecherche.Location = New Point(304, 24)
        btnRecherche.Name = "btnRecherche"
        btnRecherche.Size = New Size(24, 23)
        btnRecherche.TabIndex = 2
        btnRecherche.Text = "..."
        '
        'btnLire
        '
        btnLire.Location = New Point(8, 56)
        btnLire.Name = "btnLire"
        btnLire.Size = New Size(104, 23)
        btnLire.TabIndex = 3
        btnLire.Text = "Lire le fichier .pls"
        '
        'lvFichiers
        '
        lvFichiers.Columns.AddRange(New ColumnHeader() {colFichier, colDurée})
        lvFichiers.GridLines = True
        lvFichiers.Location = New Point(8, 88)
        lvFichiers.Name = "lvFichiers"
        lvFichiers.Size = New Size(320, 424)
        lvFichiers.TabIndex = 4
        lvFichiers.View = View.Details
        '
        'colFichier
        '
        colFichier.Text = "Fichier"
        colFichier.Width = 220
        '
        'colDurée
        '
        colDurée.Text = "Durée"
        '
        'Form1
        '
        AutoScaleBaseSize = New Size(5, 13)
        ClientSize = New Size(760, 526)
        Controls.AddRange(New Control() {lvFichiers, btnLire, btnRecherche, txtFichierPLS, Label1})
        Name = "Form1"
        Text = "Form1"
        ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnLire_Click(sender As Object, e As EventArgs) Handles btnLire.Click

        Dim sr As StreamReader
        Dim er As Exception

        Try
            sr = File.OpenText(txtFichierPLS.Text)
        Catch er
            MsgBox("Echec à l'ouverture du fichier '" & txtFichierPLS.Text & "'" & Chr(13) & er.Source & ": " & er.Message, MsgBoxStyle.Exclamation)
            Exit Sub
        End Try

        Dim l As String
        Dim lvi As ListViewItem = Nothing

        Do
            l = sr.ReadLine()
            If l Is Nothing Then Exit Do

            If l.Substring(1, 4) = "File" Then
                Dim p As Integer
                p = l.IndexOf("="c)
                lvi = lvFichiers.Items.Add(l.Substring(p + 1))
            End If

            If l.Substring(1, 6) = "Length" Then
                Dim p As Integer
                p = l.IndexOf("="c)
                lvi.SubItems(1).Text = l.Substring(p + 1)
            End If
        Loop

        sr.Close()

        ' On vérifie qu'on a toutes les durées
        For Each lvi In lvFichiers.Items
            If lvi.SubItems(1).Text = "" Then
                MsgBox("Manque une durée, seuls les fichiers .pls avec l'ensemble des durées sont pris en compte.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
        Next

        MsgBox("Fichier Ok")

    End Sub

End Class
