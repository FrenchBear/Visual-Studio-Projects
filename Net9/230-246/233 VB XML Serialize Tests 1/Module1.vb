﻿' 233 VB XML Serialize Tests 1
'
' 2012-02-25	PV		VS2010
' 2021-09-20 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9

Imports System.Console
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization

' The XmlRootAttribute allows you to set an alternate name
' (PurchaseOrder) of the XML element, the element namespace; by
' default, the XmlSerializer uses the class name. The attribute
' also allows you to set the XML namespace for the element.  Lastly,
' the attribute sets the IsNullable property, which specifies whether
' the xsi:null attribute appears if the class instance is set to
' a null reference.

'<XmlRootAttribute("AllPurchaseOrders", Namespace:="http://www.cpandl.com", IsNullable:=False)>

Public Class AllPurchaseOrders

    <XmlArray("Orders")>
    Public Orders() As PurchaseOrder

End Class

Public Class PurchaseOrder

    <XmlAttribute()>
    Public Number As Integer

    Public ShipTo As Address
    Public OrderDate As String

    ' The XmlArrayAttribute changes the XML element name
    ' from the default of "OrderedItems" to "Items".
    <XmlArray("Items")>
    Public OrderedItems() As OrderedItem

    Public SubTotal As Decimal
    Public ShipCost As Decimal
    Public TotalCost As Decimal
End Class 'PurchaseOrder

Public Class Address

    ' The XmlAttribute instructs the XmlSerializer to serialize the Name
    ' field as an XML attribute instead of an XML element (the default
    ' behavior).
    <XmlAttribute()>
    Public Name As String

    Public Line1 As String

    ' Setting the IsNullable property to false instructs the
    ' XmlSerializer that the XML attribute will not appear if
    ' the City field is set to a null reference.
    <XmlElement(IsNullable:=False)>
    Public City As String

    Public State As String
    Public Zip As String
End Class 'Address

Public Class OrderedItem
    Public ItemName As String
    Public Description As String
    Public UnitPrice As Decimal
    Public Quantity As Integer
    Public LineTotal As Decimal

    ' Calculate is a custom method that calculates the price per item,
    ' and stores the value in a field.
    Public Sub Calculate()
        LineTotal = UnitPrice * Quantity
    End Sub 'Calculate

End Class 'OrderedItem

Public Class Test

    Public Shared Sub Main()
        ' Read and write purchase orders.
        Dim t As New Test()
        CreatePO("c:\po.xml")
        t.ReadPO("c:\po.xml")
    End Sub 'Main

    Private Shared Sub CreatePO(filename As String)
        ' Create an instance of the XmlSerializer class;
        ' specify the type of object to serialize.
        Dim serializer As New XmlSerializer(GetType(AllPurchaseOrders))
        Dim writer As New StreamWriter(filename)

        Dim po1 As New PurchaseOrder With {
            .Number = 1
        }
        ' Create an address to ship and bill to.
        Dim billAddress As New Address With {
            .Name = "Teresa Atkinson",
            .Line1 = "1 Main St.",
            .City = "AnyTown",
            .State = "WA",
            .Zip = "00000"
        }
        ' Set ShipTo and BillTo to the same addressee.
        po1.ShipTo = billAddress
        po1.OrderDate = Date.Now.ToLongDateString()

        ' Create an OrderedItem object.
        Dim i1 As New OrderedItem With {
            .ItemName = "Widget S",
            .Description = "Small widget",
            .UnitPrice = 5.23,
            .Quantity = 3
        }
        i1.Calculate()

        ' Insert the item into the array.
        Dim items(0) As OrderedItem
        items(0) = i1
        po1.OrderedItems = items
        ' Calculate the total cost.
        Dim subTotal As New Decimal()
        Dim oi As OrderedItem
        For Each oi In items
            subTotal += oi.LineTotal
        Next oi
        po1.SubTotal = subTotal
        po1.ShipCost = 12.51
        po1.TotalCost = po1.SubTotal + po1.ShipCost

        Dim po2 As New PurchaseOrder With {
            .Number = 2
        }
        ' Create an address to ship and bill to.
        Dim billAddress2 As New Address With {
            .Name = "John Doe",
            .Line1 = "8343 Colby Pkwy",
            .City = "Urb",
            .State = "IA",
            .Zip = "50322"
        }
        ' Set ShipTo and BillTo to the same addressee.
        po2.ShipTo = billAddress2
        po2.OrderDate = Date.Now.ToLongDateString()

        ' Create an OrderedItem object.
        Dim i2 As New OrderedItem With {
            .ItemName = "Sprocket K",
            .Description = "Small sprocket",
            .UnitPrice = 3.14,
            .Quantity = 2
        }
        i2.Calculate()

        ' Insert the item into the array.
        Dim items2(0) As OrderedItem
        items2(0) = i2
        po2.OrderedItems = items2
        ' Calculate the total cost.
        Dim subTotal2 As New Decimal()
        Dim oi2 As OrderedItem
        For Each oi2 In items2
            subTotal += oi2.LineTotal
        Next oi2
        po2.SubTotal = subTotal
        po2.ShipCost = 12.51
        po2.TotalCost = po2.SubTotal + po2.ShipCost

        Dim apo As New AllPurchaseOrders
        ReDim apo.Orders(2)
        apo.Orders(0) = po1
        apo.Orders(1) = po2

        ' Serialize the purchase order, and close the TextWriter.
        serializer.Serialize(writer, apo)
        writer.Close()
        'Stop
    End Sub 'CreatePO

    Protected Sub ReadPO(filename As String)
        ' Create an instance of the XmlSerializer class;
        ' specify the type of object to be deserialized.
        Dim serializer As New XmlSerializer(GetType(AllPurchaseOrders))
        ' If the XML document has been altered with unknown
        ' nodes or attributes, handle them with the
        ' UnknownNode and UnknownAttribute events.
        AddHandler serializer.UnknownNode, AddressOf Serializer_UnknownNode
        AddHandler serializer.UnknownAttribute, AddressOf Serializer_UnknownAttribute

        ' A FileStream is needed to read the XML document.
        Dim fs As New FileStream(filename, FileMode.Open)
        ' Declare an object variable of the type to be deserialized.

        Dim apo As AllPurchaseOrders
