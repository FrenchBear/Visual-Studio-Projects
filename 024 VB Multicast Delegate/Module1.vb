' 24 VB Multicast Delegate
' Essais de combinaison de delegates Multicast
' 2001-01-27    PV
' 2006-10-01    PV  VS2005
' 2012-02-25	PV  VS2010

Delegate Sub MyDelegate(ByVal sMsg As String)


Class MyApp

    Public Shared Sub Main()
        Dim d1, d2, d3 As MyDelegate
        d1 = New MyDelegate(AddressOf Sub1)
        d2 = AddressOf Sub2
        d3 = CType(System.Delegate.Combine(d1, d2), MyDelegate)

        d1.Invoke("Hello 1")
        d2("Hello 2")
        d3("Hello 3")

        Console.ReadLine()
    End Sub


    Shared Sub Sub1(ByVal s As String)
        Console.WriteLine("Sub1: " & s)
    End Sub

    Shared Sub Sub2(ByVal s As String)
        Console.WriteLine("Sub2: " & s)
    End Sub

End Class
