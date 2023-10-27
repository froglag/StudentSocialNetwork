using ApplicationDbContext;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Get
{
    public class GetStudentInfo
    {
        private ReservoomDbContext _context;

        public GetStudentInfo(ReservoomDbContext context)
        {
            _context = context;
        }

        public Response? Do(int studentId)
        {
            return _context.Student.Where(s => s.StudentId == studentId)
                .Select(s => new Response
                {
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Email = s.Email,
                    PhoneNumber = s.PhoneNumber,
                    FacultyName = s.FacultyName,
                    Specialization = s.Specialization
                })
                .First();
        }

        public class Response
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
            public string FacultyName { get; set; }
            public string Specialization { get; set; }
        }
    }
}
