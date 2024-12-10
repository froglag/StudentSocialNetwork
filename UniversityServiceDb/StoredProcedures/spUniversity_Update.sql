CREATE PROCEDURE [dbo].[spUniversity_Update]
	@Id int,
	@Name nvarchar(50),
	@Description nvarchar(200)
AS

begin
	update dbo.[University]
	set Name = @Name, Description = @Description
	where Id = @Id
end
