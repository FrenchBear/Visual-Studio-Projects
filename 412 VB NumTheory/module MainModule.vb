﻿' 412 VB NumTheory
' Essais de code sur les nombres premiers
' 2011-10-22 PV

Imports System.Runtime.CompilerServices

#Disable Warning IDE0051 ' Remove unused private members

Module MainModule

    Private Delegate Function FunctionToTest(n As Long) As Long

    Private Delegate Function NextPrimeDelegate(n As Long) As Long

    ReadOnly nt As New NumTheory

    Sub Main()
        Dim np As Long = nt.NextPrimeMillerRabin(100) * nt.NextPrimeMillerRabin(200) * nt.NextPrimeMillerRabin(300)
        Dim lf = nt.factors(np)
        Console.Write("factors of {0}: ", np)
        lf.WriteLine()
        Console.WriteLine()

        TestNextPrime(AddressOf nt.NextPrimeWilson, 1000000)
        TestNextPrime(AddressOf nt.NextPrimeMillerRabin, 1000000)
        'Console.ReadLine()

        Const n As Long = 10000000
        ' Max 715 million (2^31\3)
        'TimeExec(AddressOf TestWilson, n)
        TimeExec(AddressOf TestDivision, n)
        TimeExec(AddressOf TestSieve, n)
        TimeExec(AddressOf TestSieve2, n)
        TimeExec(AddressOf TestSieve3, n)
        TimeExec(AddressOf TestMillerRabin, n)

        Console.ReadLine()
    End Sub

    Private Sub TestNextPrime(nextPrime As NextPrimeDelegate, start As Long)
        Dim sw = Stopwatch.StartNew
        For i = 1 To 10
            start = nextPrime(start)
            Console.Write(start)
            Console.Write(" "c)
        Next
        Console.WriteLine()
        Console.WriteLine("Test of " & nextPrime.Method.ToString & ": " & sw.Elapsed.ToString)
        Console.WriteLine()
    End Sub

    Private Sub TimeExec(ft As FunctionToTest, n As Long)
        Dim sw = Stopwatch.StartNew
        Dim np As Long = ft(n)
        sw.Stop()
        Console.WriteLine("Test of " & ft.Method.ToString & ": " & sw.Elapsed.ToString)
        Console.WriteLine(np.ToString & " prime(s) <= " & n.ToString & " found.")
        Console.WriteLine()
    End Sub

    Private Function TestWilson(n As Long) As Long
        Return nt.GeneratePrimeListWilson(n).Count
    End Function

    Private Function TestDivision(n As Long) As Long
        Return nt.GeneratePrimeListDivision(n).Count
    End Function

    Private Function TestSieve(n As Long) As Long
        Return nt.GeneratePrimeListSieve(n).Count
    End Function

    Private Function TestSieve2(n As Long) As Long
        Return nt.GeneratePrimeListSieve2(n).Count
    End Function

    Private Function TestSieve3(n As Long) As Long
        Return nt.GeneratePrimeListSieve3(n).Count
    End Function

    Private Function TestMillerRabin(n As Long) As Long
        Return nt.GeneratePrimeListMillerRabin(n).Count
    End Function

    ' Quick helpers to print an enumaration
    <Extension()>
    Public Sub Write(Of TSource)(source As IEnumerable(Of TSource))
        For Each element As TSource In source
            Console.Write(element)
            Console.Write(" "c)
        Next
    End Sub

    <Extension()>
    Public Sub WriteLine(Of TSource)(source As IEnumerable(Of TSource))
        Write(source)
        Console.WriteLine()
    End Sub

End Module