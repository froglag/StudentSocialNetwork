using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApplicationDbContext.Models
{
    public class StudentModel
    {
        [Key]
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int FacultyId { get; set; }
        public int SpecializationId { get; set; }

        public ICollection<FriendModel> Friends { get; set; }
    }
}
