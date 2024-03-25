using MVVM.Model.DataFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MVVM.Model;

public class GetStudentInfo
{
    private HttpClient _client;

    public GetStudentInfo(HttpClient client)
    {
        _client = client;
    }
    
    public StudentModel Do(string JWT)
    {
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + JWT);
        var getResponse = _client.GetAsync("/userinfo").Result;

        return getResponse.Content.ReadFromJsonAsync<StudentModel>().Result;
    }
}
