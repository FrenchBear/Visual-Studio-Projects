' 228 VB ImageTool
' 2012-02-25	PV  VS2010

Option Compare Text

Public Class frmImageTool
    Dim imOriginalImage As Drawing.Image

    Dim fRatio As Single
    Dim sZoom As String

    Private Sub frmImageTool_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadImage()
    End Sub

    Sub LoadImage()
        imOriginalImage = Image.FromFile("C:\Pictures\Titus\Photo 042.jpg")
        'imOriginalImage = Image.FromFile("C:\Documents\Mes Images\dEviLisH.jpg")
        tscboZoom.SelectedIndex = 0   ' Auto on load

        tsbHandTool.Checked = True
    End Sub

    Private Sub frmImageTool_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Not imOriginalImage Is Nothing Then ResizeMe()
    End Sub

    Sub ResizeMe()
        If paPicWindow.Width <= 1 Or paPicWindow.Height <= 1 Then Exit Sub

        pbDisplayedPic.Image = Nothing

        If sZoom = "Auto" Then
            'pbDisplayedPic.Left = 0
            'pbDisplayedPic.Width = paPicWindow.Width
            vsScrollBar.Visible = False

            'pbDisplayedPic.Top = 0
            'pbDisplayedPic.Height = paPicWindow.Height
            hsScrollBar.Visible = False

            Dim r1, r2 As Single
            r1 = paPicWindow.Width / imOriginalImage.Width
            r2 = paPicPanel.Height / imOriginalImage.Height
            If r2 < r1 Then r1 = r2
            If r1 < 0 Then Exit Sub
            If r1 > 1 Then r1 = 1
            fRatio = r1

            pbDisplayedPic.Left = (paPicWindow.Width - imOriginalImage.Width * fRatio) / 2
            pbDisplayedPic.Width = imOriginalImage.Width * fRatio

            pbDisplayedPic.Top = (paPicWindow.Height - imOriginalImage.Height * fRatio) / 2
            pbDisplayedPic.Height = imOriginalImage.Height * fRatio
        Else
            fRatio = Val(sZoom) / 100
            pbDisplayedPic.Width = imOriginalImage.Width * fRatio
            pbDisplayedPic.Height = imOriginalImage.Height * fRatio

            If pbDisplayedPic.Width < paPicWindow.Width Then
                pbDisplayedPic.Left = (paPicWindow.Width - pbDisplayedPic.Width) / 2
                hsScrollBar.Visible = False
            Else
                hsScrollBar.Visible = True
                If pbDisplayedPic.Left < 0 Then
                    If pbDisplayedPic.Left + pbDisplayedPic.Width < paPicWindow.Width Then pbDisplayedPic.Left = paPicWindow.Width - pbDisplayedPic.Width
                ElseIf pbDisplayedPic.Left > 0 Then
                    pbDisplayedPic.Left = 0
                End If
                hsScrollBar.Minimum = 0
                hsScrollBar.Maximum = pbDisplayedPic.Width - paPicWindow.Width
                hsScrollBar.Value = -pbDisplayedPic.Left
                hsScrollBar.LargeChange = hsScrollBar.Maximum / 10
                hsScrollBar.SmallChange = hsScrollBar.Maximum / 25
                hsScrollBar.Maximum += hsScrollBar.LargeChange - 1
            End If

            If pbDisplayedPic.Height < paPicWindow.Height Then
                pbDisplayedPic.Top = (paPicWindow.Height - pbDisplayedPic.Height) / 2
                vsScrollBar.Visible = False
            Else
                vsScrollBar.Visible = True
                If pbDisplayedPic.Top < 0 Then
                    If pbDisplayedPic.Top + pbDisplayedPic.Height < paPicWindow.Height Then pbDisplayedPic.Top = paPicWindow.Height - pbDisplayedPic.Height
                ElseIf pbDisplayedPic.Top > 0 Then
                    pbDisplayedPic.Top = 0
                End If
                vsScrollBar.Minimum = 0
                vsScrollBar.Maximum = pbDisplayedPic.Height - paPicWindow.Height
                vsScrollBar.Value = -pbDisplayedPic.Top
                vsScrollBar.LargeChange = vsScrollBar.Maximum / 10
                vsScrollBar.SmallChange = vsScrollBar.Maximum / 25
                vsScrollBar.Maximum += vsScrollBar.LargeChange - 1
            End If

        End If
        sbStatus.Panels(2).Text = FormatPercent(fRatio, 0)

        Dim imgOutput As Bitmap
        imgOutput = New Bitmap(imOriginalImage.Width * fRatio, imOriginalImage.Height * fRatio, System.Drawing.Imaging.PixelFormat.Format32bppRgb)
        Dim h As Graphics = Graphics.FromImage(imgOutput)
        h.Clear(Color.FromKnownColor(KnownColor.Control))
        h.DrawImage(imOriginalImage, 0, 0, imOriginalImage.Width * fRatio, imOriginalImage.Height * fRatio)
        pbDisplayedPic.Image = imgOutput

    End Sub

    Private bDoNotProcessZoomEvents As Boolean

    Private Sub tscboZoom_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tscboZoom.SelectedIndexChanged
        If Not bDoNotProcessZoomEvents Then
            bDoNotProcessZoomEvents = True
            AfterZoomChange(tscboZoom.Items(tscboZoom.SelectedIndex))
            ActiveControl = Nothing
            bDoNotProcessZoomEvents = False
        End If
    End Sub

    Private Sub tscboZoom_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tscboZoom.KeyDown
        If e.KeyCode = 13 And e.Modifiers = 0 Then
            e.SuppressKeyPress = True
            If bValidZoom() Then
                bDoNotProcessZoomEvents = True
                ActiveControl = Nothing
                bDoNotProcessZoomEvents = False
            End If
        End If
        If e.KeyCode = 27 And e.Modifiers = 0 Then
            bDoNotProcessZoomEvents = True
            tscboZoom.Text = sZoom
            ActiveControl = Nothing
            bDoNotProcessZoomEvents = False
        End If
    End Sub

    Private Sub tscboZoom_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tscboZoom.LostFocus
        If Not bDoNotProcessZoomEvents Then bValidZoom()
    End Sub

    Function bValidZoom() As Boolean
        bValidZoom = True
        If tscboZoom.Text = sZoom Then Exit Function
        If tscboZoom.Text = "Auto" Then
            AfterZoomChange("Auto")
            Exit Function
        End If
        If Val(tscboZoom.Text) >= 10 And Val(tscboZoom.Text) <= 400 Then
            AfterZoomChange(Str(Int(Val(tscboZoom.Text) + 0.5)) & "%")
            Exit Function
        End If
        Beep()
        bDoNotProcessZoomEvents = True
        tscboZoom.Text = sZoom
        bDoNotProcessZoomEvents = False
        tscboZoom.SelectionStart = 0
        tscboZoom.SelectionLength = 99
        bValidZoom = False
    End Function

    Private Sub tsbZoomReduce_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbZoomReduce.Click
        Dim z, z0 As Integer
        If tscboZoom.Text = "Auto" Then
            z0 = 100 * fRatio + 0.5
        Else
            z0 = Val(tscboZoom.Text)
        End If
        z = Int(z0 * 2 / 3 + 0.5)
        If z < 10 Then z = 10
        If tscboZoom.Text <> Str(z) & "%" Then AfterZoomChange(Str(z) & "%")
    End Sub

    Private Sub tsbZoomEnlarge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbZoomEnlarge.Click
        Dim z, z0 As Integer
        If tscboZoom.Text = "Auto" Then
            z0 = 100 * fRatio + 0.5
        Else
            z0 = Val(tscboZoom.Text)
        End If
        z = Int(z0 * 4 / 3 + 0.5)
        If z > 400 Then z = 400
        If tscboZoom.Text <> Str(z) & "%" Then AfterZoomChange(Str(z) & "%")
    End Sub

    Sub AfterZoomChange(ByVal sZ As String)
        tscboZoom.Text = sZ
        sZoom = tscboZoom.Text
        ResizeMe()
    End Sub



    Private Sub vsScrollBar_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles vsScrollBar.Scroll
        If vsScrollBar.Value <> -pbDisplayedPic.Top Then pbDisplayedPic.Top = -vsScrollBar.Value
    End Sub

    Private Sub hsScrollBar_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles hsScrollBar.Scroll
        If hsScrollBar.Value <> -pbDisplayedPic.Left Then pbDisplayedPic.Left = -hsScrollBar.Value
    End Sub




    Private Sub tsbHandTool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbHandTool.Click
        tsbSelectionTool.Checked = False
    End Sub

    Private Sub tsbSelectionTool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSelectionTool.Click
        tsbHandTool.Checked = False
    End Sub

    Dim bMouseCapture As Boolean
    Dim xStart, yStart As Integer
    Dim hs0, vs0 As Integer

    Private Sub pbDisplayedPic_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbDisplayedPic.MouseDown
        xStart = e.X
        yStart = e.Y
        bMouseCapture = True
        If tsbSelectionTool.Checked Then
            SelectionTool_MouseDown(e)
        ElseIf tsbHandTool.Checked Then
            HandTool_MouseDown(e)
        End If
    End Sub

    Sub SelectionTool_MouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)

    End Sub

    Sub HandTool_MouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Hand
        hs0 = hsScrollBar.Value + pbDisplayedPic.Left
        vs0 = vsScrollBar.Value + pbDisplayedPic.Top
    End Sub

    Private Sub pbDisplayedPic_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbDisplayedPic.MouseMove
        '        Debug.Print("pbDisplayedPic_MouseMove x=" & Str(e.X) & ", y=" & Str(e.Y))
        If bMouseCapture Then
            If tsbSelectionTool.Checked Then
                SelectionTool_MouseMove(e)
            ElseIf tsbHandTool.Checked Then
                HandTool_MouseMove(e)
            End If
        End If
    End Sub

    Sub SelectionTool_MouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim imgOutput As Bitmap
        imgOutput = New Bitmap(imOriginalImage.Width * fRatio, imOriginalImage.Height * fRatio, System.Drawing.Imaging.PixelFormat.Format32bppRgb)
        Dim h As Graphics = Graphics.FromImage(imgOutput)
        h.Clear(Color.FromKnownColor(KnownColor.Control))
        h.DrawImage(imOriginalImage, 0, 0, imOriginalImage.Width * fRatio, imOriginalImage.Height * fRatio)

        Dim p As New Pen(Brushes.Red, 4)
        h.DrawRectangle(p, xStart, yStart, e.X - xStart, e.Y - yStart)
        p.Dispose()

        pbDisplayedPic.Image = imgOutput
        pbDisplayedPic.Refresh()
    End Sub

    Sub HandTool_MouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
        If hsScrollBar.Visible Then
            Dim hs1 As Integer = hs0 + xStart - e.X - pbDisplayedPic.Left
            If hs1 < 0 Then hs1 = 0
            If hs1 > pbDisplayedPic.Width - paPicWindow.Width Then hs1 = pbDisplayedPic.Width - paPicWindow.Width
            If hs1 <> hsScrollBar.Value Then
                hsScrollBar.Value = hs1
                If hsScrollBar.Value <> -pbDisplayedPic.Left Then pbDisplayedPic.Left = -hsScrollBar.Value
            End If
        End If

        If vsScrollBar.Visible Then
            Dim vs1 As Integer = vs0 + yStart - e.Y - pbDisplayedPic.Top
            If vs1 < 0 Then vs1 = 0
            If vs1 > pbDisplayedPic.Height - paPicWindow.Height Then vs1 = pbDisplayedPic.Height - paPicWindow.Height
            If vs1 <> vsScrollBar.Value Then
                vsScrollBar.Value = vs1
                If vsScrollBar.Value <> -pbDisplayedPic.Top Then pbDisplayedPic.Top = -vsScrollBar.Value
            End If
        End If
    End Sub


    Private Sub pbDisplayedPic_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbDisplayedPic.MouseUp
        If bMouseCapture Then
            bMouseCapture = False
            If tsbSelectionTool.Checked Then
                SelectionTool_MouseUp(e)
            ElseIf tsbHandTool.Checked Then
                HandTool_MouseUp(e)
            End If
        End If
    End Sub

    Sub SelectionTool_MouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)

    End Sub

    Sub HandTool_MouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub btnRotate90Left_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRotate90Left.Click
        imOriginalImage.RotateFlip(RotateFlipType.Rotate270FlipNone)
        ResizeMe()
    End Sub

    Private Sub btnRotate90Right_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRotate90Right.Click
        imOriginalImage.RotateFlip(RotateFlipType.Rotate90FlipNone)
        ResizeMe()
    End Sub

End Class
