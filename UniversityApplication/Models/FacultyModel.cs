namespace UniversityApplication.Models;
public class FacultyModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<SpecializationModel> Specializations { get; set; } = new List<SpecializationModel>();
    public int UniversityId { get; set; }
    public UniversityModel University { get; set; }
}
