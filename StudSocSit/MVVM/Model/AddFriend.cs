using System.Net.Http;
using static System.Net.Mime.MediaTypeNames;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Model;

public class AddFriend
{
    private HttpClient _client;
    private string _JWT;

    public AddFriend(HttpClient client, string JWT)
    {
        _client = client;
        _JWT = JWT;
    }

    public async Task Do(int friendId)
    {
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _JWT);

        var json = JsonSerializer.Serialize(friendId);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        await _client.PostAsync("addfriend", content);
    }

}
