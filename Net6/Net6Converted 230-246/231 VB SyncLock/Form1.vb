' 231 VB SyncLock
'
' 2012-02-25	PV  VS2010
' 2021-09-20    PV  VS2022; Net6

Option Compare Text

Public Class frmVB231

    Private Sub Button1_Click(sender As System.Object, e As EventArgs) Handles Button1.Click
        Dim country As New Country
        With country
            .Name = "France" : .Area = 55000000
        End With
        SyncLock "country".GetType
            Debug.WriteLine(country!Name)
            Debug.WriteLine(country!Area)
        End SyncLock
    End Sub

End Class

Class Country
    Public Name As String
    Public Area As Double
    Public Population As Integer

    Default Public ReadOnly Property machin(sProperty As String) As String
        Get
            Select Case sProperty
                Case "Name" : Return Name
                Case "Area" : Return Area
                Case "Population" : Return Population
            End Select
            Return "Unknown property <" & sProperty & ">"
        End Get
    End Property

End Class