CREATE PROCEDURE [dbo].[spFriending_Get]
	@Id int
AS

begin
	select *
	from dbo.[Friending]
	where Id = @Id
end
