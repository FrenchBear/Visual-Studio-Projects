' 235 VB SQLAnalysis
'
' 2012-02-25	PV  VS2010
' 2021-09-20    PV  VS2022; Net6
' 2023-01-10	PV		Net7

Imports System.Text
Imports System.Text.RegularExpressions

Module Module1

    Sub Main()
        Const sFile As String = "C:\SVN\eLIMS\Trunk\Common\Stored Procedures\eusp_e5_DLL_All.sql"

        ' Read file
        Dim c1 As Long = QueryPerformanceCounter()
        Dim sOriginal As String = My.Computer.FileSystem.ReadAllText(sFile)
        sOriginal = "CREATE    FUNCTION    [dbo].[toto]()" & vbCrLf & "AS SELECT * FROM T1"
        Dim sbMasked As New StringBuilder(sOriginal)
        Dim c2 As Long = QueryPerformanceCounter()

        ' Mask comments and strings
        Dim bInQuote As Boolean
        Dim bInLineComment As Boolean
        Dim bInGeneralComment As Boolean
        For i As Integer = 0 To sOriginal.Length - 2
            If bInLineComment Then
                If sOriginal(i) = Chr(13) Then
                    bInLineComment = False
                Else
                    sbMasked(i) = " "c
                End If
            ElseIf bInGeneralComment Then
                sbMasked(i) = " "c
                If sOriginal(i) = "*"c And sOriginal(i + 1) = "/"c Then
                    sbMasked(i + 1) = " "c
                    i += 1
                    bInGeneralComment = False
                End If
            ElseIf bInQuote Then
                sbMasked(i) = " "c
                If sOriginal(i) = "'"c Then bInQuote = False
            Else
                If sOriginal(i) = "'"c Then
                    bInQuote = True
                    sbMasked(i) = " "c
                ElseIf sOriginal(i) = "-"c And sOriginal(i + 1) = "-"c Then
                    bInLineComment = True
                    sbMasked(i) = " "c
                ElseIf sOriginal(i) = "/"c And sOriginal(i + 1) = "*"c Then
                    bInGeneralComment = True
                    sbMasked(i) = " "c
                End If
            End If
        Next
        Dim c3 As Long = QueryPerformanceCounter()

        'Dim t1 As Double = CDbl(c2 - c1) / QueryPerformanceFrequency
        'Dim t2 As Double = CDbl(c3 - c2) / QueryPerformanceFrequency
        'MsgBox(String.Format("Read: {0:F}s  Analyze: {1:F}", t1, t2))
        Dim sMasked As String = sbMasked.ToString

        Dim re As Regex
        re = New Regex("^ *GO *\r?$", RegexOptions.Multiline Or RegexOptions.IgnoreCase)
        Dim mc As MatchCollection = re.Matches(sMasked)
        If mc.Count = 0 Then
            ProcessSQLBlock(sOriginal, sMasked)
        Else
            Dim p As Integer = 0
            For Each m As Match In mc
                If m.Index <> p Then
                    ProcessSQLBlock(sOriginal.Substring(p, m.Index - p), sMasked.Substring(p, m.Index - p))
                End If
                p = m.Index + m.Length + 1
            Next
            If p < sOriginal.Length Then
                ProcessSQLBlock(sOriginal.Substring(p, sOriginal.Length - p), sMasked.Substring(p, sOriginal.Length - p))
            End If
        End If
    End Sub

    Private Sub ProcessSQLBlock(sSource As String, sMasked As String)
        Dim re As New Regex("(\s|^)CREATE\s+((?<1>P)ROC(EDURE)?|(?<1>F)UNCTION)\s+(\[?[A-Z_][A-Z0-9_\$#@]*\]?\.)?(\[?(?<2>[A-Z_][A-Z0-9_\$#@]*)\]?)(\s|\()", RegexOptions.ExplicitCapture Or RegexOptions.IgnoreCase)
        Dim m As Match = re.Match(sMasked)
        If m.Success Then
            MsgBox("SQL Block:" & vbCrLf & "<" & sSource & ">" & vbCrLf & "Type: " & m.Groups(1).Value & vbCrLf & "Name: <" & m.Groups(2).Value & ">")
        End If
    End Sub

End Module