#Disable Warning CA5369 ' Use XmlReader for 'XmlSerializer.Deserialize()'
        apo = CType(serializer.Deserialize(fs), AllPurchaseOrders)

        Dim po As PurchaseOrder
        po = apo.Orders(1)
        WriteLine("OrderDate: " & po.OrderDate)

        ' Read the shipping address.
        Dim shipTo As Address = po.ShipTo
        ReadAddress(shipTo, "Ship To:")
        ' Read the list of ordered items.
        Dim items As OrderedItem() = po.OrderedItems
        WriteLine("Items to be shipped:")
        Dim oi As OrderedItem
        For Each oi In items
            WriteLine(ControlChars.Tab & oi.ItemName & ControlChars.Tab &
            oi.Description & ControlChars.Tab & oi.UnitPrice & ControlChars.Tab &
            oi.Quantity & ControlChars.Tab & oi.LineTotal)
        Next oi
        ' Read the subtotal, shipping cost, and total cost.
        WriteLine(New String(ControlChars.Tab, 5) &
        " Subtotal" & ControlChars.Tab & po.SubTotal)
        WriteLine(New String(ControlChars.Tab, 5) &
        " Shipping" & ControlChars.Tab & po.ShipCost)
        WriteLine(New String(ControlChars.Tab, 5) &
        " Total" & New String(ControlChars.Tab, 2) & po.TotalCost)
    End Sub 'ReadPO

    Protected Shared Sub ReadAddress(a As Address, label As String)
        ' Read the fields of the Address object.
        WriteLine(label)
        WriteLine(ControlChars.Tab & a.Name)
        WriteLine(ControlChars.Tab & a.Line1)
        WriteLine(ControlChars.Tab & a.City)
        WriteLine(ControlChars.Tab & a.State)
        WriteLine(ControlChars.Tab & a.Zip)
        WriteLine()
    End Sub 'ReadAddress

    Private Sub Serializer_UnknownNode(sender As Object, e As XmlNodeEventArgs)
        WriteLine("Unknown Node:" & e.Name & ControlChars.Tab & e.Text)
    End Sub 'serializer_UnknownNode

    Private Sub Serializer_UnknownAttribute(sender As Object, e As XmlAttributeEventArgs)
        Dim attr As XmlAttribute = e.Attr
        WriteLine("Unknown attribute " & attr.Name & "='" & attr.Value & "'")
    End Sub 'serializer_UnknownAttribute

End Class 'Test
