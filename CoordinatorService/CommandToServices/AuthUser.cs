namespace CommandToServices;

public class AuthUser
{
    private HttpClient _httpClient;

    public AuthUser(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IResult> Do()
    {

        return Results.Ok();
    }

    class Request
    {
        public int MyProperty { get; set; }
    }
}
