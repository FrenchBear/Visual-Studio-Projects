' 320 VB Enumerate ODBC Sources
'
' 2012-02-25	PV		VS2010
' 2021-09-22 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9

Imports System.Data.Odbc

Friend Module Module1
    Public Sub Main()
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
