CREATE PROCEDURE [dbo].[spFriending_Delete]
	@StudentId int,
	@FriendId int
AS

begin
	delete from dbo.[Friending]
	where (StudentId = @StudentId 
	and FriendId = @FriendId) 
	or (StudentId = @FriendId 
	and FriendId = @StudentId)
end
