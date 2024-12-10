namespace UniversityApplication.Models;
public class UniversityModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<FacultyModel> Faculties { get; set; } = new List<FacultyModel>();
}
