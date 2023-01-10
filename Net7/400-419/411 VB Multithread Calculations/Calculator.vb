' 411 Multithread VB Calculations
'
' 2011-10-22    PV
' 2021-09-23    PV  VS2022; Net6
' 2023-01-10	PV		Net7
Imports System.Threading

#Disable Warning IDE0059 ' Unnecessary assignment of a value

Public Class Calculator

    ' Declares the variables you will use to hold your thread objects.
    Public FactorialThread As Thread

    Public FactorialMinusOneThread As Thread
    Public AddTwoThread As Thread
    Public LoopThread As Thread

    Public varAddTwo As Integer
    Public varFact1 As Integer
    Public varFact2 As Integer
    Public varLoopValue As Integer
    Public varTotalCalculations As Double = 0

    Public Event FactorialComplete(Factorial As Double, TotalCalculations As Double)

    Public Event FactorialMinusComplete(Factorial As Double, TotalCalculations As Double)

    Public Event AddTwoComplete(Result As Integer, TotalCalculations As Double)

    Public Event LoopComplete(TotalCalculations As Double, Counter As Integer)

    ' This sub will calculate the value of a number minus 1 factorial
    ' (varFact2-1!).
    Public Sub FactorialMinusOne()
        Dim varX As Integer = 1
        Dim varTotalAsOfNow As Double
        Dim varResult As Double = 1
        ' Performs a factorial calculation on varFact2 - 1.
        For varX = 1 To varFact2 - 1
            varResult *= varX
            ' Increments varTotalCalculations and keeps track of the current
            ' total as of this instant.
            SyncLock Me
                varTotalCalculations += 1
                varTotalAsOfNow = varTotalCalculations
            End SyncLock
        Next varX
        ' Signals that the method has completed, and communicates the
        ' result and a value of total calculations performed up to this
        ' point
        RaiseEvent FactorialMinusComplete(varResult, varTotalAsOfNow)
    End Sub

    ' This sub will calculate the value of a number factorial (varFact1!).
    Public Sub Factorial()
        Dim varX As Integer = 1
        Dim varResult As Double = 1
        Dim varTotalAsOfNow As Double = 0
        For varX = 1 To varFact1
            varResult *= varX
            SyncLock Me
                varTotalCalculations += 1
                varTotalAsOfNow = varTotalCalculations
            End SyncLock
        Next varX
        RaiseEvent FactorialComplete(varResult, varTotalAsOfNow)
    End Sub

    ' This sub will add two to a number (varAddTwo + 2).
    Public Sub AddTwo()
        Dim varResult As Integer
        Dim varTotalAsOfNow As Double
        varResult = varAddTwo + 2
        SyncLock Me
            varTotalCalculations += 1
            varTotalAsOfNow = varTotalCalculations
        End SyncLock
        RaiseEvent AddTwoComplete(varResult, varTotalAsOfNow)
    End Sub

    ' This method will run a loop with a nested loop varLoopValue times.
    Public Sub RunALoop()
        Dim varX As Integer
        Dim varY As Integer
        Dim varTotalAsOfNow As Double
        For varX = 1 To varLoopValue
            ' This nested loop is added solely for the purpose of slowing
            ' down the program and creating a processor-intensive
            ' application.
            For varY = 1 To 500
                SyncLock Me
                    varTotalCalculations += 1
                    varTotalAsOfNow = varTotalCalculations
                End SyncLock
            Next
        Next
        RaiseEvent LoopComplete(varTotalAsOfNow, varX - 1)
    End Sub

    Public Sub ChooseThreads(threadNumber As Integer)
        ' Determines which thread to start based on the value it receives.
        Select Case threadNumber
            Case 1
                ' Sets the thread using the AddressOf the subroutine where the thread will start.
                FactorialThread = New Thread(AddressOf Factorial)
                ' Starts the thread.
                FactorialThread.Start()
            Case 2
                FactorialMinusOneThread = New Thread(AddressOf FactorialMinusOne)
                FactorialMinusOneThread.Start()
            Case 3
                AddTwoThread = New Thread(AddressOf AddTwo)
                AddTwoThread.Start()
            Case 4
                LoopThread = New Thread(AddressOf RunALoop)
                LoopThread.Start()
        End Select
    End Sub

End Class
