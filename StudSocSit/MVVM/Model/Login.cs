﻿using System.Net.Http;
using System.Text.Json;
using System.Text;
using Newtonsoft.Json.Linq;

namespace MVVM.Model;

public class Login
{
    private HttpClient _client;

    public Login(HttpClient client)
    {
        _client = client;
    }
    public string Do(Request request)
    {
        var json = JsonSerializer.Serialize(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var postResponse = _client.PostAsync("login", content).Result;

        var stringResponse = postResponse.Content.ReadAsStringAsync().Result;
        var response = JObject.Parse(stringResponse);
        return (string)response["value"]["token"];
        
    }

    public class Request
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    
}
