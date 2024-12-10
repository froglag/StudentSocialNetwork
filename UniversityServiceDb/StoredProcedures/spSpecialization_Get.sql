CREATE PROCEDURE [dbo].[spSpecialization_Get]
	@Id int
AS
	
begin
	select *
	from dbo.[Specialization]
	where Id = @Id
end
