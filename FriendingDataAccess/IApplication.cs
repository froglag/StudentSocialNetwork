using FriendingApplication.Models;

namespace FriendingApplication;
public interface IApplication
{
    Task FriedingDelete(int studentId, int friendId);
    Task<IEnumerable<FriendingModel>> FriendGetAllByStudentId(int studentId);
    Task<FriendingModel?> FriendingGet(int id);
    Task FriendingInsert(FriendingModel friending);
    Task FriendRequestDelete(int id);
    Task<FriendRequestModel?> FriendRequestGet(int Id);
    Task<IEnumerable<FriendRequestModel>> FriendRequestGetAllByStudentId(int studentId);
    Task FriendRequestInsert(FriendRequestModel friendRequest);
}