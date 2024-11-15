' 2021-09-19 	PV		VS2022, Net6.  Moved away from assemblyinfo.vb
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
Imports System.Reflection

Public Module InfoVersion
    Public Function GetVersion() As String
        Return FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly.Location).FileMajorPart &
                "." & FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly.Location).FileMinorPart &
                "." & FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly.Location).FileBuildPart
        'Return My.Application.Info.Version.ToString
    End Function

End Module
