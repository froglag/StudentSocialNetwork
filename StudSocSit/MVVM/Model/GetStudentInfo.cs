using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MVVM.Model;

public class GetStudentInfo
{
    private HttpClient _client;

    public GetStudentInfo(HttpClient client)
    {
        _client = client;
    }
    
    public void Do(Request request, string JWT)
    {
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + JWT);
        _client.GetAsync(JsonSerializer.Serialize(request));
    }

    public class Request
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
