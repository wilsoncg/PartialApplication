SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

USE [master];
GO

ALTER DATABASE FundingData
SET SINGLE_USER WITH
ROLLBACK AFTER 5 --this will give your current connections 5 seconds to complete

IF EXISTS (SELECT * FROM sys.databases WHERE name = 'FundingData')
  DROP DATABASE FundingData;
GO

-- Create the FundingData database.
CREATE DATABASE FundingData;
GO

-- Specify a simple recovery model 
-- to keep the log growth to a minimum.
ALTER DATABASE FundingData 
SET RECOVERY SIMPLE;
GO

USE FundingData;
GO

-- Create the [TradingAccount] table.
CREATE TABLE [dbo].[TradingAccount] (
  [Id]			INT        NOT NULL,
  [AccountCode]	NVARCHAR(MAX)    NOT NULL
  PRIMARY KEY CLUSTERED ([Id] ASC)
);