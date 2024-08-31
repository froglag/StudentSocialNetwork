using DataAccess.DbAccess;
using DataAccess.Models;

namespace DataAccess.Application;
public class UserApplication : IUserApplication
{
    private readonly ISqlAccess _sqlAccess;

    public UserApplication(ISqlAccess sqlAccess)
    {
        _sqlAccess = sqlAccess;
    }

    public async Task<IEnumerable<UserModel>> GetUsers()
    {
        return await _sqlAccess.LoadData<UserModel, dynamic>("dbo.spUser_GetAll", new { });
    }

    public async Task<UserModel?> GetUser(int id)
    {
        var result = await _sqlAccess.LoadData<UserModel, dynamic>("dbo.spUser_Get", new { Id = id });
        return result.FirstOrDefault();
    }

    public async Task InsertUser(UserModel user)
    {
        await _sqlAccess.SaveData("dbo.spUser_Insert", new { user.FirstName, user.LastName, user.University, user.Faculty, user.Specialization, user.Email });
    }

    public async Task UpdateUser(UserModel user)
    {
        await _sqlAccess.SaveData("dbo.spUser_Update", user);
    }
}
