CREATE TABLE [dbo].[Message]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [StudentId] INT NOT NULL, 
    [ChatId] INT NOT NULL, 
    [Content] NVARCHAR(200) NOT NULL, 
    [SendAt] TIMESTAMP NOT NULL DEFAULT GETDATA(),
    

    FOREIGN KEY (ChatId) REFERENCES Chat(Id) on delete cascade
)
