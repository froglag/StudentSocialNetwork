CREATE PROCEDURE [dbo].[spUniversity_Insert]
	@Name nvarchar(50),
	@Description nvarchar(200)
AS

begin
	Insert into dbo.[University] (Name, Description)
	values (@Name, @Description);
end
