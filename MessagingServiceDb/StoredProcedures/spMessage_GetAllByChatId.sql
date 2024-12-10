CREATE PROCEDURE [dbo].[spMessage_GetAllByChatId]
	@ChatId int,
    @Offset int
AS

begin
	select *
    from dbo.[Message]
    where ChatId = @ChatId
    ORDER BY dbo.[Message].SendAt DESC
    OFFSET @Offset ROWS
    FETCH NEXT 100 ROWS ONLY;
end