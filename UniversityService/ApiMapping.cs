using UniversityApplication.Models;

namespace UniversityService;

public static class ApiMapping
{
    public static void ConfigurationApi(this WebApplication app)
    {
        app.MapPost("university", UniversityInsert);
        app.MapPost("faculty", FacultyInsert);
        app.MapPost("specialization", SpecializationInsert);


        app.MapGet("universities", UniversityGetAll);
        app.MapGet("faculties", FacultyGetAll);
        app.MapGet("specializations", SpecializationGetAll);

        app.MapGet("university/{id}", UniversityGet);
        app.MapGet("faculty/{id}", FacultyGet);
        app.MapGet("specialization/{id}", SpecializationGet);

        app.MapPut("university", UniversityUpdate);
        app.MapPut("faculty", FacultyUpdate);
        app.MapPut("specialization", SpecializationUpdate);

        app.MapGet("university/faculity/specialization", UniversityGetFullTable);
    }

    public static async Task<IResult> UniversityInsert(IApplication application, UniversityModel university)
    {
        try
        {
            await application.UniversityInsert(university);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    public static async Task<IResult> FacultyInsert(IApplication application, FacultyModel faculty)
    {
        try
        {
            var result = await application.FacultyInsert(faculty);
            if (result == 1) return Results.NotFound();
            else  return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    public static async Task<IResult> SpecializationInsert(IApplication application, SpecializationModel specialization)
    {
        try
        {
            var result = await application.SpecializationInsert(specialization);
            if (result == 1) return Results.NotFound();
            else return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    public static async Task<IResult> UniversityGetAll(IApplication application)
    {
        try
        {
            var result = await application.UniversityGetAll();
            return Results.Ok(result);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    public static async Task<IResult> FacultyGetAll(IApplication application)
    {
        try
        {
            var result = await application.FacultyGetAll();
            return Results.Ok(result);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    public static async Task<IResult> SpecializationGetAll(IApplication application)
    {
        try
        {
            var result = await application.SpecializationGetAll();
            return Results.Ok(result);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    public static async Task<IResult> UniversityGet(IApplication application, int id)
    {
        try
        {
            var result = await application.UniversityGet(id);
            return Results.Ok(result);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    public static async Task<IResult> FacultyGet(IApplication application, int id)
    {
        try
        {
            var result = await application.FacultyGet(id);
            return Results.Ok(result);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    public static async Task<IResult> SpecializationGet(IApplication application, int id)
    {
        try
        {
            var result = await application.SpecializationGet(id);
            return Results.Ok(result);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    public static async Task<IResult> UniversityUpdate(IApplication application, UniversityModel university)
    {
        try
        {
            await application.UniversityUpdate(university);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    public static async Task<IResult> FacultyUpdate(IApplication application, FacultyModel faculty)
    {
        try
        {
            await application.FacultyUpdate(faculty);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    public static async Task<IResult> SpecializationUpdate(IApplication application, SpecializationModel specialization)
    {
        try
        {
            await application.SpecializationUpdate(specialization);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    public static async Task<IResult> UniversityGetFullTable(IApplication application)
    {
        try
        {
            var result = await application.UniversityGetFullTable();
            return Results.Ok(result);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}
