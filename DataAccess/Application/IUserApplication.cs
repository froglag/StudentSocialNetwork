using DataAccess.Models;

namespace DataAccess.Application;
public interface IUserApplication
{
    Task<UserModel?> GetUser(int id);
    Task<IEnumerable<UserModel>> GetUsers();
    Task InsertUser(UserModel user);
    Task UpdateUser(UserModel user);
}