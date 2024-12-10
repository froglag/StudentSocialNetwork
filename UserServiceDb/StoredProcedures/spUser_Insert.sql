CREATE PROCEDURE [dbo].[spUser_Insert]
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@UniversityId int,
	@FacultyId int,
	@SpecializationId int,
	@Email nvarchar(50),
	@Image varbinary(max)
AS

begin
	insert into dbo.[User] (FirstName, LastName, UniversityId, FacultyId, SpecializationId, Email, Image)
	values (@FirstName, @LastName, @UniversityId, @FacultyId, @SpecializationId, @Email, @Image);
end
