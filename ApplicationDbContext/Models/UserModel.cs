using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDbContext.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;

        public string Role { get; set; } = null!;

        public StudentModel? Student { get; set; }
    }
}
