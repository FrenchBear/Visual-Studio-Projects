' 414 VB CleanEmuleFilenames
'
' 2012-01-20    PV
' 2021-09-23 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9

Option Compare Text

Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Windows

Public Class MainWindow

    Private Sub OnLoad(sender As Object, e As RoutedEventArgs)
        Dim reEpisodeNum1 As New Regex("^[0-9]+x[0-9]+$")
        Dim reEpisodeNum2 As New Regex("^S([0-9]+)E([0-9]+)$")
        For Each sFilename As String In Directory.EnumerateFiles("C:\Users\Pierre\Downloads\eMule\Incoming")
            Dim sBase As String = Path.GetFileNameWithoutExtension(sFilename)

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
                ElseIf s.Contains("Vostfr", StringComparison.InvariantCultureIgnoreCase) Then
                    s = "- Vostfr"
                ElseIf s = "fr" Then
                    s = "- Fr"
                ElseIf s.Contains("HDTV", StringComparison.InvariantCultureIgnoreCase) Then
                    s = ""
                ElseIf s.Contains("XVID", StringComparison.InvariantCultureIgnoreCase) Then
                    s = ""
                ElseIf s.Contains("BAWLS", StringComparison.InvariantCultureIgnoreCase) Then
                    s = ""
                ElseIf s.Contains("DIMENSION", StringComparison.InvariantCultureIgnoreCase) Then
                    s = ""
                ElseIf s.Contains("FASTSUB", StringComparison.InvariantCultureIgnoreCase) Then
                    s = ""
                ElseIf s.Contains("AlFleNi", StringComparison.InvariantCultureIgnoreCase) Then
                    s = ""
                End If

                If s <> "" Then
                    If sRes.Length > 0 Then sRes.Append(" "c)
                    sRes.Append(s)
                End If
            Next
            sRes.Append("."c)
            sRes.Append(Path.GetExtension(sFilename))

            Dim sNewName As String = Replace(sRes.ToString, "..", ".")

            ListBox1.Items.Add(sBase)
            ListBox1.Items.Add(sNewName)

            File.Move(sFilename, sNewName)
        Next
    End Sub

End Class
