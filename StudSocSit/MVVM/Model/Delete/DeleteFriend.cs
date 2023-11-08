using ApplicationDbContext;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Delete
{
    public class DeleteFriend
    {
        private readonly ReservoomDbContext _context;

        public DeleteFriend(ReservoomDbContext context)
        {
            _context = context;
        }

        public void Do(Request request)
        {
            var studentIdentity = _context.Student
                .Where(s => s.StudentId == request.StudentId)
                .First();

            var friendIdentity = studentIdentity.Friends
                .Where(f => f.StudentId == request.FriendId)
                .First();

            studentIdentity.Friends.Remove(friendIdentity);

            _context.SaveChanges();
        }
        public class Request
        {
            public int StudentId { get; set; }
            public int FriendId { get; set; }
        }
    }
}
