using ApplicationDbContext;
using ApplicationDbContext.Models;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Model.Create
{
    public class AddStudentToDb
    {
        private readonly ReservoomDbContext _context;

        public AddStudentToDb(ReservoomDbContext context)
        {
            _context = context;
        }

        public void Do(Request request)
        {
            var student = new StudentModel
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                FacultyName = request.FacultyName,
                Specialization = request.Specialization,
            };
            _context.Student.Add(student);
            _context.SaveChanges();
        }
        public class Request
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
