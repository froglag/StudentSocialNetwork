
using MVVM.Model.DataFields;
using System.Net.Http;
using System.Net.Http.Json;

namespace MVVM.Model;

public class GetStudentInfoById
{
    private HttpClient _client;
    private string _JWT;

    public GetStudentInfoById(HttpClient client, string JWT)
    {
        _client = client;
        _JWT = JWT;
    }

    public StudentModel Do(int studentId)
    {
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _JWT);
        var getResponse = _client.GetAsync($"/friendinfo/{studentId}").Result;

        return getResponse.Content.ReadFromJsonAsync<StudentModel>().Result;
    }
}
