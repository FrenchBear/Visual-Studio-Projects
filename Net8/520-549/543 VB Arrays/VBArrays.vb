' 543 VB Arrays
' Play with arrays in VB
'
' 2016-08-05    PV
' 2021-09-26    PV      VS2022; Net6
' 2023-01-10	PV		Net7

Imports System.Console

Module VBArrays

    Sub Main()
        Dim mat3(,,) As Integer = New Integer(2, 3, 4) {}
        Dim jag2()() As Integer = New Integer(2)() {New Integer() {1, 2, 3}, New Integer() {4, 5, 6, 7, 8, 9}, New Integer() {0}}

        Write($"{mat3.Length} = ")
        For i As Integer = 0 To mat3.Rank - 1
            If (i > 0) Then Write(" * ")
            Write(mat3.GetLength(i))
        Next
        WriteLine()

        mat3(1, 1, 1) = 111
        mat3(0, 1, 2) = 12
        For Each m As Integer In mat3
            Write($"{m} ")
        Next
        WriteLine()

        Write($"jag2: {jag2.Length}: ")
        For i As Integer = 0 To jag2.Length - 1
            Write($"[{i}] = {jag2(i).Length}  ")
        Next
        WriteLine()
    End Sub

End Module
