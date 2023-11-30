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
    /// <summary>
    /// This class provides functionality to add a new student and associated user credentials to the database.
    /// </summary>
    public class AddStudentToDb
    {
        private readonly ReservoomDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddStudentToDb"/> class.
        /// </summary>
        /// <param name="context">The database context used for data operations.</param>
        public AddStudentToDb(ReservoomDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new student and associated user credentials to the database based on the provided request.
        /// </summary>
        /// <param name="request">The request containing information about the student and user credentials.</param>
        public void Do(Request request)
        {
            // Check if either UserName or Password is not null before creating a new student
            if (request.UserName != null || request.Password != null)
            {
                // Create a new student and user
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

                // Add student and user to the respective tables and save changes
                _context.Student.Add(student);
                _context.User.Add(user);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Represents the request format for adding a new student and user credentials.
        /// </summary>
        public class Request
        {
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public string? Email { get; set; }
            public int? PhoneNumber { get; set; }
            public string? FacultyName { get; set; }
            public string? Specialization { get; set; }

            /// <summary>
            /// Gets or sets the username for the user associated with the student.
            /// </summary>
            [Required]
            public string UserName { get; set; }

            /// <summary>
            /// Gets or sets the password for the user associated with the student.
            /// </summary>
            [Required]
            public string Password { get; set; }
        }
    }
}
