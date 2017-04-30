' ImageTool
' Image edition tool trials
' 2006-04-13    PV  First version
' 2012-02-25	PV  VS2010

Option Compare Text

Imports System.Drawing.Imaging

Public Class frmImageTool
    Private m_doc As EditDoc

    Private m_bDirty As Boolean
    Private m_bHandMode As Boolean
    Private m_bSelectionInProgress As Boolean
    Private m_bSelectionAvailable As Boolean
    Private m_rectSelection As Rectangle            ' Expressed in m_bmpOriginalImage coordinates

    Private m_bmpOriginalImage As Bitmap

    Dim m_fRatio As Single                          ' 0.5 if image is displayed at 50%
    Dim sZoom As String                             ' Auto or number

    Public Sub OpenEditDoc(ByVal ed As EditDoc)
        Visible = True
        m_doc = ed
        Text = ed.sPathName & " - Image Tool"
        m_bmpOriginalImage = Image.FromFile(m_doc.sPathName)
        tscboZoom.SelectedIndex = 0   ' Auto on load
        RefreshImage()
        RefreshToolBar()
    End Sub

    Sub RefreshToolBar()
        If m_doc Is Nothing Or m_bSelectionInProgress Then
            tsbSave.Enabled = False
            tsbZoomReduce.Enabled = False
            tscboZoom.Enabled = False
            tsbZoomEnlarge.Enabled = False
            tsbHandTool.Checked = False
            tsbSelectionTool.Checked = False
            tsbHandTool.Enabled = False
            tsbSelectionTool.Enabled = True
            tsbClearSelection.Enabled = False
            tsbCropSelection.Enabled = False
            tsbRotate90Left.Enabled = False
            tsbRotate90Right.Enabled = False
        Else
            tsbSave.Enabled = m_bDirty
            tsbZoomReduce.Enabled = True
            tscboZoom.Enabled = True
            tsbZoomEnlarge.Enabled = True
            tsbHandTool.Enabled = True
            tsbSelectionTool.Enabled = True
            tsbHandTool.Checked = m_bHandMode
            tsbSelectionTool.Checked = Not m_bHandMode
            tsbClearSelection.Enabled = m_bSelectionAvailable
            tsbCropSelection.Enabled = m_bSelectionAvailable
            tsbRotate90Left.Enabled = True
            tsbRotate90Right.Enabled = True
        End If
    End Sub

    Private Sub frmImageTool_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RefreshToolBar()
    End Sub

    Private Sub frmImageTool_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Not m_bmpOriginalImage Is Nothing Then RefreshImage()
    End Sub

    Sub RefreshImage()
        If paPicWindow.Width <= 1 Or paPicWindow.Height <= 1 Then Exit Sub

        pbDisplayedPic.Image = Nothing

        If sZoom = "Auto" Then
            vsScrollBar.Visible = False
            hsScrollBar.Visible = False

            Dim r1, r2 As Single
            r1 = paPicWindow.Width / m_bmpOriginalImage.Width
            r2 = paPicPanel.Height / m_bmpOriginalImage.Height
            If r2 < r1 Then r1 = r2
            If r1 < 0 Then Exit Sub
            If r1 > 1 Then r1 = 1
            m_fRatio = r1

            pbDisplayedPic.Left = (paPicWindow.Width - m_bmpOriginalImage.Width * m_fRatio) / 2
            pbDisplayedPic.Width = m_bmpOriginalImage.Width * m_fRatio

            pbDisplayedPic.Top = (paPicWindow.Height - m_bmpOriginalImage.Height * m_fRatio) / 2
            pbDisplayedPic.Height = m_bmpOriginalImage.Height * m_fRatio
        Else
            m_fRatio = Val(sZoom) / 100
            pbDisplayedPic.Width = m_bmpOriginalImage.Width * m_fRatio
            pbDisplayedPic.Height = m_bmpOriginalImage.Height * m_fRatio

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
        sbStatus.Panels(2).Text = FormatPercent(m_fRatio, 0)

        Dim imgOutput As Bitmap
        imgOutput = New Bitmap(m_bmpOriginalImage.Width * m_fRatio, m_bmpOriginalImage.Height * m_fRatio, Graphics.FromImage(m_bmpOriginalImage))
        Dim h As Graphics = Graphics.FromImage(imgOutput)
        h.Clear(Color.FromKnownColor(KnownColor.Control))
        h.DrawImage(m_bmpOriginalImage, 0, 0, m_bmpOriginalImage.Width * m_fRatio, m_bmpOriginalImage.Height * m_fRatio)
        If m_bSelectionAvailable Then RefreshSelection(h)
        pbDisplayedPic.Image = imgOutput
    End Sub

    Sub RefreshSelection(ByVal h As Graphics)
        Dim p As New Pen(Brushes.Yellow, 4)
        h.DrawRectangle(p, m_rectSelection.X * m_fRatio, m_rectSelection.Y * m_fRatio, m_rectSelection.Width * m_fRatio, m_rectSelection.Height * m_fRatio)
        p.Dispose()
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
            z0 = 100 * m_fRatio + 0.5
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
            z0 = 100 * m_fRatio + 0.5
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
        RefreshImage()
    End Sub



    Private Sub vsScrollBar_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles vsScrollBar.Scroll
        If vsScrollBar.Value <> -pbDisplayedPic.Top Then pbDisplayedPic.Top = -vsScrollBar.Value
    End Sub

    Private Sub hsScrollBar_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles hsScrollBar.Scroll
        If hsScrollBar.Value <> -pbDisplayedPic.Left Then pbDisplayedPic.Left = -hsScrollBar.Value
    End Sub




    Private Sub tsbHandTool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbHandTool.Click
        m_bHandMode = True
        RefreshToolBar()
    End Sub

    Private Sub tsbSelectionTool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSelectionTool.Click
        m_bHandMode = False
        RefreshToolBar()
    End Sub

    Dim xStart, yStart As Integer
    Dim hs0, vs0 As Integer

    Private Sub pbDisplayedPic_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbDisplayedPic.MouseDown
        xStart = e.X
        yStart = e.Y
        m_bSelectionInProgress = True
        If m_bHandMode Then
            HandTool_MouseDown(e)
        Else
            SelectionTool_MouseDown(e)
        End If
        RefreshToolBar()
    End Sub

    Sub SelectionTool_MouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Cross
    End Sub

    Sub HandTool_MouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        'System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Hand
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.NoMove2D
        hs0 = hsScrollBar.Value + pbDisplayedPic.Left
        vs0 = vsScrollBar.Value + pbDisplayedPic.Top
    End Sub

    Private Sub pbDisplayedPic_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbDisplayedPic.MouseMove
        If m_bSelectionInProgress Then
            If m_bHandMode Then
                HandTool_MouseMove(e)
            Else
                SelectionTool_MouseMove(e)
            End If
        End If
    End Sub

    Sub SelectionTool_MouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim imgOutput As Bitmap
        imgOutput = New Bitmap(m_bmpOriginalImage.Width * m_fRatio, m_bmpOriginalImage.Height * m_fRatio, Graphics.FromImage(m_bmpOriginalImage))
        Dim h As Graphics = Graphics.FromImage(imgOutput)
        h.Clear(Color.FromKnownColor(KnownColor.Control))
        h.DrawImage(m_bmpOriginalImage, 0, 0, m_bmpOriginalImage.Width * m_fRatio, m_bmpOriginalImage.Height * m_fRatio)
        m_rectSelection = New Rectangle(Math.Min(xStart, e.X) / m_fRatio, Math.Min(yStart, e.Y) / m_fRatio, Math.Abs(e.X - xStart) / m_fRatio, Math.Abs(e.Y - yStart) / m_fRatio)
        If m_rectSelection.X < 0 Then
            m_rectSelection.Width = Math.Max(0, m_rectSelection.Width + m_rectSelection.X)
            m_rectSelection.X = 0
        End If
        If m_rectSelection.Y < 0 Then
            m_rectSelection.Height = Math.Max(0, m_rectSelection.Height + m_rectSelection.Y)
            m_rectSelection.Y = 0
        End If

        If m_rectSelection.X + m_rectSelection.Width > m_bmpOriginalImage.Width Then m_rectSelection.Width = m_bmpOriginalImage.Width - m_rectSelection.X
        If m_rectSelection.Y + m_rectSelection.Height > m_bmpOriginalImage.Height Then m_rectSelection.Height = m_bmpOriginalImage.Height - m_rectSelection.Y
        RefreshSelection(h)
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
        If m_bSelectionInProgress Then
            m_bSelectionInProgress = False
            If m_bHandMode Then
                HandTool_MouseUp(e)
            Else
                SelectionTool_MouseUp(e)
            End If
        End If
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        RefreshToolBar()
    End Sub

    Sub SelectionTool_MouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
        If m_rectSelection.Width < 50 Or m_rectSelection.Height < 50 Then
            ClearSelection()
        Else
            m_bSelectionAvailable = True
        End If
    End Sub

    Sub HandTool_MouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)

    End Sub



    Private Sub tsbRotate90Left_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRotate90Left.Click
        m_bDirty = True
        If m_bSelectionAvailable Then
            Dim xp1, yp1, xp2, yp2 As Integer
            xp1 = m_rectSelection.Y
            yp1 = m_bmpOriginalImage.Width - m_rectSelection.X
            xp2 = m_rectSelection.Y + m_rectSelection.Height
            yp2 = m_bmpOriginalImage.Width - m_rectSelection.X - m_rectSelection.Width
            m_rectSelection = New Rectangle(Math.Min(xp1, xp2), Math.Min(yp1, yp2), Math.Abs(xp2 - xp1), Math.Abs(yp2 - yp1))
        End If
        m_bmpOriginalImage.RotateFlip(RotateFlipType.Rotate270FlipNone)
        RefreshImage()
    End Sub

    Private Sub tsbRotate90Right_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRotate90Right.Click
        m_bDirty = True
        If m_bSelectionAvailable Then
            Dim xp1, yp1, xp2, yp2 As Integer
            xp1 = m_bmpOriginalImage.Height - m_rectSelection.Y
            yp1 = m_rectSelection.X
            xp2 = m_bmpOriginalImage.Height - m_rectSelection.Y - m_rectSelection.Height
            yp2 = m_rectSelection.X + m_rectSelection.Width
            m_rectSelection = New Rectangle(Math.Min(xp1, xp2), Math.Min(yp1, yp2), Math.Abs(xp2 - xp1), Math.Abs(yp2 - yp1))
        End If
        m_bmpOriginalImage.RotateFlip(RotateFlipType.Rotate90FlipNone)
        RefreshImage()
    End Sub

    Sub ClearSelection()
        m_bSelectionAvailable = False
        RefreshImage()
    End Sub

    Private Sub tsbClearSelection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbClearSelection.Click
        ClearSelection()
        RefreshToolBar()
    End Sub

    Private Sub tsbCropSelection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCropSelection.Click
        m_bDirty = True
        Dim imgCroppedImage As Bitmap
        imgCroppedImage = New Bitmap(m_rectSelection.Width, m_rectSelection.Height, Graphics.FromImage(m_bmpOriginalImage))
        Dim x2 As Single = imgCroppedImage.HorizontalResolution
        Dim h As Graphics = Graphics.FromImage(imgCroppedImage)
        h.DrawImage(m_bmpOriginalImage, 0, 0, m_rectSelection, GraphicsUnit.Pixel)

        m_bmpOriginalImage = imgCroppedImage
        m_bSelectionAvailable = False
        RefreshImage()
        RefreshToolBar()
    End Sub

    Private Sub tsbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSave.Click
        ' Quqlity Control
        Dim eps As EncoderParameters = New EncoderParameters(1)
        eps.Param(0) = New EncoderParameter(Encoder.Quality, CLng(80))
        Dim ici As ImageCodecInfo = GetEncoderInfo("image/jpeg")

        ' First release pending file locks
        System.GC.Collect()
        System.GC.WaitForPendingFinalizers()

        ' And save
        m_bmpOriginalImage.Save(m_doc.sPathName, ici, eps)
        m_bDirty = False
        RefreshToolBar()
    End Sub

    Private Function GetEncoderInfo(ByVal mimeType As String) As ImageCodecInfo
        Dim j As Integer
        Dim encoders As ImageCodecInfo()
        encoders = ImageCodecInfo.GetImageEncoders()
        For j = 0 To encoders.Length
            If encoders(j).MimeType = mimeType Then
                Return encoders(j)
            End If
        Next j
        Return Nothing
    End Function

End Class
