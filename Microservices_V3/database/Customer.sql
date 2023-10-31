USE master;
GO

-- Create a new database
CREATE DATABASE CustomerDB;
GO

USE CustomerDB;
GO

-- Create a Customers table and insert sample data
CREATE TABLE Customers (
    CustomerId INT PRIMARY KEY,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Email NVARCHAR(100)
);

INSERT INTO Customers (FirstName, LastName, Email)
VALUES ('John', 'Doe', 'john@example.com');
VALUES ('Katherine', 'Thompson', 'katherine@example.com');
VALUES ('Sophie', 'Doe', 'sopghie@example.com');


-- Add more sample data as needed
