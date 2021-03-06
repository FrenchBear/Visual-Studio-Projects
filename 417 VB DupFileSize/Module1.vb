﻿' DupFileSize
' Quick and dirty tool to find files with exactly the same size
' 2010-12-17    FPVI

Imports System.IO

Module Module1

    Sub Main()
        Const sPath As String = "\\Tera4\backup\TERAX\Video"   '\Bear"
        Const sPattern As String = "*.*"

        Dim sw As New StreamWriter("c:\out.txt", False, System.Text.Encoding.Default)

        Dim diTop As New DirectoryInfo(sPath)
        Dim tfi As FileInfo() = diTop.EnumerateFiles(sPattern, IO.SearchOption.AllDirectories).OrderBy(Function(fi As FileInfo) fi.Length).ToArray
        Dim i As Integer
        For i = 0 To tfi.Length - 2
            If tfi(i).Length = tfi(i + 1).Length Then
                sw.WriteLine(tfi(i).Length.ToString & vbTab & tfi(i).FullName & vbTab & tfi(i + 1).FullName)
                Console.WriteLine(tfi(i).Length.ToString & vbTab & tfi(i).FullName & vbTab & tfi(i + 1).FullName)
            End If
        Next
        sw.Close()

        Console.WriteLine()
        Console.Write("(Pause) ")
        Console.ReadLine()
    End Sub

End Module