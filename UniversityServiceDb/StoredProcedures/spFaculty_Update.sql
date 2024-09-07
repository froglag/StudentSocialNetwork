CREATE PROCEDURE [dbo].[spFaculty_Update]
	@Id int,
	@Name nvarchar(50),
	@Description nvarchar(200),
	@UniversityId int
AS

begin
	update dbo.[Faculty]
	set Name = @Name, Description = @Description, UniversityId = @UniversityId
	where Id = @Id
end
