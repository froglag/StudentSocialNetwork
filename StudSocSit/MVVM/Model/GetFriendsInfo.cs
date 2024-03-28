
using MVVM.Model.DataFields;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;

namespace MVVM.Model;

public class GetFriendsInfo
{
    private HttpClient _client;

    public GetFriendsInfo(HttpClient client)
    {
        _client = client;
    }
    public List<StudentModel> Do()
    {
        var getResponse = _client.GetStringAsync("allfriendsinfo").Result;
        var jsonString = JObject.Parse(getResponse);
        var result = new List<StudentModel>();

        for(int i = 0; i< jsonString["value"].Count(); i++)
        {
            result.Add(new StudentModel()
            {
                StudentId = (int)jsonString["value"][i]["friendId"],
                FirstName = (string)jsonString["value"][i]["firstName"],
                LastName = (string)jsonString["value"][i]["lastName"],
                Email = (string)jsonString["value"][i]["email"],
                FacultyName = (string)jsonString["value"][i]["facultyName"],
                PhoneNumber = (string)jsonString["value"][i]["phoneNumber"],
                Specialization = (string)jsonString["value"][i]["specialization"]
            });
        }
        return result;

    }
}
