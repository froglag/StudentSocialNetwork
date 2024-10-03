CREATE PROCEDURE [dbo].[spFriendRequest_Insert]
	@StudentId int,
	@FriendId int,
	@Text nvarchar(200)
AS

begin
	if not exists (select 1 from dbo.[FriendRequests] where (StudentId = @StudentId and FriendId = @FriendId) or (StudentId = FriendId and FriendId = @StudentId))
		begin
			insert into dbo.[FriendRequests] (StudentId, FriendId, Text)
			values (@StudentId, @FriendId, @Text)
		end
	
end