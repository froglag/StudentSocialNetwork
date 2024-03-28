using MVVM.Model.DataFields;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;

namespace MVVM.Model;

public class UpdateUserInfo
{
    private HttpClient _client;

    public UpdateUserInfo(HttpClient client)
    {
        _client = client;
    }

    public void Do(Request request)
    {
        var json = JsonSerializer.Serialize(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        _client.PutAsync("studentinfo", content);
    }

    public class Request
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? FacultyName { get; set; }
        public string? Specialization { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
