select 'Customers.Add(New Customer With {.CustomerID="'+CustomerID+'", .CompanyName="'+CompanyName+'", .Country="'+Country+'"})'
 from customers


select 'Orders.Add(New Order With {.OrderID='+cast(OrderID as nvarchar)+', .CustomerID="'+CustomerID+'", .EmployeeID='+cast(EmployeeID as nvarchar)+', .Freight='+cast(Freight as nvarchar)+'})'
 from orders

