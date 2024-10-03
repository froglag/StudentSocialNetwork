CREATE PROCEDURE [dbo].[spFriending_Insert]
	@StudentId int,
	@FriendId int
AS

begin try
	begin transaction

		insert into dbo.[Friending] (StudentId, FriendId)
		values (@StudentId, @FriendId)

		insert into dbo.[Friending] (StudentId, FriendId)
		values (@FriendId, @StudentId)
	commit transaction
end try
begin catch
	rollback transaction
end catch
