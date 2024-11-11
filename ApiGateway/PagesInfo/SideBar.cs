using ApiGateway.Models;
using Grpc.Core;
using Grpc.Net.Client;
using MessagingService;
using Newtonsoft.Json;

namespace ApiGateway.PagesInfo;

public class SideBar
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public SideBar(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }
    public async Task<IResult> GetSideBarData(int id)
    {
        try
        {
            var messageServiceUrl = _configuration.GetValue<string>("RequestStrings:Developer:MessageService");
            if (string.IsNullOrWhiteSpace(messageServiceUrl))
            {
                return Results.Problem("Message service URL is missing in configuration.", statusCode: 500);
            }

            using var channel = GrpcChannel.ForAddress(messageServiceUrl);
            var client = new Chat.ChatClient(channel);

            var chats = new List<ChatModel>();
            using var call = client.ChatGetAll(new GetAllChatRequest { StudentId = id });
            await foreach (var chat in call.ResponseStream.ReadAllAsync())
            {
                chats.Add(chat);
            }

            var userServiceUrl = _configuration.GetValue<string>("RequestStrings:Developer:UserService");
            if (string.IsNullOrWhiteSpace(userServiceUrl))
            {
                return Results.Problem("User service URL is missing in configuration.", statusCode: 500);
            }

            var response = await _httpClient.GetAsync($"{userServiceUrl}/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return Results.Problem($"User service request failed with status: {response.StatusCode}", statusCode: 500);
            }

            var responseData = await response.Content.ReadAsStringAsync();
            var jsonData = JsonConvert.DeserializeObject<UserModel>(responseData);

            if (jsonData == null)
            {
                return Results.Problem("No user data available.", statusCode: 400);
            }

            return Results.Ok(new SideBarModel
            {
                FirstName = jsonData.FirstName,
                LastName = jsonData.LastName,
                Image = jsonData.Image,
                ChatsName = chats.Select(c => c.Name).ToList()
            });
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message, statusCode: 500);
        }
    }
}
