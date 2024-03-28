
using MVVM.Model.DataFields;
using System.Net.Http;
using System.Net.Http.Json;

namespace MVVM.Model;

public class GetStudentInfoById
{
    private HttpClient _client;

    public GetStudentInfoById(HttpClient client)
    {
        _client = client;
    }

    public StudentModel Do(int studentId)
    {
        var getResponse = _client.GetAsync($"/friendinfo/{studentId}").Result;

        return getResponse.Content.ReadFromJsonAsync<StudentModel>().Result;
    }
}
