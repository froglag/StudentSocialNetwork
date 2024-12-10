using DataAccess.DbAccess;
using UniversityApplication.Models;

namespace UniversityApplication;

public class Application : IApplication
{
    private readonly ISqlAccess _sqlAccess;

    public Application(ISqlAccess sqlAccess)
    {
        _sqlAccess = sqlAccess;
    }

    public async Task UniversityInsert(UniversityModel university)
    {
        await _sqlAccess.SaveData<dynamic>("dbo.spUniversity_Insert", new { university.Name, university.Description });
    }

    public async Task<int> FacultyInsert(FacultyModel faculty)
    {
        var result = await _sqlAccess.SaveDataWithFeedback<dynamic>("dbo.spFaculty_Insert", new { faculty.Name, faculty.Description, faculty.UniversityId });
        return result;
    }

    public async Task<int> SpecializationInsert(SpecializationModel specialization)
    {
        var result = await _sqlAccess.SaveDataWithFeedback<dynamic>("dbo.spSpecialization_Insert", new { specialization.Name, specialization.Description, specialization.FacultyId });
        return result;
    }

    public async Task<IEnumerable<UniversityModel>?> UniversityGetAll()
    {
        var result = await _sqlAccess.LoadData<UniversityModel, dynamic>("dbo.spUniversity_GetAll", new { });
        return result;
    }

    public async Task<IEnumerable<FacultyModel>?> FacultyGetAll()
    {
        var result = await _sqlAccess.LoadData<FacultyModel, dynamic>("dbo.spFaculty_GetAll", new { });
        return result;
    }

    public async Task<IEnumerable<SpecializationModel>?> SpecializationGetAll()
    {
        var result = await _sqlAccess.LoadData<SpecializationModel, dynamic>("dbo.spSpecialization_GetAll", new { });
        return result;
    }

    public async Task<UniversityModel?> UniversityGet(int id)
    {
        var result = await _sqlAccess.LoadData<UniversityModel, dynamic>("dbo.spUniversity_Get", new { Id = id });
        return result.FirstOrDefault();
    }

    public async Task<FacultyModel?> FacultyGet(int id)
    {
        var result = await _sqlAccess.LoadData<FacultyModel, dynamic>("dbo.spFaculty_Get", new { Id = id });
        return result.FirstOrDefault();
    }

    public async Task<SpecializationModel?> SpecializationGet(int id)
    {
        var result = await _sqlAccess.LoadData<SpecializationModel, dynamic>("dbo.spSpecialization_Get", new { Id = id });
        return result.FirstOrDefault();
    }

    public async Task UniversityUpdate(UniversityModel university)
    {
        await _sqlAccess.SaveData("dbo.spUniversity_Update", university);
    }

    public async Task FacultyUpdate(FacultyModel faculty)
    {
        await _sqlAccess.SaveData("dbo.spFaculty_Update", faculty);
    }

    public async Task SpecializationUpdate(SpecializationModel specialization)
    {
        await _sqlAccess.SaveData("dbo.spSpecialization_Update", specialization);
    }

    public async Task<IEnumerable<SpecializationModel>> UniversityGetFullTable()
    {
        var universityDictionary = new Dictionary<int, UniversityModel>();
        var facultyDictionary = new Dictionary<int, FacultyModel>();

        var result = await _sqlAccess.LoadThreeTable<SpecializationModel, FacultyModel, UniversityModel, dynamic>("dbo.spUniversity_GetFullTable", new {},  (specialization, faculty, university) =>
        {
            specialization.Faculty = faculty;
            faculty.University = university;

            return specialization;

        });
        
        return result;
    }
}
