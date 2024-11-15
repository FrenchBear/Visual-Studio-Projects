' Lambda functions and Select projections
'
' 2008-08-20    PV
' 2012-02-25 	PV		VS2010
' 2012-03-04    List --> IEnumerable; Console output; C# version
' 2021-09-20 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
Imports System.Text

Friend Module Module1
    Public Sub Main()
        Dim fruits() As String =
            {"apple", "passionfruit", "banana", "mango",
             "orange", "blueberry", "grape", "strawberry"}

        ' Project the length of each string and
        ' put the length values into an enumerable object.
        Dim lengths As IEnumerable(Of Integer)
        ' With a lambda function
        lengths = fruits.Select(Function(fruit) fruit.Length)

        ' With a generic delegate
        ' Note: a custom delegate does not work since there are no delegates conversions
        Dim selector As Func(Of String, Integer) = AddressOf LengthOfString
        lengths = fruits.Select(selector)

        ' Display the results.
        Dim output As New StringBuilder
        For Each length As Integer In lengths
            output.AppendLine(length.ToString)
        Next

        WriteLine(output.ToString())
    End Sub

    Private Function LengthOfString(s As String) As Integer
        Return s.Length
    End Function

End Module
