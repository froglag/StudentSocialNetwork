CREATE PROCEDURE [dbo].[spUniversity_GetFullTableId]
	@Id int
AS

begin
	select un.*, fa.*, sp.*
	from dbo.[University] as un
	left join dbo.[Faculty] as fa
	on UniversityId = fa.UniversityId
	left join dbo.[Specialization] as sp
	on fa.Id = sp.FacultyId
	where un.Id = @Id
end
