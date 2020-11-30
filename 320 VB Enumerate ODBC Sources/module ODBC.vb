Option Explicit On
Option Compare Text

Module ODBC

    Private Declare Function SQLDataSources Lib "odbc32.dll" (hEnv As Integer, fDirection As Short, szDSN As String, cbDSNMax As Short, ByRef pcbDSN As Short, szDescription As String, cbDescriptionMax As Short, ByRef pcbDescription As Short) As Integer
    Private Declare Function SQLAllocHandle Lib "odbc32.dll" (HandleType As Short, InputHandle As Integer, ByRef OutputHandlePtr As Integer) As Integer
    Private Declare Function SQLSetEnvAttr Lib "odbc32.dll" (EnvironmentHandle As Integer, dwAttribute As Integer, ValuePtr As Integer, StringLen As Integer) As Integer
    Private Declare Function SQLFreeHandle Lib "odbc32.dll" (HandleType As Short, Handle As Integer) As Integer

    Private Const SQL_MAX_DSN_LENGTH As Integer = 32
    Private Const SQL_MAX_DESC_LENGTH As Integer = 128
    Private Const SQL_SUCCESS As Integer = 0
    Private Const SQL_FETCH_NEXT As Integer = 1
    Private Const SQL_NULL_HANDLE As Integer = 0
    Private Const SQL_HANDLE_ENV As Integer = 1
    Private Const SQL_ATTR_ODBC_VERSION As Integer = 200
    Private Const SQL_OV_ODBC3 As Integer = 3
    Private Const SQL_IS_INTEGER As Integer = (-6)

    Public Class DSNInfo
        'Public
    End Class

    Public Function GetSystemDSN(dsnName As String) As Object
        Dim hEnv As Integer 'handle to the environment
        Dim sServer As String
        Dim sDriver As String
        Dim nSvrLen As Short
        Dim nDvrLen As Short

        'obtain a handle to the environment
        If SQLAllocHandle(SQL_HANDLE_ENV, SQL_NULL_HANDLE, hEnv) <> 0 Then

            'if successful, set the
            'environment for subsequent calls
            If SQLSetEnvAttr(hEnv, SQL_ATTR_ODBC_VERSION, SQL_OV_ODBC3, SQL_IS_INTEGER) <> 0 Then

                'set up the strings for the call
                sServer = Space(SQL_MAX_DSN_LENGTH)
                sDriver = Space(SQL_MAX_DESC_LENGTH)

                'load the DSN names
                Do While SQLDataSources(hEnv, SQL_FETCH_NEXT, sServer, SQL_MAX_DSN_LENGTH, nSvrLen, sDriver, SQL_MAX_DESC_LENGTH, nDvrLen) = SQL_SUCCESS

                    'add data to the controls
                    Console.WriteLine(Left(sServer, nSvrLen) & ": " & Left(sDriver, nDvrLen))

                    'repad the strings
                    sServer = Space(SQL_MAX_DSN_LENGTH)
                    sDriver = Space(SQL_MAX_DESC_LENGTH)
                Loop

            End If 'If SQLSetEnvAttr

            'clean up
            Call SQLFreeHandle(SQL_HANDLE_ENV, hEnv)

        End If 'If SQLAllocHandle

        'since each DSN returned its corresponding
        'driver, and a given driver can be used
        'for multiple DSN's, remove any adjacent
        'duplicates
        'RemoveListDuplicates(List2)
        Return Nothing
    End Function

End Module