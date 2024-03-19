using ApplicationDbContext;
using ApplicationDbContext.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace StudentApplication.Update
{
    /// <summary>
    /// This class provides functionality to update student information in the database.
    /// </summary>
    public class UpdateStudentInfo
    {
        private readonly ReservoomDbContext _context;
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateStudentInfo"/> class.
        /// </summary>
        /// <param name="context">The database context used for data operations.</param>
        public UpdateStudentInfo(ReservoomDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Updates student information in the database based on the provided request.
        /// </summary>
        /// <param name="request">The request containing information about the student and the updates to be applied.</param>
        public async Task<IResult> Do(Request request)
        {
            // Find the student based on the provided student identifier
            var studentIdentity = await _context.Student.FirstOrDefaultAsync(x => x.StudentId == request.StudentId);

            if (studentIdentity is null)
            {
                _logger.LogError("Student not found");
                return Results.NotFound("Student not found");
            }

            try
            {
                // Update student information based on the provided request
                if (request.FirstName != null)
                    studentIdentity.FirstName = request.FirstName;
                if (request.LastName != null)
                    studentIdentity.LastName = request.LastName;
                if (request.Email != null)
                    studentIdentity.Email = request.Email;
                if (request.FacultyName != null)
                    studentIdentity.FacultyName = request.FacultyName;
                if (request.Specialization != null)
                    studentIdentity.Specialization = request.Specialization;

                // Save changes to the database
                await _context.SaveChangesAsync();
                return Results.Ok("Data updated");
            }catch (Exception ex)
            {
                _logger.LogError("Data not updated:" + ex.Message);
                return Results.Problem(detail: ex.Message);
            }
            
        }

        /// <summary>
        /// Represents the request format for updating student information.
        /// </summary>
        public class Request
        {
            // Gets or sets the identifier of the student for whom information is to be updated.
            public int StudentId { get; set; }

            // Gets or sets the updated first name of the student.
            public string? FirstName { get; set; }

            // Gets or sets the updated last name of the student.
            public string? LastName { get; set; }

            // Gets or sets the updated email address of the student.
            public string? Email { get; set; }

            // Gets or sets the updated phone number of the student.
            public string? PhoneNumber { get; set; }

            // Gets or sets the updated faculty name of the student.
            public string? FacultyName { get; set; }

            // Gets or sets the updated specialization of the student.
            public string? Specialization { get; set; }
        }
    }

}
