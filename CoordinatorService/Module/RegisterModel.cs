using System.Text.Json;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace CoordinatorService.Module;

public class RegisterModel
{
    private readonly HttpClient _httpClient;
    private readonly ILogger _logger;

    public RegisterModel(HttpClient httpClient, ILogger logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task Do(Request request)
    {
        var json = JsonSerializer.Serialize(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        
    }

    public class Request
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? FacultyName { get; set; }
        public string? Specialization { get; set; }
    }
}
