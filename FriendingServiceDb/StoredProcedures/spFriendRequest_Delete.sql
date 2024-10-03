CREATE PROCEDURE [dbo].[spFriendRequest_Delete]
	@Id int
AS

begin
	delete from dbo.[FriendRequests]
	where Id = @Id
end