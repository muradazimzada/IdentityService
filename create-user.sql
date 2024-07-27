-- Connect to the master database
USE master;
GO

-- Create a new login if it does not exist
IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = 'identityuser')
BEGIN
    CREATE LOGIN [identityuser] WITH PASSWORD = 'IdentityPassword123!';
END
GO

-- Create a new database if it does not exist
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'IdentityService')
BEGIN
    CREATE DATABASE [IdentityService];
END
GO

-- Use the new database
USE [IdentityService];
GO

-- Create a user for the login if it does not exist
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = 'identityuser')
BEGIN
    CREATE USER [identityuser] FOR LOGIN [identityuser];
END
GO

-- Grant db_owner role to the user
ALTER ROLE db_owner ADD MEMBER [identityuser];
GO
