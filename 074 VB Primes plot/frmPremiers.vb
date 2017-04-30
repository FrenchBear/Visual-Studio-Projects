' PV 2003
' 2006-10-01    PV  VS2005
' 2012-02-25	PV  VS2010

Imports System.Collections
Imports Microsoft.VisualBasic.Compatibility.VB6

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
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents btnCrible As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnCrible = New System.Windows.Forms.Button()
        Me.StatusBar1 = New System.Windows.Forms.StatusBar()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'btnCrible
        '
        Me.btnCrible.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCrible.Location = New System.Drawing.Point(448, 15)
        Me.btnCrible.Name = "btnCrible"
        Me.btnCrible.Size = New System.Drawing.Size(150, 42)
        Me.btnCrible.TabIndex = 0
        Me.btnCrible.Text = "Crible"
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 533)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Size = New System.Drawing.Size(608, 41)
        Me.StatusBar1.TabIndex = 1
        Me.StatusBar1.Text = "StatusBar1"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.RosyBrown
        Me.Panel1.Location = New System.Drawing.Point(16, 15)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(416, 489)
        Me.Panel1.TabIndex = 2
        Me.Panel1.Visible = False
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(10, 24)
        Me.ClientSize = New System.Drawing.Size(608, 574)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.btnCrible)
        Me.Name = "Form1"
        Me.Text = "Nombres premiers visuels"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Const n As Integer = 1585 * 1006      ' 1184 * 892
    Dim t As New BitArray(n + 1)

    Dim bResizeEnCours As Boolean = False

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCrible.Click
        t.SetAll(1)
        Dim ti As Double
        ti = Microsoft.VisualBasic.DateAndTime.Timer

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

        ti = Microsoft.VisualBasic.DateAndTime.Timer - ti
        StatusBar1.Text = "Terminé, t=" & FormatNumber(ti, 1) & "s"
        Me.Refresh()
    End Sub

    Private Sub Form1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim myBitmap As New Bitmap(Panel1.Width, Panel1.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        Dim nbp As Integer = 0

        If Not bResizeEnCours Then
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
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
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        bResizeEnCours = True
        Me.Refresh()
        bResizeEnCours = False
    End Sub

    Private Sub Form1_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.Refresh()
    End Sub

End Class


