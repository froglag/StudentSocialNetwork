CREATE PROCEDURE [dbo].[spChat_Delete]
	@Id int
AS

begin
	
	delete from dbo.[Chat]
	where Id = @Id
end