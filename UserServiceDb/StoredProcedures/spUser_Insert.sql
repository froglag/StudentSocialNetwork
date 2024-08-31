CREATE PROCEDURE [dbo].[spUser_Insert]
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@University nvarchar(50),
	@Faculty nvarchar(50),
	@Specialization nvarchar(50),
	@Email nvarchar(50)
AS

begin
	insert into dbo.[User] (FirstName, LastName, University, Faculty, Specialization, Email)
	values (@FirstName, @LastName, @University, @Faculty, @Specialization, @Email);
end
