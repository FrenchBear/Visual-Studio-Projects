' 411 Multithread VB Calculations
' 2011-10-22    PV

Public Delegate Sub FHandler(Value As Double, Calculations As Double)

Public Delegate Sub A2Handler(Value As Integer, Calculations As Double)

Public Delegate Sub LDhandler(Calculations As Double, Count As Integer)

Public Class frmCalculations

    Public Sub FactHandler(Factorial As Double, TotalCalculations As Double)
        ' Displays the returned value in the appropriate label.
        lblFactorial1.Text = Factorial.ToString
        ' Re-enables the button so it can be used again.
        btnFactorial1.Enabled = True
        ' Updates the label that displays the total calculations performed
        lblTotalCalculations.Text = "TotalCalculations are " & TotalCalculations.ToString
    End Sub

    Public Sub Fact1Handler(Factorial As Double, TotalCalculations As Double)
        lblFactorial2.Text = Factorial.ToString
        btnFactorial2.Enabled = True
        lblTotalCalculations.Text = "TotalCalculations are " & TotalCalculations.ToString
    End Sub

    Public Sub Add2Handler(Result As Integer, TotalCalculations As Double)
        lblAddTwo.Text = Result.ToString
        btnAddTwo.Enabled = True
        lblTotalCalculations.Text = "TotalCalculations are " & TotalCalculations.ToString
    End Sub

    Public Sub LDoneHandler(TotalCalculations As Double, Counter As Integer)
        btnRunLoops.Enabled = True
        lblRunLoops.Text = Counter.ToString
        lblTotalCalculations.Text = "TotalCalculations are " & TotalCalculations.ToString
    End Sub

    Private Sub Calculator1_FactorialComplete(Factorial As System.Double, TotalCalculations As System.Double) Handles Calculator1.FactorialComplete
        ' BeginInvoke causes asynchronous execution to begin at the address
        ' specified by the delegate. Simply put, it transfers execution of
        ' this method back to the main thread. Any parameters required by
        ' the method contained at the delegate are wrapped in an object and
        ' passed.
        Me.BeginInvoke(New FHandler(AddressOf FactHandler), New Object() {Factorial, TotalCalculations})
    End Sub

    Private Sub Calculator1_FactorialMinusComplete(Factorial As System.Double, TotalCalculations As System.Double) Handles Calculator1.FactorialMinusComplete
        Me.BeginInvoke(New FHandler(AddressOf Fact1Handler), New Object() {Factorial, TotalCalculations})
    End Sub

    Private Sub Calculator1_AddTwoComplete(Result As System.Int32, TotalCalculations As System.Double) Handles Calculator1.AddTwoComplete
        Me.BeginInvoke(New A2Handler(AddressOf Add2Handler), New Object() {Result, TotalCalculations})
    End Sub

    Private Sub Calculator1_LoopComplete(TotalCalculations As System.Double, Counter As System.Int32) Handles Calculator1.LoopComplete
        Me.BeginInvoke(New LDhandler(AddressOf LDoneHandler), New Object() {TotalCalculations, Counter})
    End Sub

    Private Sub btnFactorial1_Click(sender As Object, e As EventArgs) Handles btnFactorial1.Click
        ' Passes the value typed in the txtValue to Calculator.varFact1.
        Calculator1.varFact1 = CInt(txtValue.Text)
        ' Disables the btnFactorial1 until this calculation is complete.
        btnFactorial1.Enabled = False
        'Calculator1.Factorial()
        Calculator1.ChooseThreads(1)
    End Sub

    Private Sub btnFactorial2_Click(sender As Object, e As EventArgs) Handles btnFactorial2.Click
        Calculator1.varFact2 = CInt(txtValue.Text)
        btnFactorial2.Enabled = False
        'Calculator1.FactorialMinusOne()
        Calculator1.ChooseThreads(2)
    End Sub

    Private Sub btnAddTwo_Click(sender As Object, e As EventArgs) Handles btnAddTwo.Click
        Calculator1.varAddTwo = CInt(txtValue.Text)
        btnAddTwo.Enabled = False
        'Calculator1.AddTwo()
        Calculator1.ChooseThreads(3)
    End Sub

    Private Sub btnRunLoops_Click(sender As Object, e As EventArgs) Handles btnRunLoops.Click
        Calculator1.varLoopValue = CInt(txtValue.Text)
        btnRunLoops.Enabled = False
        ' Lets the user know that a loop is running.
        lblRunLoops.Text = "Looping"
        'Calculator1.RunALoop()
        Calculator1.ChooseThreads(4)
    End Sub

End Class