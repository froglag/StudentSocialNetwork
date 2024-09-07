CREATE PROCEDURE [dbo].[spUniversity_Get]
	@Id int
AS
	
begin
	select *
	from dbo.[University]
	where Id = @Id
end
