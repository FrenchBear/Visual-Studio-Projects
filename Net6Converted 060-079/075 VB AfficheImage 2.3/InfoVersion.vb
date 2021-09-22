' 2021-09-19    PV  VS2022, Net6.  Moved away from assemblyinfo.vb

Public Module InfoVersion

    Function GetVersion() As String
        Return System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart &
                "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart &
                "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart
        'Return My.Application.Info.Version.ToString
    End Function

End Module