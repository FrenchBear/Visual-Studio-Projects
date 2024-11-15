' Essais d'E/S sur le FIleSystem avec System.IO
'
' 2006-10-01 	PV		VS2005
' 2012-02-25	PV		VS2010
' 2021-09-19 	PV		VS2022, Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
Imports System.ComponentModel
Imports System.IO

#Disable Warning IDE1006 ' Naming Styles


Public Class frmEssaisIO
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
    Friend WithEvents btnEssaisIO As Button

    <DebuggerStepThrough()> Private Sub InitializeComponent()
        btnEssaisIO = New Button
        SuspendLayout()
        '
        'btnEssaisIO
        '
        btnEssaisIO.Location = New Point(200, 16)
        btnEssaisIO.Name = "btnEssaisIO"
        btnEssaisIO.TabIndex = 0
        btnEssaisIO.Text = "Essais I/O"
        '
        'frmEssaisIO
        '
        AutoScaleBaseSize = New Size(5, 13)
        ClientSize = New Size(292, 266)
        Controls.Add(btnEssaisIO)
        Name = "frmEssaisIO"
        Text = "Essais I/O"
        ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnEssaisIO_Click(sender As Object, e As EventArgs) Handles btnEssaisIO.Click
        Dim fbm As DirectoryInfo
        fbm = New DirectoryInfo("C:\Music\MP3P\Eurovision")
        MsgBox("Nb fichiers: " & fbm.GetFiles.Length)
        For Each f As FileInfo In fbm.GetFiles
            Debug.WriteLine(f.Name)
        Next
    End Sub

End Class
