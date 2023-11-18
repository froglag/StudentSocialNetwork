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
    public class GetAuthorizedStudentInfo
    {
        private readonly ReservoomDbContext _context;

        public GetAuthorizedStudentInfo(ReservoomDbContext context)
        {
            _context = context;
        }

        public StudentModel? Do(Request request)
        {
            if (request != null)
            {
                try
                {
                    return _context.User.Where(u => u.UserName == request.UserName && u.Password == request.Password)
                                .Select(u => u.Student)
                                .First();
                }catch (Exception)
                {
                    return null;
                }
                
            }
            else
            {
                return null;
            }
                
        }

        public class Request
        {
            public string? UserName { get; set; }
            public string? Password { get; set; }
        }
    }
}
