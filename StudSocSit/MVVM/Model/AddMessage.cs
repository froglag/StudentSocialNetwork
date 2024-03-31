using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Model;

public class AddMessage
{
    private HttpClient _client;

    public AddMessage(HttpClient client)
    {
        _client = client;
    }

    public async Task Do(string text)
    {
        var json = JsonSerializer.Serialize(text);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        
        var response = await _client.PostAsync("addmessage", content);
    }
}
