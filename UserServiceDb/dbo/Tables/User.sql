CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NULL, 
    [UniversityId] INT NULL, 
    [FacultyId] INT NULL, 
    [SpecializationId] INT NULL, 
    [Email] NVARCHAR(50) NULL
)
