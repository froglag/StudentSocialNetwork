using Microsoft.VisualBasic;
using MVVM.Model.DataFields;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;

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
        var getResponse = _client.GetStringAsync($"chatmessages/{friendId}").Result;

        var jsonString = JObject.Parse(getResponse);
        
        var result = new List<MessageModel>();

        foreach(var item in jsonString["value"])
        {
            result.Add(new MessageModel()
            {
                AuthorId = (int)item["authorId"],
                Text = (string)item["text"],
                Timestamp = (DateTime)item["timestamp"]
            });
        }

        return result;
    }
}
