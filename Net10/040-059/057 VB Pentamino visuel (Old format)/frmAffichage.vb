' Pentamino visuel
'
' 2001-08-11    PV
' 2001-08-15    PV Navigateur de solutions
' 2006-10-01 	PV		VS2005
' 2010-07-19	PV		VS2010
' 2021-09-18 	PV		VS2022, Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
' 2026-01-19	PV		Net10

Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Windows.Forms

#Disable Warning IDE1006 ' Naming Styles

Public Class frmAffichage
    Inherits Form

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
    ReadOnly alSolutions As New ArrayList()

    Friend WithEvents btnPause As Button
    Friend WithEvents btnStop As Button
    Friend WithEvents vsSol As VScrollBar
    Friend WithEvents Button1 As Button
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
    Protected Overloads Overrides Sub Dispose(disposing As Boolean)
        If disposing Then
            components?.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    Friend WithEvents btnAnalyse As Button
    Friend WithEvents txtSolution As TextBox
    Friend WithEvents pic As PictureBox

    'Required by the Windows Form Designer
    Private ReadOnly components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnPause = New Button()
        Me.Button1 = New Button()
        Me.pic = New PictureBox()
        Me.btnStop = New Button()
        Me.btnAnalyse = New Button()
        Me.txtSolution = New TextBox()
        Me.vsSol = New VScrollBar()
        Me.SuspendLayout()
        '
        'btnPause
        '
        Me.btnPause.Enabled = False
        Me.btnPause.Location = New Point(8, 40)
        Me.btnPause.Name = "btnPause"
        Me.btnPause.TabIndex = 1
        Me.btnPause.Text = "Pause"
        '
        'Button1
        '
        Me.Button1.Location = New Point(32, 136)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New Size(48, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Button1"
        Me.Button1.Visible = False
        '
        'pic
        '
        Me.pic.BorderStyle = BorderStyle.FixedSingle
        Me.pic.Location = New Point(96, 8)
        Me.pic.Name = "pic"
        Me.pic.Size = New Size(208, 424)
        Me.pic.TabIndex = 1
        Me.pic.TabStop = False
        '
        'btnStop
        '
        Me.btnStop.Enabled = False
        Me.btnStop.Location = New Point(8, 72)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.TabIndex = 2
        Me.btnStop.Text = "Stop"
        '
        'btnAnalyse
        '
        Me.btnAnalyse.Location = New Point(8, 8)
        Me.btnAnalyse.Name = "btnAnalyse"
        Me.btnAnalyse.TabIndex = 0
        Me.btnAnalyse.Text = "&Analyse"
        '
        'txtSolution
        '
        Me.txtSolution.Location = New Point(8, 104)
        Me.txtSolution.Name = "txtSolution"
        Me.txtSolution.ReadOnly = True
        Me.txtSolution.Size = New Size(80, 20)
        Me.txtSolution.TabIndex = 3
        Me.txtSolution.Text = ""
        '
        'vsSol
        '
        Me.vsSol.Location = New Point(8, 136)
        Me.vsSol.Name = "vsSol"
        Me.vsSol.Size = New Size(16, 296)
        Me.vsSol.TabIndex = 4
        Me.vsSol.Visible = False
        '
        'frmAffichage
        '
        Me.AutoScaleBaseSize = New Size(5, 13)
        Me.ClientSize = New Size(320, 447)
        Me.Controls.AddRange(New Control() {Me.Button1, Me.vsSol, Me.btnStop, Me.btnPause, Me.txtSolution, Me.pic, Me.btnAnalyse})
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "frmAffichage"
        Me.Text = "Analyseur Pentamino"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnAnalyse_Click(sender As Object, e As EventArgs) Handles btnAnalyse.Click
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
        'vsSol.Visible = True
        ModeNavigation()
        'Beep()
    End Sub

    Private Sub SolutionTrouvée(iNumSol As Integer, jeu As Jeu, ByRef bStopMoteur As Boolean) Handles app.Solution
        alSolutions.Add(jeu)
        DessineUneSolution(iNumSol, jeu)
        Application.DoEvents()
        While bPause And Not bStop
            Application.DoEvents()
        End While
        bStopMoteur = bStop
    End Sub

    Private Sub DessineUneSolution(iNumSol As Integer, jeu As Jeu)
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

    Private Sub btnPause_Click(sender As Object, e As EventArgs) Handles btnPause.Click
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

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        bStop = True
        If bPause Then
            bPause = False
            btnPause.Text = "Pause"
        End If
        ModeNavigation()
    End Sub

    Private Sub vsSol_Scroll(sender As Object, e As ScrollEventArgs) Handles vsSol.Scroll
        txtSolution.Text = "Valeur: " & vsSol.Value
        'Debug.WriteLine($"vSol.value = {vsSol.Value}")
        ' Temp comment, causes a crash...
        DessineUneSolution(vsSol.Value, CType(alSolutions(vsSol.Value - 1), Jeu))
    End Sub

    Private Sub ModeNavigation()
        With vsSol
            .Minimum = 1
            .Maximum = alSolutions.Count + 9      ' +9: bug de la vScroll ????
            .Value = alSolutions.Count
            .Visible = True
        End With
        Button1.Visible = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MsgBox("Min: " & vsSol.Minimum & vbCrLf & "Max: " & vsSol.Maximum & vbCrLf & "Val: " & vsSol.Value)
    End Sub

    ' Au cas où on ferme la feuille en mode pause
    Private Sub OnFormClose(sender As Object, e As CancelEventArgs) Handles MyBase.Closing
        bStop = True
    End Sub

End Class
