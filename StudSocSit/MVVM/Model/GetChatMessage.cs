
using MVVM.Model.DataFields;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Windows.Documents;

namespace MVVM.Model;

public class GetChatMessage
{
    private HttpClient _client;
    private string _JWT;

    public GetChatMessage(HttpClient client, string JWT)
    {
        _client = client;
        _JWT = JWT;
    }
    public List<MessageModel> Do(string friendId)
    {
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _JWT);
        var getResponse = _client.GetAsync($"chatmessages/{friendId}").Result;

        return getResponse.Content.ReadFromJsonAsync<List<MessageModel>>().Result;
    }
}
