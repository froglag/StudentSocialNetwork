CREATE PROCEDURE [dbo].[spChat_Update]
	@Id int,
	@Name nvarchar(50)
AS

begin
	update dbo.[Chat]
	set Name = @Name
	where Id = @Id
end