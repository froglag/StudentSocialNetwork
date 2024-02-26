using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDbContext.Models
{
    public class FriendshipModel
    {
        [Key]
        public int FriendshipId { get; set; }

        public StudentModel Student { get; set; } = null!;
        public int StudentId { get; set; }

        public StudentModel Friend { get; set; } = null!;
        public int FriendId { get; set; }
    }
}
