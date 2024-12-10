CREATE PROCEDURE [dbo].[spChat_Insert]
	@Name nvarchar(50)
AS

begin
	insert into dbo.[Chat] (Name, CreatedAt)
	values (@Name, GETDATE());
end