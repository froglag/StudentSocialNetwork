CREATE PROCEDURE [dbo].[spUser_Update]
	@Id int,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@University nvarchar(50),
	@Faculty nvarchar(50),
	@Specialization nvarchar(50),
	@Email nvarchar(50)
AS

begin
	update dbo.[User]
	set FirstName = @FirstName, LastName = @LastName, University = @University, Faculty = @Faculty, Specialization = @Specialization, Email = @Email
	where Id = @Id;
end
