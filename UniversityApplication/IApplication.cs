using UniversityApplication.Models;

namespace UniversityApplication;

public interface IApplication
{
    Task<int> FacultyInsert(FacultyModel faculty);
    Task<FacultyModel?> FacultyGet(int id);
    Task<IEnumerable<FacultyModel>?> FacultyGetAll();
    Task FacultyUpdate(FacultyModel faculty);
    Task<int> SpecializationInsert(SpecializationModel specialization);
    Task<SpecializationModel?> SpecializationGet(int id);
    Task<IEnumerable<SpecializationModel>?> SpecializationGetAll();
    Task SpecializationUpdate(SpecializationModel specialization);
    Task<IEnumerable<UniversityModel>?> UniversityGetAll();
    Task UniversityInsert(UniversityModel university);
    Task<UniversityModel?> UniversityGet(int id);
    Task UniversityUpdate(UniversityModel university);
    Task<IEnumerable<SpecializationModel>> UniversityGetFullTable();
}