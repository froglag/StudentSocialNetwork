CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NULL, 
    [University] NVARCHAR(50) NULL, 
    [Faculty] NVARCHAR(50) NULL, 
    [Specialization] NVARCHAR(50) NULL, 
    [Email] NVARCHAR(50) NULL
)
