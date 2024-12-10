CREATE PROCEDURE [dbo].[spSpecialization_Insert]
	@Name nvarchar(50),
	@Description nvarchar(200),
	@FacultyId int
AS
begin
	if exists (select 1 from dbo.[University] where Id = @FacultyId)
		begin
			insert into dbo.[Specialization] (Name, Description, FacultyId)
			values (@Name, @Description, @FacultyId)
			return 0
		end
	else
		begin
			return 1
		end
end

