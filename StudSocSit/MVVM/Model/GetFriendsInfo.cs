
using MVVM.Model.DataFields;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;

namespace MVVM.Model;

public class GetFriendsInfo
{
    private HttpClient _client;
    private string _JWT;

    public GetFriendsInfo(HttpClient client, string JWT)
    {
        _client = client;
        _JWT = JWT;
    }
    public List<StudentModel> Do()
    {
        _client.DefaultRequestHeaders.Accept.Clear();
        var getResponse = _client.GetAsync("/allfriendsinfo").Result;
        return getResponse.Content.ReadFromJsonAsync<List<StudentModel>>().Result;
    }
}
