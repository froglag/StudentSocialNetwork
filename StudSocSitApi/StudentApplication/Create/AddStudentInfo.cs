using ApplicationDbContext;
using ApplicationDbContext.Authentication;
using ApplicationDbContext.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentApplication.Authentication
{
    /// <summary>
    /// This class provides functionality to add a new student and associated user credentials to the database.
    /// </summary>
    public class AddStudentInfo
    {
        private readonly ReservoomDbContext _context;
        private readonly ILogger _logger;
        private readonly UserManager<UserModel> _userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddStudentInfo"/> class.
        /// </summary>
        /// <param name="context">The database context used for data operations.</param>
        public AddStudentInfo(ReservoomDbContext context, ILogger logger, UserManager<UserModel> userManager)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
        }

        /// <summary>
        /// Adds a new student and associated user credentials to the database based on the provided request.
        /// </summary>
        /// <param name="request">The request containing information about the student and user credentials.</param>
        public async Task<IResult> Do(Request request)
        {
            var user = await _userManager.FindByEmailAsync(request.UserName);

            // Check if either UserName or PasswordHash is not null before creating a new student
            if (user == null || request.FirstName == null)
            {
                _logger.LogError("Invalid request data");
                return Results.BadRequest("Invalid request data");
            }

            var studentCheck = await _context.Student.FirstOrDefaultAsync(s => s.UserId == user.Id);

            if(studentCheck != null)
            {
                _logger.LogError("A student with this user already exists");
                return Results.BadRequest("A student with this user already exists");
            }

            // Create a new student and user
            var student = new StudentModel
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                FacultyName = request.FacultyName,
                Specialization = request.Specialization,
                User = user
            };

            try
            {
                // Add student and user to the respective tables and save changes
                await _context.Student.AddAsync(student);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Student information succesfully added");
                return Results.Created("Student information succesfully added", student); 
            }catch (Exception ex)
            {
                _logger.LogError("Not added - exception message: " + ex.Message);
                return Results.Problem(detail: ex.Message);
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
            public string? FacultyName { get; set; }
            public string? Specialization { get; set; }

            public string UserName { get; set; }
        }
    }
}
