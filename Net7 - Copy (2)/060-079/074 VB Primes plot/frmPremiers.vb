' PV 2003
' 2006-10-01    PV  VS2005
' 2012-02-25	PV  VS2010
' 2021-09-19    PV  VS2022, Net6
Imports System.ComponentModel
Imports System.Drawing.Imaging

#Disable Warning IDE1006 ' Naming Styles


Public Class frmPremiers
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
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requis par le Concepteur Windows Form
    Private ReadOnly components As IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée en utilisant le Concepteur Windows Form.
    'Ne la modifiez pas en utilisant l'éditeur de code.

    Friend WithEvents btnCrible As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents StatusBar1 As ToolStripStatusLabel
    Friend WithEvents Panel1 As Panel

    <DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnCrible = New Button()
        Me.Panel1 = New Panel()
        Me.StatusStrip1 = New StatusStrip()
        Me.StatusBar1 = New ToolStripStatusLabel()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCrible
        '
        Me.btnCrible.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.btnCrible.Location = New Point(416, 20)
        Me.btnCrible.Name = "btnCrible"
        Me.btnCrible.Size = New Size(180, 56)
        Me.btnCrible.TabIndex = 0
        Me.btnCrible.Text = "Crible"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) _
            Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.Panel1.BackColor = Color.RosyBrown
        Me.Panel1.Location = New Point(19, 20)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New Size(377, 461)
        Me.Panel1.TabIndex = 2
        Me.Panel1.Visible = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New Size(32, 32)
        Me.StatusStrip1.Items.AddRange(New ToolStripItem() {Me.StatusBar1})
        Me.StatusStrip1.Location = New Point(0, 552)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New Size(608, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'StatusBar1
        '
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Size = New Size(593, 12)
        Me.StatusBar1.Spring = True
        '
        'frmPremiers
        '
        Me.AutoScaleBaseSize = New Size(12, 32)
        Me.ClientSize = New Size(608, 574)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnCrible)
        Me.Name = "frmPremiers"
        Me.Text = "Nombres premiers visuels"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Const n As Integer = 1585 * 1006      ' 1184 * 892
    ReadOnly t As New BitArray(n + 1)

    Dim bResizeEnCours As Boolean = False

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnCrible.Click
        t.SetAll(1)
        Dim ti As Double
        ti = DateAndTime.Timer

        Dim i As Integer
        Dim ns2 As Integer = n \ 2 + 1
        i = 2
        Do While i <= ns2
            If t(i) Then
                'StatusBar1.Text = Str(i)
                'StatusBar1.Refresh()
                For j As Integer = 2 * i To n Step i
                    t(j) = False
                Next
            End If
            If i = 2 Then
                i = 3
            Else
                i += 2
            End If
        Loop

        ti = DateAndTime.Timer - ti
        StatusBar1.Text = "Terminé, t=" & FormatNumber(ti, 1) & "s"
        Me.Refresh()
    End Sub

    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        Dim myBitmap As New Bitmap(Panel1.Width, Panel1.Height, PixelFormat.Format24bppRgb)
        Dim nbp As Integer = 0

        If Not bResizeEnCours Then
            Cursor.Current = Cursors.WaitCursor
            Dim i As Integer = 1
            For Ycount As Integer = 0 To myBitmap.Height - 1
                For Xcount As Integer = 0 To myBitmap.Width - 1
                    If i > n Then
                        myBitmap.SetPixel(Xcount, Ycount, Color.Red)
                    ElseIf t(i) Then
                        myBitmap.SetPixel(Xcount, Ycount, Color.White)
                        nbp += 1
                    Else
                        myBitmap.SetPixel(Xcount, Ycount, Color.Black)
                    End If
                    i += 1
                Next
            Next
        End If
        e.Graphics.DrawImage(myBitmap, Panel1.Left, Panel1.Top, myBitmap.Width, myBitmap.Height)
        StatusBar1.Text = Panel1.Width & " x " & Panel1.Height & ", nbp=" & nbp
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        bResizeEnCours = True
        Me.Refresh()
        bResizeEnCours = False
    End Sub

    Private Sub Form1_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        Me.Refresh()
    End Sub

End Class