using ApplicationDbContext;
using ApplicationDbContext.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Model.Update
{
    /// <summary>
    /// This class provides functionality to update student information in the database.
    /// </summary>
    public class UpdateStudentInfo
    {
        private readonly ReservoomDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateStudentInfo"/> class.
        /// </summary>
        /// <param name="context">The database context used for data operations.</param>
        public UpdateStudentInfo(ReservoomDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Updates student information in the database based on the provided request.
        /// </summary>
        /// <param name="request">The request containing information about the student and the updates to be applied.</param>
        public void Do(Request request)
        {
            // Find the student based on the provided student identifier
            var studentIdentity = _context.Student.FirstOrDefault(x => x.StudentId == request.StudentId);

            // Check if the student is found before attempting to update information
            if (studentIdentity != null)
            {
                // Update student information based on the provided request
                if (request.FirstName != null)
                    studentIdentity.FirstName = request.FirstName;
                if (request.LastName != null)
                    studentIdentity.LastName = request.LastName;
                if (request.Email != null)
                    studentIdentity.Email = request.Email;
                if (request.PhoneNumber != null)
                    studentIdentity.PhoneNumber = request.PhoneNumber;
                if (request.FacultyName != null)
                    studentIdentity.FacultyName = request.FacultyName;
                if (request.Specialization != null)
                    studentIdentity.Specialization = request.Specialization;

                // Save changes to the database
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Represents the request format for updating student information.
        /// </summary>
        public class Request
        {
            /// <summary>
            /// Gets or sets the identifier of the student for whom information is to be updated.
            /// </summary>
            public int? StudentId { get; set; }

            /// <summary>
            /// Gets or sets the updated first name of the student.
            /// </summary>
            public string? FirstName { get; set; }

            /// <summary>
            /// Gets or sets the updated last name of the student.
            /// </summary>
            public string? LastName { get; set; }

            /// <summary>
            /// Gets or sets the updated email address of the student.
            /// </summary>
            public string? Email { get; set; }

            /// <summary>
            /// Gets or sets the updated phone number of the student.
            /// </summary>
            public int? PhoneNumber { get; set; }

            /// <summary>
            /// Gets or sets the updated faculty name of the student.
            /// </summary>
            public string? FacultyName { get; set; }

            /// <summary>
            /// Gets or sets the updated specialization of the student.
            /// </summary>
            public string? Specialization { get; set; }
        }
    }

}
