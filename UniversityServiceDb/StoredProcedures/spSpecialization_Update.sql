CREATE PROCEDURE [dbo].[spSpecialization_Update]
	@Id int,
	@Name nvarchar(50),
	@Description nvarchar(200),
	@FacultyId int
AS

begin
	update dbo.[Specialization]
	set Name = @Name, Description = @Description, FacultyId = @FacultyId
	where Id = @Id
end
