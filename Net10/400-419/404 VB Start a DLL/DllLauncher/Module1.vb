' DllLauncher
'
' 2011-05-19    PV
' 2021-09-23 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
' 2026-01-19	PV		Net10

Imports System.IO
Imports System.Reflection

Friend Module Module1
    Public Sub Main()
        'Dim a = Assembly.LoadFile("C:\Development\Visual Studio Projects\404 Start a DLL\Output\MyDLL.dll")
        Dim a = Assembly.LoadFile(Path.GetFullPath("MyDLL.dll"))
        Dim m = a.GetTypes.Where(Function(t) t.Name = "MainClass").First
        Dim o = Activator.CreateInstance(m)
        o.Main("Hello World")
    End Sub

End Module
