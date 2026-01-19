' 246 VB TimeZone Conversions
'
' 2012-02-25	PV		VS2010
' 2021-09-20 	PV		VS2022; Net6
' 2021-12-05 	PV		Better output
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
' 2026-01-19	PV		Net10

Friend Module Module1
    Public Sub Main()
        WriteLine("date d               LocalToUTC(d)        UTCToLocal(d)        LocalToUTC(UTCToLocal(d))")
        T(#11/17/2006 11:05:00 AM#)
        T(#7/17/2006 11:05:00 AM#)
    End Sub

    Public Sub T(d As Date)
        WriteLine("{0}  {1}  {2}  {3}", d.ToString, LocalToUTC(d).ToString, UTCToLocal(d).ToString, LocalToUTC(UTCToLocal(d)).ToString)
    End Sub

End Module

Friend Module modTimeZone
    'ReadOnly localZone As TimeZone = TimeZone.CurrentTimeZone
    Private ReadOnly localZone2 As TimeZoneInfo = TimeZoneInfo.Local

    Public Function LocalToUTC(dLocal As Date) As Date
        Return TimeZoneInfo.ConvertTimeToUtc(dLocal, localZone2)
        'Return localZone.ToUniversalTime(dLocal)
    End Function

    Public Function UTCToLocal(dUTC As Date) As Date
        Return TimeZoneInfo.ConvertTimeFromUtc(dUTC, localZone2)
        'Return localZone.ToLocalTime(dUTC)
    End Function

End Module
