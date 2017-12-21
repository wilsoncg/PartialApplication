SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

USE [master];
GO

IF EXISTS (SELECT * FROM sys.databases WHERE name = 'PartialApplicationData')
BEGIN
	ALTER DATABASE PartialApplicationData
	SET SINGLE_USER WITH
	ROLLBACK AFTER 5 --this will give your current connections 5 seconds to complete
END

IF EXISTS (SELECT * FROM sys.databases WHERE name = 'PartialApplicationData')
  DROP DATABASE PartialApplicationData;
GO

-- Create the PartialApplicationData database.
CREATE DATABASE PartialApplicationData;
GO

-- Specify a simple recovery model 
-- to keep the log growth to a minimum.
ALTER DATABASE PartialApplicationData 
SET RECOVERY SIMPLE;
GO

USE PartialApplicationData;
GO

-- Create the [TradingAccount] table.
CREATE TABLE [dbo].[TradingAccount] (
  [Id]			INT        NOT NULL,
  [AccountCode]	NVARCHAR(MAX)    NOT NULL
  PRIMARY KEY CLUSTERED ([Id] ASC)
);