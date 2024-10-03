using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;

namespace DataAccess.DbAccess;
public class SqlAccess : ISqlAccess
{
    private readonly IConfiguration _configuration;

    public SqlAccess(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionId = "Default")
    {
        using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connectionId));
        return await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task SaveData<T>(string storedProcedure, T parameters, string connectionId = "Default")
    {
        using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connectionId));

        await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<int> SaveDataWithFeedback<T>(string storedProcedure, T parameters, string connectionId = "Default")
    {
        using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connectionId));

        var result = await connection.ExecuteScalarAsync<int>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        return result;
    }

    public async Task<IEnumerable<T1>> LoadThreeTable<T1, T2, T3, U>(string storedProceder, U parameter, Func<T1,T2, T3, T1> mapping, string connectionId = "Default", string splitOn = "Id")
    {
        using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connectionId));

        var result = await connection.QueryAsync<T1, T2, T3, T1>(storedProceder, param: parameter, commandType: CommandType.StoredProcedure, splitOn: splitOn, map: mapping);

        return result;
    }
}