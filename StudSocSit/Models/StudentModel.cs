using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public List<FriendsModel> Friends { get; set; }

        public List<FriendRequestModel> FriendRequests { get; set; }
    }
}
