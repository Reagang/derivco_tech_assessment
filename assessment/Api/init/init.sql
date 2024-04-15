USE [master];
GO

-- Drop the database if it exists
IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'Northwind')
 DROP DATABASE Northwind;
GO
 -- Create the database
CREATE DATABASE Northwind;
GO

USE [Northwind]
GO

IF NOT EXISTS (SELECT * FROM sys.sql_logins WHERE name = 'Developer')
BEGIN
    CREATE LOGIN Developer WITH PASSWORD = 'Pa$$word5221!', CHECK_POLICY = OFF;
    ALTER SERVER ROLE [sysadmin] ADD MEMBER Developer;
END
GO

