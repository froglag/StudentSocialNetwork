using System.ComponentModel.DataAnnotations;

namespace ApplicationDbContext.Models;

public class StudentChatModel
{
    [Key]
    public int StudentChatId { get; set; }
    public int StudentId { get; set; }
    public int ChatId { get; set; }
    public StudentModel Student { get; set; } = null!;
    public ChatModel Chat { get; set; } = null!;
}
