using FriendingApplication.Models;

namespace FriendingService;

public static class ApiMapping
{
    public static void ConfigurationApi(this WebApplication app)
    {
        app.MapPost("/friending", FriendingInsert);
        app.MapGet("/friending/{studentid}/student", FriendingGetAllByStudentId);
        app.MapGet("/friending/{id}", FriendingGet);
        app.MapDelete("/friending/{studentid}/{friendid}", FriendingDelete);

        app.MapPost("/friendrequest", FriendRequestInsert);
        app.MapGet("/friendrequest/{studentid}/student", FriendRequestGetByStudentId);
        app.MapGet("/friendrequest/{id}", FriendRequestGet);
        app.MapDelete("/friendrequest/{id}", FriendRequestDelete);
    }

    public static async Task<IResult> FriendingInsert(IApplication application, FriendingModel friending)
    {

        try
        {
            var allfriends = await application.FriendGetAllByStudentId(friending.StudentId);
            if (allfriends.FirstOrDefault(f => f.FriendId == friending.FriendId) != null)
            {
                return Results.BadRequest("The friend already inserted");
            }

            await application.FriendingInsert(friending);
            return Results.Ok(); 
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    public static async Task<IResult> FriendingGetAllByStudentId(IApplication application, int studentId)
    {
        try
        {
            var result = await application.FriendGetAllByStudentId(studentId);
            return Results.Ok(result);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    public static async Task<IResult> FriendingGet(IApplication application, int id)
    {
        try
        {
            var result = await application.FriendingGet(id);
            return Results.Ok(result);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    public static async Task<IResult> FriendingDelete(IApplication application, int studentId, int friendId)
    {
        try
        {
            await application.FriedingDelete(studentId, friendId);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    public static async Task<IResult> FriendRequestInsert(IApplication application, FriendRequestModel friendRequest)
    {
        try
        {
            var allFriendRequests = await application.FriendRequestGetAllByStudentId(friendRequest.StudentId);

            if (allFriendRequests.FirstOrDefault(fr => fr.FriendId == friendRequest.FriendId) != null)
            {
                return Results.BadRequest("The friendrequest is exists");
            }

            await application.FriendRequestInsert(friendRequest);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    public static async Task<IResult> FriendRequestGetByStudentId(IApplication application, int studentId)
    {
        try
        {
            var result = await application.FriendRequestGetAllByStudentId(studentId);
            return Results.Ok(result);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    public static async Task<IResult> FriendRequestGet(IApplication application, int id)
    {
        try
        {
            var result = await application.FriendRequestGet(id);
            return Results.Ok(result);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    public static async Task<IResult> FriendRequestDelete(IApplication application, int id)
    {
        try
        {
            await application.FriendRequestDelete(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}
