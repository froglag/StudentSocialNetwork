CREATE PROCEDURE [dbo].[spFaculty_Get]
	@Id int
AS
	
begin
	select *
	from dbo.[Faculty]
	where Id = @Id
end