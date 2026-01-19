' Pentamino visuel
'
' 2001-08-11    PV
' 2001-08-15    PV      Navigateur de solutions
' 2006-10-01 	PV		VS2005
' 2010-07-19	PV		VS2010
' 2021-09-18 	PV		VS2022, Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-04-30	PV		Rebuild solution in a new WinForms VB project, old structure of VB forms was crashing visual designer
' 2024-11-15	PV		Net9
' 2026-01-19	PV		Net10

Imports System.ComponentModel
Imports System.Drawing.Imaging

#Disable Warning IDE1006 ' Naming Styles

Public Class FrmAffichage
    Inherits Form

    Private Shared ReadOnly tBrushes() As Brush = {
      Brushes.Red, Brushes.Black, Brushes.Yellow,
      Brushes.White, Brushes.Blue, Brushes.Orange,
      Brushes.Aquamarine, Brushes.PaleGreen, Brushes.Purple,
      Brushes.RosyBrown, Brushes.DarkKhaki, Brushes.Gray}

    Private bPause As Boolean
    Private bStop As Boolean

    Private ReadOnly g As Graphics
    Private ReadOnly kEch As Integer

    ' Collection des solutions trouvées
    Private ReadOnly alSolutions As New ArrayList()

    Friend WithEvents app As PentaminoSolveur

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
