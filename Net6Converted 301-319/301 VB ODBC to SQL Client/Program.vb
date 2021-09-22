' 301 VB ODBC to SQL Client
'
' 2012-02-25    PV  VS2010; App 32-bit
' 2021-09-20    PV  VS2022; Net6.  Use Microsoft.Win32.Registry instead of My.Computer.Registry

Imports Microsoft.Win32

#Disable Warning CA1416 ' Validate platform compatibility

Module Program
    Sub Main()
        Dim sDataSource As String, sDatabase As String

        '' Open a DSN using ODBC provider to retrieve Server and Database
        '' Working, but probably not efficient
        'Dim conODBC As New System.Data.Odbc.OdbcConnection
        'conODBC.ConnectionString = "DSN=dsnEurodat50;UID=eurodatonline;PWD=madeinchina"
        'conODBC.Open()
        'sDataSource = conODBC.DataSource
        'sDatabase = conODBC.Database
        'conODBC.Close()

        ' Get DSN information directly from the registry
        sDataSource = CStr(Registry.GetValue("HKEY_LOCAL_MACHINE\Software\ODBC\ODBC.INI\dsnEurodat50", "Server", ""))
        sDatabase = CStr(Registry.GetValue("HKEY_LOCAL_MACHINE\Software\ODBC\ODBC.INI\dsnEurodat50", "Database", ""))

        Dim s As String
        s = "Data Source=" & sDataSource & ";Initial Catalog=" & sDatabase & ";Persist Security Info=True;User ID=EurodatOnLine;Password=madeinchina"
        Dim conSQL As SqlClient.SqlConnection
        conSQL = New SqlClient.SqlConnection(s)
        conSQL.Open()
        Dim cmdSQL As SqlClient.SqlCommand
        cmdSQL = conSQL.CreateCommand
        cmdSQL.CommandText = "SELECT COUNT(*) FROM Operators"
        Dim n As Integer = cmdSQL.ExecuteScalar
        conSQL.Close()

        Console.WriteLine("{0} operators", n)
    End Sub
End Module
