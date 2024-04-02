
using MVVM.Model.DataFields;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Json;

namespace MVVM.Model;

public class GetStudentInfoById
{
    private HttpClient _client;

    public GetStudentInfoById(HttpClient client)
    {
        _client = client;
    }

    public StudentModel Do(int studentId)
    {
        var getResponse = _client.GetStringAsync($"friendinfo/{studentId}").Result;
        
        var jsonString = JObject.Parse(getResponse);

        return new StudentModel { 
            StudentId = (int)jsonString["value"]["studentId"],
            FirstName = (string)jsonString["value"]["firstName"],
            LastName = (string)jsonString["value"]["lastName"],
            Email = (string)jsonString["value"]["email"],
            FacultyName = (string)jsonString["value"]["facultyName"],
            PhoneNumber = (string)jsonString["value"]["phoneNumber"],
            Specialization = (string)jsonString["value"]["specialization"]
        };
    }
}
