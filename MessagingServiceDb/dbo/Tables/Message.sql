CREATE TABLE [dbo].[Message]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [StudentId] INT NOT NULL,
    [ChatId] INT FOREIGN KEY  REFERENCES dbo.[Chat](Id) on delete cascade,
    [Content] NVARCHAR(200) NOT NULL, 
    [SendAt] DATETIME NOT NULL ,
)
