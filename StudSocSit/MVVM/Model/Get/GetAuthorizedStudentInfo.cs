using ApplicationDbContext;
using ApplicationDbContext.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Get
{
    /// <summary>
    /// This class provides functionality to retrieve student information for an authorized user from the database.
    /// </summary>
    public class GetAuthorizedStudentInfo
    {
        private readonly ReservoomDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAuthorizedStudentInfo"/> class.
        /// </summary>
        /// <param name="context">The database context used for data operations.</param>
        public GetAuthorizedStudentInfo(ReservoomDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves student information for an authorized user based on the provided username and password.
        /// </summary>
        /// <param name="request">The request containing the username and password for authentication.</param>
        /// <returns>Returns the <see cref="StudentModel"/> for the authorized user; returns null if authorization fails.</returns>
        public StudentModel? Do(Request request)
        {
            if (request != null)
            {
                try
                {
                    // Find the user based on the provided username and password, then retrieve the associated student information
                    return _context.User
                        .Where(u => u.UserName == request.UserName && u.Password == request.Password)
                        .Select(u => u.Student)
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
                // Return null if the request is null
                return null;
            }
        }

        /// <summary>
        /// Represents the request format for retrieving student information for an authorized user.
        /// </summary>
        public class Request
        {
            /// <summary>
            /// Gets or sets the username for the authorized user.
            /// </summary>
            public string? UserName { get; set; }

            /// <summary>
            /// Gets or sets the password for the authorized user.
            /// </summary>
            public string? Password { get; set; }
        }
    }

}
