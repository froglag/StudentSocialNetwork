using DataAccess.DbAccess;
using FriendingApplication.Models;
using System.Data.SqlClient;
using System.Transactions;

namespace FriendingApplication;

public class Application : IApplication
{
    private readonly ISqlAccess _access;

    public Application(ISqlAccess access)
    {
        _access = access;
    }

    public async Task<IEnumerable<FriendingModel>> FriendGetAllByStudentId(int studentId)
    {
        var result = await _access.LoadData<FriendingModel, dynamic>("dbo.spFriending_GetAllByStudentId", new {StudentId = studentId});
        return result;
    }

    public async Task<FriendingModel?> FriendingGet(int id)
    {
        var result = await _access.LoadData<FriendingModel, dynamic>("dbo.spFriending_Get", new {Id = id});
        return result.FirstOrDefault();
    }

    public async Task FriendingInsert(FriendingModel friending)
    {
            await _access.SaveData<dynamic>("dbo.spFriending_Insert", new { friending.StudentId, friending.FriendId });
    }

    public async Task FriedingDelete(int studentId, int friendId)
    {
        await _access.SaveData<dynamic>("dbo.spFriending_Delete", new { StudentId = studentId, FriendId = friendId });
    }

    public async Task<IEnumerable<FriendRequestModel>> FriendRequestGetAllByStudentId(int studentId)
    {
        var result = await _access.LoadData<FriendRequestModel, dynamic>("dbo.spFriendRequest_GetAllByStudentId", new {StudentId = studentId});
        return result;
    }

    public async Task<FriendRequestModel?> FriendRequestGet(int id)
    {
        var result = await _access.LoadData<FriendRequestModel, dynamic>("dbo.spFriendRequest_Get", new {Id = id});
        return result.FirstOrDefault();
    }

    public async Task FriendRequestInsert(FriendRequestModel friendRequest)
    {
        await _access.SaveData<dynamic>("dbo.spFriendRequest_Insert", new { friendRequest.StudentId, friendRequest.FriendId, friendRequest.Text });
    }

    public async Task FriendRequestDelete(int id)
    {
        await _access.SaveData("dbo.spFriendRequest_Delete", id);
    }
}
