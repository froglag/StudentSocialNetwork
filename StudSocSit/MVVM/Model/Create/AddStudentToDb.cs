using ApplicationDbContext;
using ApplicationDbContext.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Model.Create
{
    public class AddStudentToDb
    {
        private readonly ReservoomDbContext _context;

        public AddStudentToDb(ReservoomDbContext context)
        {
            _context = context;
        }

        public void Do(Request request)
        {
            if (request.UserName != null || request.Password != null)
            {
                var student = new StudentModel
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    FacultyName = request.FacultyName,
                    Specialization = request.Specialization,
                };
                var user = new UserModel
                {
                    UserName = request.UserName,
                    Password = request.Password,
                    Student = student
                };
                _context.Student.Add(student);
                _context.User.Add(user);
                _context.SaveChanges();
            }
        }
        public class Request
        {
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public string? Email { get; set; }
            public int? PhoneNumber { get; set; }
            public string? FacultyName { get; set; }
            public string? Specialization { get; set; }
            [Required]
            public string UserName { get; set; }
            [Required]
            public string Password { get; set; }
        }
    }
}
