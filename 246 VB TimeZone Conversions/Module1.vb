' 246 VB TimeZone Conversions
' 2012-02-25	PV  VS2010

Module Module1

    Sub Main()
        T(#11/17/2006 11:05:00 AM#)
        T(#7/17/2006 11:05:00 AM#)
        Console.ReadLine()
    End Sub



    Sub T(ByVal d As Date)
        Console.WriteLine("{0}  {1}  {2}  {3}", d.ToString, LocalToUTC(d).ToString, UTCToLocal(d).ToString, LocalToUTC(UTCToLocal(d)).ToString)
    End Sub
End Module



Module modTimeZone
    ReadOnly localZone As TimeZone = TimeZone.CurrentTimeZone

    Function LocalToUTC(ByVal dLocal As Date) As Date
        Return localZone.ToUniversalTime(dLocal)
    End Function

    Function UTCToLocal(ByVal dUTC As Date) As Date
        Return localZone.ToLocalTime(dUTC)
    End Function
End Module