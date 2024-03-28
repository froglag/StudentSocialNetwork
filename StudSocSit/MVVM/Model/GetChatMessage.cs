
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

    public GetChatMessage(HttpClient client)
    {
        _client = client;
    }
    public List<MessageModel> Do(string friendId)
    {
        var getResponse = _client.GetAsync($"chatmessages/{friendId}").Result;

        return getResponse.Content.ReadFromJsonAsync<List<MessageModel>>().Result;
    }
}
