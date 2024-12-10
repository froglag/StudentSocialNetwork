CREATE PROCEDURE [dbo].[spMessage_Delete]
	@Id int
AS

begin
	delete from dbo.[Message]
	where Id = @Id
end