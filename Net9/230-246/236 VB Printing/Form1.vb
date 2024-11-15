' 236 VB Printing
'
' 2012-02-25	PV		VS2010
' 2021-09-20 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
Imports System.Drawing.Printing

#Disable Warning IDE1006 ' Naming Styles

Public Class Form1

    Public iPrintedPage As Integer

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        ActionPrint()
    End Sub

    Private Sub ActionPrint()
        With PrintDocument1.DefaultPageSettings
            .Margins.Top = .PrintableArea.Top
            .Margins.Left = .PrintableArea.Left
            .Margins.Right = .PaperSize.Width - .PrintableArea.Left - .PrintableArea.Width
            .Margins.Bottom = .PaperSize.Height - .PrintableArea.Height - .PrintableArea.Top
        End With

        iPrintedPage = 0
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.ShowDialog()
    End Sub

    ' Printing
    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument1.PrintPage
        iPrintedPage += 1

        Dim rOut As Rectangle
        rOut = e.MarginBounds

        Dim p As New Pen(Color.Red, 5)
        e.Graphics.DrawRectangle(p, New Rectangle(0, 0, rOut.Width, rOut.Height))
        e.Graphics.DrawLine(p, 0, 0, rOut.Width, rOut.Height)
        e.Graphics.DrawLine(p, rOut.Width, 0, 0, rOut.Height)

        Dim f As New Font("Arial", 36, FontStyle.Bold)
        e.Graphics.DrawString("Page " & iPrintedPage.ToString, f, Brushes.Black, 100, 100)

        e.HasMorePages = iPrintedPage <= 2
    End Sub

    Private Sub btnPageSetup_Click(sender As Object, e As EventArgs) Handles btnPageSetup.Click
        PageSetupDialog1.PageSettings = New PageSettings
        PageSetupDialog1.PrinterSettings = New PrinterSettings

        PageSetupDialog1.AllowMargins = False
        PageSetupDialog1.AllowPrinter = False

        If PageSetupDialog1.ShowDialog = DialogResult.OK Then
            MsgBox("New settings")
        End If
    End Sub

End Class
