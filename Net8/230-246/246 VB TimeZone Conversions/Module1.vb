' 246 VB TimeZone Conversions
'
' 2012-02-25	PV		VS2010
' 2021-09-20 	PV		VS2022; Net6
' 2021-12-05 	PV		Better output
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8

Module Module1

    Sub Main()
        WriteLine("date d               LocalToUTC(d)        UTCToLocal(d)        LocalToUTC(UTCToLocal(d))")
        T(#11/17/2006 11:05:00 AM#)
        T(#7/17/2006 11:05:00 AM#)
    End Sub

    Sub T(d As Date)
        WriteLine("{0}  {1}  {2}  {3}", d.ToString, LocalToUTC(d).ToString, UTCToLocal(d).ToString, LocalToUTC(UTCToLocal(d)).ToString)
    End Sub

End Module

Module modTimeZone
    'ReadOnly localZone As TimeZone = TimeZone.CurrentTimeZone
    ReadOnly localZone2 As TimeZoneInfo = TimeZoneInfo.Local

    Function LocalToUTC(dLocal As Date) As Date
        Return TimeZoneInfo.ConvertTimeToUtc(dLocal, localZone2)
        'Return localZone.ToUniversalTime(dLocal)
    End Function

    Function UTCToLocal(dUTC As Date) As Date
        Return TimeZoneInfo.ConvertTimeFromUtc(dUTC, localZone2)
        'Return localZone.ToLocalTime(dUTC)
    End Function

End Module
