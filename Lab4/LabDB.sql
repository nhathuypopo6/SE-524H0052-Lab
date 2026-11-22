-- =========================================================================
-- SCRIPT TAO DATABASE VA DU LIEU MAU CHO SE LAB 03 (FIT - TDTU)
-- Author: Software Engineering Lab 3
-- Description: Tao Database LabDB gom cac bang cho Exercise 1, 2, 3 va Homework
-- =========================================================================

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'LabDB')
BEGIN
    CREATE DATABASE LabDB;
END
GO

USE LabDB;
GO

-- =========================================================================
-- 1. EXERCISE 1: BANG CUSTOMERS (Theo dung PDF Trang 14)
-- =========================================================================
IF OBJECT_ID('dbo.Customers', 'U') IS NOT NULL
    DROP TABLE dbo.Customers;
GO

CREATE TABLE Customers (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL
);
GO

-- Du lieu mau Customers theo PDF trang 14
INSERT INTO Customers (Name, Email) VALUES 
(N'John Doe', 'john.doe@tdtu.com'),
(N'Jane Smith', 'jane.smith@tdtu.com'),
(N'Trung Pham', 'trung.pham@tdtu.com'),
(N'Emily Davis', 'emily.davis@tdtu.com'),
(N'Thai Pham', 'thai.pham@etdtu.com');
GO

-- =========================================================================
-- 2. EXERCISE 2: BANG USERS (Login Form 3-Tier Architecture)
-- =========================================================================
IF OBJECT_ID('dbo.Users', 'U') IS NOT NULL
    DROP TABLE dbo.Users;
GO

CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(100) NOT NULL,
    FullName NVARCHAR(100) NOT NULL,
    Role NVARCHAR(50) NOT NULL DEFAULT 'User'
);
GO

-- Du lieu mau Users de dang nhap
INSERT INTO Users (Username, Password, FullName, Role) VALUES
(N'admin', '123456', N'Administrator', 'Admin'),
(N'user', '123', N'Regular User', 'User'),
(N'trungpham', 'tdtu2026', N'Ky-Trung Pham', 'Lecturer');
GO

-- =========================================================================
-- 3. EXERCISE 3: BANG PRODUCTS (Main Form Menu -> Product Form)
-- =========================================================================
IF OBJECT_ID('dbo.Products', 'U') IS NOT NULL
    DROP TABLE dbo.Products;
GO

CREATE TABLE Products (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Price DECIMAL(18,2) NOT NULL DEFAULT 0,
    Stock INT NOT NULL DEFAULT 0
);
GO

-- Du lieu mau Products
INSERT INTO Products (Name, Price, Stock) VALUES
(N'Laptop Dell XPS 13', 25000000.00, 15),
(N'Wireless Mouse Logitech MX Master 3', 2200000.00, 45),
(N'Mechanical Keyboard Keychron K2', 1850000.00, 30),
(N'Monitor LG UltraFine 27 Inch 4K', 11500000.00, 12),
(N'Sony WH-1000XM5 Headphone', 7900000.00, 20);
GO

-- =========================================================================
-- 4. EXERCISE 3: BANG SUPPLIERS (Main Form Menu -> Supplier Form)
-- =========================================================================
IF OBJECT_ID('dbo.Suppliers', 'U') IS NOT NULL
    DROP TABLE dbo.Suppliers;
GO

CREATE TABLE Suppliers (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Address NVARCHAR(200),
    Phone NVARCHAR(50)
);
GO

-- Du lieu mau Suppliers
INSERT INTO Suppliers (Name, Address, Phone) VALUES
(N'Phong Vu Computer', N'264 Nguyen Thi Minh Khai, Q3, TP.HCM', '1800 6867'),
(N'GearVN Technology', N'78-80-82 Hoang Hoa Tham, Binh Thanh, TP.HCM', '1800 6975'),
(N'FPT Retail Corporation', N'261 Khanh Hoi, Q4, TP.HCM', '1800 6601'),
(N'An Phat Computer', N'84T Tran Dinh Xu, Q1, TP.HCM', '1900 0323');
GO

-- =========================================================================
-- 5. HOMEWORK: BANG STUDENTS (School Management System - 3-Tier)
-- =========================================================================
IF OBJECT_ID('dbo.Students', 'U') IS NOT NULL
    DROP TABLE dbo.Students;
GO

CREATE TABLE Students (
    Id INT PRIMARY KEY IDENTITY(1,1),
    StudentCode NVARCHAR(20) NOT NULL UNIQUE,
    FullName NVARCHAR(100) NOT NULL,
    DateOfBirth DATETIME NOT NULL,
    Gender NVARCHAR(10) NOT NULL DEFAULT 'Male',
    Email NVARCHAR(100),
    Major NVARCHAR(100)
);
GO

-- Du lieu mau Students
INSERT INTO Students (StudentCode, FullName, DateOfBirth, Gender, Email, Major) VALUES
('52100001', N'Nguyen Van An', '2003-05-15', 'Male', 'an.nv@student.tdtu.edu.vn', N'Software Engineering'),
('52100002', N'Tran Thi Bich', '2003-08-20', 'Female', 'bich.tt@student.tdtu.edu.vn', N'Computer Science'),
('52100003', N'Le Hoang Cuong', '2002-12-10', 'Male', 'cuong.lh@student.tdtu.edu.vn', N'Information Technology'),
('52100004', N'Pham Ngoc Dung', '2003-01-25', 'Female', 'dung.pn@student.tdtu.edu.vn', N'Data Science'),
('52100005', N'Vo Minh Em', '2003-11-03', 'Male', 'em.vm@student.tdtu.edu.vn', N'Network & Security');
GO

-- =========================================================================
-- KIEM TRA DU LIEU VUA TAO
-- =========================================================================
SELECT * FROM Customers;
SELECT * FROM Users;
SELECT * FROM Products;
SELECT * FROM Suppliers;
SELECT * FROM Students;
GO
