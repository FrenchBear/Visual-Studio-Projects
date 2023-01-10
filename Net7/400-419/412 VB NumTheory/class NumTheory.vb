' Class NumTheory
' Essais de code sur les nombres premiers
'
' 2011-10-22 PV
' 2021-09-23    PV  VS2022; Net6
' 2023-01-10	PV		Net7

Class NumTheory

    ''' <summary>
    ''' Computes n factorial mod b
    ''' </summary>
    Public Shared Function FactMod(n As Long, b As Long) As Long
        Dim r As Long = 1
        While n > 1
            r = (r * n) Mod b
            n -= 1
        End While
        Return r
    End Function

    ''' <summary>
    ''' Returns if a number is prime using Wilson's theorem
    ''' </summary>
    ''' <remarks>
    ''' p is prime if and only if (p-1)! = -1 (mod p)
    '''</remarks>
    Private Shared Function IsPrimeWilson(n As Long) As Boolean
        Return FactMod(n - 1, n) = n - 1
    End Function

    ''' <summary>
    ''' Generate a list of primes using Wilson's theorem, but practically this is too slow
    ''' </summary>
    Shared Function GeneratePrimeListWilson(n As Long) As IEnumerable(Of Long)
        Dim lp As New List(Of Long)
        If n < 2 Then Return lp
        lp.Add(2)
        If n = 2 Then Return lp
        For pp As Long = 3 To n Step 2
            If IsPrimeWilson(pp) Then lp.Add(pp)
        Next
        Return lp
    End Function

    ''' <summary>
    ''' Returns next prime using Wilson's Theorem prime detection algorithm
    ''' </summary>
    Shared Function NextPrimeWilson(n As Long) As Long
        If n Mod 2 = 0 Then n += 1 Else n += 2
        While Not IsPrimeWilson(n)
            n += 2
        End While
        Return n
    End Function

    ''' <summary>
    ''' Return a list of primes based on successive divisions
    ''' </summary>
    Shared Function GeneratePrimeListDivision(n As Long) As IEnumerable(Of Long)
        Dim lp As New List(Of Long)
        If n < 2 Then Return lp
        lp.Add(2)
        If n = 2 Then Return lp
        Dim pp As Long = 3
        While pp <= n
            Dim isPrime As Boolean = True
            Dim r = CInt(Math.Sqrt(CDbl(n)))
            For Each p As Long In lp
                If p > r Then Exit For
                If pp Mod p = 0 Then isPrime = False : Exit For
            Next
            If isPrime Then lp.Add(pp)
            pp += 2
        End While
        Return lp
    End Function

    ''' <summary>
    ''' Return a list of primes based on simple Erathostenes sieve (eliminating even numbers)
    ''' </summary>
    Shared Function GeneratePrimeListSieve(n As Long) As IEnumerable(Of Long)
        Dim lp As New List(Of Long)
        If n < 2 Then Return lp
        lp.Add(2)
        If n = 2 Then Return lp

        Dim ba As New BitArray(n \ 2 + 1)
        Dim r As Long = Math.Sqrt(n)
        Dim pos As Long = 0
        For pp As Long = 3 To n Step 2
            If Not ba(pos) Then
                lp.Add(pp)
                If pp <= r Then
                    Dim pos2 As Long = (pp * pp - 3) \ 2
                    For pp2 As Long = pp * pp To n Step 2 * pp
                        ba(pos2) = True
                        pos2 += pp
                    Next
                End If
            End If
            pos += 1
        Next
        Return lp
    End Function

    ''' <summary>
    ''' Return a list of primes based on Erathostenes sieve, using factorization wheel (2x3x5)
    ''' </summary>
    ''' <remarks>
    ''' Using factorization wheel 2x3x5 eliminates multiples in a block of 30.
    ''' In the range [30k+1..30k+30], we should only check 30k+1,7,11,13,17,19,23,29, that is, we only need 8 bits
    ''' </remarks>
    Shared Function GeneratePrimeListSieve2(n As Long) As IEnumerable(Of Long)
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

    ''' <summary>
    ''' Return a list of primes based on Erathostenes sieve, using factorization wheel (2x3x5) but storing all even numbers
    ''' </summary>
    ''' <remarks>
    ''' Using factorization wheel 2x3x5 eliminates multiples in a block of 30.
    ''' In the range [30k+1..30k+30], we should only check 30k+1,7,11,13,17,19,23,29
    ''' </remarks>
    Shared Function GeneratePrimeListSieve3(n As Long) As IEnumerable(Of Long)
        Dim lp As New List(Of Long)
        If n < 2 Then Return lp
        lp.Add(2)
        If n = 2 Then Return lp
        lp.Add(3)
        If n <= 4 Then Return lp
        lp.Add(5)
        If n <= 6 Then Return lp

        ' Value to add to (n mod 30) to look for next prime
        Dim offsetAdd As SByte() = New SByte() {-1, 6, -1, -1, -1, -1, -1, 4, -1, -1, -1, 2, -1, 4, -1, -1, -1, 2, -1, 4, -1, -1, -1, 6, -1, -1, -1, -1, -1, 2, -1}

        Dim ba As New BitArray(n \ 2 + 1)
        Dim pp As Long = 7
        Dim pos As Long = (7 - 3) \ 2
        Dim r As Long = Math.Sqrt(n)
        While pp <= n
            If Not ba(pos) Then
                lp.Add(pp)
                If pp <= r Then
                    Dim pos2 As Long = (pp * pp - 3) \ 2
                    For pp2 As Long = pp * pp To n Step 2 * pp
                        ba(pos2) = True
                        pos2 += pp
                    Next
                End If
            End If
            pos += offsetAdd(pp Mod 30) \ 2
            pp += offsetAdd(pp Mod 30)
        End While
        Return lp
    End Function

    ''' <summary>
    ''' Computes a power n modulo b using binary exponentiation
    ''' </summary>
    Private Shared Function PwrMod(a As Long, n As Long, b As Long) As Long
        Dim v, r, p, res As Long
        res = 1
        p = a
        v = n
        While v > 0
            r = v Mod 2
            v \= 2
            If r = 1 Then res = (res * p) Mod b
            p = (p * p) Mod b

        End While
        Return res
    End Function

    ''' <summary>
    ''' Miller–Rabin probabilistic primality test
    ''' </summary>
    ''' <returns>false if n is composite, true if n is probably prime</returns>
    ''' <remarks>http://en.wikipedia.org/wiki/Miller%E2%80%93Rabin_primality_test</remarks>
    Public Shared Function IsPrimeMillerRabin(n As Long) As Boolean
        If n <= 3 Then Return True
        If n Mod 2 = 0 Then Return False
        Dim d As Long = n - 1
        Dim s As Long = 0
        While d Mod 2 = 0
            d \= 2
            s += 1
        End While
        For i As Long = 1 To 5        ' repeat several times
            Dim a As Long = Int(Rnd() * (n - 2) + 2)
            Dim x As Long = PwrMod(a, d, n)
            If x = 1 Or x = n - 1 Then GoTo NextLoop
            For r As Long = 1 To s - 1
                x = (x * x) Mod n
                If x = 1 Then Return False
                If x = n - 1 Then GoTo NextLoop
            Next
            Return False
NextLoop:
        Next
        Return True
    End Function

    ''' <summary>
    ''' Return a list of primes built using Miller-Rabin algorithm
    ''' </summary>
    Shared Function GeneratePrimeListMillerRabin(n As Long) As IEnumerable(Of Long)
        Dim lp As New List(Of Long)
        If n < 2 Then Return lp
        lp.Add(2)
        If n = 2 Then Return lp
        For pp As Long = 3 To n Step 2
            If IsPrimeMillerRabin(pp) Then lp.Add(pp)
        Next
        Return lp
    End Function

    ''' <summary>
    ''' Returns next prime using Miller-Rabin probabilist prime detection algorithm
    ''' </summary>
    Shared Function NextPrimeMillerRabin(n As Long) As Long
        If n Mod 2 = 0 Then n += 1 Else n += 2
        While Not IsPrimeMillerRabin(n)
            n += 2
        End While
        Return n
    End Function

    ''' <summary>
    ''' Return Greatest Common Divisor using Euclidean Algorithm
    ''' </summary>
    Shared Function GCD(a As Long, b As Long) As Long
        While b <> 0
            Dim t As Long = b
            b = a Mod b
            a = t
        End While
        Return a
    End Function

    Shared Function Factors(n As Long) As IEnumerable(Of Long)
        Dim lf As New List(Of Long)
        If IsPrimeMillerRabin(n) Then
            lf.Add(n)
            Return lf
        End If

        ' Sources:
        ' http://en.wikipedia.org/wiki/Pollard's_rho_algorithm
        ' http://www.csh.rit.edu/~pat/math/quickies/rho/

        Dim f As Long
        Do
            f = PollardRho(n)
            lf.Add(f)
            If f = 0 Then Return lf
            n \= f
            If n = 1 Then Return lf
        Loop Until IsPrimeMillerRabin(n)
        lf.Add(n)
        Return lf
    End Function

    Public Shared Function PollardRho(n As Long) As Long
        Dim x As Long = 2
        Dim y As Long = 2
        Dim d As Long = 1
        Dim f = Function(z As Long) (z * z + 1) Mod n

        While d = 1
            x = f(x)
            y = f(f(y))
            d = GCD(Math.Abs(x - y), n)
        End While
        If d = n Then Return 0 Else Return d
    End Function

End Class
