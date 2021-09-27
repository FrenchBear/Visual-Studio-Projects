' 320 VB Enumerate ODBC Sources
'
' 2012-02-25	PV  VS2010
' 2021-09-22    PV  VS2022; Net6

Imports System.Data.Odbc

Module Module1

    Sub Main()
        Dim oi As Object = GetSystemDSN("dsnELFBuild")

        Stop

        Dim myConnection As OdbcConnection
        Try
            myConnection = New OdbcConnection("DSN=dsnELFBuild")  ';trusted_connection=Yes")

            myConnection.Open()
        Catch ex As Exception
            Stop
        End Try
    End Sub

End Module