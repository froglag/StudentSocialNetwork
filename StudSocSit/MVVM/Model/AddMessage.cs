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

    public async Task Do(Request request)
    {
        var json = JsonSerializer.Serialize(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        
        await _client.PostAsync("addmessage", content);
    }

    public class Request
    {
        public int FriendId { get; set; }
        public string Text { get; set; }
    }
}
