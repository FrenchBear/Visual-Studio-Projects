' 509 VB Goldbach
' Goldbach: each even number is the sum of two primes
' This code counts how many different combinations of the sum of two primes produce a given number
'
' 2013-03-08    PV
' 2021-09-26    PV      VS2022; Net6

Imports System.Console

Module App

    ' Max number of primes and max of sum too
    Const n As Long = 1000

    Sub Main()
        GeneratePrimesList(n)

        'WriteLine("2..{0}: {1} primes", n, nPrimes)
        'For i As Long = 0 To nPrimes - 1
        '    Console.Write("{0} ", tPrimes(i))
        'Next
        'WriteLine()

        ' Initialize count results
        Dim tc(n) As Pair
        For i As Integer = 0 To n
            tc(i).Number = i
        Next

        ' Generate all pair of primes, increment result[sum]
        For i As Integer = 1 To nPrimes - 1
            For j As Integer = 1 To i
                Dim s As Long = tPrimes(i) + tPrimes(j)
                If s <= n Then tc(s).Combinations += 1
            Next
        Next

        ' Present result
        'Array.Sort(Of Pair)(tc, New PairComparer())
        For i As Integer = 0 To n
            If tc(i).Combinations > 0 Then
                Write("{0}: {1},  ", tc(i).Number, tc(i).Combinations)
            End If
        Next
        WriteLine()
    End Sub

    ' This structure is only used for sorting, to keep track of initial index after sorting (stored in Number)
    Public Structure Pair
        Public Number As Integer
        Public Combinations As Integer
    End Structure

    ' Simple comparer class
    Public Class PairComparer
        Implements IComparer(Of Pair)

        Public Function Compare(x As Pair, y As Pair) As Integer Implements IComparer(Of Pair).Compare
            Return x.Combinations - y.Combinations
        End Function

    End Class

End Module