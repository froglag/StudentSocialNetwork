using MVVM.Model.DataFields;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;

namespace MVVM.Model;

public class GetFriendRequest
{
    private HttpClient _client;

    public GetFriendRequest(HttpClient client)
    {
        _client = client;
    }

    public List<FriendRequestModel> Do()
    {
        var getResponse = _client.GetAsync("friendrequest").Result;

        return getResponse.Content.ReadFromJsonAsync<List<FriendRequestModel>>().Result;
    }

    
}
