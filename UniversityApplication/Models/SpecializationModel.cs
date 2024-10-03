namespace UniversityApplication.Models;
public class SpecializationModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int FacultyId { get; set; }
    public FacultyModel Faculty { get; set; }
}
