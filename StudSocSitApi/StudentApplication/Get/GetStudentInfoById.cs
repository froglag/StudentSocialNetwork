using ApplicationDbContext;
using ApplicationDbContext.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
                    .Where(s => s.StudentId == studentId)
                    .FirstOrDefaultAsync();

                _logger.LogInformation("Student found");
                return Results.Json(student);
            }
            catch (Exception ex)
            {
                _logger.LogError("Student not found");
                return Results.NotFound(ex.Message);
            }
        }
    }
}
