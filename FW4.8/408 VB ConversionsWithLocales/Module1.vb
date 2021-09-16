' 408 VB ConversionsWithLocales
' 2011-08-23    PV

Imports System.Globalization

Module Module1

    Sub Main()
        Dim d As Double = 1003.14

        ' US locale
        Dim usen As New CultureInfo("en-US")
        Console.WriteLine(d.ToString(usen))
        Console.WriteLine(Double.Parse("1003.14", usen))
        Console.WriteLine(String.Format(usen, "{0:#,##0.###}  {0:N3}  {0:F3}", d, d, d))
        Console.WriteLine()

        ' French locale
        Dim frfr As New CultureInfo("fr-FR")
        Console.WriteLine(d.ToString(frfr))
        Console.WriteLine(Double.Parse("3,14", frfr))
        Console.WriteLine(String.Format(frfr, "{0:#,##0.###}  {0:N3}  {0:F3}", d, d, d))
        Console.WriteLine()

        ' Invariant culture
        Dim ic = CultureInfo.InvariantCulture
        Console.WriteLine(d.ToString(ic))
        Console.WriteLine(Double.Parse("3.14", ic))
        Console.WriteLine(String.Format(ic, "{0:#,##0.###}  {0:N3}  {0:F3}", d, d, d))

        ' Note: current thread default culture is CultureInfo.CurrentCulture

        Console.ReadLine()
    End Sub

End Module