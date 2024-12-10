CREATE PROCEDURE [dbo].[spFaculty_GetUniversityId]
	@UniversityId int
AS

begin
	select *
	from dbo.[Faculty]
	where UniversityId = @UniversityId;
end
