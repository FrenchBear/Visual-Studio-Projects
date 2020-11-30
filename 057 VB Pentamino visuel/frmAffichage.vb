' Pentamino visuel
' 2001-08-11    PV
' 2001-08-15    PV Navigateur de solutions
' 2006-10-01    PV  VS2005
' 2010-07-19	PV  VS2010


Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Windows.Forms


Public Class frmAffichage
    Inherits System.Windows.Forms.Form

    Shared ReadOnly tBrushes() As Brush = {
      Brushes.Red, Brushes.Black, Brushes.Yellow,
      Brushes.White, Brushes.Blue, Brushes.Orange,
      Brushes.Aquamarine, Brushes.PaleGreen, Brushes.Purple,
      Brushes.RosyBrown, Brushes.DarkKhaki, Brushes.Gray}

    Dim bPause As Boolean
    Dim bStop As Boolean

    ReadOnly g As Graphics
    ReadOnly kEch As Integer

    ' Collection des solutions trouvées
    ReadOnly alSolutions As New System.Collections.ArrayList()

    Friend WithEvents btnPause As System.Windows.Forms.Button
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents vsSol As System.Windows.Forms.VScrollBar
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Dim WithEvents app As PentaminoSolveur

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        ' On redimensionne pour un facteur d'échelle de 1
        Dim kx, ky As Integer
        kx = pic.Size.Width \ MAXCOL
        ky = pic.Size.Height \ MAXLIG
        If kx < ky Then kEch = kx Else kEch = ky
        pic.Size = New Size(kEch * MAXCOL, kEch * MAXLIG)

        Dim picBitmap As Bitmap
        picBitmap = New Bitmap(pic.Size.Width, pic.Size.Height, PixelFormat.Format24bppRgb)
        g = Graphics.FromImage(picBitmap)
        g.Clear(Color.FromKnownColor(KnownColor.Control))
        pic.BackgroundImage = picBitmap

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    Friend WithEvents btnAnalyse As System.Windows.Forms.Button
    Friend WithEvents txtSolution As System.Windows.Forms.TextBox
    Friend WithEvents pic As System.Windows.Forms.PictureBox

    'Required by the Windows Form Designer
    Private ReadOnly components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnPause = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.pic = New System.Windows.Forms.PictureBox()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.btnAnalyse = New System.Windows.Forms.Button()
        Me.txtSolution = New System.Windows.Forms.TextBox()
        Me.vsSol = New System.Windows.Forms.VScrollBar()
        Me.SuspendLayout()
        '
        'btnPause
        '
        Me.btnPause.Enabled = False
        Me.btnPause.Location = New System.Drawing.Point(8, 40)
        Me.btnPause.Name = "btnPause"
        Me.btnPause.TabIndex = 1
        Me.btnPause.Text = "Pause"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(32, 136)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(48, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Button1"
        Me.Button1.Visible = False
        '
        'pic
        '
        Me.pic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pic.Location = New System.Drawing.Point(96, 8)
        Me.pic.Name = "pic"
        Me.pic.Size = New System.Drawing.Size(208, 424)
        Me.pic.TabIndex = 1
        Me.pic.TabStop = False
        '
        'btnStop
        '
        Me.btnStop.Enabled = False
        Me.btnStop.Location = New System.Drawing.Point(8, 72)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.TabIndex = 2
        Me.btnStop.Text = "Stop"
        '
        'btnAnalyse
        '
        Me.btnAnalyse.Location = New System.Drawing.Point(8, 8)
        Me.btnAnalyse.Name = "btnAnalyse"
        Me.btnAnalyse.TabIndex = 0
        Me.btnAnalyse.Text = "&Analyse"
        '
        'txtSolution
        '
        Me.txtSolution.Location = New System.Drawing.Point(8, 104)
        Me.txtSolution.Name = "txtSolution"
        Me.txtSolution.ReadOnly = True
        Me.txtSolution.Size = New System.Drawing.Size(80, 20)
        Me.txtSolution.TabIndex = 3
        Me.txtSolution.Text = ""
        '
        'vsSol
        '
        Me.vsSol.Location = New System.Drawing.Point(8, 136)
        Me.vsSol.Name = "vsSol"
        Me.vsSol.Size = New System.Drawing.Size(16, 296)
        Me.vsSol.TabIndex = 4
        Me.vsSol.Visible = False
        '
        'frmAffichage
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(320, 447)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button1, Me.vsSol, Me.btnStop, Me.btnPause, Me.txtSolution, Me.pic, Me.btnAnalyse})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "frmAffichage"
        Me.Text = "Analyseur Pentamino"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnAnalyse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnalyse.Click
        btnAnalyse.Enabled = False
        btnPause.Enabled = True
        btnStop.Enabled = True

        vsSol.Visible = False
        alSolutions.Clear()

        bPause = False
        bStop = False
        app = New PentaminoSolveur()
        app.Analyse()

        btnAnalyse.Enabled = True
        btnPause.Enabled = False
        btnStop.Enabled = False
        vsSol.Visible = True
        Beep()
    End Sub


    Private Sub SolutionTrouvée(ByVal iNumSol As Integer, ByVal jeu As Jeu, ByRef bStopMoteur As Boolean) Handles app.Solution
        alSolutions.Add(jeu)
        DessineUneSolution(iNumSol, jeu)
        Application.DoEvents()
        While bPause And Not bStop
            Application.DoEvents()
        End While
        bStopMoteur = bStop
    End Sub


    Private Sub DessineUneSolution(ByVal iNumSol As Integer, ByVal jeu As Jeu)
        txtSolution.Text = "Solution " & iNumSol
        g.Clear(Color.FromKnownColor(KnownColor.Control))
        Dim l, c As Integer
        For l = 0 To MAXLIG - 1
            For c = 0 To MAXCOL - 1
                g.FillRectangle(tBrushes(jeu(l, c) - 1), kEch * c, kEch * l, kEch - 1, kEch - 1)
            Next
        Next
        pic.Refresh()
    End Sub


    Private Sub btnPause_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPause.Click
        If bPause Then
            bPause = False
            btnPause.Text = "Pause"
            vsSol.Visible = False
        Else
            bPause = True
            btnPause.Text = "Reprise"
            ModeNavigation()
        End If
    End Sub


    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
        bStop = True
        If bPause Then
            bPause = False
            btnPause.Text = "Pause"
        End If
        ModeNavigation()
    End Sub

    Private Sub vsSol_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles vsSol.Scroll
        txtSolution.Text = "Valeur: " & vsSol.Value
        DessineUneSolution(vsSol.Value, CType(alSolutions(vsSol.Value - 1), Jeu))
    End Sub

    Private Sub ModeNavigation()
        With vsSol
            .Minimum = 1
            .Maximum = alSolutions.Count + 9      ' +9: bug de la vScroll ????
            .Value = alSolutions.Count
            .Visible = True
        End With
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MsgBox("Min: " & vsSol.Minimum & vbCrLf & "Max: " & vsSol.Maximum & vbCrLf & "Val: " & vsSol.Value)
    End Sub

    ' Au cas où on ferme la feuille en mode pause
    Private Sub OnFormClose(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        bStop = True
    End Sub

End Class
