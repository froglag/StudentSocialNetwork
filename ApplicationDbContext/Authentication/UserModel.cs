using ApplicationDbContext.Models;
using Microsoft.AspNetCore.Identity;

namespace ApplicationDbContext.Authentication
{
    public class UserModel : IdentityUser
    {
        public StudentModel Student { get; set; }
    }
}
