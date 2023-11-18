' 2006-10-01 	PV		VS2005
' 2012-02-25	PV		VS2010
' 2021-09-19 	PV		VS2022; Net6
' 2023-01-10	PV		Net7

#Disable Warning CA1822 ' Mark members as static

<ComClass(DotNetClass1.ClassId, DotNetClass1.InterfaceId, DotNetClass1.EventsId)> _
Public Class DotNetClass1
#Region "COM GUIDs"
    ' These  GUIDs provide the COM identity for this class 
    ' and its COM interfaces. You can generate 
    ' these guids using guidgen.exe
    Public Const ClassId As String = "7666AC25-855F-4534-BC55-27BF09D49D46"
    Public Const InterfaceId As String = "54388137-8A76-491e-AA3A-853E23AC1217"
    Public Const EventsId As String = "EA329A13-16A0-478d-B41F-47583A761FF2"
#End Region

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub Message(ByVal sMsg As String)
        MsgBox(sMsg)
    End Sub

    Function AddNumbers(ByVal X As Integer, ByVal Y As Integer) As Integer
        AddNumbers = X + Y
    End Function
End Class

