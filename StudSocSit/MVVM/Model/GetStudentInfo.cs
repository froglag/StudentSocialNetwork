﻿using MVVM.Model.DataFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MVVM.Model;

public class GetStudentInfo
{
    private HttpClient _client;
    private string _JWT;

    public GetStudentInfo(HttpClient client, string JWT)
    {
        _client = client;
        _JWT = JWT;
    }
    
    public StudentModel Do()
    {
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _JWT);
        var getResponse = _client.GetAsync("/userinfo").Result;

        return getResponse.Content.ReadFromJsonAsync<StudentModel>().Result;
    }
}
