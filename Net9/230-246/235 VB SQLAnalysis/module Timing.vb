' module Timing
' Precise timing in .Net
' Usage:
' Dim c1 As Long = QueryPerformanceCounter
' ... code
' Dim c2 As Long = QueryPerformanceCounter
' Dim t1_ms As Long = (c2 - c1) * 1000.0 / QueryPerformanceFrequency
'
' 2021-09-20 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9


Friend Module Timing
    Declare Sub QueryPerformanceCounter Lib "Kernel32.dll" (ByRef perfcount As Long)
    Declare Sub QueryPerformanceFrequency Lib "Kernel32.dll" (ByRef freq As Long)

    Public Function QueryPerformanceCounter() As Long
        Dim perfCount As Long
        QueryPerformanceCounter(perfCount)
        Return perfCount
    End Function

    Public Function QueryPerformanceFrequency() As Long
        Dim freq As Long
        QueryPerformanceFrequency(freq)
        Return freq
    End Function

End Module
