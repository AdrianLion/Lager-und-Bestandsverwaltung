﻿CREATE TABLE [dbo].[Material]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(100) NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [ QuantityInStock] INT NOT NULL, 
    [CreatedDate] DATETIME2 NOT NULL, 
    [LastModified] DATETIME2 NOT NULL
)