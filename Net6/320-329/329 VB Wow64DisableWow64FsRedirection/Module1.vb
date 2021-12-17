' 329 VB Wow64DisableWow64FsRedirection
'
' 2012-02-25    PV  VS2010
' 2021-09-22    PV  VS2022; Net6

Module Module1

    Structure IntStruct
        Public i As Integer
    End Structure

    Declare Function Wow64DisableWow64FsRedirection Lib "kernel32.dll" (ByRef i As IntStruct) As Boolean

    Sub Main()
        'Dim b As Boolean = Wow64DisableWow64FsRedirection(x)

        Dim l As Long = New System.IO.FileInfo("C:\Windows\System32\Notepad.exe").Length
        WriteLine("l=" & l.ToString)
    End Sub

End Module