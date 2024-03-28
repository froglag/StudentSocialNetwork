using MVVM.Model.DataFields;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.ComponentModel;
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
        var getResponse = _client.GetStringAsync("friendrequest").Result;
        var jsonString = JObject.Parse(getResponse);

        var listFriendRequest = new List<FriendRequestModel>();

        foreach (var item in jsonString["value"])
        {
            listFriendRequest.Add(new FriendRequestModel
            {
                Firstname = (string)item["firstname"],
                Lastname = (string)item["lastname"],
                SenderId = (int)item["senderId"],
                Text = (string)item["text"],
            });
        }

        return listFriendRequest;
    }

    
}
