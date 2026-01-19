' 329 VB Wow64DisableWow64FsRedirection
'
' 2012-02-25 	PV		VS2010
' 2021-09-22 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
' 2026-01-19	PV		Net10
Imports System.IO

Friend Module Module1
    Public Structure IntStruct
        Public i As Integer
    End Structure

    Declare Function Wow64DisableWow64FsRedirection Lib "kernel32.dll" (ByRef i As IntStruct) As Boolean

    Public Sub Main()
        'Dim b As Boolean = Wow64DisableWow64FsRedirection(x)

        Dim l As Long = New FileInfo("C:\Windows\System32\Notepad.exe").Length
        WriteLine("l=" & l.ToString)
    End Sub

End Module
