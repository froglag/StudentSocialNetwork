using ApplicationDbContext;
using ApplicationDbContext.Models;
using Microsoft.EntityFrameworkCore;
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
        private readonly ReservoomDbContext _context;

        public GetStudentInfo(ReservoomDbContext context)
        {
            _context = context;
        }

        public StudentModel? Do(Request request)
        {
            return _context.User.Where(u => u.UserName == request.UserName && u.Password == request.Password)
                .Select(u => u.Student)
                .First();
        }

        public class Request
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }
    }
}
