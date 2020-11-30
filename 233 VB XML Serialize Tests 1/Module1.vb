' 233 VB XML Serialize Tests 1
' 2012-02-25	PV  VS2010

Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.IO
Imports Microsoft.VisualBasic


' The XmlRootAttribute allows you to set an alternate name
' (PurchaseOrder) of the XML element, the element namespace; by
' default, the XmlSerializer uses the class name. The attribute
' also allows you to set the XML namespace for the element.  Lastly,
' the attribute sets the IsNullable property, which specifies whether
' the xsi:null attribute appears if the class instance is set to
' a null reference. 

'<XmlRootAttribute("AllPurchaseOrders", Namespace:="http://www.cpandl.com", IsNullable:=False)> 

Public Class AllPurchaseOrders
    <XmlArrayAttribute("Orders")>
    Public Orders() As PurchaseOrder
End Class

Public Class PurchaseOrder
    <XmlAttribute()>
    Public Number As Integer

    Public ShipTo As Address
    Public OrderDate As String
    ' The XmlArrayAttribute changes the XML element name
    ' from the default of "OrderedItems" to "Items". 
    <XmlArrayAttribute("Items")>
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
    <XmlElementAttribute(IsNullable:=False)>
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
        t.CreatePO("c:\po.xml")
        t.ReadPO("c:\po.xml")

        Console.ReadLine()
    End Sub 'Main

    Private Sub CreatePO(ByVal filename As String)
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
        po1.OrderDate = System.DateTime.Now.ToLongDateString()

        ' Create an OrderedItem object.
        Dim i1 As New OrderedItem With {
            .ItemName = "Widget S",
            .Description = "Small widget",
            .UnitPrice = CDec(5.23),
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
        po1.ShipCost = CDec(12.51)
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
        po2.OrderDate = System.DateTime.Now.ToLongDateString()

        ' Create an OrderedItem object.
        Dim i2 As New OrderedItem With {
            .ItemName = "Sprocket K",
            .Description = "Small sprocket",
            .UnitPrice = CDec(3.14),
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
        po2.ShipCost = CDec(12.51)
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

    Protected Sub ReadPO(ByVal filename As String)
        ' Create an instance of the XmlSerializer class;
        ' specify the type of object to be deserialized.
        Dim serializer As New XmlSerializer(GetType(AllPurchaseOrders))
        ' If the XML document has been altered with unknown
        ' nodes or attributes, handle them with the
        ' UnknownNode and UnknownAttribute events.
        AddHandler serializer.UnknownNode, AddressOf serializer_UnknownNode
        AddHandler serializer.UnknownAttribute, AddressOf serializer_UnknownAttribute

        ' A FileStream is needed to read the XML document.
        Dim fs As New FileStream(filename, FileMode.Open)
        ' Declare an object variable of the type to be deserialized.

        Dim apo As AllPurchaseOrders
        apo = CType(serializer.Deserialize(fs), AllPurchaseOrders)

        Dim po As PurchaseOrder
        po = apo.Orders(1)
        Console.WriteLine(("OrderDate: " & po.OrderDate))

        ' Read the shipping address.
        Dim shipTo As Address = po.ShipTo
        ReadAddress(shipTo, "Ship To:")
        ' Read the list of ordered items.
        Dim items As OrderedItem() = po.OrderedItems
        Console.WriteLine("Items to be shipped:")
        Dim oi As OrderedItem
        For Each oi In items
            Console.WriteLine((ControlChars.Tab & oi.ItemName & ControlChars.Tab &
            oi.Description & ControlChars.Tab & oi.UnitPrice & ControlChars.Tab &
            oi.Quantity & ControlChars.Tab & oi.LineTotal))
        Next oi
        ' Read the subtotal, shipping cost, and total cost.
        Console.WriteLine((New String(ControlChars.Tab, 5) &
        " Subtotal" & ControlChars.Tab & po.SubTotal))
        Console.WriteLine(New String(ControlChars.Tab, 5) &
        " Shipping" & ControlChars.Tab & po.ShipCost)
        Console.WriteLine(New String(ControlChars.Tab, 5) &
        " Total" & New String(ControlChars.Tab, 2) & po.TotalCost)
    End Sub 'ReadPO

    Protected Sub ReadAddress(ByVal a As Address, ByVal label As String)
        ' Read the fields of the Address object.
        Console.WriteLine(label)
        Console.WriteLine(ControlChars.Tab & a.Name)
        Console.WriteLine(ControlChars.Tab & a.Line1)
        Console.WriteLine(ControlChars.Tab & a.City)
        Console.WriteLine(ControlChars.Tab & a.State)
        Console.WriteLine(ControlChars.Tab & a.Zip)
        Console.WriteLine()
    End Sub 'ReadAddress

    Private Sub serializer_UnknownNode(ByVal sender As Object, ByVal e As XmlNodeEventArgs)
        Console.WriteLine(("Unknown Node:" & e.Name & ControlChars.Tab & e.Text))
    End Sub 'serializer_UnknownNode


    Private Sub serializer_UnknownAttribute(ByVal sender As Object, ByVal e As XmlAttributeEventArgs)
        Dim attr As System.Xml.XmlAttribute = e.Attr
        Console.WriteLine(("Unknown attribute " & attr.Name & "='" & attr.Value & "'"))
    End Sub 'serializer_UnknownAttribute
End Class 'Test

