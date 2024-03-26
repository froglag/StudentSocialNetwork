using MVVM.Model.DataFields;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;

namespace MVVM.Model;

public class GetFriendRequest
{
    private HttpClient _client;
    private string _JWT;

    public GetFriendRequest(HttpClient client, string JWT)
    {
        _client = client;
        _JWT = JWT;
    }

    public List<FriendRequestModel> Do()
    {
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _JWT);
        var getResponse = _client.GetAsync("friendrequest").Result;

        return getResponse.Content.ReadFromJsonAsync<List<FriendRequestModel>>().Result;
    }

    
}
