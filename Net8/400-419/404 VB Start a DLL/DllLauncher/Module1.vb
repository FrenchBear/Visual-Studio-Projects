' DllLauncher
'
' 2011-05-19    PV
' 2021-09-23 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8

Imports System.IO
Imports System.Reflection

Module Module1

    Sub Main()
        'Dim a = Assembly.LoadFile("C:\Development\Visual Studio Projects\404 Start a DLL\Output\MyDLL.dll")
        Dim a = Assembly.LoadFile(Path.GetFullPath("MyDLL.dll"))
        Dim m = a.GetTypes.Where(Function(t) t.Name = "MainClass").First
        Dim o = Activator.CreateInstance(m)
        o.Main("Hello World")
    End Sub

End Module
