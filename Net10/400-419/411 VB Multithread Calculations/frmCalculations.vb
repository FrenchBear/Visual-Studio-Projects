' 411 Multithread VB Calculations
'
' 2011-10-22    PV
' 2021-09-23 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
' 2026-01-19	PV		Net10

Public Delegate Sub FHandler(Value As Double, Calculations As Double)

Public Delegate Sub A2Handler(Value As Integer, Calculations As Double)

Public Delegate Sub LDhandler(Calculations As Double, Count As Integer)

Public Class CalculationsForm

    Public Sub FactHandler(Factorial As Double, TotalCalculations As Double)
        ' Displays the returned value in the appropriate label.
        Factorial1Label.Text = Factorial.ToString
        ' Re-enables the button so it can be used again.
        Factorial1Button.Enabled = True
        ' Updates the label that displays the total calculations performed
        lblTotalCalculations.Text = "TotalCalculations are " & TotalCalculations.ToString
    End Sub

    Public Sub Fact1Handler(Factorial As Double, TotalCalculations As Double)
        lblFactorial2.Text = Factorial.ToString
        Factorial2Button.Enabled = True
        lblTotalCalculations.Text = "TotalCalculations are " & TotalCalculations.ToString
    End Sub

    Public Sub Add2Handler(Result As Integer, TotalCalculations As Double)
        lblAddTwo.Text = Result.ToString
        AddTwoButton.Enabled = True
        lblTotalCalculations.Text = "TotalCalculations are " & TotalCalculations.ToString
    End Sub

    Public Sub LDoneHandler(TotalCalculations As Double, Counter As Integer)
        RunLoopsButton.Enabled = True
        lblRunLoops.Text = Counter.ToString
        lblTotalCalculations.Text = "TotalCalculations are " & TotalCalculations.ToString
    End Sub

    Private Sub Calculator1_FactorialComplete(Factorial As Double, TotalCalculations As Double) Handles Calculator1.FactorialComplete
        ' BeginInvoke causes asynchronous execution to begin at the address
        ' specified by the delegate. Simply put, it transfers execution of
        ' this method back to the main thread. Any parameters required by
        ' the method contained at the delegate are wrapped in an object and
        ' passed.
        BeginInvoke(New FHandler(AddressOf FactHandler), New Object() {Factorial, TotalCalculations})
    End Sub

    Private Sub Calculator1_FactorialMinusComplete(Factorial As Double, TotalCalculations As Double) Handles Calculator1.FactorialMinusComplete
        BeginInvoke(New FHandler(AddressOf Fact1Handler), New Object() {Factorial, TotalCalculations})
    End Sub

    Private Sub Calculator1_AddTwoComplete(Result As Integer, TotalCalculations As Double) Handles Calculator1.AddTwoComplete
        BeginInvoke(New A2Handler(AddressOf Add2Handler), New Object() {Result, TotalCalculations})
    End Sub

    Private Sub Calculator1_LoopComplete(TotalCalculations As Double, Counter As Integer) Handles Calculator1.LoopComplete
        BeginInvoke(New LDhandler(AddressOf LDoneHandler), New Object() {TotalCalculations, Counter})
    End Sub

    Private Sub Factorial1Button_Click(sender As Object, e As EventArgs) Handles Factorial1Button.Click
        Dim n As Integer
        If Not Integer.TryParse(txtValue.Text, n) Then
            MsgBox("Enter a number first!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        ' Passes the value typed in the txtValue to Calculator.varFact1.
        Calculator1.varFact1 = CInt(txtValue.Text)
        ' Disables the btnFactorial1 until this calculation is complete.
        Factorial1Button.Enabled = False
        'Calculator1.Factorial()
        Calculator1.ChooseThreads(1)
    End Sub

    Private Sub Factorial2Button_Click(sender As Object, e As EventArgs) Handles Factorial2Button.Click
        Calculator1.varFact2 = CInt(txtValue.Text)
        Factorial2Button.Enabled = False
        'Calculator1.FactorialMinusOne()
        Calculator1.ChooseThreads(2)
    End Sub

    Private Sub AddTwoButton_Click(sender As Object, e As EventArgs) Handles AddTwoButton.Click
        Calculator1.varAddTwo = CInt(txtValue.Text)
        AddTwoButton.Enabled = False
        'Calculator1.AddTwo()
        Calculator1.ChooseThreads(3)
    End Sub

    Private Sub RunLoopsButton_Click(sender As Object, e As EventArgs) Handles RunLoopsButton.Click
        Calculator1.varLoopValue = CInt(txtValue.Text)
        RunLoopsButton.Enabled = False
        ' Lets the user know that a loop is running.
        lblRunLoops.Text = "Looping"
        'Calculator1.RunALoop()
        Calculator1.ChooseThreads(4)
    End Sub

End Class
