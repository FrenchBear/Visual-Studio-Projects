' 37: Essais ADO over ODBC
' 2001-02-06    PV
' 2006-10-01    PV  VS2005  Changed database
' 2012-02-25	PV  VS2010  Changed database again!

Imports System.Data.Odbc

Class App

    Public Shared Sub Main()

        Dim co As OdbcConnection
        co = New OdbcConnection("Driver={SQL Server};Server=LU01ZEPHYR\SQL2008;Trusted_Connection=Yes;Database=NorthWind")

        Dim cmd As OdbcCommand
        cmd = New OdbcCommand("SELECT * FROM Region", co)

        Dim da As OdbcDataAdapter
        da = New OdbcDataAdapter(cmd)

        Dim ds As DataSet
        ds = New DataSet()
        da.Fill(ds, "Region")

        Dim dr As DataRow
        For Each dr In ds.Tables(0).Rows
            Console.WriteLine("{0} {1}", dr("RegionID").ToString, dr("RegionDescription").ToString)
        Next
        Console.ReadLine()
    End Sub

End Class