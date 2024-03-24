﻿using System;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MVVM.Model;

public class AddStudent
{
    private HttpClient _client;

    public AddStudent(HttpClient client)
    {
        _client = client;
    }

    public async Task<string> Do(Request request)
    {
        var json =  JsonSerializer.Serialize(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("signup", content);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }

    public class Request
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
    }
}
