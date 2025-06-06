﻿' 323 VB Process in Linq
'
' 2012-02-25	PV		VS2010
' 2021-09-22 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9

Friend Module Module1
    Public Sub Main()
        Dim processes = Process.GetProcesses().OrderByDescending(Function(p) p.WorkingSet64).Take(10)
        WriteLine("Process                 Memory")
        For Each p As Process In processes
            WriteLine("{0,-15}{1,15:n0}", p.ProcessName, p.WorkingSet64)
        Next

    End Sub

End Module
