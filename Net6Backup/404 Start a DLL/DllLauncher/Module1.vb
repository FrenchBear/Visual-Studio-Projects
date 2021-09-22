' DllLauncher
' 2011-05-19 FPVI

Imports System.Reflection

Module Module1

    Sub Main()
        Dim a = Assembly.LoadFile("C:\Development\Visual Studio Projects\404 Start a DLL\Output\MyDLL.dll")
        Dim m = a.GetTypes.Where(Function(t) t.Name = "MainClass").First
        Dim o = Activator.CreateInstance(m)
        o.Main("Hello World")
        Console.ReadLine()
    End Sub

End Module