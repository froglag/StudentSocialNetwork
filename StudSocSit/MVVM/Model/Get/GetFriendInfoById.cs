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
    public class GetFriendInfoById
    {
        private readonly ReservoomDbContext _context;

        public GetFriendInfoById(ReservoomDbContext context)
        {
            _context = context;
        }

        public StudentModel? Do(int studentId)
        {
            return _context.Student
                .Where(s => s.StudentId == studentId)
                .First();
        }

    }
}
