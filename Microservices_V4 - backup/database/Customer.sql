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

INSERT INTO Customers (CustomerId, FirstName, LastName, Email)
VALUES (1, 'John', 'Doe', 'john@example.com');

-- Add more sample data as needed
