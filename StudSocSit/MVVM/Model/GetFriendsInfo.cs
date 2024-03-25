
using MVVM.Model.DataFields;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;

namespace MVVM.Model;

public class GetFriendsInfo
{
    private HttpClient _client;

    public GetFriendsInfo(HttpClient client)
    {
        _client = client;
    }
    public List<StudentModel> Do(string JWT)
    {
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + JWT);
        var getResponse = _client.GetAsync("/allfriendsinfo").Result;

        return getResponse.Content.ReadFromJsonAsync<List<StudentModel>>().Result;
    }
}
