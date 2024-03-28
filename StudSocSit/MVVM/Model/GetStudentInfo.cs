using MVVM.Model.DataFields;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace MVVM.Model;

public class GetStudentInfo
{
    private HttpClient _client;
    private string _JWT;

    public GetStudentInfo(HttpClient client)
    {
        _client = client;
    }
    
    public StudentModel Do()
    {
        var getResponse = _client.GetAsync("userinfo").Result;

        var jsonString = getResponse.Content.ReadAsStringAsync().Result;
        var jsonValue = JObject.Parse(jsonString);
        return new StudentModel 
        {
            StudentId = (int)jsonValue["value"]["studentId"],
            FirstName = (string)jsonValue["value"]["firstName"],
            LastName = (string)jsonValue["value"]["lastName"],
            Email = (string)jsonValue["value"]["email"],
            FacultyName = (string)jsonValue["value"]["facultyName"],
            PhoneNumber = (string)jsonValue["value"]["phoneNumber"],
            Specialization = (string)jsonValue["value"]["specialization"]
        };
    }
}
