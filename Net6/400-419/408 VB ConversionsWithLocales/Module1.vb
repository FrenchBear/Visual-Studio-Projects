' 408 VB ConversionsWithLocales
'
' 2011-08-23    PV
' 2021-09-23    PV  VS2022; Net6

Imports System.Globalization

Module Module1

    Sub Main()
        Dim d As Double = 1003.14

        ' US locale
        Dim usen As New CultureInfo("en-US")
        Console.WriteLine(d.ToString(usen))
        Console.WriteLine(Double.Parse("1003.14", usen))
        Console.WriteLine(String.Format(usen, "{0:#,##0.###}  {0:N3}  {0:F3}", d))
        Console.WriteLine()

        ' French locale
        Dim frfr As New CultureInfo("fr-FR")
        Console.WriteLine(d.ToString(frfr))
        Console.WriteLine(Double.Parse("3,14", frfr))
        Console.WriteLine(String.Format(frfr, "{0:#,##0.###}  {0:N3}  {0:F3}", d))
        Console.WriteLine()

        ' Invariant culture
        Dim ic = CultureInfo.InvariantCulture
        Console.WriteLine(d.ToString(ic))
        Console.WriteLine(Double.Parse("3.14", ic))
        Console.WriteLine(String.Format(ic, "{0:#,##0.###}  {0:N3}  {0:F3}", d))

        ' Note: current thread default culture is CultureInfo.CurrentCulture
    End Sub

End Module