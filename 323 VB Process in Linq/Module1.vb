' 323 VB Process in Linq
' 2012-02-25	PV  VS2010


Imports System.Diagnostics

Module Module1

    Sub Main()
        Dim processes = Process.GetProcesses().OrderByDescending(Function(p) p.WorkingSet64).Take(10)
        Console.WriteLine("Process                 Memory")
        For Each p As Process In processes
            Console.WriteLine("{0,-15}{1,15:n0}", p.ProcessName, p.WorkingSet64)
        Next
        Console.WriteLine()
        Console.Write("(pause)")
        Console.ReadLine()
    End Sub

End Module
