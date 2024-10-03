CREATE PROCEDURE [dbo].[spChat_Get]
	@Id int
AS

begin
	select *
	from dbo.[Chat]
	where Id = @Id
end