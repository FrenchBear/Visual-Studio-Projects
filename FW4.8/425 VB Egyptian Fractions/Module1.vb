' 425 VB Egyptian Fractions
' Finds the decomposition of a fraction in Egyptian Fractions (numerator=1)

Module Module1

    Sub Main()
        Dim r As New Random
        Dim fr As Fraction

        For i As Integer = 1 To 20
            Do
                fr = New Fraction(r.Next(2, 15), r.Next(1, 49))
            Loop While fr.Numerator = 1 Or fr.Denominator = 1       ' Eliminate trivial fractions

            Console.Write("{0} = ", fr)
            Dim isFirst As Boolean = True
            Dim fSum As Fraction = Nothing
            Try
                For Each f As Fraction In Decompose(fr)
                    If isFirst Then
                        isFirst = False
                        fSum = f
                    Else
                        Console.Write("+ ")
                        fSum += f
                    End If
                    Console.Write("{0} ", f)
                Next
                Console.Write("= {0}", fSum)
                If fSum <> fr Then Console.Write(" <========= *** Different!")
            Catch ex As OverflowException
                Console.Write(" <=== Overflow")
            Catch ex As Exception
                Console.Write(" <=== Exception " & ex.Message)
            Finally
                Console.WriteLine()
            End Try
        Next

        Console.WriteLine()
        Console.Write("(Pause)")
        Console.ReadLine()
    End Sub

    Public Function Decompose(f As Fraction) As List(Of Fraction)
        If f.Numerator = 1 Then
            Return New List(Of Fraction) From {f}
        End If

        Dim d1 As Long = f.Denominator \ f.Numerator + 1
        Dim f1 As New Fraction(1, d1)
        Dim f2 As Fraction = f - f1
        Dim l As List(Of Fraction) = Decompose(f2)
        l.Insert(0, f1)
        Return l
    End Function

End Module