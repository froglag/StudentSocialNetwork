using ApplicationDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Delete
{
    public class DeleteStudent
    {
        private readonly ReservoomDbContext _context;

        public DeleteStudent(ReservoomDbContext context)
        {
            _context = context;
        }

        public void Do(int studentId)
        {
            var studentIdentity = _context.Student.First(s => s.StudentId == studentId);
            if (studentIdentity != null)
            {
                _context.Remove(studentIdentity);
                _context.SaveChanges();
            }
        }
    }
}
