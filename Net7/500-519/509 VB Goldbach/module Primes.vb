' Primes generator
'
' 2021-09-26    PV      VS2022; Net6
' 2023-01-10	PV		Net7

Module Primes
    Public tPrimes() As Long    ' From index 0 to nPrimes-1
    Public nPrimes As Long

    Public Sub GeneratePrimesList(n As Long)
        tPrimes = GeneratePrimeListSieve2(n).ToArray()
        nPrimes = UBound(tPrimes) + 1
    End Sub

    ''' <summary>
    ''' Return a list of primes based on Erathostenes sieve, using factorization wheel (2x3x5)
    ''' </summary>
    ''' <remarks>
    ''' Using factorization wheel 2x3x5 eliminates multiples in a block of 30.
    ''' In the range [30k+1..30k+30], we should only check 30k+1,7,11,13,17,19,23,29, that is, we only need 8 bits
    ''' </remarks>
    Private Function GeneratePrimeListSieve2(n As Long) As IEnumerable(Of Long)
        Dim lp As New List(Of Long)
        If n < 2 Then Return lp
        lp.Add(2)
        If n = 2 Then Return lp
        lp.Add(3)
        If n <= 4 Then Return lp
        lp.Add(5)
        If n <= 6 Then Return lp

        ' Offest of (n mod 30) in a block of 8 bits
        Dim offsetPos As SByte() = New SByte() {-1, 0, -1, -1, -1, -1, -1, 1, -1, -1, -1, 2, -1, 3, -1, -1, -1, 4, -1, 5, -1, -1, -1, 6, -1, -1, -1, -1, -1, 7, -1}

        ' Value to add to (n mod 30) to look for next prime
        Dim offsetAdd As SByte() = New SByte() {-1, 6, -1, -1, -1, -1, -1, 4, -1, -1, -1, 2, -1, 4, -1, -1, -1, 2, -1, 4, -1, -1, -1, 6, -1, -1, -1, -1, -1, 2, -1}

        Dim ba As New BitArray((n \ 30 + 1) * 8)
        Dim pp As Long = 7
        Dim pos As Long = (pp \ 30) * 8 + offsetPos(pp Mod 30)
        Dim r As Long = Math.Sqrt(n)
        While pp <= n
            If Not ba(pos) Then
                lp.Add(pp)
                If pp <= r Then
                    Dim pp2 As Long = pp * pp
                    Dim ppd2 As Long = pp2 \ 30
                    Dim ppm2 As Integer = pp2 Mod 30
                    While pp2 <= n
                        Dim o As SByte = offsetPos(ppm2)
                        If o >= 0 Then ba((ppd2 << 3) + o) = True
                        pp2 += pp + pp
                        ppm2 += pp + pp
                        If ppm2 >= 30 Then
                            ppd2 += ppm2 \ 30
                            ppm2 = ppm2 Mod 30
                        End If
                    End While
                End If
            End If
            pp += offsetAdd(pp Mod 30)
            pos += 1
        End While
        Return lp
    End Function

End Module
