' Essais d'E/S sur le FIleSystem avec System.IO
' 2006-10-01    PV  VS2005
' 2012-02-25	PV  VS2010

#Disable Warning IDE1006 ' Naming Styles

Public Class frmEssaisIO
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
    Friend WithEvents btnEssaisIO As Button

    <DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnEssaisIO = New Button
        Me.SuspendLayout()
        '
        'btnEssaisIO
        '
        Me.btnEssaisIO.Location = New Point(200, 16)
        Me.btnEssaisIO.Name = "btnEssaisIO"
        Me.btnEssaisIO.TabIndex = 0
        Me.btnEssaisIO.Text = "Essais I/O"
        '
        'frmEssaisIO
        '
        Me.AutoScaleBaseSize = New Size(5, 13)
        Me.ClientSize = New Size(292, 266)
        Me.Controls.Add(Me.btnEssaisIO)
        Me.Name = "frmEssaisIO"
        Me.Text = "Essais I/O"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnEssaisIO_Click(sender As System.Object, e As EventArgs) Handles btnEssaisIO.Click
        Dim fbm As IO.DirectoryInfo
        fbm = New IO.DirectoryInfo("C:\Music\MP3P\Eurovision")
        MsgBox("Nb fichiers: " & fbm.GetFiles.Length)
        For Each f As IO.FileInfo In fbm.GetFiles
            Debug.WriteLine(f.Name)
        Next
    End Sub

End Class