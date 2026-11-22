-- =========================================================================
-- CODE-FIRST MIGRATION SQL SCRIPT (Add-Migration InitialCreate / Update-Database)
-- Faculty of Information Technology - Ton Duc Thang University
-- Course: Software Engineering - Lab 08 (ASP.NET Core Code-First)
-- Student: Nguyen Nhat Huy (524H0052)
-- =========================================================================

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'SchoolCodeFirstDB')
BEGIN
    CREATE DATABASE SchoolCodeFirstDB;
END
GO

USE SchoolCodeFirstDB;
GO

IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Department] (
    [DepartmentID] int NOT NULL IDENTITY,
    [Name] nvarchar(50) NOT NULL,
    [Budget] money NOT NULL,
    [StartDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Department] PRIMARY KEY ([DepartmentID])
);
GO

CREATE TABLE [Student] (
    [ID] int NOT NULL IDENTITY,
    [LastName] nvarchar(50) NOT NULL,
    [FirstName] nvarchar(50) NOT NULL,
    [EnrollmentDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Student] PRIMARY KEY ([ID])
);
GO

CREATE TABLE [Course] (
    [CourseID] int NOT NULL,
    [Title] nvarchar(50) NOT NULL,
    [Credits] int NOT NULL,
    [DepartmentID] int NOT NULL,
    CONSTRAINT [PK_Course] PRIMARY KEY ([CourseID]),
    CONSTRAINT [FK_Course_Department_DepartmentID] FOREIGN KEY ([DepartmentID]) REFERENCES [Department] ([DepartmentID]) ON DELETE CASCADE
);
GO

CREATE TABLE [Enrollment] (
    [EnrollmentID] int NOT NULL IDENTITY,
    [CourseID] int NOT NULL,
    [StudentID] int NOT NULL,
    [Grade] int NULL,
    CONSTRAINT [PK_Enrollment] PRIMARY KEY ([EnrollmentID]),
    CONSTRAINT [FK_Enrollment_Course_CourseID] FOREIGN KEY ([CourseID]) REFERENCES [Course] ([CourseID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Enrollment_Student_StudentID] FOREIGN KEY ([StudentID]) REFERENCES [Student] ([ID]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Course_DepartmentID] ON [Course] ([DepartmentID]);
GO
CREATE INDEX [IX_Enrollment_CourseID] ON [Enrollment] ([CourseID]);
GO
CREATE INDEX [IX_Enrollment_StudentID] ON [Enrollment] ([StudentID]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20261110_InitialCreate', N'8.0.10');
GO

COMMIT;
GO
