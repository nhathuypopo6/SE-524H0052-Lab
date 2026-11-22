-- =========================================================================
-- DATABASE SETUP SCRIPT FOR SE LAB 06 & 07 (SCHOOL MANAGEMENT SYSTEM)
-- Faculty of Information Technology - Ton Duc Thang University
-- Student: Nguyen Nhat Huy (524H0052)
-- =========================================================================

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'SchoolDB')
BEGIN
    CREATE DATABASE SchoolDB;
END
GO

USE SchoolDB;
GO

-- Drop tables in reverse order of FK dependencies
IF OBJECT_ID('dbo.Enrollments', 'U') IS NOT NULL DROP TABLE dbo.Enrollments;
IF OBJECT_ID('dbo.Courses', 'U') IS NOT NULL DROP TABLE dbo.Courses;
IF OBJECT_ID('dbo.Departments', 'U') IS NOT NULL DROP TABLE dbo.Departments;
IF OBJECT_ID('dbo.Students', 'U') IS NOT NULL DROP TABLE dbo.Students;
IF OBJECT_ID('dbo.tblUser', 'U') IS NOT NULL DROP TABLE dbo.tblUser;
GO

-- 1. Departments Table
CREATE TABLE Departments (
    DepartmentID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL,
    Budget DECIMAL(18,2) NOT NULL,
    StartDate DATETIME NOT NULL
);
GO

-- 2. Students Table
CREATE TABLE Students (
    StudentID INT IDENTITY(1,1) PRIMARY KEY,
    LastName NVARCHAR(50) NOT NULL,
    FirstMidName NVARCHAR(50) NOT NULL,
    EnrollmentDate DATETIME NOT NULL
);
GO

-- 3. Courses Table
CREATE TABLE Courses (
    CourseID INT PRIMARY KEY,
    Title NVARCHAR(100) NOT NULL,
    Credits INT NOT NULL,
    DepartmentID INT NOT NULL,
    CONSTRAINT FK_Courses_Departments FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID) ON DELETE CASCADE
);
GO

-- 4. Enrollments Table
CREATE TABLE Enrollments (
    EnrollmentID INT IDENTITY(1,1) PRIMARY KEY,
    CourseID INT NOT NULL,
    StudentID INT NOT NULL,
    Grade NVARCHAR(5) NULL,
    CONSTRAINT FK_Enrollments_Courses FOREIGN KEY (CourseID) REFERENCES Courses(CourseID) ON DELETE CASCADE,
    CONSTRAINT FK_Enrollments_Students FOREIGN KEY (StudentID) REFERENCES Students(StudentID) ON DELETE CASCADE
);
GO

-- 5. tblUser Table (Exercise 3 Authentication)
CREATE TABLE tblUser (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(100) NOT NULL,
    Role NVARCHAR(20) NOT NULL DEFAULT 'User'
);
GO

-- SEED DATA
INSERT INTO Departments (Name, Budget, StartDate) VALUES
(N'Computer Science', 350000.00, '2020-09-01'),
(N'Software Engineering', 420000.00, '2021-01-15'),
(N'Information Systems', 280000.00, '2020-09-01');

INSERT INTO Students (LastName, FirstMidName, EnrollmentDate) VALUES
(N'Nguyen', N'Nhat Huy', '2023-09-05'),
(N'On', N'Gia Khiem', '2023-09-05'),
(N'Vo', N'Nguyen Phuc Thinh', '2023-09-05'),
(N'Alexander', N'Carson', '2022-09-01'),
(N'Alonso', N'Meredith', '2022-09-01');

INSERT INTO Courses (CourseID, Title, Credits, DepartmentID) VALUES
(1050, N'Chemistry', 3, 1),
(4022, N'Microeconomics', 3, 3),
(4041, N'Macroeconomics', 3, 3),
(1045, N'Calculus', 4, 1),
(3141, N'Trigonometry', 4, 1),
(2021, N'Composition', 3, 2),
(2042, N'Software Architecture', 4, 2);

INSERT INTO Enrollments (CourseID, StudentID, Grade) VALUES
(1050, 1, 'A'),
(4022, 1, 'B'),
(4041, 1, 'A'),
(1045, 2, 'B'),
(3141, 2, 'F'),
(2021, 2, 'C'),
(1050, 3, 'B'),
(4022, 3, 'A');

INSERT INTO tblUser (Username, Password, Role) VALUES
('admin', 'admin123', 'Administrator'),
('huy_student', '123456', 'Student'),
('teacher', 'teacher123', 'Faculty');
GO
