CREATE PROCEDURE [dbo].[spChat_GetAllByStudentId]
	@StudentId int
AS

begin
	select ch.*
	from dbo.[Chat] as ch
	inner join dbo.[Message] as m
	on m.StudentId = @StudentId
end