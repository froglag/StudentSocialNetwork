using DataAccess.Models;

namespace DataAccess.Application;
public interface IUniversityApplication
{
    Task<int> FacultyInsert(FacultyModel faculty);
    Task<FacultyModel?> FacultyGet(int id);
    Task<IEnumerable<FacultyModel>?> FacultyGetAll();
    Task<IEnumerable<FacultyModel>> FacultyGetUniversityId(int universityId);
    Task FacultyUpdate(FacultyModel faculty);
    Task<int> SpecializationInsert(SpecializationModel specialization);
    Task<SpecializationModel?> SpecializationGet(int id);
    Task<IEnumerable<SpecializationModel>?> SpecializationGetAll();
    Task<IEnumerable<SpecializationModel>> SpecializationGetFacultyId(int facultyId);
    Task SpecializationUpdate(SpecializationModel specialization);
    Task<IEnumerable<UniversityModel>?> UniversityGetAll();
    Task UniversityInsert(UniversityModel university);
    Task<UniversityModel?> UniversityGet(int id);
    Task UniversityUpdate(UniversityModel university);
}