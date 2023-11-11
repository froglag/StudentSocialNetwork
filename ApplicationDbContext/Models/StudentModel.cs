using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApplicationDbContext.Models
{
    public class StudentModel
    {
        [Key]
        public int StudentId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Phone]
        public int? PhoneNumber { get; set; }
        public string? FacultyName { get; set; }
        public string? Specialization { get; set; }

        public ICollection<StudentModel>? Friends { get; set; }
    }
}
