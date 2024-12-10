CREATE PROCEDURE [dbo].[spFriendRequest_Get]
	@Id int
AS

begin
	select *
	from dbo.[FriendRequests]
	where Id = @Id
end