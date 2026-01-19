' 302 VB Create DataTable from schema
'
' 2012-02-25	PV		VS2010
' 2021-09-20 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
' 2026-01-19	PV		Net10

Imports System.Console
Imports System.Data.SqlClient

Friend Module Module1
    Public Sub Main()
        Const sConnectionString As String = "Data Source=LU01ZEPHYR\SQL2008;Initial Catalog=Eurodat506_EUMEDM_Dev;User ID=EurodatOnLine;Password=madeinchina;Persist Security Info=True"
        Using conSQL As New SqlConnection(sConnectionString)
            conSQL.Open()
            Dim sSQL As String = "SELECT * FROM PriorityLevels"
            Dim cmd As SqlCommand
            cmd = New SqlCommand(sSQL, conSQL)
            Dim r As SqlDataReader = cmd.ExecuteReader()
            While r.Read
                WriteLine("{0}: {1}", r("priorityLevelCode"), r("priorityLevelName"))
            End While
            r.Close()
            cmd.Dispose()
            WriteLine()

            Dim startTicks As Long = Date.Now.Ticks
            Dim da As SqlDataAdapter, T As DataTable = Nothing
            For i As Integer = 1 To 1000
                da = New SqlDataAdapter
                T = New DataTable
                da.SelectCommand = New SqlCommand("SELECT * FROM PriorityLevels WHERE 1=0", conSQL)
                da.Fill(T)
            Next
            Dim endTicks As Long = Date.Now.Ticks
            For Each column As DataColumn In T.Columns
                WriteLine("{0}: {1}, {2}", column.ColumnName, column.DataType.ToString, column.MaxLength)
            Next
            WriteLine(T.Rows.Count)
            WriteLine("t={0}", (endTicks - startTicks) / 10000000.0 / 1000.0)

        End Using

    End Sub

End Module
