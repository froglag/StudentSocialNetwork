CREATE PROCEDURE [dbo].[spMessage_Insert]
	@StudentId int,
	@ChatId int,
	@Content nvarchar(200)
AS

begin
	insert into dbo.[Message] (StudentId, ChatId, Content, SendAt)
	values (@StudentId, @ChatId, @Content, GETDATE())
end