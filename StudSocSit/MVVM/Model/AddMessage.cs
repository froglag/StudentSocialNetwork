using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Model;

public class AddMessage
{
    private HttpClient _client;
    private string _JWT;

    public AddMessage(HttpClient client, string JWT)
    {
        _client = client;
        _JWT = JWT;
    }

    public async Task<string> Do(string text)
    {
        var json = JsonSerializer.Serialize(text);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("addmessage", content);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }
}
