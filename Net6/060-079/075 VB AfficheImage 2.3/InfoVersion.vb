' 2021-09-19    PV  VS2022, Net6.  Moved away from assemblyinfo.vb
Imports System.Reflection

Public Module InfoVersion

    Function GetVersion() As String
        Return FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly.Location).FileMajorPart &
                "." & FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly.Location).FileMinorPart &
                "." & FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly.Location).FileBuildPart
        'Return My.Application.Info.Version.ToString
    End Function

End Module