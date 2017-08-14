' 231 VB SyncLock
' 2012-02-25	PV  VS2010

Option Compare Text

Public Class frmVB231
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim country As New Country
        With country
            .Name = "France" : .Area = 55000000
        End With
        SyncLock "country".GetType
            Debug.WriteLine(country!Name)
            Debug.WriteLine(country!Area)
        End SyncLock
        Stop
    End Sub
End Class

Class Country
    Public Name As String
    Public Area As Double
    Public Population As Integer
    Default Public ReadOnly Property machin(ByVal sProperty As String) As String
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
