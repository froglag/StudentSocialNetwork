CREATE PROCEDURE [dbo].[spFaculty_Insert]
	@Name nvarchar(50),
	@Description nvarchar(200),
	@UniversityId int
AS
begin
	if exists (select 1 from dbo.[University] where Id = @UniversityId)
		begin
			insert into dbo.[Faculty] (Name, Description, UniversityId)
			values (@Name, @Description, @UniversityId)
			return 0
		end
	else
		begin
			return 1
		end
end