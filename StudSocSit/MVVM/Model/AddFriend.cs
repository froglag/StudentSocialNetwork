using System.Net.Http;
using static System.Net.Mime.MediaTypeNames;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Model;

public class AddFriend
{
    private HttpClient _client;

    public AddFriend(HttpClient client)
    {
        _client = client;
    }

    public async Task Do(int friendId)
    {
        var json = JsonSerializer.Serialize(friendId);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        await _client.PostAsync("addfriend", content);
    }

}
