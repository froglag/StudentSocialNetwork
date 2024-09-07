using DataAccess.Models;

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

        app.MapGet("university/{universityid}/faculties", FacultyGetUniversityId);
        app.MapGet("faculty/{facultyid}/specializations", SpecializationGetFacultyId);


        app.MapPut("university", UniversityUpdate);
        app.MapPut("faculty", FacultyUpdate);
        app.MapPut("specialization", SpecializationUpdate);
    }

    public static async Task<IResult> UniversityInsert(IUniversityApplication application, UniversityModel university)
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

    public static async Task<IResult> FacultyInsert(IUniversityApplication application, FacultyModel faculty)
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

    public static async Task<IResult> SpecializationInsert(IUniversityApplication application, SpecializationModel specialization)
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

    public static async Task<IResult> UniversityGetAll(IUniversityApplication application)
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

    public static async Task<IResult> FacultyGetAll(IUniversityApplication application)
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

    public static async Task<IResult> SpecializationGetAll(IUniversityApplication application)
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

    public static async Task<IResult> UniversityGet(IUniversityApplication application, int id)
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

    public static async Task<IResult> FacultyGet(IUniversityApplication application, int id)
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

    public static async Task<IResult> SpecializationGet(IUniversityApplication application, int id)
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

    public static async Task<IResult> FacultyGetUniversityId(IUniversityApplication application, int universityId)
    {
        try
        {
            var result = await application.FacultyGetUniversityId(universityId);
            return Results.Ok(result);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    public static async Task<IResult> SpecializationGetFacultyId(IUniversityApplication application, int facultyId)
    {
        try
        {
            var result = await application.SpecializationGetFacultyId(facultyId);
            return Results.Ok(result);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    public static async Task<IResult> UniversityUpdate(IUniversityApplication application, UniversityModel university)
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

    public static async Task<IResult> FacultyUpdate(IUniversityApplication application, FacultyModel faculty)
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

    public static async Task<IResult> SpecializationUpdate(IUniversityApplication application, SpecializationModel specialization)
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
}
