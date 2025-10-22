-- 1) Clientes ordenados alfabéticamente por compañía

SELECT CompanyName
FROM Customers
ORDER BY CompanyName ASC;

-- 2) Clientes cuyo nombre empieza con “S”

SELECT *
FROM Customers
WHERE ContactName LIKE 'S%';

-- 3) Productos con precio unitario > 50

SELECT *
FROM Products
WHERE UnitPrice > 50;


-- 4) Cantidad de productos discontinuados

SELECT COUNT(*) AS TotalDiscontinued
FROM Products
WHERE Discontinued = 1;

--5) Producto con mayor valor unitario

SELECT TOP 1 *
FROM Products
ORDER BY UnitPrice DESC;

--6) Producto de mayor valor unitario (con subquery)

SELECT ProductName, UnitPrice
FROM Products
WHERE UnitPrice = (
    SELECT MAX(UnitPrice)
    FROM Products
);

--7) Productos con su categoría (INNER JOIN)

SELECT p.ProductName, c.CategoryName
FROM Products p
INNER JOIN Categories c
    ON p.CategoryID = c.CategoryID;

--8) Clientes con detalles de pedidos (LEFT JOIN)
SELECT c.ContactName, o.OrderDate, od.Quantity, od.UnitPrice, od.Discount
FROM Customers c
LEFT JOIN Orders o
ON o.CustomerID = c.CustomerID
INNER JOIN [Order Details] od
ON o.OrderID = od.OrderID

--9) Número total de órdenes por cliente

SELECT c.CustomerID, c.CompanyName, COUNT(o.OrderID) AS TotalOrders
FROM Customers c
LEFT JOIN Orders o
    ON c.CustomerID = o.CustomerID
GROUP BY c.CustomerID, c.CompanyName;

--10) Proveedores con más de 3 productos (HAVING)
SELECT s.SupplierID, s.CompanyName, COUNT(p.ProductID) AS total
FROM Suppliers s
INNER JOIN Products p
    ON s.SupplierID = p.SupplierID
GROUP BY s.SupplierID, s.CompanyName
HAVING COUNT(p.ProductID) > 3;

--11) Procedimiento almacenado: clientes según país
CREATE PROCEDURE CustomersForCountry
    @country VARCHAR(70)
AS
BEGIN
    SELECT *
    FROM Customers
    WHERE Country = @country;
END;
GO

EXEC CustomersForCountry @country = 'Argentina';









