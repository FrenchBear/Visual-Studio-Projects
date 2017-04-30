' 329 VB Wow64DisableWow64FsRedirection
' 2012-02-25	PV  VS2010

Module Module1

    Structure IntStruct
        Public i As Integer
    End Structure

    Declare Function Wow64DisableWow64FsRedirection Lib "kernel32.dll" (ByRef i As IntStruct) As Boolean

    Sub Main()
        'Dim b As Boolean = Wow64DisableWow64FsRedirection(x)

        Dim l As Long = My.Computer.FileSystem.GetFileInfo("C:\Windows\System32\Notepad.exe").Length
        Console.WriteLine("l=" & l.ToString)
        Console.ReadLine()
    End Sub

End Module
