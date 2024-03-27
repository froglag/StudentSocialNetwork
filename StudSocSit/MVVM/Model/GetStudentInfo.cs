using MVVM.Model.DataFields;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace MVVM.Model;

public class GetStudentInfo
{
    private HttpClient _client;
    private string _JWT;

    public GetStudentInfo(HttpClient client, string JWT)
    {
        _client = client;
        _JWT = JWT;
    }
    
    public StudentModel Do()
    {
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _JWT);
        var getResponse = _client.GetAsync("userinfo").Result;

        var jsonString = getResponse.Content.ReadAsStringAsync().Result;
        var jsonValue = JValue.Parse(jsonString);
        return new StudentModel 
        {
            FirstName = jsonValue["value"].Value<string>("firstName"),
            LastName = jsonValue["value"].Value<string>("lastName"),
            Email = jsonValue["value"].Value<string>("email"),
            FacultyName = jsonValue["value"].Value<string>("facultyName"),
            PhoneNumber = jsonValue["value"].Value<string>("phoneNumber"),
            Specialization = jsonValue["value"].Value<string>("specialization")

        };
    }
}
