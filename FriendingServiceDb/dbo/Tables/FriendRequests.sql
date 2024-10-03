CREATE TABLE [dbo].[FriendRequests]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [StudentId] INT NOT NULL, 
    [FriendId] INT NOT NULL, 
    [Text] NVARCHAR(200) NULL
)
