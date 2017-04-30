' 226 VB Text Mixer (Harry Potter)
' Mixer project
' Tests to see how text lisibility is altered adding random characters
' but based on characters/pair frequency of apparition in a given text
' 2006-02-26    FPVI
' 2010-05-01    FPVI    VS2010 and code cleanup
'
' For awful (really) array.sort performances:
' http://msdn.microsoft.com/newsgroups/default.aspx?dg=microsoft.public.dotnet.framework&mid=11166612-1b5a-4fc7-a40a-0f673b92beef


Imports System.IO                                  ' StreamReader
Imports VB = Microsoft.VisualBasic

Public Class Form1
    Declare Sub QueryPerformanceCounter Lib "Kernel32.dll" (ByRef perfcount As Long)
    Declare Sub QueryPerformanceFrequency Lib "Kernel32.dll" (ByRef freq As Long)

    Public Shared Function QueryPerformanceCounter() As Long
        Dim perfCount As Long
        QueryPerformanceCounter(perfCount)
        Return perfCount
    End Function

    Public Shared Function QueryPerformanceFrequency() As Long
        Dim freq As Long
        QueryPerformanceFrequency(freq)
        Return freq
    End Function


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim c1 As Long = QueryPerformanceCounter()

        For i As Integer = 1 To 1
            Analyze2()
        Next
        Dim c2 As Long = QueryPerformanceCounter()
        Encrypt("Harry Potter was a highly unusual boy in many ways. For one thing, he hated the summer holidays more than any other time of year. For another, he really wanted to do his homework but was forced to do it in secret, in the dead of night. And he also happened to be a wizard.")
        Dim c3 As Long = QueryPerformanceCounter()

        Dim t1_ms As Long = (c2 - c1) * 1000.0 / QueryPerformanceFrequency()
        Dim t2_ms As Long = (c3 - c2) * 1000.0 / QueryPerformanceFrequency()
        MsgBox("Analyze in " & t1_ms.ToString & "ms" & vbCrLf &
               "Encrypt in " & t2_ms.ToString & "ms")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim sw As New Stopwatch
        sw.Start()
        Analyze()
        sw.Stop()
        MsgBox("Anayze in " & sw.Elapsed.ToString)
    End Sub


    Dim tdSingleProb(126 - 32) As Double     ' Cumuled probability
    Dim tiSingleChar(126 - 32) As Integer    ' Character code
    Dim tdDoubleProb(126 - 32)() As Double     ' Cumuled probability
    Dim tiDoubleChar(126 - 32)() As Integer    ' Character code

    Function isFiller(ByVal i As Integer) As Boolean
        Static aldRand As New ArrayList
        If i >= aldRand.Count Then aldRand.Add(Rnd)
        isFiller = aldRand.Item(i) < 0
    End Function

    Sub Encrypt(ByVal s As String)
        Dim i, j, i0 As Integer, c As Integer, bFiller As Boolean
        Do
            If isFiller(i0) Then
                If i = 0 Then
                    c = GetRandomChar()
                Else
                    If isFiller(i0 + 1) Or i >= s.Length Then
                        c = GetRandomChar(c)
                    Else
                        c = GetRandomChar(c, Asc(s.Chars(i)))
                    End If
                End If
                bFiller = True
            Else
                If i >= s.Length Then Exit Do
                c = Asc(s.Chars(i))
                i += 1
                bFiller = False
            End If
            If bFiller Then
                Debug.Write(LCase(Chr(c)))
            Else
                Debug.Write(UCase(Chr(c)))
            End If

            j += 1
            If c = 32 And j >= 60 Then
                Debug.WriteLine("")
                j = 0
            End If
            i0 += 1
        Loop
        Debug.WriteLine("")
    End Sub

    Sub Analyze()
        Const sSourceFilename As String = "..\..\Harry Potter and the Prisoner of Azkaban.txt"
        Dim srSource As StreamReader
        srSource = New StreamReader(sSourceFilename)

        Dim tlSingle(126 - 32) As Long
        Dim tlPairs(126 - 32, 126 - 32) As Long
        Dim lTot As Long

        ' Read file and count characters and pairs
        Dim i, j, li As Integer
        Do
            i = srSource.Read()
            If i < 0 Then Exit Do
            If i = 13 Then i = 32 ' CR = white space
            If i >= 32 And i < 127 Then
                tlSingle(i - 32) += 1
                If li >= 32 Then tlPairs(li - 32, i - 32) += 1
                lTot += 1
                li = i
            End If
        Loop
        srSource.Close()

        ' Build single char prob arrays, sort, and calculate cumuated probability
        For i = 32 To 126
            tiSingleChar(i - 32) = i
            If tlSingle(i - 32) = 0 Then
                tdSingleProb(i - 32) = -1.0
            Else
                tdSingleProb(i - 32) = tlSingle(i - 32) / lTot
            End If
            'Debug.WriteLine(String.Format("tdSingleProb({0})={1}", i - 32, tdSingleProb(i - 32)))
        Next
        Array.Sort(tdSingleProb, tiSingleChar, New DoubleDescComparer)
        'ArraySort2(tdSingleProb, tiSingleChar)
        For i = 1 To 126 - 32
            If tdSingleProb(i) < 0 Then
                tdSingleProb(i) = 2
            Else
                tdSingleProb(i) += tdSingleProb(i - 1)
            End If
        Next

        ' Pairs
        For i = 32 To 126
            lTot = 0
            For j = 32 To 126
                lTot += tlPairs(i - 32, j - 32)
            Next
            If lTot = 0 Then Continue For

            Dim ti() As Integer, td() As Double
            ti = New Integer() {}
            ReDim ti(126 - 32)
            td = New Double() {}
            ReDim td(126 - 32)

            For j = 32 To 126
                ti(j - 32) = j
                If tlPairs(i - 32, j - 32) = 0 Then
                    td(j - 32) = -1.0
                Else
                    td(j - 32) = tlPairs(i - 32, j - 32) / lTot
                End If
            Next
            ' Use DoubleDescComparer2 takes 2s
            ' Use DoubleDescComparer takes 0.1s
            Array.Sort(td, ti, New DoubleDescComparer2)
            'ArraySort2(td, ti)
            For j = 1 To 126 - 32
                If td(j) < 0 Then
                    td(j) = 2
                Else
                    td(j) += td(j - 1)
                End If
            Next

            tiDoubleChar(i - 32) = ti
            tdDoubleProb(i - 32) = td
        Next

    End Sub

    ' Plain bubble sort, 25 times faster than Array.Sort !!!
    ' Array.Sort: 100ms
    ' ArraySort2: 4ms
    Sub ArraySort2(ByRef td() As Double, ByRef ti() As Integer)
        Dim bSwap As Boolean
        Dim i, j As Integer
        Do
            bSwap = False
            For j = UBound(td) To i + 1 Step -1
                If td(j) > td(j - 1) Then
                    bSwap = True
                    Dim dt As Double, it As Integer
                    dt = td(j) : td(j) = td(j - 1) : td(j - 1) = dt
                    it = ti(j) : ti(j) = ti(j - 1) : ti(j - 1) = it
                End If
            Next
            i = i + 1
        Loop While bSwap
    End Sub

    Function GetRandomChar() As Integer
        Static myDoubleAscComparer As New DoubleAscComparer
        Dim j As Integer
        j = Array.BinarySearch(tdSingleProb, Rnd(), myDoubleAscComparer)
        If j < 0 Then j = -1 - j
        GetRandomChar = tiSingleChar(j)
    End Function

    Function GetRandomChar(ByVal FirstChar As Integer) As Integer
        Static myDoubleAscComparer As New DoubleAscComparer
        Dim j As Integer
        j = Array.BinarySearch(tdDoubleProb(FirstChar - 32), Rnd(), myDoubleAscComparer)
        If j < 0 Then j = -1 - j
        GetRandomChar = tiDoubleChar(FirstChar - 32)(j)
    End Function

    Function GetRandomChar(ByVal FirstChar As Integer, ByVal NextChar As Integer) As Integer
        Static myDoubleAscComparer As New DoubleAscComparer
        Dim j, k As Integer
        Do
            j = Array.BinarySearch(tdDoubleProb(FirstChar - 32), Rnd(), myDoubleAscComparer)
            If j < 0 Then j = -1 - j
            Dim iCandidate As Integer
            iCandidate = tiDoubleChar(FirstChar - 32)(j)
            For k = 0 To 126 - 32
                If tiDoubleChar(iCandidate - 32)(k) = iCandidate Then Exit For
            Next
            If k <= 126 - 32 AndAlso tdDoubleProb(iCandidate - 32)(k) <= 1 Then
                GetRandomChar = iCandidate
                Exit Function
            End If
        Loop
    End Function

    Shared iCall As Integer

    Sub Analyze2()
        For i As Integer = 32 To 126
            tiSingleChar(i - 32) = i
        Next
        tdSingleProb(0) = 0.180176689018498
        tdSingleProb(1) = 0.00165308715252059
        tdSingleProb(2) = 0.0119869257320756
        tdSingleProb(3) = -1
        tdSingleProb(4) = -1
        tdSingleProb(5) = -1
        tdSingleProb(6) = -1
        tdSingleProb(7) = 0.00638016426225059
        tdSingleProb(8) = 0.0000637689406016845
        tdSingleProb(9) = 0.000068674243724891
        tdSingleProb(10) = 0.00000817550520534416
        tdSingleProb(11) = -1
        tdSingleProb(12) = 0.0133538702024092
        tdSingleProb(13) = 0.00431666674842172
        tdSingleProb(14) = 0.0154467995349773
        tdSingleProb(15) = -1
        tdSingleProb(16) = 0.00000327020208213767
        tdSingleProb(17) = 0.000019621212492826
        tdSingleProb(18) = 0.000009810606246413
        tdSingleProb(19) = 0.00000163510104106883
        tdSingleProb(20) = 0.00000163510104106883
        tdSingleProb(21) = 0.00000327020208213767
        tdSingleProb(22) = 0.00000327020208213767
        tdSingleProb(23) = 0.00000163510104106883
        tdSingleProb(24) = -1
        tdSingleProb(25) = 0.00000654040416427533
        tdSingleProb(26) = 0.0000604987385195468
        tdSingleProb(27) = 0.000582095970620504
        tdSingleProb(28) = -1
        tdSingleProb(29) = -1
        tdSingleProb(30) = -1
        tdSingleProb(31) = 0.00167597856709555
        tdSingleProb(32) = -1
        tdSingleProb(33) = 0.00188036619722916
        tdSingleProb(34) = 0.00157296720150822
        tdSingleProb(35) = 0.00106772097981795
        tdSingleProb(36) = 0.00119035355789811
        tdSingleProb(37) = 0.00112004421313215
        tdSingleProb(38) = 0.000979425523600231
        tdSingleProb(39) = 0.000979425523600231
        tdSingleProb(40) = 0.00702766427451384
        tdSingleProb(41) = 0.00332743061857508
        tdSingleProb(42) = 0.000147159093696195
        tdSingleProb(43) = 0.000250170459283531
        tdSingleProb(44) = 0.0012328661849659
        tdSingleProb(45) = 0.00166616796084914
        tdSingleProb(46) = 0.00100231693817519
        tdSingleProb(47) = 0.00096634471527168
        tdSingleProb(48) = 0.00191960862221481
        tdSingleProb(49) = 0.000142253790572988
        tdSingleProb(50) = 0.00196702655240581
        tdSingleProb(51) = 0.00231857327623561
        tdSingleProb(52) = 0.00264068818132617
        tdSingleProb(53) = 0.00036462753215835
        tdSingleProb(54) = 0.000295953288433459
        tdSingleProb(55) = 0.00168578917334197
        tdSingleProb(56) = 0.0000130808083285507
        tdSingleProb(57) = 0.000860063147602206
        tdSingleProb(58) = 0.0000245265156160325
        tdSingleProb(59) = -1
        tdSingleProb(60) = -1
        tdSingleProb(61) = -1
        tdSingleProb(62) = -1
        tdSingleProb(63) = 0.00000163510104106883
        tdSingleProb(64) = 0.00000163510104106883
        tdSingleProb(65) = 0.0600016678030619
        tdSingleProb(66) = 0.010665764090892
        tdSingleProb(67) = 0.0155563513047289
        tdSingleProb(68) = 0.036035991844116
        tdSingleProb(69) = 0.0890181708778694
        tdSingleProb(70) = 0.0148140154320836
        tdSingleProb(71) = 0.0188494448014415
        tdSingleProb(72) = 0.0424521283292701
        tdSingleProb(73) = 0.0468538203318274
        tdSingleProb(74) = 0.000663851022673946
        tdSingleProb(75) = 0.00926448249869601
        tdSingleProb(76) = 0.030620537196096
        tdSingleProb(77) = 0.0160223551014335
        tdSingleProb(78) = 0.0490791928487221
        tdSingleProb(79) = 0.0573855061373518
        tdSingleProb(80) = 0.0122550823028109
        tdSingleProb(81) = 0.000541218444593784
        tdSingleProb(82) = 0.0480376334855612
        tdSingleProb(83) = 0.044350480637951
        tdSingleProb(84) = 0.0610791993891263
        tdSingleProb(85) = 0.0212497731297306
        tdSingleProb(86) = 0.00611364279255637
        tdSingleProb(87) = 0.0169903349177462
        tdSingleProb(88) = 0.000992506331928782
        tdSingleProb(89) = 0.0179648551382233
        tdSingleProb(90) = 0.00067202652787929
        tdSingleProb(91) = -1
        tdSingleProb(92) = -1
        tdSingleProb(93) = -1
        tdSingleProb(94) = -1

        'Array.Sort(tdSingleProb, tiSingleChar, New DoubleDescComparer2)
        'ArraySort2(tdSingleProb, tiSingleChar)

        Dim t(94) As TempClass
        For i As Integer = 0 To 94
            t(i) = New TempClass
            t(i).Prob = tdSingleProb(i)
            t(i).iChar = i
        Next

        iCall = 0
        Array.Sort(t, New TempClassDescComparer)
        MsgBox("Nb call: " & iCall.ToString)
    End Sub

    Class TempClass
        Public Prob As Double
        Public iChar As Integer
    End Class

    Class TempClassDescComparer
        Implements System.Collections.IComparer

        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare
            Compare = Math.Sign(CType(y, TempClass).Prob - CType(x, TempClass).Prob)
            iCall += 1
        End Function
    End Class

End Class


Class DoubleDescComparer
    Implements System.Collections.IComparer

    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare
        Compare = Math.Sign(CType(y, Double) - CType(x, Double))
    End Function
End Class

Class DoubleDescComparer2
    Implements System.Collections.IComparer

    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare
        Compare = Math.Sign(y - x)
    End Function
End Class


Class DoubleAscComparer
    Implements System.Collections.IComparer

    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare
        Compare = Math.Sign(x - y)
    End Function
End Class
