CREATE PROCEDURE [dbo].[spFriendRequest_GetAllByStudentId]
	@StudentId int
AS

begin
	select *
	from dbo.[FriendRequests]
	where StudentId = @StudentId
end