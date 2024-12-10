namespace UserApplication.Models;

public class UserModel
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; } 
    public int UniversityId { get; set; }
    public int FacultyId { get; set; }
    public int SpecializationId { get; set; }
    public string Email { get; set; }
    public byte[] Image { get; set; }
}
