CREATE PROCEDURE [dbo].[spMessage_GetAllByChatId]
	@ChatId int
AS

begin
	select top 500 *
	from dbo.[Message]
	where ChatId = @ChatId
	order by SendAt DESC
end