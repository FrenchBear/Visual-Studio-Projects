' 325 VB WPF Fallout 3 Decrypter
' 2012-02-25	PV  VS2010

Option Explicit On
Option Compare Text

Partial Class Window1

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As RoutedEventArgs) Handles btnAdd.Click
        If txtWord.Text <> "" And IsNumeric(txtPlaced.Text) Then
            If txtWord1.Text = "" Then
                txtWord1.Text = txtWord.Text
                txtPlaced1.Text = txtPlaced.Text
            Else
                If txtWord.Text.Length <> txtWord1.Text.Length Then
                    MsgBox("Length mismatch", MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
                If txtWord2.Text = "" Then
                    txtWord2.Text = txtWord.Text
                    txtPlaced2.Text = txtPlaced.Text
                ElseIf txtWord3.Text = "" Then
                    txtWord3.Text = txtWord.Text
                    txtPlaced3.Text = txtPlaced.Text
                ElseIf txtWord4.Text = "" Then
                    txtWord4.Text = txtWord.Text
                    txtPlaced4.Text = txtPlaced.Text
                Else
                    MsgBox("No more choices", MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
            End If
            txtWord.Text = ""
            txtPlaced.Text = ""
            txtWord.Focus()
        End If
    End Sub

    Private Sub Window1_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        ClearAll()
    End Sub

    Private Sub btnClear_Click(sender As System.Object, e As RoutedEventArgs) Handles btnClear.Click
        ClearAll()
    End Sub

    Private Sub ClearAll()
        txtWord.Text = ""
        txtWord1.Text = ""
        txtWord2.Text = ""
        txtWord3.Text = ""
        txtWord4.Text = ""
        txtPlaced.Text = ""
        txtPlaced1.Text = ""
        txtPlaced2.Text = ""
        txtPlaced3.Text = ""
        txtPlaced4.Text = ""
        ClearStatuses()
        lblAnalysis.Content = ""
        txtWord.Focus()
    End Sub

    Private Sub ClearStatuses()
        lblStatus1.Content = ""
        lblStatus2.Content = ""
        lblStatus3.Content = ""
        lblStatus4.Content = ""
    End Sub

    Private Sub txtWord_TextChanged(sender As System.Object, e As TextChangedEventArgs) Handles txtWord.TextChanged
        If txtWord.Text = "" Then
            lblAnalysis.Content = ""
            ClearStatuses()
        ElseIf txtPlaced1.Text = "" Then
            lblAnalysis.Content = "Enter first word"
            ClearStatuses()
        ElseIf txtWord.Text.Length <> txtWord1.Text.Length Then
            lblAnalysis.Content = "Enter next word"
            ClearStatuses()
        Else
            CompareWord(txtWord.Text, txtWord1.Text, Val(txtPlaced1.Text), lblStatus1)
            If txtPlaced2.Text <> "" Then CompareWord(txtWord.Text, txtWord2.Text, Val(txtPlaced2.Text), lblStatus2)
            If txtPlaced3.Text <> "" Then CompareWord(txtWord.Text, txtWord3.Text, Val(txtPlaced3.Text), lblStatus3)
            If txtPlaced4.Text <> "" Then CompareWord(txtWord.Text, txtWord4.Text, Val(txtPlaced4.Text), lblStatus4)
            If lblStatus1.Content = "OK" And (lblStatus2.Content = "" Or lblStatus2.Content = "OK") And (lblStatus3.Content = "" Or lblStatus3.Content = "OK") And (lblStatus4.Content = "" Or lblStatus4.Content = "OK") Then
                lblAnalysis.Content = "Possible"
                txtPlaced.Focus()
            Else
                lblAnalysis.Content = "Nope"
            End If
            txtWord.SelectAll()
        End If
    End Sub

    Private Sub CompareWord(Word As String, Guessed As String, Placed As Integer, lblStatus As Label)
        If Word.Length <> Guessed.Length Then
            lblStatus.Content = "#Err"
            lblStatus.Foreground = Brushes.Red
        Else
            Dim Match As Integer = 0
            For i As Integer = 0 To Word.Length - 1
                If Word.Chars(i) = Guessed.Chars(i) Then Match += 1
            Next
            If Match = Placed Then
                lblStatus.Content = "OK"
                lblStatus.Foreground = Brushes.DarkGreen
            Else
                lblStatus.Content = "NO"
                lblStatus.Foreground = Brushes.Red
            End If
        End If
    End Sub

End Class