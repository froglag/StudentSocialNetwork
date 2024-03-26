using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Net.Http.Json;

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
        var response = _client.PostAsync("login", content).Result;

        return response.Content.ReadAsStringAsync().Result.ToString();
    }

    public class Request
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    
}
