CREATE VIEW HighEarningEmployees
AS
SELECT Emp.FirstName || ' '|| Emp.LastName As Name, Std.HouseNumber
, Std.City AS ArtistCity, Alb.Title AS AlbumName, Alb.Price AS AlbumPrice
FROM 
Employees AS Emp INNER JOIN
Studios AS Std ON Emp.Id=Std.EmployeeId INNER JOIN
Albums AS Alb ON Emp.Id=Alb.EmployeeId
WHERE Alb.Price >3000;