' Essais d'E/S sur le FIleSystem avec System.IO
' 2006-10-01    PV  VS2005
' 2012-02-25	PV  VS2010

Public Class frmEssaisIO
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
    Friend WithEvents btnEssaisIO As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnEssaisIO = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnEssaisIO
        '
        Me.btnEssaisIO.Location = New System.Drawing.Point(200, 16)
        Me.btnEssaisIO.Name = "btnEssaisIO"
        Me.btnEssaisIO.TabIndex = 0
        Me.btnEssaisIO.Text = "Essais I/O"
        '
        'frmEssaisIO
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.btnEssaisIO)
        Me.Name = "frmEssaisIO"
        Me.Text = "Essais I/O"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnEssaisIO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEssaisIO.Click
        Dim fbm As System.IO.DirectoryInfo
        fbm = New System.IO.DirectoryInfo("C:\Music\MP3P\Eurovision")
        MsgBox("Nb fichiers: " & fbm.GetFiles.Length)
        For Each f As System.IO.FileInfo In fbm.GetFiles
            Debug.WriteLine(f.Name)
        Next
    End Sub
End Class

