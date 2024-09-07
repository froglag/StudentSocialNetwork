CREATE TABLE [dbo].[Faculty]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NULL, 
    [Description] NVARCHAR(200) NULL, 
    [UniversityId] INT FOREIGN KEY REFERENCES dbo.[University](id)
)
