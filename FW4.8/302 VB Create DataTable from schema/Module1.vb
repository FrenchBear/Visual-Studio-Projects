' 302 VB Create DataTable from schema
' 2012-02-25	PV  VS2010

Imports System.Data.SqlClient

Module Module1

    Sub Main()
        Const sConnectionString As String = "Data Source=LU01ZEPHYR\SQL2008;Initial Catalog=Eurodat506_EUMEDM_Dev;User ID=EurodatOnLine;Password=madeinchina;Persist Security Info=True"
        Using conSQL As New SqlConnection(sConnectionString)
            conSQL.Open()
            Dim sSQL As String = "SELECT * FROM PriorityLevels"
            Dim cmd As SqlCommand
            cmd = New SqlCommand(sSQL, conSQL)
            Dim r As SqlDataReader = cmd.ExecuteReader()
            While r.Read
                Console.WriteLine("{0}: {1}", r("priorityLevelCode"), r("priorityLevelName"))
            End While
            r.Close()
            cmd.Dispose()
            Console.WriteLine()

            Dim startTicks As Long = DateTime.Now.Ticks
            Dim da As SqlDataAdapter, T As DataTable = Nothing
            For i As Integer = 1 To 1000
                da = New SqlDataAdapter
                T = New DataTable
                da.SelectCommand = New SqlCommand("SELECT * FROM PriorityLevels WHERE 1=0", conSQL)
                da.Fill(T)
            Next
            Dim endTicks As Long = DateTime.Now.Ticks
            For Each column As DataColumn In T.Columns
                Console.WriteLine("{0}: {1}, {2}", column.ColumnName, column.DataType.ToString, column.MaxLength)
            Next
            Console.WriteLine(T.Rows.Count)
            Console.WriteLine("t={0}", (endTicks - startTicks) / 10000000.0 / 1000.0)

        End Using
        Console.WriteLine("(pause)")
        Console.ReadLine()
    End Sub

End Module