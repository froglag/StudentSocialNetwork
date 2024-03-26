
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Model;

public class AddFriendRequest
{
    private HttpClient _client;
    private string _JWT;

    public AddFriendRequest(HttpClient client, string JWT)
    {
        _client = client;
        _JWT = JWT;
    }

    public async Task Do(Request request)
    {
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _JWT);

        var json = JsonSerializer.Serialize(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        await _client.PostAsync("addfriendrequest", content);
    }

    public class Request
    {
        public int SenderId { get; set; }

        public int ReceiverId { get; set; }

        public string? Text { get; set; }
    }
}
