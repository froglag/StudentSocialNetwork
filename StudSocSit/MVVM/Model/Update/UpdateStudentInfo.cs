using ApplicationDbContext;
using ApplicationDbContext.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Model.Update
{
    public class UpdateStudentInfo
    {
        private readonly ReservoomDbContext _context;

        public UpdateStudentInfo(ReservoomDbContext context)
        {
            _context = context;
        }

        public void Do(Request request)
        {
            
            var studentIdentity = _context.Student.First(x => x.StudentId == request.StudentId);

            if (studentIdentity != null) 
            {
                if(request.FirstName != null)
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

                _context.SaveChanges();
            }
            
        }

        public class Request
        {
            public int StudentId { get; set; }
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public string? Email { get; set; }
            public string? PhoneNumber { get; set; }
            public string? FacultyName { get; set; }
            public string? Specialization { get; set; }
        }
    }
}
