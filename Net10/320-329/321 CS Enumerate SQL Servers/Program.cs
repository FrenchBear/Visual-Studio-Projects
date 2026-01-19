// Enumerate SQL Servers on aabstract local network uusing ODBC services
// From http://jordev.net/forums/thread/1399.aspx
//
// 2008-12-01   PV
// 2012-02-25	PV		VS2010
// 2021-09-22	PV		VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13
// 2026-01-19	PV		Net10 C#14

#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments

using System;
using System.Runtime.InteropServices;
using System.Text;
using static System.Console;

namespace CS321;

internal class Program
{
    private static void Main(string[] args)
    {
        var ts = GetServers();
        foreach (var s in ts)
            WriteLine(s);

    }

#pragma warning disable SYSLIB1054 // Use 'LibraryImportAttribute' instead of 'DllImportAttribute' to generate P/Invoke marshalling code at compile time
    [DllImport("odbc32.dll")]
    private static extern short SQLAllocHandle(short hType, nint inputHandle, out nint outputHandle);

    [DllImport("odbc32.dll")]
    private static extern short SQLSetEnvAttr(nint henv, int attribute, nint valuePtr, int strLength);

    [DllImport("odbc32.dll")]
    private static extern short SQLFreeHandle(short hType, nint handle);
#pragma warning restore SYSLIB1054 // Use 'LibraryImportAttribute' instead of 'DllImportAttribute' to generate P/Invoke marshalling code at compile time

    [DllImport("odbc32.dll", CharSet = CharSet.Ansi)]
    private static extern short SQLBrowseConnect(nint hconn, StringBuilder inString,
        short inStringLength, StringBuilder outString, short outStringLength,
        out short outLengthNeeded);

    private const short SQL_HANDLE_ENV = 1;
    private const short SQL_HANDLE_DBC = 2;
    private const int SQL_ATTR_ODBC_VERSION = 200;
    private const int SQL_OV_ODBC3 = 3;
    private const short SQL_SUCCESS = 0;
    private const short SQL_NEED_DATA = 99;
    private const short DEFAULT_RESULT_SIZE = 1024;
    private const string SQL_DRIVER_STR = "DRIVER=SQL SERVER";

    /// <summary>
    /// Gets the sql servers instances in the network
    /// </summary>
    /// <returns></returns>
    public static string[] GetServers()
    {
        string[] retval = null;
        var txt = string.Empty;
        var henv = nint.Zero;
        var hconn = nint.Zero;
        StringBuilder inString = new(SQL_DRIVER_STR);
        StringBuilder outString = new(DEFAULT_RESULT_SIZE);
        var inStringLength = (short)inString.Length;
        short lenNeeded = 0;

        try
        {
            if (SQL_SUCCESS == SQLAllocHandle(SQL_HANDLE_ENV, henv, out henv))
                if (SQL_SUCCESS == SQLSetEnvAttr(henv, SQL_ATTR_ODBC_VERSION, SQL_OV_ODBC3, 0))
                    if (SQL_SUCCESS == SQLAllocHandle(SQL_HANDLE_DBC, henv, out hconn))
                        if (SQL_NEED_DATA == SQLBrowseConnect(hconn, inString, inStringLength, outString,
                                DEFAULT_RESULT_SIZE, out lenNeeded))
                        {
                            if (DEFAULT_RESULT_SIZE < lenNeeded)
                            {
                                outString.Capacity = lenNeeded;
                                if (SQL_NEED_DATA != SQLBrowseConnect(hconn, inString, inStringLength, outString,
                                        lenNeeded, out lenNeeded))
                                    throw new ApplicationException("Unabled to aquire SQL Servers from ODBC driver.");
                            }
                            txt = outString.ToString();
                            var start = txt.IndexOf('{') + 1;
                            var len = txt.IndexOf('}') - start;
                            txt = start > 0 && len > 0 ? txt.Substring(start, len) : string.Empty;
                        }
        }
        catch (Exception ex)
        {
            WriteLine(ex.Message);
            txt = string.Empty;
        }
        finally
        {
            if (hconn != nint.Zero)
                _ = SQLFreeHandle(SQL_HANDLE_DBC, hconn);
            if (henv != nint.Zero)
                _ = SQLFreeHandle(SQL_HANDLE_ENV, hconn);
        }

        if (txt.Length > 0)
            retval = txt.Split(",".ToCharArray());

        return retval;
    }
}
