' 414 VB CleanEmuleFilenames
' 2012-01-20    PV

Option Compare Text

Imports System.Text
Imports System.Text.RegularExpressions

Class MainWindow

    Private Sub OnLoad(sender As System.Object, e As RoutedEventArgs)
        Dim reEpisodeNum1 As New Regex("^[0-9]+x[0-9]+$")
        Dim reEpisodeNum2 As New Regex("^S([0-9]+)E([0-9]+)$")
        For Each sFilename As String In System.IO.Directory.EnumerateFiles("C:\Users\Pierre\Downloads\eMule\Incoming")
            Dim sBase As String = System.IO.Path.GetFileNameWithoutExtension(sFilename)

            Dim p1 As Integer = sBase.IndexOf("["c)
            If p1 >= 0 Then
                Dim p2 As Integer = sBase.IndexOf("]"c, p1)
                If p2 >= 0 Then
                    sBase = sBase.Remove(p1, p2 - p1 + 1)
                End If
            End If
            Dim ts() As String = sBase.Split("."c)
            If UBound(ts) <= 2 Then Continue For

            Dim sRes As New StringBuilder
            For Each s In ts
                If reEpisodeNum1.IsMatch(s) Then
                    s = "- " & s & " -"
                ElseIf reEpisodeNum2.IsMatch(s) Then
                    Dim m As Match = reEpisodeNum2.Matches(s)(0)
                    s = "- " & Format(Val(m.Groups(1).Captures(0).Value)) & "x" & Format(Val(m.Groups(2).Captures(0).Value)) & " -"
                ElseIf s.IndexOf("Vostfr", System.StringComparison.InvariantCultureIgnoreCase) >= 0 Then
                    s = "- Vostfr"
                ElseIf s = "fr" Then
                    s = "- Fr"
                ElseIf s.IndexOf("HDTV", System.StringComparison.InvariantCultureIgnoreCase) >= 0 Then
                    s = ""
                ElseIf s.IndexOf("XVID", System.StringComparison.InvariantCultureIgnoreCase) >= 0 Then
                    s = ""
                ElseIf s.IndexOf("BAWLS", System.StringComparison.InvariantCultureIgnoreCase) >= 0 Then
                    s = ""
                ElseIf s.IndexOf("DIMENSION", System.StringComparison.InvariantCultureIgnoreCase) >= 0 Then
                    s = ""
                ElseIf s.IndexOf("FASTSUB", System.StringComparison.InvariantCultureIgnoreCase) >= 0 Then
                    s = ""
                ElseIf s.IndexOf("AlFleNi", System.StringComparison.InvariantCultureIgnoreCase) >= 0 Then
                    s = ""
                End If

                If s <> "" Then
                    If sRes.Length > 0 Then sRes.Append(" ")
                    sRes.Append(s)
                End If
            Next
            sRes.Append("."c)
            sRes.Append(System.IO.Path.GetExtension(sFilename))

            Dim sNewName As String = Replace(sRes.ToString, "..", ".")

            ListBox1.Items.Add(sBase)
            ListBox1.Items.Add(sNewName)

            My.Computer.FileSystem.RenameFile(sFilename, sNewName)
        Next
    End Sub

End Class