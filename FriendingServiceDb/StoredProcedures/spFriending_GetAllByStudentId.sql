CREATE PROCEDURE [dbo].[spFriending_GetAllByStudentId]
	@StudentId int
AS

begin
	select *
	from dbo.[Friending]
	where StudentId = @StudentId
end