' 2006-10-01    PV  VS2005
' 2012-02-25	PV  VS2010

Imports System.IO

Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Code généré par le Concepteur Windows Form "

    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()

    End Sub

    'La méthode substituée Dispose du formulaire pour nettoyer la liste des composants.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requis par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée en utilisant le Concepteur Windows Form.  
    'Ne la modifiez pas en utilisant l'éditeur de code.
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFichierPLS As System.Windows.Forms.TextBox
    Friend WithEvents btnRecherche As System.Windows.Forms.Button
    Friend WithEvents btnLire As System.Windows.Forms.Button
    Friend WithEvents lvFichiers As System.Windows.Forms.ListView
    Friend WithEvents colDurée As System.Windows.Forms.ColumnHeader
    Friend WithEvents colFichier As System.Windows.Forms.ColumnHeader
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFichierPLS = New System.Windows.Forms.TextBox()
        Me.btnRecherche = New System.Windows.Forms.Button()
        Me.btnLire = New System.Windows.Forms.Button()
        Me.lvFichiers = New System.Windows.Forms.ListView()
        Me.colFichier = New System.Windows.Forms.ColumnHeader()
        Me.colDurée = New System.Windows.Forms.ColumnHeader()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fichier .pls :"
        '
        'txtFichierPLS
        '
        Me.txtFichierPLS.Location = New System.Drawing.Point(8, 24)
        Me.txtFichierPLS.Name = "txtFichierPLS"
        Me.txtFichierPLS.Size = New System.Drawing.Size(288, 20)
        Me.txtFichierPLS.TabIndex = 1
        Me.txtFichierPLS.Text = "C:\pl.pls"
        '
        'btnRecherche
        '
        Me.btnRecherche.Location = New System.Drawing.Point(304, 24)
        Me.btnRecherche.Name = "btnRecherche"
        Me.btnRecherche.Size = New System.Drawing.Size(24, 23)
        Me.btnRecherche.TabIndex = 2
        Me.btnRecherche.Text = "..."
        '
        'btnLire
        '
        Me.btnLire.Location = New System.Drawing.Point(8, 56)
        Me.btnLire.Name = "btnLire"
        Me.btnLire.Size = New System.Drawing.Size(104, 23)
        Me.btnLire.TabIndex = 3
        Me.btnLire.Text = "Lire le fichier .pls"
        '
        'lvFichiers
        '
        Me.lvFichiers.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colFichier, Me.colDurée})
        Me.lvFichiers.GridLines = True
        Me.lvFichiers.Location = New System.Drawing.Point(8, 88)
        Me.lvFichiers.Name = "lvFichiers"
        Me.lvFichiers.Size = New System.Drawing.Size(320, 424)
        Me.lvFichiers.TabIndex = 4
        Me.lvFichiers.View = System.Windows.Forms.View.Details
        '
        'colFichier
        '
        Me.colFichier.Text = "Fichier"
        Me.colFichier.Width = 220
        '
        'colDurée
        '
        Me.colDurée.Text = "Durée"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(760, 526)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lvFichiers, Me.btnLire, Me.btnRecherche, Me.txtFichierPLS, Me.Label1})
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnLire_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLire.Click

        Dim sr As IO.StreamReader
        Dim er As System.Exception

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
                p = l.IndexOf("=")
                lvi = lvFichiers.Items.Add(l.Substring(p + 1))
            End If

            If l.Substring(1, 6) = "Length" Then
                Dim p As Integer
                p = l.IndexOf("=")
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
