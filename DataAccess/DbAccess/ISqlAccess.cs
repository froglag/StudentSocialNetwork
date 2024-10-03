

namespace DataAccess.DbAccess;

public interface ISqlAccess
{
    Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionId = "Default");
    Task<IEnumerable<T1>> LoadThreeTable<T1, T2, T3, U>(string storedProceder, U parameter, Func<T1, T2, T3, T1> mapping, string connectionId = "Default", string splitOn = "Id");
    Task SaveData<T>(string storedProcedure, T parameters, string connectionId = "Default");
    Task<int> SaveDataWithFeedback<T>(string storedProcedure, T parameters, string connectionId = "Default");
}