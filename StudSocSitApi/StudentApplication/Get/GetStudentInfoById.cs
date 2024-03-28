using ApplicationDbContext;
using ApplicationDbContext.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApplication.Get
{
    /// <summary>
    /// This class provides functionality to retrieve student information from the database based on the student identifier.
    /// </summary>
    public class GetStudentInfoById
    {
        private readonly ReservoomDbContext _context;
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetStudentInfoById"/> class.
        /// </summary>
        /// <param name="context">The database context used for data operations.</param>
        public GetStudentInfoById(ReservoomDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Retrieves student information from the database based on the provided student identifier.
        /// </summary>
        /// <param name="studentId">The identifier of the student for whom information is to be retrieved.</param>
        /// <returns>Returns for the specified student; returns Result NotFound if the student is not found.</returns>
        public async Task<IResult> Do(int studentId)
        {
            try
            {
                var student = await _context.Student
                    .FirstOrDefaultAsync(s => s.StudentId == studentId);

                _logger.LogInformation("Student found");
                return Results.Ok(new Response
                {
                    StudentId = studentId,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Email = student.Email,
                    FacultyName = student.FacultyName,
                    Specialization = student.Specialization
                });
            }
            catch (Exception ex)
            {
                _logger.LogError("Student not found");
                return Results.NotFound(ex.Message);
            }
        }

        class Response
        {
            public int StudentId { get; set; }
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public string? Email { get; set; }

            public string? FacultyName { get; set; }
            public string? Specialization { get; set; }
        }
    }
}
