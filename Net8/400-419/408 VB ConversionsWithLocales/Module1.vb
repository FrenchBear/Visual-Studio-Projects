' 408 VB ConversionsWithLocales
'
' 2011-08-23    PV
' 2021-09-23 	PV		VS2022; Net6
' 2023-01-10	PV		Net7

Imports System.Console
Imports System.Globalization

Module Module1

    Sub Main()
        Dim d As Double = 1003.14

        ' US locale
        Dim usen As New CultureInfo("en-US")
        WriteLine(d.ToString(usen))
        WriteLine(Double.Parse("1003.14", usen))
        WriteLine(String.Format(usen, "{0:#,##0.###}  {0:N3}  {0:F3}", d))
        WriteLine()

        ' French locale
        Dim frfr As New CultureInfo("fr-FR")
        WriteLine(d.ToString(frfr))
        WriteLine(Double.Parse("3,14", frfr))
        WriteLine(String.Format(frfr, "{0:#,##0.###}  {0:N3}  {0:F3}", d))
        WriteLine()

        ' Invariant culture
        Dim ic = CultureInfo.InvariantCulture
        WriteLine(d.ToString(ic))
        WriteLine(Double.Parse("3.14", ic))
        WriteLine(String.Format(ic, "{0:#,##0.###}  {0:N3}  {0:F3}", d))

        ' Note: current thread default culture is CultureInfo.CurrentCulture
    End Sub

End Module
