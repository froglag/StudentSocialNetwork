﻿CREATE TABLE [dbo].[Chat]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NULL,
	[CreatedAt] DATETIME  NOT NULL
	
)