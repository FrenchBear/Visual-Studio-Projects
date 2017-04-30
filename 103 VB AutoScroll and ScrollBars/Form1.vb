' 2006-10-01    PV  VS2005
' 2012-02-25	PV  VS2010

Public Class Form1

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim imOriginalImage As Drawing.Image
        imOriginalImage = Image.FromFile("C:\Pictures\Baltik\DSC_0099.JPG")
        PictureBox1.Width = imOriginalImage.Width
        PictureBox1.Height = imOriginalImage.Height
        PictureBox1.Image = imOriginalImage

        HScrollBar1.Maximum += HScrollBar1.LargeChange - 1
    End Sub

    Private Sub Panel1_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles Panel1.Scroll
        Debug.Print(Str(e.ScrollOrientation) & " - " & Str(e.NewValue))
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MsgBox("HS:" & vbCrLf &
          "  Value: " & Str(Panel1.HorizontalScroll.Value) & vbCrLf &
          "  Min:   " & Str(Panel1.HorizontalScroll.Minimum) & vbCrLf &
          "  Max:   " & Str(Panel1.HorizontalScroll.Maximum) & vbCrLf &
          "  SC:    " & Str(Panel1.HorizontalScroll.SmallChange) & vbCrLf &
          "  LC:    " & Str(Panel1.HorizontalScroll.LargeChange))
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        MsgBox("Pic:" & vbCrLf &
          "  Width:  " & Str(PictureBox1.Width) & vbCrLf &
          "  Height: " & Str(PictureBox1.Height))
    End Sub

    Private Sub HScrollBar1_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles HScrollBar1.Scroll
        Debug.Print(e.NewValue.ToString)
    End Sub


    Private Sub PictureBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
        MsgBox("x=" & Str(e.X) & vbCrLf & "y=" & Str(e.Y))
    End Sub

    Private Sub HScrollBar2_Scroll2() Handles HScrollBar2.ScrollNew
        Debug.Print(HScrollBar2.Value)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        MsgBox("HS2:" & vbCrLf &
          "  Value: " & Str(HScrollBar2.Value) & vbCrLf &
          "  Min:   " & Str(HScrollBar2.Minimum) & vbCrLf &
          "  Max:   " & Str(HScrollBar2.Maximum) & vbCrLf &
          "  SC:    " & Str(HScrollBar2.SmallChange) & vbCrLf &
          "  LC:    " & Str(HScrollBar2.LargeChange))
    End Sub
End Class
