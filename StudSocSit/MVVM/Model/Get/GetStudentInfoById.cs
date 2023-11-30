using ApplicationDbContext;
using ApplicationDbContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Model.Get
{
    /// <summary>
    /// This class provides functionality to retrieve student information from the database based on the student identifier.
    /// </summary>
    public class GetStudentInfoById
    {
        private readonly ReservoomDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetStudentInfoById"/> class.
        /// </summary>
        /// <param name="context">The database context used for data operations.</param>
        public GetStudentInfoById(ReservoomDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves student information from the database based on the provided student identifier.
        /// </summary>
        /// <param name="studentId">The identifier of the student for whom information is to be retrieved.</param>
        /// <returns>Returns the <see cref="StudentModel"/> for the specified student; returns null if the student is not found.</returns>
        public StudentModel? Do(int? studentId)
        {
            // Check if studentId is not null before attempting to retrieve student information
            if (studentId != null)
            {
                try
                {
                    // Find the student based on the provided student identifier
                    return _context.Student
                        .Where(s => s.StudentId == studentId)
                        .FirstOrDefault();
                }
                catch (Exception)
                {
                    // Return null if any exception occurs during the process
                    return null;
                }
            }
            else
            {
                // Return null if studentId is null
                return null;
            }
        }
    }
}
