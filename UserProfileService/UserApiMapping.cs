using UserApplication.Models;

namespace UserService;

public static class UserApiMapping
{

    public static void ConfigurationApi(this WebApplication app)
    {
        app.MapGet("/users", GetUsers);
        app.MapGet("/users/{id}", GetUser);
        app.MapPost("/users", InsertUser);
        app.MapPut("/users", UpdateUser);
    }

    private static async Task<IResult> GetUsers(IApplication user)
    {
        try
        {
            return Results.Ok(await user.GetUsers());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> GetUser(IApplication user, int id)
    {
        try
        {
            var result = await user.GetUser(id);
            if (result == null) return Results.NotFound();
            return Results.Ok(result);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> InsertUser(IApplication user, UserModel userModel)
    {
        try
        {
            await user.InsertUser(userModel);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateUser(IApplication user, UserModel userModel)
    {
        try
        {
            await user.UpdateUser(userModel);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}
