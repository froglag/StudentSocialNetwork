using ApplicationDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Model.Get
{
    public class GetFriendId
    {
        private readonly ReservoomDbContext _context;

        public GetFriendId(ReservoomDbContext context)
        {
            _context = context;
        }

        public int[]? Do(int studentId)
        {
            return _context.Student
                .Where(s => s.StudentId == studentId)
                .Select(s => s.Friends.Select(f => f.StudentId))
                .First()
                .ToArray();
        }

    }
}
