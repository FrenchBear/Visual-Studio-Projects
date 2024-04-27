' 425 VB Egyptian Fractions
' Finds the decomposition of a fraction in Egyptian Fractions (numerator=1)
'
' 2021-09-23 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-04-21	PV		TableTests

Imports System.Console
Imports System.Text

Module Module1

    Sub Main()
        'RandomTests()
        'TableTests()
        ListTests()
    End Sub

    Sub RandomTests()
        Dim r As New Random
        Dim fr As Fraction

        For i As Integer = 1 To 20
            Do
                fr = New Fraction(r.Next(2, 15), r.Next(1, 49))
            Loop While fr.Numerator = 1 Or fr.Denominator = 1       ' Eliminate trivial fractions

            Write("{0} = ", fr)
            Dim isFirst As Boolean = True
            Dim fSum As Fraction = Nothing
            Try
                For Each f As Fraction In Decompose(fr)
                    If isFirst Then
                        isFirst = False
                        fSum = f
                    Else
                        Write("+ ")
                        fSum += f
                    End If
                    Write("{0} ", f)
                Next
                Write("= {0}", fSum)
                If fSum <> fr Then Write(" <========= *** Different!")
            Catch ex As OverflowException
                Write(" <=== Overflow")
            Catch ex As Exception
                Write(" <=== Exception " & ex.Message)
            Finally
                WriteLine()
            End Try
        Next
    End Sub

    Sub TableTests()
        Const max As Integer = 12
        Dim t(,) As String
        ReDim t(max, max)

        For num = 2 To max
            For den = 2 To max
                If num = den Then
                    t(num, den) = ""
                Else
                    Dim fr As New Fraction(num, den)
                    Dim msg As New StringBuilder()
                    msg.Append($"{num}/{den}")
                    If fr.Denominator = 1 Then
                        msg.Append($" = {fr.Numerator}")
                    ElseIf fr.Numerator <> 1 And fr.Denominator <> 1 Then
                        msg.Append(" = ")
                        If fr.Numerator <> num Then msg.Append($"{fr.Numerator}/{fr.Denominator} = ")
                        msg.Append(String.Join("+"c, Decompose(fr)))
                    End If
                    t(num, den) = msg.ToString()
                End If
            Next
        Next

        ' Compute width of each column
        Dim width(max) As Integer
        For c = 2 To max
            Dim maxw = 0
            For r = 2 To max
                maxw = Math.Max(maxw, t(r, c).Length)
            Next
            width(c) = maxw
        Next

        ' Print table
        Console.Write("         ")
        For c = 2 To max
            Console.Write(" | ")
            Console.Write(Center($".../{c}", width(c)))
        Next
        Console.WriteLine(" |")
        For r = 2 To max
            Console.Write($"{r}/...".PadLeft(9))
            For c = 2 To max
                Console.Write(" | ")
                Console.Write(t(r, c).PadLeft(width(c)))
            Next
            Console.WriteLine(" |")
        Next
    End Sub

    Sub ListTests()
        Const max As Integer = 13
        For num = 2 To max
            For den = num + 1 To max
                Dim fr As New Fraction(num, den)
                If num = fr.Numerator Then
                    WriteLine($"{num}/{den} = {String.Join(" + ", Decompose(fr))}")
                End If
            Next
            WriteLine()
        Next
    End Sub

    Function Center(ByVal s As String, ByVal w As Integer) As String
        If s.Length > w Then Return s
        Return s.PadLeft((w + s.Length) \ 2).PadRight(w)
    End Function

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
