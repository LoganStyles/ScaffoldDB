#!/bin/sh
sqlite3 output/Artists.db <<EOF
CREATE TABLE IF NOT EXISTS Employees (
    "Id" INTEGER NOT NULL,
    "FirstName" TEXT NOT NULL,
    "LastName" TEXT NOT NULL,
    "Age" INTEGER NOT NULL,
    PRIMARY KEY("Id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS Studios (
    "Id" INTEGER NOT NULL,
    "HouseNumber" INTEGER NOT NULL,
    "City" TEXT NOT NULL,
    "EmployeeId" INTEGER NOT NULL UNIQUE,
    PRIMARY KEY("Id" AUTOINCREMENT),
    FOREIGN KEY (EmployeeId) REFERENCES Employees (Id)
);
CREATE TABLE IF NOT EXISTS Albums (
    "Id" INTEGER NOT NULL,
    "Title" TEXT NOT NULL,
    "Price" REAL NOT NULL,
    "EmployeeId" INTEGER NOT NULL,
    PRIMARY KEY("Id" AUTOINCREMENT),
    FOREIGN KEY (EmployeeId) REFERENCES Employees (Id)
);
CREATE TABLE IF NOT EXISTS Tags (
    "Id" INTEGER NOT NULL,
    "Title" TEXT NOT NULL,
    PRIMARY KEY("Id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS AlbumTags(
    AlbumId INTEGER,
    TagId INTEGER,
    FOREIGN KEY(AlbumId) REFERENCES Albums(Id) ON DELETE CASCADE,
    FOREIGN KEY(TagId) REFERENCES Tags(Id) ON DELETE CASCADE,
    PRIMARY KEY(AlbumId, TagId)
);

INSERT INTO Employees values(1,'Max','Bello',25);
INSERT INTO Employees values(2,'Francis','Ojukwu',34);
INSERT INTO Employees values(3,'Martha','Bertha',19);

INSERT INTO Studios values(1,13,'Frankville',3);
INSERT INTO Studios values(2,209,'Ikoyi',1);
INSERT INTO Studios values(3,44,'Lekki',2);

INSERT INTO Albums values(1,'Blue Fire',2000,2);
INSERT INTO Albums values(2,'Raging Heart',3850,3);
INSERT INTO Albums values(3,'Fixated on you',4000,1);

CREATE VIEW HighEarningEmployees
AS
SELECT Emp.FirstName || ' '|| Emp.LastName As Name, Std.HouseNumber
, Std.City AS ArtistCity, Alb.Title AS AlbumName, Alb.Price AS AlbumPrice
FROM 
Employees AS Emp INNER JOIN
Studios AS Std ON Emp.Id=Std.EmployeeId INNER JOIN
Albums AS Alb ON Emp.Id=Alb.EmployeeId
WHERE Alb.Price >3000;
EOF
