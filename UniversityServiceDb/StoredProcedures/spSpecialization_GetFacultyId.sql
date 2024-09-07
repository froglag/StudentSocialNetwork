CREATE PROCEDURE [dbo].[spSpecialization_GetFacultyId]
	@FacultyId int
AS

begin
	select *
	from dbo.[Specialization]
	where FacultyId = @FacultyId;
end