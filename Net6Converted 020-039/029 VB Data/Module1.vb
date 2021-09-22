' 2001-08-19    PV  Adaptation pour la Beta2: galère...
' 2006-10-01    PV  VS2005  Working again
' 2012-02-25	PV  VS2010  Galère again, rebuild OldDb connection string for SQL 2008 and Ok again (http://www.connectionstrings.com/sql-server-2008#p2)
' 2021-09-18    PV  VS2022, Net6

Imports System.Data.OleDb

#Disable Warning CA1416 ' Validate platform compatibility

Module Module1

    Sub Main()
        Using con As New OleDbConnection("Provider=SQLNCLI10;Server=LU01ZEPHYR\SQL2008;Database=NorthWind;Trusted_Connection=Yes;")
            con.Open()

            Dim Command As New OleDbCommand("SELECT * FROM Region", con)
            Dim reader As OleDbDataReader = Command.ExecuteReader()
            While reader.Read()
                Console.WriteLine(reader.GetInt32(0).ToString & ": " & reader("RegionDescription").ToString)
            End While

            ' always call Close when done reading.
            reader.Close()
        End Using

        Console.ReadLine()
    End Sub

End Module