CREATE TABLE [dbo].[Specialization]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NULL, 
    [Description] NVARCHAR(200) NULL, 
    [FacultyId] INT FOREIGN KEY REFERENCES dbo.[Faculty](id)
)
