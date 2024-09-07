CREATE PROCEDURE [dbo].[spUser_Update]
	@Id int,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@UniversityId int,
	@FacultyId int,
	@SpecializationId int,
	@Email nvarchar(50)
AS

begin
	update dbo.[User]
	set FirstName = @FirstName, LastName = @LastName, UniversityId = @UniversityId, FacultyId = @FacultyId, SpecializationId = @SpecializationId, Email = @Email
	where Id = @Id;
end
