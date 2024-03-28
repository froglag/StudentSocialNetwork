using MVVM.Model.DataFields;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace MVVM.Model;

public class GetSearchInfo
{
    private HttpClient _client;

    public GetSearchInfo(HttpClient client)
    {
        _client = client;
    }

    public List<SearchInfo> Do()
    {
        var getResponse = _client.GetStringAsync("searchinfo").Result;
        var jsonString = JObject.Parse(getResponse);
        var result = new List<SearchInfo>();

        for (int i = 0; i < jsonString["value"].Count(); i++)
        {
            result.Add(new SearchInfo()
            {
                StudentId = (int)jsonString["value"][i]["studentId"],
                Firstname = (string)jsonString["value"][i]["firstname"],
                Lastname = (string)jsonString["value"][i]["lastname"],
            });
        }
        return result;

    }
}
